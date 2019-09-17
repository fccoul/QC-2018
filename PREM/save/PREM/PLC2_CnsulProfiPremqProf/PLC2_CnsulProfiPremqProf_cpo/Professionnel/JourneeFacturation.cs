using RAMQ.PRE.PLB3_CalculerNbrJrFactProfs_cpo;
using RAMQ.PRE.PLC2_CnsulProfiPremqProf_cpo.Parametres;
using RAMQ.PRE.PLC2_CnsulProfiPremqProf_cpo.Professionnel.Interface;
using RAMQ.PRE.PRE_Entites_cpo.Pratique.Parametre;
using System.Linq;
using OutilCommun = RAMQ.PRE.PRE_OutilComun_cpo;

namespace RAMQ.PRE.PLC2_CnsulProfiPremqProf_cpo.Professionnel
{

    /// <summary>
    /// Classe pour faire l'obtention du calcule du nombre de journée de facturation
    /// </summary>
    /// <remarks>
    /// Auteur: Jean-Benoit Drouin-Cloutier
    /// </remarks>
    public class JourneeFacturation : IJourneeFacturation
    {
        private readonly ICalculerNbrJrFactProfs _calculerNombreJourneeFacturation;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="calculerNombreJourneeFacturation">Instance de Calculer le nombre de journée de facturation</param>
        public JourneeFacturation(ICalculerNbrJrFactProfs calculerNombreJourneeFacturation)
        {
            _calculerNombreJourneeFacturation = calculerNombreJourneeFacturation;
        }

        /// <summary>
        /// Permet de faire l'appel au calcule du nombre de journée de facturation
        /// </summary>
        /// <param name="intrant">Paramètre d'entré</param>
        /// <returns>Le calcule des journées facturé</returns>
        public CalculerNbrJrFactProfsSorti CalculerNombreJourneeFacturation(CalculerNbrJrFactProfsEntre intrant)
        {
            return _calculerNombreJourneeFacturation.CalculerNbrJrsPratiProfs(intrant);
        }

        /// <summary>
        /// Permet d'obtenir le pourcentage maximum
        /// </summary>
        /// <returns>Pourcentage maximum</returns>
        public ObtenirPourcentageMaximumSorti ObtenirPourcentageMaximum()
        {

            var extrant = new ObtenirPourcentageMaximumSorti();
            var extrantObtenirParametreProduction = _calculerNombreJourneeFacturation.ObtenirParametresProduction();

            if (extrantObtenirParametreProduction.InfoMsgTrait.Any())
            {
                extrant.InfoMsgTrait = extrantObtenirParametreProduction.InfoMsgTrait;
            }
            else
            {
                extrant.PourcentageMaximum = (decimal)extrantObtenirParametreProduction.Parametres.First(x => x.NomParametre == OutilCommun.Constantes.IdentifiantPourcentage.RESPEC_PPR_PRC).ValeurNumerique;
            }

            return extrant;

        }

    }
}