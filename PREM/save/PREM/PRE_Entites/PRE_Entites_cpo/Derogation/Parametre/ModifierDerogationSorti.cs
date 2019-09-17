using RAMQ.ClasseBase;

namespace RAMQ.PRE.PRE_Entites_cpo.Derogation.Parametre
{

    /// <summary> 
    ///  Paramètres de sortie pour la modification d'une dérogation d'un professionnel de la santé
    /// </summary>
    /// <remarks>
    ///  Auteur : Danick Nadeau <br/>
    ///  Date   : Novembre 2016
    /// </remarks>
    public class ModifierDerogationSorti : ParamSorti
    {

        /// <summary>
        /// Nouveau numéro séquentiel de la dérogation
        /// </summary>
        /// <remarks></remarks>
        public long NouveauNumeroSequentiel { get; set; }


    }

}