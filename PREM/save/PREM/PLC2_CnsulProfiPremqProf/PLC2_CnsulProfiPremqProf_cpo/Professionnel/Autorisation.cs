using System;
using RAMQ.PRE.PLC2_CnsulProfiPremqProf_cpo.ObtentionInformation;
using RAMQ.PRE.PLC2_CnsulProfiPremqProf_cpo.Professionnel.Interface;
using RAMQ.PRE.PRE_Entites_cpo.Autorisation.Parametre;

namespace RAMQ.PRE.PLC2_CnsulProfiPremqProf_cpo.Professionnel
{
    /// <summary> 
    ///  Classe des autorisations
    /// </summary>
    /// <remarks>
    ///  Auteur : Jean-Benoit Drouin-Cloutier <br/>
    ///  Date   : Décembre 2016
    /// </remarks>
    public class Autorisation : IAutorisation
    {


        private readonly IObtenirInformationProfessionnelSystemeInterne _clientObtentionProfessionnel;
        #region Constructeurs

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Autorisation(IObtenirInformationProfessionnelSystemeInterne obtentionProfessionnel)
        {

            if (obtentionProfessionnel == null)
            {
                throw new ArgumentNullException($"Le paramètre : {nameof(obtentionProfessionnel)} ne peut être null.");
            }

            _clientObtentionProfessionnel = obtentionProfessionnel;

        }

        #endregion


        #region Méthodes publiques

        /// <summary>
        /// Permet d'obtenir les autorisations d'un professionnel de la santé
        /// </summary>
        /// <param name="intrant">Paramètres d'entré</param>
        /// <returns>Une liste d'autorisations d'un professionnel de la santé</returns>
        public ObtenirLesAutorisationsProfessionnelSorti ObtenirAutorisationsProfessionnelSante(ObtenirLesAutorisationsProfessionnelEntre intrant)
        {
            return _clientObtentionProfessionnel.ObtenirAutorisationProfessionnelSante(intrant);
        }

        #endregion


    }
}