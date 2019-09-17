using RAMQ.ClasseBase;
using System;

namespace RAMQ.PRE.PRE_Entites_cpo.Derogation.Parametre
{
    /// <summary> 
    ///  Paramètres de sortie pour la création d'une dérogation d'un professionnel de la santé.
    /// </summary>
    /// <remarks>
    ///  Auteur : Sébastien Bourdages <br/>
    ///  Date   : Janvier 2017
    /// </remarks>
    public class CreerDerogationSorti : ParamSorti
    {
        /// <summary>
        /// Numéro séquentiel de la dérogation.
        /// </summary>
        /// <remarks></remarks>
        public long NumeroSequentielDerogation { get; set; }

        /// <summary>
        /// Date et heure de la création de l'occurence.
        /// </summary>
        /// <remarks></remarks>
        public DateTime DateHeureCreationOccurence { get; set; }
    }
}