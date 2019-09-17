using System;
using System.Data;
using RAMQ.Attribut;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre
{

    /// <summary> 
    ///  Classe de paramètres d'entrées pour le service du noyau « Modifier une commande de correspondances ».
    /// </summary>
    /// <remarks>
    ///  Auteur : Florent Pollart<br/>
    /// </remarks>
    public class ModifierCommandeCorrespondancesEntre
    {
        /// <summary>
        /// Numéro séquentiel de réduction
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pNumNoSeqReduction", Direction = ParameterDirection.Input)]
        public long NumeroSequentielReduction { get; set; }

        /// <summary>
        /// Date prévue d'evoie
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pDatPrevueEnvoie", Direction = ParameterDirection.Input)]
        public DateTime? DatePrevueEnvoie{ get; set; }

        /// <summary>
        /// Date réelle d'envoie
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pDatReelleEnvoie", Direction = ParameterDirection.Input)]
        public DateTime? DateReelleEnvoie { get; set; }

        /// <summary>
        /// Code utilisateur de modification
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pVchrCodUtilModif", Direction = ParameterDirection.Input)]
        public string CodeUtilisateurModification { get; set; }
    }
}