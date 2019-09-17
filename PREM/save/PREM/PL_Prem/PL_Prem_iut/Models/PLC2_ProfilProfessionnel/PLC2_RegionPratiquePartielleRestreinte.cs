using RAMQ.PRE.PL_Prem_iut.Entite;
using System.Collections.Generic;

namespace RAMQ.PRE.PL_Prem_iut.Models.PLC2_ProfilProfessionnel
{
    /// <summary>
    /// Modèle pour les droits acquis
    /// </summary>
    /// <remarks>
    /// Auteur: Jean-Benoit Drouin-Cloutier
    /// </remarks>
	public class PLC2_RegionPratiquePartielleRestreinte : PLC2_InformationProfessionnel
    {
        private List<DroitExercice> _historiqueDroitExercice;
        private List<PeriodeExercice> _periodeExercice;
        private List<PeriodeExercice> _depassementPeriodesExercices;


        /// <summary>
        /// Droits d'exercices
        /// </summary>
        public List<DroitExercice> HistoriqueDroitExercice
        {

            get
            {
                if (_historiqueDroitExercice == null)
                {
                    _historiqueDroitExercice = new List<DroitExercice>();
                }
                return _historiqueDroitExercice;
            }
            set { _historiqueDroitExercice = value; }
        }

        private List<DroitExercice> _droitExercice;
        /// <summary>
        /// Droits d'exercices
        /// </summary>
        public List<DroitExercice> DroitsExercices
        {

            get
            {
                if (_droitExercice == null)
                {
                    _droitExercice = new List<DroitExercice>();
                }
                return _droitExercice;
            }
            set { _droitExercice = value; }
        }

        /// <summary>
        /// Historique des droits d'exercices
        /// </summary>
        public List<DroitExercice> HistoriquesDroitExercice { get; set; }

        /// <summary>
        /// Périodes d'exercices
        /// </summary>
        public List<PeriodeExercice> PeriodesExercices
        {
            get
            {
                if (_periodeExercice == null)
                {
                    _periodeExercice = new List<PeriodeExercice>();
                }
                return _periodeExercice;
            }
            set { _periodeExercice = value; }
        }

        /// <summary>
        /// Dépassement du maximum autorisé par un droit d'exercice
        /// </summary>
        public List<PeriodeExercice> DepassementPeriodesExercices
        {
            get
            {
                if (_depassementPeriodesExercices == null)
                {
                    _depassementPeriodesExercices = new List<PeriodeExercice>();
                }
                return _depassementPeriodesExercices;
            }
            set { _depassementPeriodesExercices = value; }
        }

        /// <summary>
        /// Message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Pourcentage maximum
        /// </summary>
        public string PourcentageMaximum { get; set; }


    }
}