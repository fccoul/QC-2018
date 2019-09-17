using RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal;
using RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre;
using RAMQ.PRE.PRE_Entites_cpo.Professionnel.Parametre;
using System;
using EPZ3 = RAMQ.PRE.PRE_SysExt_cpo.FIP.EPZ3;


namespace RAMQ.PRE.PL_LogiqueAffaire_cpo.Professionnel
{
    /// <summary> 
    ///  Classe pour la recherche de professionnels.
    /// </summary>
    /// <remarks>
    ///  Auteur : Florent Pollart <br/>
    ///  Date   : Janvier 2017
    /// </remarks>
    public class RechercherProfessionnel : IRechercherProfessionnel
    {
        #region Attributs privées

        private readonly EPZ3.IInfoDispCnsul _infoDispCnsul;
       
        #endregion

        #region Constructeur

        /// <summary>
        /// Constructeur.
        /// </summary>
        /// <param name="infoDispCnsul">Classe d'information d'un dispensateur en consultation.</param>
        public RechercherProfessionnel(EPZ3.IInfoDispCnsul infoDispCnsul)
        {
            if (infoDispCnsul == null)
            {
                throw new System.ArgumentNullException($"Le paramètre {nameof(infoDispCnsul)} est obligatoire");
            }

            _infoDispCnsul = infoDispCnsul;
        }
 
        #endregion

        #region Méthodes publiques

        /// <summary>
        ///  Obtenir les informations sur la relation dispensateur individu.
        /// </summary>
        /// <param name="intrant">Les critètres de recherche.</param>
        /// <returns>Une liste avec les informations des professionnels.</returns>
        /// <remarks></remarks>
        public ObtenirDispensateurIndividuSorti ObtenirInformationProfessionnel(ObtenirDispensateurIndividuEntre intrant)
        {
            EPZ3.Parametre.ObtnRelDispIndivEntre intrantEPZ3 = Utilitaire.Mappeur.Mapper(intrant);
            EPZ3.Parametre.ObtnRelDispIndivSorti extrantEPZ3 = _infoDispCnsul.ObtenirRelDispIndiv(intrantEPZ3);

            return Utilitaire.Mappeur.Mapper(extrantEPZ3);
        }

        /// <summary>
        ///  Obtenir les informations personnelles d'un dispensateur
        /// </summary>
        /// <param name="intrant">Les critètres de recherche.</param>
        /// <returns>Une liste avec les informations des professionnels.</returns>
        /// <remarks></remarks>
        public ObtenirInfoPerslDispSorti ObtenirInforPersonnellesDispensateur(ObtenirInfoPerslDispEntre intrant)
        {
            EPZ3.Parametre.ObtenirInfoPerslDispEntre intrantEPZ3 = new EPZ3.Parametre.ObtenirInfoPerslDispEntre();
            EPZ3.Parametre.ObtenirInfoPerslDispSorti extrantEPZ3 = null;

            ObtenirInfoPerslDispSorti extrant = null;

            Utilitaire.Mappeur.Mapper(intrant, ref intrantEPZ3);

            extrantEPZ3 = _infoDispCnsul.ObtenirInfoPerslDisp(intrantEPZ3);

            Utilitaire.Mappeur.Mapper(extrantEPZ3, ref extrant);

            return extrant;
        }

        #endregion

    }
}