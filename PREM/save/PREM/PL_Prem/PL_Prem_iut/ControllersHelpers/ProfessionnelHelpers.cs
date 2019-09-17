using RAMQ.Message;
using RAMQ.PRE.PL_Prem_iut.Entite;
using RAMQ.PRE.PL_PremMdl_cpo.Professionnel;
using RAMQ.PRE.PRE_Entites_cpo.Professionnel.Parametre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OutilCommun = RAMQ.PRE.PRE_OutilComun_cpo;

namespace RAMQ.PRE.PL_Prem_iut.ControllersHelpers
{
    /// <summary>
    /// Classe utilitaire en lien au professionnel.
    /// </summary>
    public class ProfessionnelHelpers : IProfessionnelHelpers
    {
        private readonly IProfessionnelFactory _professionnelFactory;

        /// <summary>
        /// Constructeur de la classe.
        /// </summary>
        /// <param name="professionnelFactory">Injection du factory du professionnel.</param>
        public ProfessionnelHelpers(IProfessionnelFactory professionnelFactory)
        {
            _professionnelFactory = professionnelFactory;
        }

        /// <summary>
        /// Fonction permettant d'obtenir les informations d'un professionnel.
        /// </summary>
        /// <param name="intrant"></param>
        /// <returns></returns>
        public RechercheProfessionnelInformation ObtenirProfessionnelRecherche(RechercheProfessionnel intrant)
        {
            RechercheProfessionnelInformation extrant = new RechercheProfessionnelInformation();

            if (intrant.NumeroPratique.ToString().Length == 6)
            {
                int numeroDispensateur = int.Parse(intrant.NumeroPratique.ToString().Substring(1, 5));
                int numeroClasse = int.Parse(intrant.NumeroPratique.ToString().Substring(0, 1));

                if (intrant.ClassesPossible.Any(x => x == numeroClasse))
                {
                    var informationProfessionnel = _professionnelFactory.Instancier().ObtenirInformationProfessionnel(
                        new ObtenirDispensateurIndividuEntre
                        {
                            NumeroDispensateur = numeroDispensateur,
                            NumeroClasseDispensateur = numeroClasse
                        });

                    if (informationProfessionnel.InfoMsgTrait.Any())
                    {
                        extrant.MessageErreurs.AddRange(informationProfessionnel.InfoMsgTrait.Select(x => x.TxtMsgFran));
                    }
                    else
                    {
                        extrant.DateDeces = informationProfessionnel.DatesDecesIndividu.FirstOrDefault();
                        extrant.DateSpecialite = informationProfessionnel.DatesPremiereSpecialite.FirstOrDefault();
                        extrant.DateObtentionPermis = informationProfessionnel.DatesObtentionPermis.FirstOrDefault();
                        extrant.NumeroSequentielDispensateur = informationProfessionnel.NumerosSequentielDispensateur.FirstOrDefault();
                        extrant.NumeroSequentielIndividu = informationProfessionnel.NumerosSequentielIndividu.FirstOrDefault();
                        if (informationProfessionnel.NomsIndividu.Any() && informationProfessionnel.PrenomsIndividu.Any())
                        {
                            extrant.NomAffichage = informationProfessionnel.NomsIndividu.First() + ", " + informationProfessionnel.PrenomsIndividu.First();
                        }
                        else
                        {
                            extrant.NomAffichage = string.Empty;
                        }
                    }
                }
            }
            else
            {
                extrant.MessageErreurs.Add(new MsgTrait(OutilCommun.Constantes.CodeApplication,
                            OutilCommun.Constantes.CodeRetour.E_149061_NumeroPratiqueSixCaractereCommenceParUn).TxtMsgFran);
            }
            
            return extrant;
        }
    }
}