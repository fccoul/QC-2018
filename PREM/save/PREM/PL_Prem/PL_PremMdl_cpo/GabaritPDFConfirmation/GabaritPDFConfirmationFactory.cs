namespace RAMQ.PRE.PL_PremMdl_cpo.GabaritPDFConfirmation
{
    /// <summary>
    /// Fabrique qui permet d'instancier le bon objet tout dépendant 
    /// du contexte d'utilisation pour les gabarits PDF de confirmation
    /// </summary>
    /// <remarks>
    /// Auteur : Alexis Garon-Michaud
    /// Date   : Avril 2017
    /// </remarks>
    public class GabaritPDFConfirmationFactory : IGabaritPDFConfirmationFactory
    {

        private string _environnementCourant;
        private bool? _estSimulation;

        /// <summary>
        /// Environnement courant, utilisée pour les essais unitaires
        /// </summary>
        internal string EnvironnementCourant
        {
            get
            {
                if (string.IsNullOrEmpty(_environnementCourant))
                {
                    _environnementCourant = Utilitaires.ObtenirEnvir();
                }

                return _environnementCourant;
            }
            set
            {
                _environnementCourant = value;
            }
        }

        /// <summary>
        /// Défini si nous sommes en simulation, utilisée pour les essais unitaires
        /// </summary>
        internal bool EstSimulation
        {
            get
            {
                if (!_estSimulation.HasValue)
                {
                    _estSimulation = Config.SimulationGabaritPDFConfirmation;
                }

                return _estSimulation.Value;
            }
            set
            {
                _estSimulation = value;
            }
        }

        /// <summary>
        ///  Instancie le référentiel de type référentiel de type IGabaritPDFConfirmation en fonction de la configuration de 
        ///  l'application.
        /// </summary>
        /// <returns>Le référentiel selon les configurations</returns>
        public IGabaritPDFConfirmation Instancier()
        {
            return EstModeSimulation() ? (IGabaritPDFConfirmation)new GabaritPDFConfirmationSimulation() : new GabaritPDFConfirmationRepository();
        }

        private bool EstModeSimulation()
        {
            return EstEnvironnementDeDeveloppement() && EstSimulation;
        }

        private bool EstEnvironnementDeDeveloppement()
        {
            return EnvironnementCourant != Environnement.Production;
        }
    }
}