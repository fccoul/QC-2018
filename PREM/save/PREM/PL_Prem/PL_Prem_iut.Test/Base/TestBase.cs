using Ploeh.AutoFixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAMQ.PRE.PL_Prem_iut.Test.Base
{
    /// <summary>
    /// Classe de base pour les classes des tests
    /// </summary>
    /// <remarks>
    /// Auteur: Franck COULIBALY
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