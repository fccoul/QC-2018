using RAMQ.PRE.PRE_Entites_cpo.PeriodePratique.Parametre;
using RAMQ.PRE.PRE_Entites_cpo.Professionnel.Parametre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAMQ.PRE.PL_Prem_iut.Models.PLC2_ProfilProfessionnel.Entite
{
    /// <summary>
    /// Classe pour l'historique d'engqgement
    /// </summary>
    /// <remarks>
    /// </remarks>
	public class HistoriqueEngagement
    {
        /// <summary>
        /// indformation sur les periodes engagement et absence
        /// </summary>
        public ObtenirVuePeriodeEngagementSorti PeriodeEngagementsAbsence { get; set; }
        /// <summary>
        /// informations sur les periode de pratique
        /// </summary>
        public ObtenirPeriodePratiqueProfessionnelSorti PeriodePratiqueProfessionnel { get; set; }
        /// <summary>
        /// information sur le professionel
        /// </summary>
        public ObtenirDispensateurIndividuSorti InformationProfessionnel { get; set; }
    }
}