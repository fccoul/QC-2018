using RAMQ.ClasseBase;

namespace RAMQ.PRE.PRE_Entites_cpo.Securite.Entite
{
    /// <summary> 
    ///  Contexte règle accès
    /// </summary>
    /// <remarks>
    ///  Auteur : Danick Nadeau <br/>
    ///  Date   : 2016-11-02
    /// </remarks>
    public class ContexteRegleAcces : ParamSorti
    {

        /// <summary>
        /// Code de contexte du droite d'accès.
        /// </summary>
        public string CodeContexteDroitAcces { get; set; }

        /// <summary>
        /// Id de contexte de la règle d'accès.
        /// </summary>
        public string IdContexteRegleAcces { get; set; }

        /// <summary>
        /// Numéro séquentiel du droit d'accès
        /// </summary>
        public long NumeroSequentielDroitAcces { get; set; }
    }
}