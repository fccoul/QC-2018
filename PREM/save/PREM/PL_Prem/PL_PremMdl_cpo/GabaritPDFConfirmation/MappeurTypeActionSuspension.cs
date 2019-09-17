using System;
using RAMQ.PRE.PL_PremMdl_cpo.svcSaisDecisAvisConf;
using static RAMQ.PRE.PRE_Entites_cpo.Enumerations;

namespace RAMQ.PRE.PL_PremMdl_cpo.GabaritPDFConfirmation
{
    /// <summary>
    /// Mappeur qui permet de faire la corrélation entre le type d'action
    /// fait sur une suspension
    /// </summary>
    /// <remarks>
    /// Auteur : Alexis Garon-Michaud
    /// Date   : Avril 2017
    /// </remarks>
    public static class MappeurTypeActionSuspension
    {
        /// <summary>
        /// Permet de faire la corrélation entre le type d'action fait à l'interface et
        /// du côté service pour une suspension avis de conformité
        /// </summary>
        /// <param name="typeAction">Type d'action fait à l'interface sur un avis de conformité</param>
        /// <returns>Équivalent de l'action côté service</returns>
        public static TypeActionSuspension DefinirTypeActionSuspension(TypeTraitementSuspension typeAction)
        {
            TypeActionSuspension typeActionService = default(TypeActionSuspension);

            switch (typeAction)
            {
                case TypeTraitementSuspension.Ajouter:
                    typeActionService = TypeActionSuspension.Transmettre;
                    break;
                case TypeTraitementSuspension.Modifier:
                    typeActionService = TypeActionSuspension.Modification;
                    break;
                case TypeTraitementSuspension.Annuler:
                    typeActionService = TypeActionSuspension.Annule;
                    break;
                default:
                    throw new NotSupportedException($"Le type d'action : {typeAction.ToString()} n'est pas supporté.");
            }

            return typeActionService;
        }
    }
}