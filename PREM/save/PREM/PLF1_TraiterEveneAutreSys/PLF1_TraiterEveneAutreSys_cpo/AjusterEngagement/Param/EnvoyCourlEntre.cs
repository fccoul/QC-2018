using RAMQ.Enumeration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAMQ.PRE.PLF1_TraiterEveneAutreSys_cpo.AjusterEngagement.Param
{
    /// <summary>
    /// Classe de paramètres d'entrée pour l'envoi de courriel
    /// </summary>
    /// <remarks>
    /// </remarks>
	public class EnvoyCourlEntre
    {
        /// <summary>
        /// Sujet du message
        /// </summary>
        public string Sujet { get; set; }

        /// <summary>
        /// contenu du message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Expediteur du message
        /// </summary>
        public string Expediteur { get; set; }

        /// <summary>
        /// Destinataire du message
        /// </summary>
        public string Destinataire { get; set; }

        /// <summary>
        /// Destinataire CC
        /// </summary>
        public string CCDestinataire { get; set; }

        /// <summary>
        /// Destinataire CCI
        /// </summary>
        public string CCIDestinataire { get; set; }

        /// <summary>
        /// Importance du message
        /// </summary>
        public EnumImportanceCourl Importance { get; set; }

        /// <summary>
        /// Format du message (Texte ou HTML)
        /// </summary>
        public EnumFormatMessage Format { get; set; }

        /// <summary>
        /// Encodage du message
        /// </summary>
        public EnumEncodMsgCourl EncodageMsg { get; set; }

    }

    /// <summary>
    /// Enumeration des raison pour lesquelles un evenment n'a pas été traité
    /// </summary>
    public enum EnumRaisonCourriel
    {

        Specialiste,
        Derogation,
        Autorisation,
        AvisConformite,
        Deces
    }
}