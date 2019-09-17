using RAMQ.Attribut;
using RAMQ.ClasseBase;
using System.Data;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre
{

    /// <summary> 
    ///  Classe de paramètres de sortie pour le service du noyau « Modifier une dérogation d'un professionnel de la santé ».
    /// </summary>
    /// <remarks>
    ///  Auteur : Danick Nadeau<br/>
    ///  Date   : Septembre 2016
    /// </remarks>
    public class ModifierDerogationSorti : ParamSorti
    {

        /// <summary>
        /// Nouveau numéro séquentiel de la dérogation
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pNumNouveauNoSeqDerogation", Direction = ParameterDirection.Output)]
        public long NouveauNumeroSequentiel { get; set; }

    }

}