using System.Collections.Generic;
using RAMQ.PRE.PRE_Entites_cpo.Professionnel.Entite;
using RAMQ.ClasseBase;

namespace RAMQ.PRE.PRE_Entites_cpo.Professionnel.Parametre
{
    /// <summary> 
    ///  Paramètre de sorti pour obtenir les informations sur l'admissibilité d'un professionnel à facturer
    /// </summary>
    /// <remarks>
    ///  Auteur : Danick Nadeau <br/>
    ///  Date   : Novembre 2016
    /// </remarks>
    public class VerifierAdmissibiliteProfessionnelFacturerSorti : ParamSorti
    {

        #region Constructeur

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <remarks></remarks>
        public VerifierAdmissibiliteProfessionnelFacturerSorti()
        {
            PeriodesAdmissibilite = new List<AdmissibiliteFacturer>();
        }

        #endregion

        #region Propriétés publiques

        /// <summary>
        /// Indicateur d'admissibilité
        /// </summary>
        public string IndicateurAdmissibilite { get; set; }

        /// <summary>
        /// Liste de périodes d'admissibilité
        /// </summary>
        public List<AdmissibiliteFacturer> PeriodesAdmissibilite { get; set; }

        #endregion
    }
}