using Ploeh.AutoFixture;

namespace RAMQ.PRE.PL_LogiqueAffaire_cpo.test.Base
{
    /// <summary> 
    ///   Classe de base pour les essais unitaires
    /// </summary>
    /// <remarks>
    ///  Auteur : Autre <br/>
    ///  Date   : 
    /// </remarks>
    public class TestBase
    {
        private Fixture _fixture;

        /// <summary>
        /// Autofixture
        /// </summary>
        protected Fixture Fixture
        {
            get
            {
                if (_fixture == null)
                {
                    _fixture = new Fixture();
                }
                return _fixture;
            }
        }
    }
}