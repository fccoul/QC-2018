using RAMQ.PRE.PL_PremMdl_cpo.LieuGeographique;
using RAMQ.PRE.PRE_Entites_cpo.LieuGeographique.Parametre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAMQ.PRE.PL_Prem_iut.ControllersHelpers
{
    /// <summary>
    /// Classe utilitaire en lien au lieu géographique.
    /// </summary>
    public class LieuGeographiqueHelpers : ILieuGeographiqueHelpers
    {

        private readonly ILieuGeographiqueFactory _lieuGeographiqueFactory;
        private readonly Securite.ISecurite _securite;

        /// <summary>
        /// Constructeur de la classe.
        /// </summary>
        /// <param name="lieuGeographiqueFactory">Injection du factory LieuGeographique</param>
        /// <param name="securite">Injection de l'objet de sécurité</param>
        public LieuGeographiqueHelpers(ILieuGeographiqueFactory lieuGeographiqueFactory,
                                       Securite.ISecurite securite)
        {
            _lieuGeographiqueFactory = lieuGeographiqueFactory;
            _securite = securite;
        }

        /// <summary>
        /// Fonction permettant d'obtenir le territoire RSS de l'utilisateur courant.
        /// </summary>
        /// <returns>Territoire RSS</returns>
        public string ObtenirNomTerritoireRSSUtilisateurCourant()
        {
            string nomTerritoire = _lieuGeographiqueFactory.Instancier().ObtenirNomTerritoire(
               new ObtenirNomTerritoireEntre
               {
                   Type = "RSS",
                   Code = _securite.ObtenirCodeRSSUtilisateurCourant().CodeRSS
               }).NomTerritoire;

            return nomTerritoire;
        }

    }
}