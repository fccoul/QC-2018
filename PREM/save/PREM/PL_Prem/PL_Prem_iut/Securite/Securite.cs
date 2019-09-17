using System;
using System.Linq;
using RAMQ.PRE.PRE_Entites_cpo.Securite.Parametre;
using OutilCommun = RAMQ.PRE.PRE_OutilComun_cpo;
using RAMQ.PRE.PRE_OutilComun_cpo.Cache;
using RAMQ.PRE.PL_Prem_iut.Entite;

namespace RAMQ.PRE.PL_Prem_iut.Securite
{
	/// <summary>
	/// Classe en lien avec la sécurité
	/// </summary>
	public class Securite : ISecurite
	{
        #region Constantes

        private const string CleCodeRSS = "CodeRss";
        private const int DroitRSS = 353;

        #endregion

        #region Attributs privées

        private readonly OutilCommun.ISecurite _securite;
        private readonly OutilCommun.IMessageTraitement _messageTraitement;
        private MemoireCache<string> _cacheRSS = new MemoireCache<string>(new TimeSpan(0, 0, 10), false);
        private string _utilisateur = RAMQ.Securite.Principal.Identite.ObtnUtil(System.Web.HttpContext.Current.Request.RequestContext.HttpContext);

        #endregion

        #region Constructeur

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="securiteFactory"></param>
        /// <param name="messageTraitement"></param>
        public Securite(OutilCommun.ISecurite securiteFactory,
                        OutilCommun.IMessageTraitement messageTraitement)
		{
			_securite = securiteFactory;
			_messageTraitement = messageTraitement;
		}

		#endregion

		#region Obtention du code RSS

		/// <summary>
		/// Obtient la région de la personne connecté
		/// </summary>
		public CodeRSSUtilisateur ObtenirCodeRSSUtilisateurCourant()
		{
			var code = new CodeRSSUtilisateur();

			if (Utilitaires.Utilitaire.EstDansGroupe(Utilitaires.Configuration.GroupeSupport))
			{
				code = ObtenirCodeRSSUtilisateurCookie();
			}
			else
			{
				if (_cacheRSS.Obtenir(CleCodeRSS + _utilisateur) == null)
				{
					code = ObtenirCodeRSSUtilisateurAGS();

					if (code.InfoMsgTrait.Any())
					{
						return code;
					}

					_cacheRSS.Ajouter(CleCodeRSS + _utilisateur, code.CodeRSS);
				}

				code.CodeRSS = _cacheRSS.Obtenir(CleCodeRSS + _utilisateur);
			}

			return code;
		}

		/// <summary>
		/// Va chercher le code RSS de l'utilisateur à partir d'AGS
		/// </summary>
		private CodeRSSUtilisateur ObtenirCodeRSSUtilisateurAGS()
		{
			var code = new CodeRSSUtilisateur();

			var extrantRegleContext = _securite.RechercherContexteRegleAcces(
					new RechercherContexteRegleAccesEntre
					{
						IdentifiantUtilisateur = _utilisateur,
						CodeApplication = OutilCommun.Constantes.CodeApplication
					});

			if (extrantRegleContext.InfoMsgTrait.Any())
			{
				if (extrantRegleContext.InfoMsgTrait.First().IdMsg == "-1")
				{
					code.InfoMsgTrait.Add(_messageTraitement.NouveauMessageTraitement(OutilCommun.Constantes.CodeRetour.E_147939_PasDroits));
				}
				else
				{
					code.InfoMsgTrait = extrantRegleContext.InfoMsgTrait;
				}

				return code;
			}

			code.CodeRSS = (from item in extrantRegleContext.ContextesDroitAcces
							where item.NumeroSequentielDroitAcces == DroitRSS
							select item.IdContexteRegleAcces).SingleOrDefault();

			if (string.IsNullOrWhiteSpace(code.CodeRSS))
			{
				code.InfoMsgTrait.Add(_messageTraitement.NouveauMessageTraitement(OutilCommun.Constantes.CodeRetour.E_147939_PasDroits));
			}

			return code;
		}

		/// <summary>
		/// Va chercher le code RSS de l'utilisateur à partir du cookie
		/// </summary>
		public CodeRSSUtilisateur ObtenirCodeRSSUtilisateurCookie()
		{
			var code = new CodeRSSUtilisateur();

			code.CodeRSS = Utilitaires.Utilitaire.ObtenirCookie(CleCodeRSS);

			if (string.IsNullOrWhiteSpace(code.CodeRSS))
			{
				code.InfoMsgTrait.Add(_messageTraitement.NouveauMessageTraitement(OutilCommun.Constantes.CodeRetour.E_148378_AucunRSSChoisi));
			}

			return code;
		}

		#endregion

	}
}