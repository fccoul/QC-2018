using System.Data;
using RAMQ.Attribut;

namespace RAMQ.PRE.PRE_SysExt_cpo.FIP.EPZ3.Parametre
{

    /// <summary> 
    ///  Paramètre d'entrée pour obtenir les périodes de pratiques des professionnels
    /// </summary>
    public class ObtenirPeriodePratiqueProfessionnelEntre
    {

        /// <summary>
        /// Numéro de séquence du dispensateur
        /// </summary>
        [ValeurEntite(ElementName = "pNumNoSeqDis", Direction = ParameterDirection.Input)]
        public long NumeroSequenceDispensateur { get; set; }

        /// <summary>
        /// Numéro du type de la pratique
        /// </summary>
        [ValeurEntite(ElementName = "pNumTypPrati", Direction = ParameterDirection.InputOutput)]
        public int NumeroTypePratique { get; set; }

    }


}

