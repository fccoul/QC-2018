using RAMQ.PRE.PRE_Entites_cpo.LieuGeographique.Parametre;
using Entite = RAMQ.PRE.PRE_Entites_cpo.LieuGeographique.Entite;
using System;
using System.Collections.Generic;

namespace RAMQ.PRE.PL_PremMdl_cpo.LieuGeographique
{
    /// <summary> 
    ///  Référentiel bidon qui permet d'obtenir les regroupements de lieux géographiques fictifs 
    ///  codés en dur.
    /// </summary>
    /// <remarks>
    ///  Auteur : Danick Nadeau <br/>
    ///  Date   : Septembre 2016
    /// <br/>
    ///  Historique des modifications<br/>
    ///  ------------------------------------------------------------------------------<br/>
    ///  Auteur : [Auteur]<br/>
    ///  Date   : [aaaa-mm-jj]<br/>
    ///  Description:<br/>
    /// <br/>
    /// </remarks>
    public class LieuGeographiqueSimulation : ILieuGeographique
    {

        /// <summary>
        /// Obtenir la liste des regroupements et des lieux géographiques     
        /// rattachés à un RSS ou à un regroupement administratif.
        /// </summary>
        /// <returns>Retourne la liste des regroupements</returns>
        /// <remarks></remarks>
        public ObtenirRegroupementsLgeoRssSorti ObtenirRegroupementsLieuxGeographiquesRSS(ObtenirRegroupementsLgeoRssEntre intrant)
        {

            List<Entite.LieuGeographique> lieuxGeographiques = new List<Entite.LieuGeographique> {
                new Entite.LieuGeographique {
                    CodeLieuGeographique = "108",
                    DateDebut = DateTime.Parse("2016-01-01"),
                    NomLieuGeographique = "RLS DE KAMOURASKA",
                    NumeroSequence = 1,
                    NumeroSequenceRegroupement = 1,
                    TypeLieuGeographique = "RLS"
                },
                new Entite.LieuGeographique {
                    CodeLieuGeographique = "3025",
                    DateDebut = DateTime.Parse("2016-01-01"),
                    NomLieuGeographique = "RLS DE QUEBEC-SUD",
                    NumeroSequence = 17,
                    NumeroSequenceRegroupement = 3,
                    TypeLieuGeographique = "RLS"
                }
            };
            List<Entite.Regroupement> regroupements = new List<Entite.Regroupement> {
                new Entite.Regroupement {
                    CodeLieuGeographique = "1",
                    CodeRegroupement = "1",
                    DateDebut = DateTime.Parse("2016-01-01"),
                    Nom = "RSS Bas-Saint-Laurent",
                    NumeroNiveau = 1,
                    NumeroSequenceDocumentOfficiel = 1177,
                    NumeroSequenceRegroupement = 1,
                    TypeLieuGeographique = "RSS",
                    TypeRegroupement = "PREM"
                },
                new Entite.Regroupement {
                    CodeLieuGeographique = "3",
                    CodeRegroupement = "3",
                    DateDebut = DateTime.Parse("2016-01-01"),
                    Nom = "RSS Capitale-Nationale",
                    NumeroNiveau = 1,
                    NumeroSequenceDocumentOfficiel = 1177,
                    NumeroSequenceRegroupement = 3,
                    TypeLieuGeographique = "RSS",
                    TypeRegroupement = "PREM"
                }
            };

            return new ObtenirRegroupementsLgeoRssSorti
            {
                LieuxGeographiques = lieuxGeographiques,
                Regroupements = regroupements
            };

        }

        /// <summary>
        /// Permet d'obtenir les information d'un territoire CLCS
        /// </summary>
        /// <param name="intrant">Entité contenant les valeur de recherche du territoire CLSC</param>
        /// <returns>Territoire CLSC</returns>
        /// <remarks></remarks>
        public ObtenirInformationTerritoireCLSCSortie ObtenirInformationTerritoireCLSC(ObtenirInformationTerritoireCLSCEntre intrant)
        {
            if (string.IsNullOrEmpty(intrant.CodeTerritoireCLSC))
            {
                return new ObtenirInformationTerritoireCLSCSortie()
                {
                    NomTerritoires = new List<string>()
                    {
                        $"{intrant.CodeRegionSocioSanitaire}-TerriCLSC-1",
                        $"{intrant.CodeRegionSocioSanitaire}-TerriCLSC-2",
                        $"{intrant.CodeRegionSocioSanitaire}-TerriCLSC-3",
                        $"{intrant.CodeRegionSocioSanitaire}-TerriCLSC-4"
                    }
                };
            }
            else
            {
                return new ObtenirInformationTerritoireCLSCSortie()
                {
                    NomTerritoires = new List<string>()
                    {
                        $"{intrant.CodeRegionSocioSanitaire}-TerriCLSC-{intrant.CodeTerritoireCLSC}",
                    }
                };
            }
           
        }

        /// <summary>
        /// Permet d'obtenir les informations des territoire RLS
        /// </summary>
        /// <param name="intrant">Entité contenant les paramètre de recherche</param>
        /// <returns>Liste de nom des territoire</returns>
        /// <remarks></remarks>
        public ObtenirInformationTerritoireRLSSorti ObtenirLesNomsTerritoireRLS(ObtenirInformationTerritoireRLSEntre intrant)
        {
            return new ObtenirInformationTerritoireRLSSorti()
            {
                NomTerritoires = new List<string>()
                {
                    $"TerriRLS-{intrant.CodeRegionSocioSanitaire}-{intrant.CodeTerritoireRLS}-01",
                    $"TerriRLS-{intrant.CodeRegionSocioSanitaire}-{intrant.CodeTerritoireRLS}-02",
                }
            };
        }


        /// <summary>
        /// Fonction pour retourner le nom du territoire en paramètre
        /// </summary>
        /// <param name="intrant">information du territoire</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public ObtenirNomTerritoireSorti ObtenirNomTerritoire(ObtenirNomTerritoireEntre intrant)
        {
            return new ObtenirNomTerritoireSorti()
            {
                NomTerritoire = $"Territoire {intrant.Code} de {intrant.CodeRSS}"
            };
        }


        /// <summary>
        /// Fonction pour retourner la liste des territoires permis
        /// </summary>
        /// <param name="intrant">date de début de pratique</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public ObtenirTerritoiresPermisSorti ObtenirTerritoiresPermis(ObtenirTerritoiresPermisEntre intrant)
        {
            return new ObtenirTerritoiresPermisSorti()
            {
                TerritoiresPermis = new List<PRE_Entites_cpo.LieuGeographique.Entite.TerritoirePermis>()
                {
                    new Entite.TerritoirePermis()
                    {
                        Id = $"{intrant.CodeRSS}01",
                        Nom = $"Territoire {intrant.CodeRSS}01 de la région {intrant.CodeRSS}"
                    },
                    new Entite.TerritoirePermis()
                    {
                        Id = $"{intrant.CodeRSS}02",
                        Nom = $"Territoire {intrant.CodeRSS}02 de la région {intrant.CodeRSS}"
                    },
                    new Entite.TerritoirePermis()
                    {
                        Id = $"{intrant.CodeRSS}03",
                        Nom = $"Territoire {intrant.CodeRSS}03 de la région {intrant.CodeRSS}"
                    },
                    new Entite.TerritoirePermis()
                    {
                        Id = $"{intrant.CodeRSS}134",
                        Nom = $"Territoire {intrant.CodeRSS}134 de la région {intrant.CodeRSS}"
                    }
                }
            };
        }
    }
}