using RAMQ.Attribut;
using RAMQ.ClasseBase;
using System.Collections.Generic;
using System.Data;

namespace RAMQ.PRE.PRE_SysExt_cpo.FIP.EPZ3.Parametre
{

    /// <summary> 
    ///  Paramètre de sortie pour obtenir les informations personnelles d'un ou plusieurs dispensateur(s)
    /// </summary>
    public class ObtenirInfoPerslDispSorti : ParamSorti
    {
        /// <summary>
        /// Liste de codes de professions
        /// </summary>
        [ValeurEntite(ElementName = "pTblProCod", Direction = ParameterDirection.Output, TypeSorti = Enumeration.EnumTypeParamSorti.Tableau)]
        public List<string> CodesDeProfession { get; set; }

        /// <summary>
        /// Liste de numéros séquentiels de dispensateurs
        /// </summary>
        [ValeurEntite(ElementName = "pTblDisNoSeq", Direction = ParameterDirection.Output, TypeSorti = Enumeration.EnumTypeParamSorti.Tableau)]
        public List<long?> NumerosSeqDisp { get; set; }

        /// <summary>
        /// Liste des prénoms de dispensateur  
        /// </summary>
        [ValeurEntite(ElementName = "pTblPreDisp", Direction = ParameterDirection.Output, TypeSorti = Enumeration.EnumTypeParamSorti.Tableau)]
        public List<string> PrenomsDisp { get; set; }

        /// <summary>
        /// Liste des noms de dispensateur  
        /// </summary>
        [ValeurEntite(ElementName = "pTblNomDisp", Direction = ParameterDirection.Output, TypeSorti = Enumeration.EnumTypeParamSorti.Tableau)]
        public List<string> NomsDisp { get; set; }

        /// <summary>
        /// Liste de dates de décès 
        /// </summary>
        [ValeurEntite(ElementName = "pTblDatDeces", Direction = ParameterDirection.Output, TypeSorti = Enumeration.EnumTypeParamSorti.Tableau)]
        public List<System.DateTime?> DatesDeces { get; set; }

        /// <summary>
        /// Liste de dates de début de spécialité
        /// </summary>
        [ValeurEntite(ElementName = "pTblDdSpecDisp", Direction = ParameterDirection.Output, TypeSorti = Enumeration.EnumTypeParamSorti.Tableau)]
        public List<System.DateTime?> DatesDebutSpec { get; set; }

        /// <summary>
        /// Liste de dates d'obtention de permis
        /// </summary>
        [ValeurEntite(ElementName = "pTblDatObtenPermi", Direction = ParameterDirection.Output, TypeSorti = Enumeration.EnumTypeParamSorti.Tableau)]
        public List<System.DateTime?> DatesObtentionPermis { get; set; }

        /// <summary>
        /// Liste de classes de dispensateurs
        /// </summary>
        [ValeurEntite(ElementName = "pTblClaDisp", Direction = ParameterDirection.InputOutput, TypeSorti = Enumeration.EnumTypeParamSorti.Tableau)]
        public List<short?> ClassesDispensateur { get; set; }

        /// <summary>
        /// Numéro du Dispensateurs
        /// </summary>
        [ValeurEntite(ElementName = "pTblNoDisp", Direction = ParameterDirection.InputOutput, TypeSorti = Enumeration.EnumTypeParamSorti.Tableau)]
        public List<int?> NumerosDispensateur { get; set; }

    }


}