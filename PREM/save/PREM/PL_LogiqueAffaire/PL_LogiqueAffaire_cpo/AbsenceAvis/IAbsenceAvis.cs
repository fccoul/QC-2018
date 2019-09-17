using RAMQ.PRE.PRE_Entites_cpo.AbsencesAvis.Parametre;

namespace RAMQ.PRE.PL_LogiqueAffaire_cpo.AbsenceAvis
{
    /// <summary>
    /// Interfac AbsenceAvis
    /// </summary>
    public interface IAbsenceAvis
    {
        ObtenirListeEngagementsEtAbsencesAvisSorti ObtenirListeEngagementsEtAbsencesAvis(ObtenirListeEngagementsEtAbsencesAvisEntre intrant);
    }
}
