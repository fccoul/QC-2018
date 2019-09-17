using RAMQ.PRE.PRE_Entites_cpo.Professionnel.Parametre;
using RAMQ.PRE.PRE_SysExt_cpo.FIP.EPZ3.Parametre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAMQ.PRE.PLF1_TraiterEveneAutreSys_cpo.Utilitaire
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// </remarks>
	internal class Mappeur
    {
        #region Professionnel

        /// <summary>
        ///  Map un objet Professionnel.Parametre.ObtenirDispensateurIndividuEntre en FIP.EPZ3.Parametre.ObtnRelDispIndivEntre
        /// </summary>
        /// <Parametre name="parametreEntre">Objet source</Parametre>
        /// <remarks></remarks>
        static internal ObtnRelDispIndivEntre Mapper(ObtenirDispensateurIndividuEntre intrant)
        {
            var intrantEZP3 = new ObtnRelDispIndivEntre();
            intrantEZP3.DateService = intrant.DateService;
            intrantEZP3.NumeroClasseDispensateur = intrant.NumeroClasseDispensateur;
            intrantEZP3.NumeroDispensateur = intrant.NumeroDispensateur;
            intrantEZP3.NumeroSequentielDispensateur = intrant.NumeroSequentielDispensateur;
            intrantEZP3.NumeroSequentielIndividu = intrant.NumeroSequentielIndividu;

            return intrantEZP3;
        }

        /// <summary>
        ///  Map un objet FIP.EPZ3.Parametre.ObtnRelDispIndivSorti en Professionnel.Parametre.ObtenirDispensateurIndividuSorti
        /// </summary>
        /// <Parametre name="parametreEntreEZP3">Objet source</Parametre>
        /// <remarks></remarks>
        static internal ObtenirDispensateurIndividuSorti Mapper(ObtnRelDispIndivSorti intrantEPZ3)
        {
            var extrant = new ObtenirDispensateurIndividuSorti();
            extrant.AnneesGraduation = intrantEPZ3.AnneesGraduation;
            extrant.ChiffresPreuveDispensateur = intrantEPZ3.ChiffresPreuveDispensateur;
            extrant.CodesProfession = intrantEPZ3.CodesProfession;
            extrant.DatesCreationDispensateur = intrantEPZ3.DatesCreationDispensateur;
            extrant.DatesCreationIndividu = intrantEPZ3.DatesCreationIndividu;
            extrant.DatesDebutPratique = intrantEPZ3.DatesDebutPratique;
            extrant.DatesDecesIndividu = intrantEPZ3.DatesDecesIndividu;
            extrant.DatesInscriptionRamq = intrantEPZ3.DatesInscriptionRamq;
            extrant.DatesMAJDispensateur = intrantEPZ3.DatesMAJDispensateur;
            extrant.DatesModificationIndividu = intrantEPZ3.DatesModificationIndividu;
            extrant.DatesNaissanceIndividu = intrantEPZ3.DatesNaissanceIndividu;
            extrant.DatesObtentionPermis = intrantEPZ3.DatesObtentionPermis;
            extrant.DatesPremiereSpecialite = intrantEPZ3.DatesPremiereSpecialite;
            extrant.DroitsAcquisTarifHoraire = intrantEPZ3.DroitsAcquisTarifHoraire;
            extrant.IdentifiantsUtilisateurCreateur = intrantEPZ3.IdentifiantsUtilisateurCreateur;
            extrant.IdentifiantsUtilisateurModificateur = intrantEPZ3.IdentifiantsUtilisateurModificateur;
            extrant.IdentifiantsUtilisteurCreateurIndividu = intrantEPZ3.IdentifiantsUtilisteurCreateurIndividu;
            extrant.IdentifiantUtilisateurModificateurIndividu = intrantEPZ3.IdentifiantUtilisateurModificateurIndividu;
            extrant.IndicateursDemandeCourrier = intrantEPZ3.IndicateursDemandeCourrier;
            extrant.IndicateursFacturationRecente = intrantEPZ3.IndicateursFacturationRecente;
            extrant.InfoMsgTrait = intrantEPZ3.InfoMsgTrait;
            extrant.LanguesIndividu = intrantEPZ3.LanguesIndividu;
            extrant.NombresAnneesExperienceQuebecSpecialiste = intrantEPZ3.NombresAnneesExperienceQuebecSpecialiste;
            extrant.NombresAnnneesExperienceHorsQuebec = intrantEPZ3.NombresAnnneesExperienceHorsQuebec;
            extrant.NomsIndividu = intrantEPZ3.NomsIndividu;
            extrant.NomsNaissanceIndividu = intrantEPZ3.NomsNaissanceIndividu;
            extrant.NomsTronqueIndividu = intrantEPZ3.NomsTronqueIndividu;
            extrant.NumeroAssuranceSocialeIndividu = intrantEPZ3.NumeroAssuranceSocialeIndividu;
            extrant.NumerosClasseDispensateur = intrantEPZ3.NumerosClasseDispensateur;
            extrant.NumerosDispensateur = intrantEPZ3.NumerosDispensateur;
            extrant.NumerosSequentielDispensateur = intrantEPZ3.NumerosSequentielDispensateur;
            extrant.NumerosSequentielIndividu = intrantEPZ3.NumerosSequentielIndividu;
            extrant.NumerosSequentielIntervenantGraduation = intrantEPZ3.NumerosSequentielIntervenantGraduation;
            extrant.PrenomsIndividu = intrantEPZ3.PrenomsIndividu;
            extrant.SexeIndividu = intrantEPZ3.SexeIndividu;
            extrant.StatutsCivilIndividu = intrantEPZ3.StatutsCivilIndividu;
            extrant.TerritoiresPermis = intrantEPZ3.TerritoiresPermis;
            extrant.TitreCiviliteIndividu = intrantEPZ3.TitreCiviliteIndividu;

            return extrant;
        }

        #endregion
    }
}