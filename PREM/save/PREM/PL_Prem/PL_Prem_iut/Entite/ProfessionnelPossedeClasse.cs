namespace RAMQ.PRE.PL_Prem_iut.Entite
{
    /// <summary>
    /// Entité pour la validation de classe d'un professionnel
    /// </summary>
    public class ProfessionnelPossedeClasse
    {
        /// <summary>
        /// Numéro d'individu
        /// </summary>
        public long NumeroIndividu { get; set; }

        /// <summary>
        /// Classe de professionnel à vérifier
        /// </summary>
        public short Classe { get; set; }
    }
}