using System;
using System.Xml;
using System.Xml.Serialization;

namespace RAMQ.PRE.PL_LogiqueAffaire_cpo.GenerationPDF.GenerationXmlGabarit.Gabarits.Priorite
{
    /// <summary> 
    ///  Classe représentant la colonne1 dans le fichier XML
    /// </summary>
    /// <remarks>
    ///  Auteur : Alexis Garon-Michaud <br/>
    ///  Date   : Mars 2017
    /// </remarks>
    [Serializable]
    public class Colonne1 
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        public Colonne1()
        {
            Texte = string.Empty;
        }

        /// <summary>
        /// Numéro
        /// </summary>
        [XmlAttribute]
        public int Numero { get; set; } = 1;

        /// <summary>
        /// Texte
        /// </summary>
        [XmlIgnore]
        public string Texte
        {
            get
            {
                if (ChaineXmlBrute == null)
                {
                    return string.Empty;
                }

                return ChaineXmlBrute.Texte;
            }
            set
            {
                if (ChaineXmlBrute == null)
                {
                    ChaineXmlBrute = new ChaineXmlBrute();
                }

                ChaineXmlBrute.Texte  = AjouterBaliseParagrapheAuTourDuTexte(value);
            }
        }

        /// <summary>
        /// Chaîne de texte XML brute
        /// </summary>
        [XmlElement(nameof(Texte))]
        public ChaineXmlBrute ChaineXmlBrute;

        private string AjouterBaliseParagrapheAuTourDuTexte(string texte)
        {
            return $"<p>{texte ?? string.Empty}</p>";
        }
    }
}