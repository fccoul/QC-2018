using System;

namespace RAMQ.PRE.PLF1_TraiterEveneAutreSys_cpo.AjusterEngagement.Entite
{
    /// <summary>
    ///  Informations sur le dispensateur.
    /// </summary>
    public class Dispensateur
    {
        /// <summary>
        ///  Numéro séquentiel du dispensateur
        /// </summary>
        public long NoSeq { get; set; }

        /// <summary>
        ///  Le code de la classe du dispensateur permet en partie d'identifier la 
        ///  profession d'un dispensateur et le territoire (Québec ou Hors Québec) du 
        ///  permis de pratique.
        /// </summary>
        public byte Classe { get; set; }

        /// <summary>
        ///  Numéro identifiant un DISPENSATEUR de façon unique dans sa PROFESSION.
        /// </summary>
        public int Numero { get; set; }

        /// <summary>
        ///  Numéro séquentiel de l'individu
        /// </summary>
        public long NoSeqIndiv { get; set; }

        /// <summary>
        ///  Territoire où un dispensateur peut pratiquer selon son permis soit au Québec 
        ///  ou hors Québec.
        /// </summary>
        public string TerritoirePermis { get; set; }

        /// <summary>
        ///  Valeur utilisée pour s'assurer de l'exactitude du numéro du dispensateur 
        ///  inscrit ou saisi, et pour toutes correspondances destinées ou concernant les 
        ///  dispensateurs, avec le numéro et la classe du dispensateur sous le format 
        ///  9-99999-C où "C" est le chiffre preuve.
        /// </summary>
        public byte ChiffrePreuve { get; set; }

        /// <summary>
        ///  Code identifiant une profession.
        /// </summary>
        public string Profession { get; set; }

        /// <summary>
        ///  Date à laquelle un DISPENSATEUR obtient son premier permis de pratique.
        /// </summary>
        public DateTime? DateObtentionPermis { get; set; }

        /// <summary>
        ///  Date à laquelle l'inscription du DISPENSATEUR à la RAMQ est effective.
        /// </summary>
        public DateTime? DateInscriptionRAMQ { get; set; }

        /// <summary>
        ///  Année à laquelle le dispensateur a obtenu son diplôme d'étude.
        /// </summary>
        public short? AnneeGraduation { get; set; }

        /// <summary>
        ///  Numéro séquentiel identifiant un INTERVENANT SECONDAIRE, de type 
        ///  "université". Sert à déterminer l'université de graduation du 
        ///  dispensateur.
        /// </summary>
        public long? NoSeqUniversite { get; set; }

        /// <summary>
        ///  Ce champ indique si le DISPENSATEUR a contacté la RAMQ afin de demander :
        ///  l'arrêt de l'envoi de son courrier.
        /// </summary>
        public string IndEnvoiCourrier { get; set; }

        /// <summary>
        ///  L'indicateur de facturation récente indique si le DISPENSATEUR a facturé la 
        ///  Régie depuis 1 an, ou plus précisément, s'il a reçu paiement pour sa 
        ///  facturation dans la dernière année.
        /// </summary>
        public string IndFacturationRecente { get; set; }

        /// <summary>
        ///  Date à laquelle un médecin omnipraticien devient spécialiste c'est-à-dire 
        ///  obtient sa première SPÉCIALITÉ.
        /// </summary>
        public DateTime? DdSpecialite { get; set; }

        /// <summary>
        ///  Nombre d'années d'expérience reconnues pour la pratique hors Québec des 
        ///  généralistes, médecin omnipraticien, dentiste ou optométriste.
        /// </summary>
        public int? NombreAnPratiqueHq { get; set; }

        /// <summary>
        ///  Ce champ représente la date de début de pratique continue, évaluée pour le 
        ///  calcul des années de pratique, servant à déterminer l'échelle salariale (en 
        ///  considérant aussi le nombre d'année de pratique hors Québec (NBR AN HQ)).
        /// </summary>
        public DateTime? DdPratique { get; set; }
        
        /// <summary>
        ///  Date de création de l'occurence
        /// </summary>
        public DateTime? Dc { get; set; }

        /// <summary>
        ///  Identifiant de l'utilisateur ayant créer l'occurence
        /// </summary>
        public string IdUtilCreat { get; set; }
    }

    #region BizTalk
    public class DispensateurBizTalk
    {
        /// <summary>
        ///  Numéro séquentiel du dispensateur
        /// </summary>
        public string NoSeq { get; set; }

        /// <summary>
        ///  Le code de la classe du dispensateur permet en partie d'identifier la 
        ///  profession d'un dispensateur et le territoire (Québec ou Hors Québec) du 
        ///  permis de pratique.
        /// </summary>
        public string Classe { get; set; }

        /// <summary>
        ///  Numéro identifiant un DISPENSATEUR de façon unique dans sa PROFESSION.
        /// </summary>
        public string Numero { get; set; }

        /// <summary>
        ///  Numéro séquentiel de l'individu
        /// </summary>
        public string NoSeqIndiv { get; set; }

        /// <summary>
        ///  Territoire où un dispensateur peut pratiquer selon son permis soit au Québec 
        ///  ou hors Québec.
        /// </summary>
        public string TerritoirePermis { get; set; }

        /// <summary>
        ///  Valeur utilisée pour s'assurer de l'exactitude du numéro du dispensateur 
        ///  inscrit ou saisi, et pour toutes correspondances destinées ou concernant les 
        ///  dispensateurs, avec le numéro et la classe du dispensateur sous le format 
        ///  9-99999-C où "C" est le chiffre preuve.
        /// </summary>
        public string ChiffrePreuve { get; set; }

        /// <summary>
        ///  Code identifiant une profession.
        /// </summary>
        public string Profession { get; set; }

        /// <summary>
        ///  Date à laquelle un DISPENSATEUR obtient son premier permis de pratique.
        /// </summary>
        public string DateObtentionPermis { get; set; }

        /// <summary>
        ///  Date à laquelle l'inscription du DISPENSATEUR à la RAMQ est effective.
        /// </summary>
        public string DateInscriptionRAMQ { get; set; }

        /// <summary>
        ///  Année à laquelle le dispensateur a obtenu son diplôme d'étude.
        /// </summary>
        public string AnneeGraduation { get; set; }

        /// <summary>
        ///  Numéro séquentiel identifiant un INTERVENANT SECONDAIRE, de type 
        ///  "université". Sert à déterminer l'université de graduation du 
        ///  dispensateur.
        /// </summary>
        public string NoSeqUniversite { get; set; }

        /// <summary>
        ///  Ce champ indique si le DISPENSATEUR a contacté la RAMQ afin de demander :
        ///  l'arrêt de l'envoi de son courrier.
        /// </summary>
        public string IndEnvoiCourrier { get; set; }

        /// <summary>
        ///  L'indicateur de facturation récente indique si le DISPENSATEUR a facturé la 
        ///  Régie depuis 1 an, ou plus précisément, s'il a reçu paiement pour sa 
        ///  facturation dans la dernière année.
        /// </summary>
        public string IndFacturationRecente { get; set; }

        /// <summary>
        ///  Date à laquelle un médecin omnipraticien devient spécialiste c'est-à-dire 
        ///  obtient sa première SPÉCIALITÉ.
        /// </summary>
        public string DdSpecialite { get; set; }

        /// <summary>
        ///  Nombre d'années d'expérience reconnues pour la pratique hors Québec des 
        ///  généralistes, médecin omnipraticien, dentiste ou optométriste.
        /// </summary>
        public string NombreAnPratiqueHq { get; set; }

        /// <summary>
        ///  Ce champ représente la date de début de pratique continue, évaluée pour le 
        ///  calcul des années de pratique, servant à déterminer l'échelle salariale (en 
        ///  considérant aussi le nombre d'année de pratique hors Québec (NBR AN HQ)).
        /// </summary>
        public string DdPratique { get; set; }

        /// <summary>
        ///  Date de création de l'occurence
        /// </summary>
        public string Dc { get; set; }

        /// <summary>
        ///  Identifiant de l'utilisateur ayant créer l'occurence
        /// </summary>
        public string IdUtilCreat { get; set; }
    }
    #endregion
}