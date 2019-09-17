#region Imports
using System;
using System.Reflection;
#endregion

namespace RAMQ.PRE.PRE_OutilComun_cpo
{
    /// <summary> 
    ///  Classe contenant des méthodes permettant la gestion et 
    ///  la journalisation d'erreurs
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// 
    public class Journalisation
    {

        /// <summary>
        /// Méthode permettant de journaliser une erreur technique
        /// </summary>
        /// <param name="excptionJournaliser">Exception à journaliser</param>
        /// <param name="codeSeveriteErreur">Code de sévérité</param>
        /// <param name="identifiantUtilisateur">Identifiant utilisateur</param>
        /// <param name="informationComplementaire">Information complémentaire à journaliser</param>
        /// <param name="niveauIntervention">Niveau d'intervention</param>
        /// <param name="numeroMessageErreur">Numéro du message d'erreur</param>
        /// <param name="nomUniteTraitement">Nom de l'unité de tâche</param>
        /// <remarks></remarks>

#pragma warning disable RAMQ0200 // Règle RAMQ 12.7 : Évitez les méthodes avec plus de 5 paramètres.
        public static void JournaliserErreurTechnique(Exception excptionJournaliser, 
                                                      Enumeration.EnumCodSever codeSeveriteErreur = Enumeration.EnumCodSever.Erreur, 
                                                      string identifiantUtilisateur = null, 
                                                      string informationComplementaire = null, 
                                                      Enumeration.EnumNivInter niveauIntervention = Enumeration.EnumNivInter.DSU, 
                                                      string numeroMessageErreur = Constantes.CodeRetour.E_40758_ErreurImprevu, 
                                                      string nomUniteTraitement = null)
        {
            RAMQ.Journalisation.IParamEntreeJournErrTech journaliserErreurTechniqueEntre = default(RAMQ.Journalisation.IParamEntreeJournErrTech);

            try
            {
                //Récupérer le nom de l'unité de traitement et l'identifiant de l'usager courant
                if (string.IsNullOrEmpty(nomUniteTraitement))
                {
                    nomUniteTraitement = Composante.ObtenirCodUt(Assembly.GetCallingAssembly());
                }

            }
            catch (Exception)
            {
                
                //Nous retournons pas d'erreur
            }

            try
            {
                //Dans le cas où la valeur est nulle
                if (string.IsNullOrEmpty(identifiantUtilisateur))
                {
                    identifiantUtilisateur = Composante.ObtenirIdUtil();
                }
            }
            catch (Exception)
            {
                //Nous retournons pas d'erreur
            }

            // Journaliser l'erreur
            try
            {
                journaliserErreurTechniqueEntre = new RAMQ.Journalisation.ParamEntreeJournErrTech();

                journaliserErreurTechniqueEntre.CodAppli = Constantes.CodeApplication;
                journaliserErreurTechniqueEntre.CodSeverErr = codeSeveriteErreur;
                journaliserErreurTechniqueEntre.DetlErr = excptionJournaliser.Message;
                journaliserErreurTechniqueEntre.DhErr = DateTime.Now;
                journaliserErreurTechniqueEntre.IDUtil = identifiantUtilisateur;
                journaliserErreurTechniqueEntre.InfoCompl = informationComplementaire;
                journaliserErreurTechniqueEntre.LibelMsgErr = excptionJournaliser.Message;
                journaliserErreurTechniqueEntre.NivInter = niveauIntervention;
                journaliserErreurTechniqueEntre.NoMsgErr = numeroMessageErreur;
                journaliserErreurTechniqueEntre.NomSysExptnErr = Enumeration.EnumNomSysExptnErr.Windows;
                try
                {
                    //Dans le cas où le nom de l'application ne respecte pas la regex, mettre vide
                    journaliserErreurTechniqueEntre.NomUnitTach = nomUniteTraitement;
                }
                catch (Exception)
                {
                    journaliserErreurTechniqueEntre.NomUnitTach = string.Empty;
                }

                journaliserErreurTechniqueEntre.PileAppel = excptionJournaliser.StackTrace;

                using (RAMQ.Journalisation.JournErrTech journaliserErreurTechnique = new RAMQ.Journalisation.JournErrTech())
                {
                    journaliserErreurTechnique.JournaliserErrTech(journaliserErreurTechniqueEntre);
                }

            }
            finally
            {
                journaliserErreurTechniqueEntre = null;
            }

        }
#pragma warning restore RAMQ0200 // Règle RAMQ 12.7 : Évitez les méthodes avec plus de 5 paramètres.

    }

}
