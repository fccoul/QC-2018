using RAMQ.PRE.PLC2_CnsulProfiPremqProf_cpo.Parametres;
using RAMQ.PRE.PLC2_CnsulProfiPremqProf_cpo.Professionnel.Interface;
using RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal;
using RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre;
using System;
using System.Collections.Generic;
using System.Linq;
using OutilCommun = RAMQ.PRE.PRE_OutilComun_cpo;

namespace RAMQ.PRE.PLC2_CnsulProfiPremqProf_cpo.Professionnel
{
    /// <summary>
    /// Classe de la réduction à la rémunération
    /// </summary>
    /// <remarks>
    /// Auteur: Jean-Benoit Drouin-Cloutier
    /// </remarks>
	public class ReductionRemuneration : IReductionRemuneration
    {
        private readonly IPlanRegnMdcal _accesDonne;
        private readonly OutilCommun.IMessageTraitement _messageTraitement;

        /// <summary>
        /// Constructeur
        /// </summary>
        public ReductionRemuneration(IPlanRegnMdcal accesDonne,
                                     OutilCommun.IMessageTraitement messageTraitement)
        {
            if (accesDonne == null)
            {
                throw new ArgumentNullException($"Le paramètre : {nameof(accesDonne)} ne peut être null.");
            }

            if (messageTraitement == null)
            {
                throw new ArgumentNullException($"Le paramètre : {nameof(messageTraitement)} ne peut être null.");
            }

            _accesDonne = accesDonne;
            _messageTraitement = messageTraitement;
        }

        /// <summary>
        /// Obtenir la réduction à la rémunération
        /// </summary>
        /// <param name="intrant">Paramètre d'entrer</param>
        /// <returns>Réductions à la rémunération</returns>
        public ReductionRemunerationSorti ObtenirReductionRemuneration(ReductionRemunerationEntre intrant)
        {
            var extrant = new ReductionRemunerationSorti();

            try
            {
                // Faire appel au traitement "Obtenir la liste des réductions d’un professionnel"
                var extrantReduction = _accesDonne.ObtenirReductionsRemuneration(new ObtenirReductionsRemunerationEntre()
                {
                    NumeroSequenceDispensateur = intrant.NumeroSequentielMedecin,
                    EstRPPRUniquement = "N"
                });


                // Si le code de retour est "0" et si des informations sur les réductions sont retournées par le service
                if (!extrantReduction.InfoMsgTrait.Any() && extrantReduction.ReductionsRemuneration.Any())
                {
                    foreach (var reduction in extrantReduction.ReductionsRemuneration)
                    {
                        // Pour chaque réduction, appeler le service du noyau « Obtenir les exemptions d’une réduction »
                        var extrantExcemption = _accesDonne.ObtenirListeExemptions(new ObtenirListeExemptionsEntre()
                        {
                            NumerosSeqReduction = new List<string>() { reduction.NumeroSequence.ToString() }
                        });

                        if (extrantExcemption.InfoMsgTrait.Any())
                        {
                            extrant.InfoMsgTrait = extrantExcemption.InfoMsgTrait;
                            break; //Termine la boucle;
                        }
                        else
                        {
                            extrant.ReductionRemunerations.Add(new Entites.ReductionRemuneration()
                            {
                                NumeroSequentielReduction = reduction.NumeroSequence,
                                DateDebut = reduction.DateDebut,
                                DateFin = reduction.DateFin,
                                RaisonReduction = reduction.CodeRaison,
                                TypeReduction = string.Empty, //TODO : Trouver le type de réduction avec la table pre.pre_per_nresp. Ce n'est pas indiqué dans le dossier fonctionnel.
                                EstExemption = extrantExcemption.ListeExemptions.Any(),
                                RaisonExemption = extrantExcemption.ListeExemptions.Any() ? 
                                                  extrantExcemption.ListeExemptions.First(x => x.NumeroSequentielReduction == reduction.NumeroSequence).RaisonExemption : 
                                                  string.Empty
                            });
                        }
                    }

                }
                //	Si le code de retour est « 1 » (aucune occurrence retournée)
                else if (extrant.InfoMsgTrait.Any() && extrant.InfoMsgTrait.First().IdMsg == "1")
                {
                    extrant.InfoMsgTrait = new List<Message.MsgTrait>()
                    {
                        _messageTraitement.NouveauMessageTraitement(OutilCommun.Constantes.CodeRetour.I_148603_AucuneReductionRemunerationDossier)
                    };
                }
                else
                {
                    extrant.InfoMsgTrait = extrantReduction.InfoMsgTrait;
                }
            }
            catch (Exception)
            {
                throw;
            }


            return extrant;
        }
    }
}