using RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal;
using RAMQ.PRE.PRE_Entites_cpo.Rapport.Entite;
using RAMQ.PRE.PRE_Entites_cpo.Rapport.Parametre;
using System;
using System.Collections.Generic;

namespace RAMQ.PRE.PL_LogiqueAffaire_cpo.Rapport
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// </remarks>
	public class Rapport : IRapport
    {
        #region Attributs privées

        private readonly IPlanRegnMdcal _clientPlanRegnMdcal;

        #endregion

        #region Constructeur

        /// <summary>
        /// Constructeur.
        /// </summary>
        /// <param name="clientPlanRegnMdcal">.</param>
        public Rapport(IPlanRegnMdcal clientPlanRegnMdcal)
        {
            if (clientPlanRegnMdcal == null)
            {
                throw new System.ArgumentNullException($"Le paramètre {nameof(clientPlanRegnMdcal)} est obligatoire");
            }

            _clientPlanRegnMdcal = clientPlanRegnMdcal;
        }

        #endregion

        #region Méthodes publiques

        /// <summary>
        /// 
        /// </summary>
        /// <param name="intrant"></param>
        /// <returns></returns>
        public IEnumerable<LigneRapportRepartInterRegionPrati> ObtenirLignesRapportRepartInterRegionPrati(ParamObtnrRappRepartInterRegionPrati intrant)
        {
            var listeRetour = new List<LigneRapportRepartInterRegionPrati>();

            try
            {
                var paramEntre = Utilitaire.Mappeur.Mapper(intrant);

                var paramSorti = _clientPlanRegnMdcal.ObtenirVueJoursFactPratiAvis(paramEntre);

                foreach (var ligneVue in paramSorti.ListeJoursFactParAvis)
                {
                    listeRetour.Add(new LigneRapportRepartInterRegionPrati()
                    {
                        NombreJoursFactures = (double)ligneVue.Jours,
                        Medecin = "Lucy Firenwriht",
                        NumeroPratique = ligneVue.NoSeqDispensateur.ToString(),
                        PourcentageEffectue = 100.0,
                        Region = ligneVue.CodeRss.ToString(),
                        SousTerritoire = ligneVue.CodeLieuGeo
                    });
                } 
            }
            catch (Exception)
            {
                throw;
            }

            return listeRetour;
        }

        #endregion
    }
}