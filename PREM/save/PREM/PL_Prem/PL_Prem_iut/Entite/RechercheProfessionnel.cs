namespace RAMQ.PRE.PL_Prem_iut.Entite
{
    /// <summary>
    /// Entité pour l'obtention des information d'un professionnel en entré
    /// </summary>
    public class RechercheProfessionnel
    {
        /// <summary>
        /// Numéro de pratique
        /// </summary>
        public int NumeroPratique { get; set; }

        /// <summary>
        /// Classes de professionnel possible
        /// </summary>
        public int[] ClassesPossible { get; set; }
    }
}