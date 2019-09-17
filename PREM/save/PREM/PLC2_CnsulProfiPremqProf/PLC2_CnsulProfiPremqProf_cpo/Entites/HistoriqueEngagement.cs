using RAMQ.PRE.PRE_Entites_cpo.EngagementPratique.Entite;
using RAMQ.PRE.PRE_Entites_cpo.PeriodePratique.Parametre;
using RAMQ.PRE.PRE_Entites_cpo.Professionnel.Parametre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAMQ.PRE.PLC2_CnsulProfiPremqProf_cpo.Entites
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// </remarks>
	public class HistoriqueEngagement
    {
        // <summary>
        /// indformation sur les periodes engagement et absence
        /// </summary>
        public ObtenirVuePeriodeEngagementSorti PeriodeEngagementsAbsence { get; set; }
        /// <summary>
        /// informations sur les periode de pratique - date 1ère facturation
        /// </summary>
        //public ObtenirPeriodePratiqueProfessionnelSorti PeriodePratiqueProfessionnel { get; set; }
        public DateTime? DatePremiereFacturation { get; set; }
        /// <summary>
        /// information sur le professionel
        /// </summary>
        public ObtenirDispensateurIndividuSorti InformationProfessionnel { get; set; }

    }

    /// <summary>
    /// comparateur
    /// </summary>
    public class PeriodeComparer : IEqualityComparer<Periode>
    {
        public bool Equals(Periode x, Periode y)
        {
            if (object.ReferenceEquals(x, y))
            { return true; }

            return x != null && y != null && x.DateDebut.Value.Equals(y.DateDebut.Value) && x.DateFin.Value.Equals(y.DateFin.Value);
             
        }

        public int GetHashCode(Periode obj)
        {
            int hashPeriodDateDebut = obj.DateDebut == null ? 0 : obj.DateDebut.Value.GetHashCode();
            int hashPeriodDateFin = obj.DateFin == null ? 0 : obj.DateFin.Value.GetHashCode();
            return hashPeriodDateDebut ^ hashPeriodDateFin;
        }
    }

    public class PerCompare : IComparer<Periode>
    {
        public int Compare(Periode x, Periode y)
        {
            return x.DateDebut.Value.CompareTo(y.DateDebut.Value) + x.DateFin.Value.CompareTo(y.DateFin.Value);
        }
    }

    /// <summary>
    /// Chevauchement de periode dans l'historique
    /// </summary>
    public class ChevauchementPeriode
    {
        /// <summary>
        /// liste des periodes d'absence à supprimer de l'historique
        /// </summary>
        public List<EngagementPratique> SupprimerPeriodeAbs { get; set; } = new List<EngagementPratique>();

        /// <summary>
        /// liste des periodes d'absence à ajouter dans l'historique
        /// </summary>
        public List<EngagementPratique> AjouterPeriodeAbs { get; set; } = new List<EngagementPratique>();
    }

}