using System;
using RAMQ.PRE.PL_LogiqueAffaire_cpo.GenerationPDF.GenerationXmlGabarit.Gabarits;
using RAMQ.PRE.PL_LogiqueAffaire_cpo.GenerationPDF.GenerationXmlGabarit.Gabarits.ConfirmationAvisConformite;
using RAMQ.PRE.PL_LogiqueAffaire_cpo.GenerationPDF.GenerationXmlGabarit.Gabarits.ConfirmationDerogation;
using RAMQ.PRE.PL_LogiqueAffaire_cpo.GenerationPDF.GenerationXmlGabarit.Gabarits.ConfirmationModificationSuspension;
using RAMQ.PRE.PL_LogiqueAffaire_cpo.GenerationPDF.GenerationXmlGabarit.Gabarits.ConfirmationSuspension;

namespace RAMQ.PRE.PL_LogiqueAffaire_cpo.GenerationPDF.GenerationXmlGabarit
{
    /// <summary> 
    ///  Classe permettant de fabriquer le bon XmlBuilder selon le
    ///  type de gabarit
    /// </summary>
    /// <remarks>
    ///  Auteur : Alexis Garon-Michaud <br/>
    ///  Date   : Mars 2017
    /// </remarks>
    public class XmlBuilderFactory : IXmlBuilderFactory
    {
        /// <summary>
        /// Fabriquer le builder spécifique pour construire le XML
        /// </summary>
        /// <param name="typeGabarit">Type de gabarit</param>
        /// <returns>Retourne le bon builder tout dépendamment du type de gabarit</returns>
        public IXmlBuilder FabriquerBuilder(TypeGabarit typeGabarit)
        {
            IXmlBuilder xmlBuilder = null;

            switch (typeGabarit)
            {
                case TypeGabarit.ConfirmationAvisConformite:
                    xmlBuilder = new ConfirmationAvisConformiteXmlBuilder(new SerialiseurXml());
                    break;
                case TypeGabarit.ConfirmationSuspension:
                    xmlBuilder = new ConfirmationSuspensionXmlBuilder(new SerialiseurXml());
                    break;
                case TypeGabarit.ConfirmationModificationSuspension:
                    xmlBuilder = new ConfirmationModificationSuspensionXmlBuilder(new SerialiseurXml());
                    break;
                case TypeGabarit.ConfirmationDerogation:
                    xmlBuilder = new ConfirmationDerogationXmlBuilder(new SerialiseurXml());
                    break;
                default:
                    throw new NotSupportedException($"La valeur de la variable {nameof(typeGabarit)} : {typeGabarit.ToString()} n'est pas supportée.");
            }

            return xmlBuilder;
        }
    }
}