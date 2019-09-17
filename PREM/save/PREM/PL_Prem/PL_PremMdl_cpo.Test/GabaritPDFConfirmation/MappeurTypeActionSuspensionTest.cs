using RAMQ.PRE.PL_PremMdl_cpo.GabaritPDFConfirmation;
using RAMQ.PRE.PL_PremMdl_cpo.svcSaisDecisAvisConf;
using Xunit;
using static RAMQ.PRE.PRE_Entites_cpo.Enumerations;

namespace RAMQ.PRE.PL_PremMdl_cpo.Test.GabaritPDFConfirmation
{
    /// <summary> 
    ///  Essais unitaire sur la classe "MappeurTypeActionSuspension"
    /// </summary>
    /// <remarks>
    ///  Auteur : Alexis Garon-Michaud <br/>
    ///  Date   : Avril 2017
    /// </remarks>
    public class MappeurTypeActionSuspensionTest
    {
        [Theory]
        [InlineData(TypeTraitementSuspension.Ajouter, TypeActionSuspension.Transmettre)]
        [InlineData(TypeTraitementSuspension.Modifier, TypeActionSuspension.Modification)]
        [InlineData(TypeTraitementSuspension.Annuler, TypeActionSuspension.Annule)]
        public void DefinirTypeActionSuspension_LeTypeActionInterface_DevraitRetournerLeBonTypeService(TypeTraitementSuspension typeActionInterface,
                                                                                                       TypeActionSuspension typeActionService)
        {
            var type = MappeurTypeActionSuspension.DefinirTypeActionSuspension(typeActionInterface);

            Assert.Equal(typeActionService, type);
        }
    }
}