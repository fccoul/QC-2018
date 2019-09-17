using RAMQ.PRE.PL_LogiqueAffaire_cpo.AvisConformite;
using RAMQ.PRE.PL_LogiqueAffaire_cpo.Derogation;
using RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal;
using RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Entite;
using RAMQ.PRE.PRE_SysExt_cpo.FIP.EPZ3;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RAMQ.PRE.PLF1_TraiterEveneAutreSys_cpo
{
    /// <summary>
    ///  
    /// </summary>
    public class TraiterAdmissProf : ITraiterAdmissProf
    {

        private ITraitementDonneesAdmissProf _traitementDonneesAdmissProf;
        public ITraitementDonneesAdmissProf TraitementDonneesAdmissProf
        {
            get
            {
                return _traitementDonneesAdmissProf;
            }

            set
            {
                _traitementDonneesAdmissProf = value;
            }
        }

        /// <summary>
        /// Constructeur de la CPO
        /// </summary>
        /// <param name="traitementDonneesAdmissProf"></param>
        public TraiterAdmissProf(ITraitementDonneesAdmissProf traitementDonneesAdmissProf)
        {
            if (traitementDonneesAdmissProf == null)
            {
                throw new ArgumentNullException($"Le paramètre : {nameof(traitementDonneesAdmissProf)} ne peut être null.");
            }

            _traitementDonneesAdmissProf = traitementDonneesAdmissProf;
        }

        public ParamSortiTraiterAdmissProf TraiterEvenementSuppression(ParamEntreTraiterAdmissProf intrant)
        {
            var sortant = new ParamSortiTraiterAdmissProf();

            //Obtient les avis du prof, ne garde que ceux qui sont ont un statut terminés/annulés par la raison 21,
            //pour ainsi réactiver l'avis en désactivant le statut impliqué
            var listeAvisConformiteDuProf = TraitementDonneesAdmissProf.ObtenirListeAvisProf(intrant.DisNoSeq, intrant.DHEvenement);

            var listeIdStatutADesactiver = TraitementDonneesAdmissProf.ObtenirCouplesIdAvisStatutTermineOuAnnule(listeAvisConformiteDuProf);

            TraitementDonneesAdmissProf.DesactiverStatutTermineOuAnnuleAvis(listeIdStatutADesactiver);


            //Obtient les dérogations du prof,  ne garde que celles qui sont terminées/annulées par la raison 6 et les réactive en conséquence
            var listeDerogationsDuProf = TraitementDonneesAdmissProf.ObtenirListeDerogationsProf(intrant.DisNoSeq, intrant.DHEvenement);

            listeDerogationsDuProf = TraitementDonneesAdmissProf.GarderIDDerogationsTermineesAnnuleesRaisonSix(listeDerogationsDuProf);

            TraitementDonneesAdmissProf.ReactiverDerogationsTermineesOuAnnuleesRaisonSix(listeDerogationsDuProf, intrant.DisNoSeq, intrant.DHEvenement);

            return sortant;
        }

        public ParamSortiTraiterAdmissProf TraiterEvenementAjoutModification(ParamEntreTraiterAdmissProf intrant)
        {
            var sortant = new ParamSortiTraiterAdmissProf();

            var listeAvisConformiteDuProf = TraitementDonneesAdmissProf.ObtenirListeAvisProf(intrant.DisNoSeq, intrant.DHEvenement);

            var listeDerogationsDuProf = TraitementDonneesAdmissProf.ObtenirListeDerogationsProf(intrant.DisNoSeq, intrant.DHEvenement);

            if (!TraitementDonneesAdmissProf.VerifierListesAvisEtDerogations(listeAvisConformiteDuProf, listeDerogationsDuProf))
            {
                return sortant;
            }

            //On garde les avis actifs ou futurs
            var listeAvisConformiteActifsDuProf = TraitementDonneesAdmissProf.GarderAvisActifs(listeAvisConformiteDuProf);
            var listeAvisConformiteFutursDuProf = TraitementDonneesAdmissProf.GarderAvisFuturs(listeAvisConformiteDuProf);

            //Même chose our les dérogations
            var listeDerogationsActivesDuProf = TraitementDonneesAdmissProf.GarderDerogationActives(listeDerogationsDuProf);
            var listeDerogationsFuturesDuProf = TraitementDonneesAdmissProf.GarderDerogationFutures(listeDerogationsDuProf);

            TraitementDonneesAdmissProf.FermerAvisActifs(listeAvisConformiteActifsDuProf, intrant.DHEvenement);

            TraitementDonneesAdmissProf.FermerDerogationsActives(listeDerogationsActivesDuProf, intrant.DisNoSeq, intrant.DHEvenement);

            TraitementDonneesAdmissProf.AnnulerAvisFuturs(listeAvisConformiteFutursDuProf, intrant.DHEvenement);

            TraitementDonneesAdmissProf.AnnulerDerogationsFutures(listeDerogationsFuturesDuProf, intrant.DisNoSeq, intrant.DHEvenement);

            return sortant;
        }


        public bool EstUnEvenementDeSuppression(string messageEvenement)
        {
            return messageEvenement == Constantes.MessageEvenementSuppression;
        }

        public bool EstUnEvenementDAjout(string messageEvenement)
        {
            return messageEvenement == Constantes.MessageEvenementAjout;
        }

        public bool EstUnEvenementDeModification(string messageEvenement)
        {
            return messageEvenement == Constantes.MessageEvenementModification;
        }


    }
}
