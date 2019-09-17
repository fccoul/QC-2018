using RAMQ.PRE.PL_PremMdl_cpo.Autorisation.Mappeur;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAMQ.PRE.PL_PremMdl_cpo.Autorisation
{
    /// <summary>
    ///  Instancie le référentiel de type IAutorisation en fonction de la configuration de 
    ///  l'application.
    /// </summary>
    public class AutorisationFactory
    {
        private readonly IAutorisationMappeur _mappeur;

        /// <summary>
        /// Constructeur de la classe.
        /// </summary>
        /// <param name="autorisationMappeur"></param>
        public AutorisationFactory(IAutorisationMappeur autorisationMappeur)
        {
            _mappeur = autorisationMappeur;
        }
        /// <summary>
        ///  Instancie le référentiel de type IAutorisation en fonction de la configuration de 
        ///  l'application.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        ///  Si la valeur de configuration AutorisationSimulation est à « OUI » le référentiel créé
        ///  est une simulation qui n'accède pas aux données réelles.
        /// </remarks>
        public IAutorisation Instancier()
        {
            IAutorisation retour = (Utilitaires.ObtenirEnvir() != Environnement.Production && Config.SimulationAutorisation)
                                   ? (IAutorisation)new AutorisationSimulation() : new AutorisationReferentiel(_mappeur);

            return retour;
        }
    }
}
