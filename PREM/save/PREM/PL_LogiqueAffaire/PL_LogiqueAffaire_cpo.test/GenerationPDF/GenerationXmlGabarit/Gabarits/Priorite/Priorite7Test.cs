﻿using RAMQ.PRE.PL_LogiqueAffaire_cpo.GenerationPDF.GenerationXmlGabarit.Gabarits.Priorite;
using Xunit;

namespace RAMQ.PRE.PL_LogiqueAffaire_cpo.test.GenerationPDF.GenerationXmlGabarit.Gabarits.Priorite
{
    /// <summary> 
    ///  Essais unitaire sur la classe "Priorite7"
    /// </summary>
    /// <remarks>
    ///  Auteur : Alexis Garon-Michaud <br/>
    ///  Date   : Mars 2017
    /// </remarks>
    public class Priorite7Test
    {
        [Fact]
        public void Priorite7_PossedeUnNumero_LeNumeroDevraitEtreSept()
        {
            var priorite = new Priorite7();

            var numeroAttendu = 7;

            Assert.Equal(numeroAttendu, priorite.Numero);
        }
    }
}