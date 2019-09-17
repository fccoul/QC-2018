using RAMQ.Message;
using RAMQ.PRE.PRE_Entites_cpo.Securite.Parametre;
using System;

namespace RAMQ.PRE.PRE_OutilComun_cpo
{
    /// <summary>
    /// Classe d'opération pour la recherche de règle d'accès dans la base de données d'AGS.
    /// </summary>
    public class Securite : ISecurite
	{
		private readonly IResolutionMessage _resolutionMessage;

		/// <summary>
		/// Constructeur
		/// </summary>
		/// <param name="resolutionMessage"></param>
		public Securite(IResolutionMessage resolutionMessage)
		{
			_resolutionMessage = resolutionMessage;
		}

		/// <summary>
		/// Cette méthode demande les contextes et règles d'accès pour un utilisateur.
		/// </summary>
		/// <param name="intrant"></param>
		/// <returns></returns>
		public RechercherContexteRegleAccesSorti RechercherContexteRegleAcces(RechercherContexteRegleAccesEntre intrant)
		{

			if (intrant == null)
			{
				throw new ArgumentNullException(nameof(intrant));
			}

			svcRechrRegleAcces.RegleAccesContxDroitDS extrantYRD1 = new svcRechrRegleAcces.RegleAccesContxDroitDS();
			svcRechrRegleAcces.InfoRegleAccesContxDS intrantYRD1 = new svcRechrRegleAcces.InfoRegleAccesContxDS();
			RechercherContexteRegleAccesSorti extrant = new RechercherContexteRegleAccesSorti();

			try
			{
				intrantYRD1 = Utilitaire.Mappeur.Mapper(intrant);

				UtilitaireService.AppelerService<svcRechrRegleAcces.RechrRegleAccesSoap,
												 svcRechrRegleAcces.RechrRegleAccesSoapClient>
												 (x => x.ObtnDroitContxRegleAcces(intrantYRD1, ref extrantYRD1));

				extrant = Utilitaire.Mappeur.Mapper(extrantYRD1);
			}
			catch (ApplicationException)
			{
				throw;
			}
			catch (Exception ex)
			{

                Journalisation.JournaliserErreurTechnique(ex, 
                                                          codeSeveriteErreur: Enumeration.EnumCodSever.Information,
                                                          informationComplementaire: "Utilisateur n'a pas accès");

				//Dans tous les cas, retourner un message de traitement indiquant que l'usager
				//n'a pas d'accès
				
				extrant.InfoMsgTrait.Add(new MsgTrait(_resolutionMessage,
													  Constantes.CodeApplication,
													  Constantes.CodeRetour.E_147939_PasDroits,
													  new string[] { }));
			}

			return extrant;
		}
	}
}