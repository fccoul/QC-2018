using RAMQ.PRE.PLC2_CnsulProfiPremqProf_cpo.Professionnel.Interface;
using RAMQ.PRE.PRE_SysExt_cpo.FIP.EPZ3;
using RAMQ.PRE.PRE_SysExt_cpo.FIP.EPZ3.Parametre;
using System;
using Entite = RAMQ.PRE.PRE_Entites_cpo.PeriodePratique.Parametre;

namespace RAMQ.PRE.PLC2_CnsulProfiPremqProf_cpo.Professionnel
{
    /// <summary> 
    ///  Classe des période de pratique
    /// </summary>
    /// <remarks>
    ///  Auteur : Jean-Benoit Drouin-Cloutier <br/>
    ///  Date   : Décembre 2016
    /// </remarks>
    public class PeriodePratique : IPeriodePratique
    {

        private readonly IInfoDispCnsul _informationDispensateur;

        #region Constructeurs

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public PeriodePratique(IInfoDispCnsul informationDispensateur)
        {


            if (informationDispensateur == null)
            {
                throw new ArgumentNullException($"Le paramètre : {nameof(informationDispensateur)} ne peut être null.");
            }

            _informationDispensateur = informationDispensateur;

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

            extrantEPZ3 = _informationDispensateur.ObtenirPeriodePratiqueProfessionnel(intrantEPZ3);

            Utilitaire.Mappeur.Mapper(extrantEPZ3, ref extrant);

            return extrant;
        }

        #endregion

    }
}