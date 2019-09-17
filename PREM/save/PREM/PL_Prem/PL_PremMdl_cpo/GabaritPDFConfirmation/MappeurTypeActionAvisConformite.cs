using System;
using RAMQ.PRE.PL_PremMdl_cpo.svcSaisAvisConf;
using RAMQ.PRE.PRE_Entites_cpo;

namespace RAMQ.PRE.PL_PremMdl_cpo.GabaritPDFConfirmation
{
    /// <summary>
    /// Mappeur qui permet de faire la corrélation entre le type d'action
    /// fait sur un avis de conformité pour son 
    /// </summary>
    /// <remarks>
    /// Auteur : Alexis Garon-Michaud
    /// Date   : Avril 2017
    /// </remarks>
    public static class MappeurTypeActionAvisConformite
    {
        /// <summary>
        /// Permet de faire la corrélation entre le type d'action fait à l'interface et
        /// du côté service pour un avis de conformité
        /// </summary>
        /// <param name="typeAction">Type d'action fait à l'interface sur un avis de conformité</param>
        /// <returns>Équivalent de l'action côté service</returns>
        public static TypeActionAvisConformite DefinirTypeActionAvisConformite(Enumerations.TypeTraitementAvisConformite typeAction)
        {
            var typeActionAvisConformite = default(TypeActionAvisConformite);

            switch (typeAction)
            {
                case Enumerations.TypeTraitementAvisConformite.Transmettre:
                    typeActionAvisConformite = TypeActionAvisConformite.Transmis;
                    break;
                case Enumerations.TypeTraitementAvisConformite.Enregistrer:
                    typeActionAvisConformite = TypeActionAvisConformite.Enregistre;
                    break;
                case Enumerations.TypeTraitementAvisConformite.Modifier:
                    typeActionAvisConformite = TypeActionAvisConformite.Modifier;
                    break;
                case Enumerations.TypeTraitementAvisConformite.Annuler:
                    typeActionAvisConformite = TypeActionAvisConformite.Annule;
                    break;
                case Enumerations.TypeTraitementAvisConformite.Inactiver:
                    typeActionAvisConformite = TypeActionAvisConformite.Inactive;
                    break;
                case Enumerations.TypeTraitementAvisConformite.Reporter:
                    typeActionAvisConformite = TypeActionAvisConformite.Reporte;
                    break;
                case Enumerations.TypeTraitementAvisConformite.Revoquer:
                    typeActionAvisConformite = TypeActionAvisConformite.Revoque;
                    break;
                case Enumerations.TypeTraitementAvisConformite.Supprimer:
                    typeActionAvisConformite = TypeActionAvisConformite.Supprime;
                    break;
                default:
                    throw new NotSupportedException($"Le type d'action : {typeAction.ToString()} n'est pas supporté.");
            }

            return typeActionAvisConformite;
        }
    }
}