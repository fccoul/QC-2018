using RAMQ.PRE.PL_PremMdl_cpo.GabaritPDFConfirmation.Param;
using RAMQ.PRE.PL_PremMdl_cpo.svcSaisAvisConf;
using RAMQ.PRE.PL_PremMdl_cpo.svcSaisDecisAvisConf;
using RAMQ.PRE.PRE_OutilComun_cpo;

namespace RAMQ.PRE.PL_PremMdl_cpo.GabaritPDFConfirmation
{
    /// <summary>
    /// Classe offrant les fonctionnalités pour récupérer les gabarits de confirmation
    /// de façon simulé
    /// </summary>
    /// <remarks>
    /// Auteur : Alexis Garon-Michaud
    /// Date   : Avril 2017
    /// </remarks>
    public class GabaritPDFConfirmationRepository : IGabaritPDFConfirmation
    {
        /// <summary>
        /// Permet de récupérer une confirmation PDF selon l'action faite sur un 
        /// avis de conformité
        /// </summary>
        /// <param name="paramEntre">Paramètre d'entrée</param>
        /// <returns>Retourne une confirmation PDF</returns>
        public ObtnConfirmationPDFAvisConformiteSortie ObtenirConfirmationPDFAvisConformite(ObtnConfirmationPDFAvisConformiteEntre paramEntre)
        {
            var paramEntreSVC = new ObtnGabaritEntre()
            {
                MessageConfirmation = paramEntre.MessageConfirmation,
                IdentificationMedecin = paramEntre.IdentificationMedecin,
                Territoire = paramEntre.Territoire,
                DateDebutPrevueAvis = paramEntre.DateDebutPrevueAvis,
                TypeAction = MappeurTypeActionAvisConformite.DefinirTypeActionAvisConformite(paramEntre.TypeAction)
            };

            var paramSortiSVC = UtilitaireService.AppelerService<svcSaisAvisConf.IServSaisAvisConf,
                                                                 svcSaisAvisConf.ServSaisAvisConfClient,
                                                                 ObtnGabaritSorti>(x => x.ObtenirGabaritConfirmation(paramEntreSVC));

            var paramSorti = new ObtnConfirmationPDFAvisConformiteSortie()
            {
                GabaritPDF = paramSortiSVC.GabaritPDF,
                InfoMsgTrait = MessageTraitement.ObtenirMessagesTraitement(paramSortiSVC.InfoMsgTrait)
            };

            return paramSorti;
        }

        /// <summary>
        /// Permet de récupérer une confirmation PDF selon l'action faite sur
        /// une dérogation
        /// </summary>
        /// <param name="paramEntre">Paramètre d'entrée</param>
        /// <returns>Retourne une confirmation PDF</returns>
        public ObtnConfirmationPDFDerogationSortie ObtenirConfirmationPDFDerogation(ObtnConfirmationPDFDerogationEntre paramEntre)
        {
            var paramEntreSVC = new ObtnConfirmationDerogPDFEntre()
            {
                MessageConfirmation = paramEntre.MessageConfirmation,
                IdentificationMedecin = paramEntre.IdentificationMedecin,
                TypeDerogation = paramEntre.TypeDerogation,
                DateDebut = paramEntre.DateDebut,
                MessageInformatifComplementaire = paramEntre.MessageInformatifComplementaire,
                TypeAction = paramEntre.EstUneAnnulation ? TypeActionDerogtion.Annule : TypeActionDerogtion.Transmettre
            };

            var paramSortiSVC = UtilitaireService.AppelerService<svcSaisDecisAvisConf.IServSaisDecisAvisConf,
                                                                 svcSaisDecisAvisConf.ServSaisDecisAvisConfClient,
                                                                 ObtnConfirmationDerogPDFSorti>(x => x.ObtenirGabaritConfirmationDerog(paramEntreSVC));

            var paramSorti = new ObtnConfirmationPDFDerogationSortie()
            {
                GabaritPDF = paramSortiSVC.GabaritPDF,
                InfoMsgTrait = MessageTraitement.ObtenirMessagesTraitement(paramSortiSVC.InfoMsgTrait)
            };

            return paramSorti;
        }

        /// <summary>
        /// Permet de récupérer une confirmation PDF selon l'action faite
        /// sur une suspension
        /// </summary>
        /// <param name="paramEntre">Paramètre d'entrée</param>
        /// <returns>Retourne une confirmation PDF</returns>
        public ObtnConfirmationPDFSuspensionSortie ObtenirConfirmationPDFSuspension(ObtnConfirmationPDFSuspensionEntre paramEntre)
        {
            var paramEntreSVC = new ObtnConfirmationSuspPDFEntre()
            {
                 MessageConfirmation = paramEntre.MessageConfirmation,
                 IdentificationMedecin = paramEntre.IdentificationMedecin,
                 AvisConformite = paramEntre.AvisConformite,
                 TypeSuspension = paramEntre.TypeSuspension,
                 DateDebut = paramEntre.DateDebut,
                 DateFin = paramEntre.DateFin,
                 DateDebutPerModif = paramEntre.DateDebutPerModif,
                 DateFinPerModif = paramEntre.DateFinPerModif,
                 TypeAction = MappeurTypeActionSuspension.DefinirTypeActionSuspension(paramEntre.TypeAction)
            };

            var paramSortiSVC = UtilitaireService.AppelerService<svcSaisDecisAvisConf.IServSaisDecisAvisConf,
                                                                 svcSaisDecisAvisConf.ServSaisDecisAvisConfClient,
                                                                 ObtnConfirmationSuspPDFSorti>(x => x.ObtenirGabaritConfirmationSusp(paramEntreSVC));

            var paramSorti = new ObtnConfirmationPDFSuspensionSortie()
            {
                GabaritPDF = paramSortiSVC.GabaritPDF,
                InfoMsgTrait = MessageTraitement.ObtenirMessagesTraitement(paramSortiSVC.InfoMsgTrait)
            };

            return paramSorti;
        }
    }
}