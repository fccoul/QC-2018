
namespace RAMQ.PRE.PRE_SysExt_cpo
{
    /// <summary> 
    /// Classe de constantes.
    /// </summary>
    internal sealed class Constantes
    {

        #region Constantes spécifiques au système FIP

        /// <summary>
        ///  Constantes spécifiques au système FIP
        /// </summary>
        /// <remarks></remarks>
        internal sealed class FIP
        {
            private FIP() { }

            /// <summary>
            ///  Code de l'application FIP
            /// </summary>
            internal const string CodeApplication = nameof(FIP);

            /// <summary>
            ///  Code d'erreur imrévue utilisé par FIP
            /// </summary>
            internal const string ErreurImprevu = "1036";

            /// <summary>
            /// Nom de la procédure ObtenirRelDispIndiv dans EPZ3
            /// </summary>
            internal const string ObtenirRelationDispensateurIndividu = "EPZ3_InfoDispCnsul.ObtenirRelDispIndiv";

            /// <summary>
            /// Nom de la procédure ObtenirRelDispIndiv dans EPZ3
            /// </summary>
            internal const string ObtenirInfoPersonnellesDispensateur = "EPZ3_InfoDispCnsul.ObtenirInfoPerslDisp";

            /// <summary>
            /// Nom de la procédure pour obtenir les information sur la période de pratique d'un professionnel
            /// </summary>
            internal const string ObtenirPeriodePratiqueProfessionnel = "EPZ3_InfoDispCnsul.ObtenirPerPratiProf";
        }

        #endregion

    }
}





