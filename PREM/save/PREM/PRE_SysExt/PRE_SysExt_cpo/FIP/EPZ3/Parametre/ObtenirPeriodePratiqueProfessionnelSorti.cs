using System.Data;
using RAMQ.ClasseBase;
using RAMQ.Attribut;

namespace RAMQ.PRE.PRE_SysExt_cpo.FIP.EPZ3.Parametre
{

    /// <summary> 
    ///  Paramètre de sortie pour obtenir les périodes de pratiques des professionnels
    /// </summary>
    public class ObtenirPeriodePratiqueProfessionnelSorti : ParamSorti
    {

        /// <summary>
        /// Numéro séquentiel de la pratique 
        /// </summary>
        [ValeurEntite(ElementName = "pNumSeqPrati", Direction = ParameterDirection.Output)]
        public long NumeroSequencePratique { get; set; }

        /// <summary>
        /// Date de première facturation
        /// </summary>
        [ValeurEntite(ElementName = "pDatDatPremFac", Direction = ParameterDirection.Output)]
        public System.DateTime? DatePremiereFacturation { get; set; }

        /// <summary>
        /// Date de dernière facturation 
        /// </summary>
        [ValeurEntite(ElementName = "pDatDatDernFac", Direction = ParameterDirection.Output)]
        public System.DateTime? DateDerniereFacturation { get; set; }

        /// <summary>
        /// Type de pratique
        /// </summary>
        [ValeurEntite(ElementName = "pNumTypPrati", Direction = ParameterDirection.InputOutput)]
        public int NumeroTypePratique { get; set; }



    }


}