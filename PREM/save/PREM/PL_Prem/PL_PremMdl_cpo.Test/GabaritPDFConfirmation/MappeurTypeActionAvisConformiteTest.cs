using RAMQ.PRE.PL_PremMdl_cpo.GabaritPDFConfirmation;
using RAMQ.PRE.PL_PremMdl_cpo.svcSaisAvisConf;
using Xunit;
using static RAMQ.PRE.PRE_Entites_cpo.Enumerations;

namespace RAMQ.PRE.PL_PremMdl_cpo.Test.GabaritPDFConfirmation
{
    /// <summary> 
    ///  Essais unitaire sur la classe "MappeurTypeActionAvisConformiteTest"
    /// </summary>
    /// <remarks>
    ///  Auteur : Alexis Garon-Michaud <br/>
    ///  Date   : Avril 2017
    /// </remarks>
    public class MappeurTypeActionAvisConformiteTest
    {
        [Theory]
        [InlineData(TypeTraitementAvisConformite.Transmettre, TypeActionAvisConformite.Transmis)]
        [InlineData(TypeTraitementAvisConformite.Enregistrer, TypeActionAvisConformite.Enregistre)]
        [InlineData(TypeTraitementAvisConformite.Modifier, TypeActionAvisConformite.Modifier)]
        [InlineData(TypeTraitementAvisConformite.Annuler, TypeActionAvisConformite.Annule)]
        [InlineData(TypeTraitementAvisConformite.Inactiver, TypeActionAvisConformite.Inactive)]
        [InlineData(TypeTraitementAvisConformite.Reporter, TypeActionAvisConformite.Reporte)]
        [InlineData(TypeTraitementAvisConformite.Revoquer, TypeActionAvisConformite.Revoque)]
        [InlineData(TypeTraitementAvisConformite.Supprimer, TypeActionAvisConformite.Supprime)]
        public void DefinirTypeActionAvisConformite_LeTypeActionInterface_DevraitRetournerLeBonTypeService(TypeTraitementAvisConformite typeActionInterface, 
                                                                                                           TypeActionAvisConformite typeActionService)
        {
            var type = MappeurTypeActionAvisConformite.DefinirTypeActionAvisConformite(typeActionInterface);

            Assert.Equal(typeActionService, type);
        }
    }
}