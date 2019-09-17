using System.Collections.Generic;
using RAMQ.ClasseBase;

namespace RAMQ.PRE.PRE_Entites_cpo.Derogation.Parametre
{

    /// <summary> 
    ///  Paramètres de sortie pour l'obtention des dérogation d'un professionnel de la santé
    /// </summary>
    /// <remarks>
    ///  Auteur : Jean-Benoit Drouin-Cloutier <br/>
    /// </remarks>
    public class ObtenirDerogationsProfessionnelSanteSorti : ParamSorti
    {

        /// <summary>
        /// Constructeur
        /// </summary>
        public ObtenirDerogationsProfessionnelSanteSorti()
        {
            Derogations = new List<Entite.Derogation>();
        }

        /// <summary>
        /// Liste de dérogations
        /// </summary>
        /// <remarks></remarks>
        public List<Entite.Derogation> Derogations { get; set; }
        
    }
}