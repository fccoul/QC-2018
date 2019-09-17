using RAMQ.Message;
using RAMQ.PRE.PL_RegleAffaiComne_cpo.Validations;
using RAMQ.PRE.PLC2_CnsulProfiPremqProf_cpo.Parametres;
using RAMQ.PRE.PRE_Entites_cpo.Professionnel.Parametre;
using System;
using System.Collections.Generic;
using System.Linq;
using LogiqueAffaire = RAMQ.PRE.PL_LogiqueAffaire_cpo.Admissibilite;
using OutilsCommun = RAMQ.PRE.PRE_OutilComun_cpo;

namespace RAMQ.PRE.PLC2_CnsulProfiPremqProf_cpo.Validations
{
    /// <summary> 
    ///  Classe de validations
    /// </summary>
    /// <remarks>
    ///  Auteur : Jean-Benoit Drouin-Cloutier <br/>
    ///  Date   : Avril 2017
    /// </remarks>
    public class Validations : IValidations
    {
        #region Attributs

        private readonly IReglesValidations _reglesValidations;
        private readonly LogiqueAffaire.IAdmissibilite _admissibilite;
        private readonly OutilsCommun.IMessageTraitement _messageTraitement;

        #endregion

        #region Constructeur

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Validations(IReglesValidations reglesValidations,
                           LogiqueAffaire.IAdmissibilite admissibilite,
                           OutilsCommun.IMessageTraitement messageTraitement)
        {
            if (reglesValidations == null)
            {
                throw new ArgumentNullException($"Le paramètre : {nameof(reglesValidations)} ne peut être null.");
            }

            if (admissibilite == null)
            {
                throw new ArgumentNullException($"Le paramètre : {nameof(admissibilite)} ne peut être null.");
            }

            if (messageTraitement == null)
            {
                throw new ArgumentNullException($"Le paramètre : {nameof(messageTraitement)} ne peut être null.");
            }

            _reglesValidations = reglesValidations;
            _admissibilite = admissibilite;
            _messageTraitement = messageTraitement;
        }

        #endregion


        #region Méthodes publiques

        /// <summary>
        /// Valider le professionnel
        /// </summary>
        /// <param name="informationProfessionnel">Information du professionnel</param>
        /// <returns>Liste de messages</returns>
        public ValiderProfessionnelSorti ValiderProfessionnel(ValiderProfessionnelEntre informationProfessionnel)
        {
            var extrant = new ValiderProfessionnelSorti() { InfoMsgTrait = new List<MsgTrait>()};
            var avantPremierMars2004 = new DateTime(2004, 3, 1).AddDays(-1);
            var dateDuJour = DateTime.Today;



            if (ValiderDecesProfessionnel(informationProfessionnel.DateDeces, avantPremierMars2004) || 
                ValiderDecesProfessionnel(informationProfessionnel.DatePremiereSpecialite, avantPremierMars2004) ||
                ValiderAdmissibilite(informationProfessionnel.NumeroDispensateur, informationProfessionnel.NumeroClasseDispensateur, avantPremierMars2004).HasValue)
            {
                extrant.InfoMsgTrait.Add(
                    _messageTraitement.NouveauMessageTraitement(OutilsCommun.Constantes.CodeRetour.I_148723_MedecinJamaisSoumisEntentePREM));

                //extrant.InfoMsgTrait.Add(
                //       new MsgTrait("PRE", OutilsCommun.Constantes.CodeRetour.I_148723_MedecinJamaisSoumisEntentePREM));
            }
            else
            {
                if (ValiderDecesProfessionnel(informationProfessionnel.DateDeces, dateDuJour))
                {
                    extrant.InfoMsgTrait.Add(_messageTraitement.NouveauMessageTraitement(OutilsCommun.Constantes.CodeRetour.I_148724_MedecinDecederOuSpecialiteDepuis,
                                             new string[] { "décédé", informationProfessionnel.DateDeces.Value.ToLongDateString() }));
                }

                if (ValiderSpecialiste(informationProfessionnel.DatePremiereSpecialite, dateDuJour))
                {
                    extrant.InfoMsgTrait.Add(_messageTraitement.NouveauMessageTraitement(OutilsCommun.Constantes.CodeRetour.I_148724_MedecinDecederOuSpecialiteDepuis,
                                             new string[] { "spécialiste", informationProfessionnel.DatePremiereSpecialite.Value.ToLongDateString() }));
                }


                var dateDebutNonParticipant = ValiderAdmissibilite(informationProfessionnel.NumeroDispensateur, informationProfessionnel.NumeroClasseDispensateur, dateDuJour);

                if (dateDebutNonParticipant.HasValue)
                {
                    extrant.InfoMsgTrait.Add(_messageTraitement.NouveauMessageTraitement(OutilsCommun.Constantes.CodeRetour.I_148724_MedecinDecederOuSpecialiteDepuis,
                                             new string[] { "non-participant", dateDebutNonParticipant.Value.ToLongDateString() }));

                }

            }

            return extrant;
        }

        #endregion

        #region Méthodes privées

        private bool ValiderDecesProfessionnel(DateTime? dateDeces, DateTime datePrevue)
        {
            return _reglesValidations.VerifierDeces(dateDeces, datePrevue);
        }

        private bool ValiderSpecialiste(DateTime? datePremiereSpecialite, DateTime datePrevue)
        {
            return _reglesValidations.VerifierSpecialiste(datePremiereSpecialite, datePrevue);
        }

        private DateTime? ValiderAdmissibilite(int? numeroDispensateur, int? numeroClasseDispensateur, DateTime datePrevue)
        {
            var admissibilite = _admissibilite.VerifierAdmissibiliteProfessionnel(new VerifierAdmissibiliteProfessionnelFacturerEntre
            {
                NumeroDispensateur = numeroDispensateur.Value,
                NumeroClasse = numeroClasseDispensateur.Value,
                DateDebutPeriode = datePrevue,
                DateFinPeriode = DateTime.MaxValue
            });


            return admissibilite.PeriodesAdmissibilite.Any(x => x.StatutAdmissibilite == "NA" && 
                                                                x.CodeRaisonNonAdmissibilite == "NPAR" &&
                                                         (datePrevue >= x.DateDebutAdmissibilite &&
                                                             (x.DateFinAdmissibilite.HasValue ? datePrevue <= x.DateFinAdmissibilite.Value : true))) ? admissibilite.PeriodesAdmissibilite.First(x => x.StatutAdmissibilite == "NA" &&  x.CodeRaisonNonAdmissibilite == "NPAR" &&
                                                                   (datePrevue >= x.DateDebutAdmissibilite &&
                                                                       (x.DateFinAdmissibilite.HasValue ? datePrevue <= x.DateFinAdmissibilite.Value : true))).DateDebutAdmissibilite : (DateTime?)null;

        }

        #endregion

    }
}