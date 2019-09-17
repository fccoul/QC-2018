using RAMQ.Attribut;
using System;
using System.Data;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre
{
    /// <summary>
    ///  Classe de paramètres d'entrée pour l'obtention de la vue des pourcentages de jours facturés en dérogation
    /// </summary>
    /// <remarks>
    ///  Auteur : Maxime Comtois<br/>
    ///  Date   : Mars 2018
    /// </remarks>
	public class ObtenirListeDemReevaEntre
    {

        /// <summary>
        /// Numéro séquentiel du dispensateur
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pNumNoSeqDisp", Direction = ParameterDirection.Input)]
        public long? NumeroSequentielDispensateur { get; set; }

        /// <summary>
        /// Date de début de période de réévaluation
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pDDPerReeva", Direction = ParameterDirection.Input)]
        public DateTime? DateDebutPeriodeReeva { get; set; }


        /// <summary>
        /// Date de fin de période de réévaluation
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pDFPerReeva", Direction = ParameterDirection.Input)]
        public DateTime? DateFinPeriodeReeva { get; set; }

        /// <summary>
        /// Numéro séquentiel du dispensateur
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pIndOccActive", Direction = ParameterDirection.Input)]
        public string IndOccActive { get; set; }

        /// <summary>
        /// Numéro séquentiel de la demande
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pNumNoSeqDemReeva", Direction = ParameterDirection.Input)]
        public long? NumeroSequentielDemandeReeva { get; set; }

        /// <summary>
        /// Numéro du code source de la demande
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pNumCodSourceDem", Direction = ParameterDirection.Input)]
        public long? CodeSourceDemandeReeva { get; set; }


        /// <summary>
        /// Numéro de catégorie de la demande
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pNumCodCatgReeva", Direction = ParameterDirection.Input)]
        public long? NumeroCategorieReeva { get; set; }



    }
}