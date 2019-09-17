using Entite = RAMQ.PRE.PRE_Entites_cpo.PeriodePratique.Parametre;
using RAMQ.PRE.PRE_Entites_cpo.Professionnel.Parametre;
using RAMQ.PRE.PRE_SysExt_cpo.FIP.EPZ3.Parametre;
using RAMQ.PRE.PRE_SysExt_cpo.FIP.EPZ3;
using System;

namespace RAMQ.PRE.PLC2_CnsulProfiPremqProf_cpo.ObtentionInformation
{
    /// <summary> 
    ///  Classe d'obtention des informations des professionnels à partir des systèmes externes
    /// </summary>
    /// <remarks>
    ///  Auteur : Jean-Benoit Drouin-Cloutier <br/>
    ///  Date   : Octobre 2016
    /// </remarks>
    public class ObtenirInformationProfessionnelSystemeExterne : IObtenirInformationProfessionnelSystemeExterne
    {

        #region Attributs privés


        private readonly IInfoDispCnsul _clientInformationDispensateur;
        #endregion

        #region Constructeurs

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public ObtenirInformationProfessionnelSystemeExterne(IInfoDispCnsul informationDispensateur)
        {


            if(informationDispensateur == null)
            {
                throw new ArgumentNullException($"Le paramètre : {nameof(informationDispensateur)} ne peut être null.");
            }

            _clientInformationDispensateur = informationDispensateur;


        }

        #endregion

        #region Méthodes publiques

        /// <summary>
        /// Permet d'obtenir la période de pratique d'un professionnel
        /// </summary>
        /// <param name="intrant">Paramètres d'entrées</param>
        /// <returns>Les informations de la période de pratique d'un professionnel</returns>
        /// <remarks></remarks>
        public Entite.ObtenirPeriodePratiqueProfessionnelSorti ObtenirPeriodePratiqueProfessionnel(Entite.ObtenirPeriodePratiqueProfessionnelEntre intrant)
        {
            ObtenirPeriodePratiqueProfessionnelEntre intrantEPZ3 = new ObtenirPeriodePratiqueProfessionnelEntre();
            ObtenirPeriodePratiqueProfessionnelSorti extrantEPZ3 = null;
            Entite.ObtenirPeriodePratiqueProfessionnelSorti extrant = null;


            Utilitaire.Mappeur.Mapper(intrant, ref intrantEPZ3);

            extrantEPZ3 = _clientInformationDispensateur.ObtenirPeriodePratiqueProfessionnel(intrantEPZ3);

            Utilitaire.Mappeur.Mapper(extrantEPZ3, ref extrant);

            return extrant;

        }

        #endregion


    }
}