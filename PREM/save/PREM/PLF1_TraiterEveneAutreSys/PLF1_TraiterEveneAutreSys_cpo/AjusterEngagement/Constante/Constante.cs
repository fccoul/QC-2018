using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAMQ.PRE.PLF1_TraiterEveneAutreSys_cpo.AjusterEngagement.Constante
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// </remarks>
	public sealed class Constante
    {
        /// <summary>
        /// Le sujet du courriel est fonction de l’événement traité Non-Participation
        /// </summary>
        public const string TypeEvenementNonparticipation = "Non-Participation : PREM -Événement de non-participation du FIP non-traité";
        /// <summary>
        /// Le sujet du courriel est fonction de l’événement traité Première spécialité 
        /// </summary>
        public const string TypeEvenementPremiereSpecialite = "Première spécialité : Événement de première spécialité";
        /// <summary>
        /// Le sujet du courriel est fonction de l’événement traité Décès
        /// </summary>
        public const string TypeEvenemenDeces = "Décès : PREM - Événement de décès du FIP non-traité";

        /// <summary>
        /// Message pour Médecin devenu spécialiste
        /// </summary>
        public const string MessageSpecialiste = "Médecin devenu spécialiste : L’événement n’a pas été traité puisque que le médecin est devenu spécialiste.";

        /// <summary>
        /// Message pour une presence derogation
        /// </summary>
        public const string MessageDerogation = "Présence d’une dérogation : L’événement n’a pas été traité puisque qu’une dérogation existe après l’événement initial.";


        /// <summary>
        /// Message pour une presence derogationayant plusieurs statuts
        /// </summary>
        public const string MessageDerogationPlusieurStatuts = "Plusieurs statuts pour une dérogation  : L’événement n’a pas été traité puisque la dérogation n’a pu être réactivé.";


        /// <summary>
        /// Message pour une presence autorisation
        /// </summary>
        public const string MessageAutorisation = "Présence d’une autorisation : L’événement n’a pas été traité puisque qu’une autorisation existe après l’événement initial.";

        /// <summary>
        /// Message pour une presence d'avis de conformite
        /// </summary>
        public const string MessageAvisConformite = "Présence d’un avis de conformité : L’événement n’a pas été traité puisque qu’un avis de conformité existe après l’événement initial.";

        /// <summary>
        /// Message pour un Décès
        /// </summary>
        public const string MessageDeces = "Décès : L’événement n’a pas été traité puisque que le médecin est décédé.";


        /// <summary>
        /// Code raison statut suite à la reactivation de l'avis de conformite dans le cas d'une modification de la periode de non admissibilite
        /// </summary>
        public const string EvtModif_CodeRaiStaAvisDatNPartPosterieur = "22";
        /// <summary>
        /// Code raison statut suite à la reactivation de l'avis de conformite dans le cas d'une modification de la periode de specialite
        /// </summary>
        public const string EvtSpec_CodeRaiStaAvisDatNPartPosterieur = "29";
        /// <summary>
        /// Code raison statut suite à la reactivation de l'avis de conformite dans le cas d'une modification de la periode de décès
        /// </summary>
        public const string EvtDec_CodeRaiStaAvisDatNPartPosterieur = "26";

        /// <summary>
        /// Code raison statut suite à la reactivation de la derogation dans le cas d'une modification de la periode de non admissibilite
        /// </summary>
        public const string EvtModif_CodeRaiStaDerogationDatNPartPosterieur = "08";
               /// <summary>
        /// Code raison statut suite à la reactivation de la derogation dans le cas d'une modification de la periode de specialite
        /// </summary>
        public const string EvtSpec_CodeRaiStaDerogationDatNPartPosterieur = "30";
        /// <summary>
        /// Code raison statut suite à la reactivation de la derogation dans le cas d'une modification de la periode de décès
        /// </summary>
        public const string EvtDec_CodeRaiStaDerogationDatNPartPosterieur = "27";

        /// <summary>
        /// Code raison statut suite à la reactivation de l'autorisation dans le cas d'une modification de la periode de non admissibilite
        /// </summary>
        public const string EvtModif_CodeRaiStaAutorisationDatNPartPosterieur = "12";
        /// <summary>
        /// Code raison statut suite à la reactivation de l'autorisation dans le cas d'une modification de la periode de specialite
        /// </summary>
        public const string EvtSpec_CodeRaiStaAutorisationDatNPartPosterieur = "31";
        /// <summary>
        /// Code raison statut suite à la reactivation de l'autorisation  dans le cas d'une modification de la periode de décès
        /// </summary>
        public const string EvtDec_CodeRaiStaAutorisationDatNPartPosterieur = "28";

        /// <summary>
        /// Code raison statut pour l'avis de non conformité  - periode de non admissibilite
        /// </summary>
        public const string CodeRaisonStatutAvisConf_DateNonPartn = "21";

        /// <summary>
        /// Code raison statut pour l'avis de non conformité  - date de premère spécialité
        /// </summary>
        public const string CodeRaisonStatutAvisConf_DateSpec = "14";

        /// <summary>
        /// Code raison statut pour l'avis de non conformité  - date décès
        /// </summary>
        public const string CodeRaisonStatutAvisConf_DateDec = "13";

        /// <summary>
        /// Code raison statut pour Derogation(Fermeture)  - periode de non admissibilite
        /// </summary>
        public const string CodeRaisonStatutDerogation_DateNonPartn = "7";

        /// <summary>
        /// Code raison statut pour Derogation(Fermeture)  - date de premère spcialité
        /// </summary>
        public const string CodeRaisonStatutDerogation_DateSpec = "2";

        /// <summary>
        /// Code raison statut pour Derogation(Fermeture)  - date de premère spcialité
        /// </summary>
        public const string CodeRaisonStatutDerogation_DateDec = "1";

        /// <summary>
        /// Code raison statut pour Autorisation Fermeture  - periode de non admissibilite
        /// </summary>
        public const string CodeRaisonStatutAutorisationFerm_DateNonPartn = "3";

        /// <summary>
        /// Code raison statut pour Autorisation Annulation  - periode de non admissibilite
        /// </summary>
        public const string CodeRaisonStatutAutorisationAnn_DateNonPartn = "7";

        /// <summary>
        /// Code raison statut pour Autorisation Fermeture  - date de premère spcialité
        /// </summary>
        public const string CodeRaisonStatutAutorisationFerm_DateSpec = "5";

        /// <summary>
        /// Code raison statut pour Autorisation Annulation  - date de premère spcialité
        /// </summary>
        public const string CodeRaisonStatutAutorisationAnn_DateSpec = "8";

        /// <summary>
        /// Code raison statut pour Autorisation Fermeture  - date décès
        /// </summary>
        public const string CodeRaisonStatutAutorisationFerm_DateDec = "6";

        /// <summary>
        /// Code raison statut pour Autorisation Annulation  - date  décès
        /// </summary>
        public const string CodeRaisonStatutAutorisationAnn_DateDec = "9";

    }
}