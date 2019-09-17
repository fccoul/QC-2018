using System;
using RAMQ.PRE.PRE_Entites_cpo.Professionnel.Parametre;
using RAMQ.PRE.PRE_SysExt_cpo.FIP.EPZ3;

namespace RAMQ.PRE.PL_LogiqueAffaire_cpo.Admissibilite
{
    /// <summary> 
    ///  Classe des admissibilités
    /// </summary>
    /// <remarks>
    ///  Auteur : Florent Pollart <br/>
    ///  Date   : Janvier 2017
    /// </remarks>
    public class Admissibilite : IAdmissibilite
    {
        #region Attributs privés

        private readonly IInfoDispCnsul _clientInformationDispensateur;

        #endregion

        #region Constructeurs

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Admissibilite(IInfoDispCnsul informationDispensateur)
        {


            if (informationDispensateur == null)
            {
                throw new ArgumentNullException($"Le paramètre : {nameof(informationDispensateur)} ne peut être null.");
            }

            _clientInformationDispensateur = informationDispensateur;


        }

        #endregion
    
        #region  Méthodes publiques 

        /// <summary>
        /// Permet de vérifier les admissibilités d'un professionnel
        /// </summary>
        /// <param name="intrant">Paramètres d'entrées</param>
        /// <returns>La vérification des admissibilités</returns>
        public VerifierAdmissibiliteProfessionnelFacturerSorti VerifierAdmissibiliteProfessionnel(VerifierAdmissibiliteProfessionnelFacturerEntre intrant)
        {
            //Pas besoin de Mappeur car le mappage est fait dans SysExt
            var extrant = _clientInformationDispensateur.VerifierAdmissibiliteProfessionnel(intrant);

            PRE_OutilComun_cpo.MessageTraitement.ValiderMessageTraitement(extrant);

            return extrant;
        }

        #endregion

    }
}