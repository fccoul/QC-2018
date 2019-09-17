using System;
using System.Collections.Generic;
using RAMQ.PRE.PL_LogiqueAffaire_cpo.AvisConformite;
using RAMQ.PRE.PL_LogiqueAffaire_cpo.Derogation;
using RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal;
using RAMQ.PRE.PRE_Entites_cpo.AvisConformite.Entite;
using RAMQ.PRE.PRE_Entites_cpo.Derogation.Entite;
using RAMQ.PRE.PRE_SysExt_cpo.FIP.EPZ3;

namespace RAMQ.PRE.PLF1_TraiterEveneAutreSys_cpo
{
    public interface ITraitementDonneesAdmissProf
    {
        IPlanRegnMdcal AccesDonneesPRE { get; set; }
        IInfoDispCnsul AccesSysExt { get; set; }
        IAvisConformite AvisConformite { get; set; }
        IDerogation Derogation { get; set; }

        void AnnulerAvisFuturs(List<PRE_Entites_cpo.AvisConformite.Entite.AvisConformite> listeAvisFuturs, DateTime dateHeureEvenement);
        void AnnulerDerogationsFutures(List<PRE_Entites_cpo.Derogation.Entite.Derogation> listeDerogationsFutures, long noSequentielDispensateur, DateTime dateHeureEvenement);
        void DesactiverStatutTermineOuAnnuleAvis(List<CoupleIDAvisStatut> listeCoupleIDAvisStatut);
        void FermerAvisActifs(List<PRE_Entites_cpo.AvisConformite.Entite.AvisConformite> listeAvisActifs, DateTime dateHeureEvenement);
        void FermerDerogationsActives(List<PRE_Entites_cpo.Derogation.Entite.Derogation> listeDerogationsActives, long noSequentielDispensateur, DateTime dateHeureEvenement);
        List<PRE_Entites_cpo.AvisConformite.Entite.AvisConformite> GarderAvisActifs(List<PRE_Entites_cpo.AvisConformite.Entite.AvisConformite> listeAvis);
        List<PRE_Entites_cpo.AvisConformite.Entite.AvisConformite> GarderAvisFuturs(List<PRE_Entites_cpo.AvisConformite.Entite.AvisConformite> listeAvis);
        List<PRE_Entites_cpo.Derogation.Entite.Derogation> GarderDerogationActives(List<PRE_Entites_cpo.Derogation.Entite.Derogation> listeDerogations);
        List<PRE_Entites_cpo.Derogation.Entite.Derogation> GarderDerogationFutures(List<PRE_Entites_cpo.Derogation.Entite.Derogation> listeDerogations);
        List<PRE_Entites_cpo.Derogation.Entite.Derogation> GarderIDDerogationsTermineesAnnuleesRaisonSix(List<PRE_Entites_cpo.Derogation.Entite.Derogation> listeDerogations);
        List<CoupleIDAvisStatut> ObtenirCouplesIdAvisStatutTermineOuAnnule(List<PRE_Entites_cpo.AvisConformite.Entite.AvisConformite> listeAvis);
        List<PRE_Entites_cpo.AvisConformite.Entite.AvisConformite> ObtenirListeAvisProf(long noSeqDispensateur, DateTime dateHeureEvenement);
        List<PRE_Entites_cpo.Derogation.Entite.Derogation> ObtenirListeDerogationsProf(long noSeqDispensateur, DateTime dateHeureEvenement);
        void ReactiverDerogationsTermineesOuAnnuleesRaisonSix(List<PRE_Entites_cpo.Derogation.Entite.Derogation> listeDerogations, long noSeqDispensateur, DateTime dateHeureEvenement);
        bool VerifierListesAvisEtDerogations(List<PRE_Entites_cpo.AvisConformite.Entite.AvisConformite> listeAvis, List<PRE_Entites_cpo.Derogation.Entite.Derogation> listeDerogations);
        bool VerifierListeAvis(List<PRE_Entites_cpo.AvisConformite.Entite.AvisConformite> listeAvis);
        bool VerifierListeDerogations(List<PRE_Entites_cpo.Derogation.Entite.Derogation> listeDerogations);
    }
}