using Ploeh.AutoFixture;

namespace RAMQ.PRE.PLC2_CnsulProfiPremqProf_cpo.test.Base
{
    /// <summary>
    /// Classe de base pour les classes des tests
    /// </summary>
    /// <remarks>
    /// Auteur: Jean-Benoit Drouin-Cloutier
    /// </remarks>
    public abstract class TestBase
    {

        #region Propriétés et Variables

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

        #endregion


    }
}