#region Imports
using System.Data;
using RAMQ.Attribut;
#endregion

namespace RAMQ.PRE.PRE_SysExt_cpo.FIP.EPZ3.Parametre
{

    /// <summary> 
    ///  Paramètre d'entrée pour obtenir les informations sur la relation dispensateur individu
    /// </summary>
    public class ObtnRelDispIndivEntre
    {

        /// <summary>
        /// Classe du dispensateur
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pNumPvcClaDisp", Direction = ParameterDirection.Input)]
        public int? NumeroClasseDispensateur { get; set; }


        /// <summary>
        /// Numéro du dispensateur
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pNumDisNo", Direction = ParameterDirection.Input)]
        public int? NumeroDispensateur { get; set; }

        /// <summary>
        /// Numéro séquentiel du dispensateur
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pNumDisNoSeq", Direction = ParameterDirection.Input)]
        public long? NumeroSequentielDispensateur { get; set; }

        /// <summary>
        /// Numéro séquentiel d'individu
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pNumIndNoSeq", Direction = ParameterDirection.Input)]
        public long? NumeroSequentielIndividu { get; set; }

        /// <summary>
        /// Date de service
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pDatDatServ", Direction = ParameterDirection.Input)]
        public System.DateTime? DateService { get; set; }
    }
}

