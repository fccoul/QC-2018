using System.Collections.Generic;
using RAMQ.PRE.PL_LogiqueAffaire_cpo.GenerationPDF.CheminReseauGabarit;
using RAMQ.PRE.PL_LogiqueAffaire_cpo.GenerationPDF.GenerationGabaritXSL;
using RAMQ.PRE.PL_LogiqueAffaire_cpo.GenerationPDF.GenerationXmlGabarit;

namespace RAMQ.PRE.PL_LogiqueAffaire_cpo.GenerationPDF.GenerationPDF
{
    /// <summary> 
    ///  Classe pour la génération d'un fichier PDF
    /// </summary>
    /// <remarks>
    ///  Auteur : Alexis Garon-Michaud <br/>
    ///  Date   : Mars 2017
    /// </remarks>
    public class GenerateurPDF : IGenerateurPDF
    {
        private readonly IXmlBuilderFactory _xmlBuilderFactory;
        private readonly ICheminGabarit _cheminGabarit;
        private readonly IGenerateurGabaritXSL _generateurGabaritXSL;
        private IXmlBuilder _xmlBuilder;

        /// <summary>
        /// Constructeur
        /// </summary>
        public GenerateurPDF(IXmlBuilderFactory xmlBuilderFactory,
                             ICheminGabarit cheminGabarit,
                             IGenerateurGabaritXSL generateurGabaritXSL)
        {
            ValidateurParametreObligatoire.ValiderParametreNull(xmlBuilderFactory, nameof(xmlBuilderFactory));
            ValidateurParametreObligatoire.ValiderParametreNull(cheminGabarit, nameof(cheminGabarit));
            ValidateurParametreObligatoire.ValiderParametreNull(generateurGabaritXSL, nameof(generateurGabaritXSL));

            _xmlBuilderFactory = xmlBuilderFactory;
            _cheminGabarit = cheminGabarit;
            _generateurGabaritXSL = generateurGabaritXSL;
        }

        /// <summary>
        /// Propriété pour permettre l'injection de dépendance du IXmlBuilder
        /// </summary>
        public IXmlBuilder XmlBuilder
        {
            get
            {
                return _xmlBuilder;
            }
            set
            {
                if (_xmlBuilder == null)
                {
                    _xmlBuilder = value;
                }
            }
        }

        /// <summary>
        /// Générer fichier PDF
        /// </summary>
        /// <param name="typeGabarit">Type de gabarit</param>
        /// <param name="priorites">Liste des priorités</param>
        /// <returns>Retourne un fichier PDF soit faire d'array de byte</returns>
        public byte[] Generer(TypeGabarit typeGabarit, IList<string> priorites)
        {

            XmlBuilder = _xmlBuilderFactory.FabriquerBuilder(typeGabarit);

            var xml = XmlBuilder.Construire(priorites);

            var cheminReseauGabarit = _cheminGabarit.Obtenir(typeGabarit);

            var fichierPDF = _generateurGabaritXSL.GenererGabaritXSL(cheminReseauGabarit, xml);

            return fichierPDF;
        }
    }
}
