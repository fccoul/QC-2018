using System.Data;
using RAMQ.Attribut;
using System.Collections.Generic;

namespace RAMQ.PRE.PRE_SysExt_cpo.FIP.EPZ3.Parametre
{
    /// <summary> 
    ///  Paramètre d'entrée pour obtenir les informations personnelles d'un ou plusieurs dispensateur(s)
    /// </summary>
    public class ObtenirInfoPerslDispEntre
    {
        /// <summary>
        /// Classe du Dispensateur
        /// </summary>
        [ValeurEntite(ElementName = "pTblClaDisp", Direction = ParameterDirection.InputOutput, TypeSorti = Enumeration.EnumTypeParamSorti.Tableau)]
        public List<short?> ClassesDispensateur { get; set; }

        /// <summary>
        /// Numéro du Dispensateur
        /// </summary>
        [ValeurEntite(ElementName = "pTblNoDisp", Direction = ParameterDirection.InputOutput, TypeSorti = Enumeration.EnumTypeParamSorti.Tableau)]
        public List<int?> NumerosDispensateur { get; set; }

        /// <summary>
        /// Nom du Dispensateur
        /// </summary>
        [ValeurEntite(ElementName = "pVchrNomDisp", Direction = ParameterDirection.Input)]
        public string NomDispensateur { get; set; }

        /// <summary>
        /// Prenom du Dispensateur
        /// </summary>
        [ValeurEntite(ElementName = "pVchrPreNomDisp", Direction = ParameterDirection.Input)]
        public string PrenomDispensateur { get; set; }
    }
}

