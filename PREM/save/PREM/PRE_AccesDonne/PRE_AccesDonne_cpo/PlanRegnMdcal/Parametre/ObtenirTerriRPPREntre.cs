using RAMQ.Attribut;
using System;
using System.Data;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre
{

    /// <summary> 
    ///  Classe de paramètres d'entrées pour le service du noyau « Obtenir les territoires RPPR ».
    /// </summary>
    /// <remarks>
    ///  Auteur : Maxime Comtois<br/>
    ///  Date   : Aout 2017
    /// </remarks>
    public class ObtenirTerriRPPREntre
    {

        /// <summary>
        /// Code de région socio-sanitaire
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pVchrCodeRss", Direction = ParameterDirection.Input)]
        public string CodeRss { get; set; }

        /// <summary>
        /// Code de lieu-géographique 
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pVchrCodeLGEO", Direction = ParameterDirection.Input)]
        public string CodeLGEO { get; set; }

        /// <summary>
        /// Numéro de séquence de la région administrative
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pNumNoSeqRegAdmn", Direction = ParameterDirection.Input)]
        public long? NoSeqRegAdmn { get; set; }

        /// <summary>
        /// Date de début de territoire RPPR
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pDatDateDebut", Direction = ParameterDirection.Input)]
        public DateTime? Dd { get; set; }

        /// <summary>
        /// Date de fin de territoire RPPR
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pDatDateFin", Direction = ParameterDirection.Input)]
        public DateTime? Df { get; set; }


    }
}