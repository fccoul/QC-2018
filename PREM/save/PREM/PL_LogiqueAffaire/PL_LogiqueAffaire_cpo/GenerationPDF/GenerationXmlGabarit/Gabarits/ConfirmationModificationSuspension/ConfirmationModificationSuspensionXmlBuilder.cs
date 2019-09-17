using System;
using System.Collections.Generic;

namespace RAMQ.PRE.PL_LogiqueAffaire_cpo.GenerationPDF.GenerationXmlGabarit.Gabarits.ConfirmationModificationSuspension
{
    /// <summary> 
    ///  Classe qui prend en charge la création du XML pour
    ///  la page de confirmation d'une modification d'une
    ///  suspension
    /// </summary>
    /// <remarks>
    ///  Auteur : Alexis Garon-Michaud <br/>
    ///  Date   : Mars 2017
    /// </remarks>
    public class ConfirmationModificationSuspensionXmlBuilder : IXmlBuilder
    {
        private readonly ISerialiseurXml _serialiseurXml;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="serialiseurXml">Sérialiseur XML</param>
        public ConfirmationModificationSuspensionXmlBuilder(ISerialiseurXml serialiseurXml)
        {
            ValidateurParametreObligatoire.ValiderParametreNull(serialiseurXml, nameof(serialiseurXml));

            _serialiseurXml = serialiseurXml;
        }

        /// <summary>
        /// Gabarit
        /// </summary>
        public GabaritConfirmationModificationSuspension Gabarit { get; } = new GabaritConfirmationModificationSuspension();

        /// <summary>
        /// Nombre de priorité requis
        /// </summary>
        public static readonly byte NombrePrioriteRequis = 9;

        /// <summary>
        /// Construire 
        /// </summary>
        /// <param name="priorites">Liste des priorités à insérer dans le gabarit</param>
        /// <returns>Retourne une structure XML en format d'array de byte</returns>
        public byte[] Construire(IList<string> priorites)
        {
            ValiderNombrePriorite(priorites);

            AssignerTexteAPartirDesPriorites(priorites);

            return _serialiseurXml.Serialiser(Gabarit);
        }

        private void ValiderNombrePriorite(IList<string> priorites)
        {
            if (priorites == null)
            {
                throw new ArgumentNullException($"Le paramètre : {nameof(priorites)}, ne peut être nul.");
            }

            if (priorites.Count != NombrePrioriteRequis)
            {
                throw new ArgumentOutOfRangeException($"Le paramètre : {nameof(priorites)}, ne contient pas le bon nombre de priorité.");
            }
        }

        private void AssignerTexteAPartirDesPriorites(IList<string> priorites)
        {
            Gabarit.Page.Priorite1.Ligne1.Colonne1.Texte = priorites[0];
            Gabarit.Page.Priorite2.Ligne1.Colonne1.Texte = priorites[1];
            Gabarit.Page.Priorite3.Ligne1.Colonne1.Texte = priorites[2];
            Gabarit.Page.Priorite4.Ligne1.Colonne1.Texte = priorites[3];
            Gabarit.Page.Priorite5.Ligne1.Colonne1.Texte = priorites[4];
            Gabarit.Page.Priorite6.Ligne1.Colonne1.Texte = priorites[5];
            Gabarit.Page.Priorite7.Ligne1.Colonne1.Texte = priorites[6];
            Gabarit.Page.Priorite8.Ligne1.Colonne1.Texte = priorites[7];
            Gabarit.Page.Priorite9.Ligne1.Colonne1.Texte = priorites[8];
        }
    }
}