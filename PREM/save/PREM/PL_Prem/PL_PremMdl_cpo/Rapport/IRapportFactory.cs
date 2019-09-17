using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAMQ.PRE.PL_PremMdl_cpo.Rapport
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// </remarks>
    public interface IRapportFactory
    {
        /// <summary>
        ///  Instancie le référentiel de type IRapport en fonction de la configuration de 
        ///  l'application.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        ///  Si la valeur de configuration RapportSimulation est à « OUI » le référentiel créé
        ///  est une simulation qui n'accède pas aux données réelles.
        /// </remarks>
        IRapport Instancier();
    }
}