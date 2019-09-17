using System.Collections.Generic;
using System.Data;
using RAMQ.PRE.PRE_Entites_cpo.LieuGeographique.Parametre;
using RAMQ.PRE.PRE_Entites_cpo.LieuGeographique.Entite;
using RAMQ.PRE.PRE_Entites_cpo.Professionnel.Parametre;
using RAMQ.PRE.PRE_Entites_cpo.Professionnel.Entite;
using System.Linq;
using System;

namespace RAMQ.PRE.PRE_SysExt_cpo.Utilitaire
{
    /// <summary>
    /// Classe de mappagge
    /// </summary>
    public class Mappeur
    {
        /// <summary>
        ///  Map un objet RAMQ.AccesDonnees.BDOracle.IAccesDonnesOra en FIP.EPZ3.Param.ObtnRelDispIndivSorti
        /// </summary>
        /// <param name="source">Objet source</param>
        /// <returns>Objet cible</returns>
        public static FIP.EPZ3.Parametre.ObtnRelDispIndivSorti Mapper(AccesDonnees.BDOracle.IAccesDonnesOra source)
        {
            FIP.EPZ3.Parametre.ObtnRelDispIndivSorti cible = new FIP.EPZ3.Parametre.ObtnRelDispIndivSorti();

            cible.AnneesGraduation = source.Odp.ObtenirValParamRetou<List<int?>>("pTblAnGradDisp");
            cible.ChiffresPreuveDispensateur = source.Odp.ObtenirValParamRetou<List<int?>>("pTblChifrPrvDisp");
            cible.CodesProfession = source.Odp.ObtenirValParamRetou<List<string>>("pTblCodPrfsn");
            cible.DatesDecesIndividu = source.Odp.ObtenirValParamRetou<List<DateTime?>>("pTblDatDecesIndiv");
            cible.DatesInscriptionRamq = source.Odp.ObtenirValParamRetou<List<DateTime?>>("pTblDatInscrRamqDisp");
            cible.DatesNaissanceIndividu = source.Odp.ObtenirValParamRetou<List<DateTime?>>("pTblDatNaissIndiv");
            cible.DatesObtentionPermis = source.Odp.ObtenirValParamRetou<List<DateTime?>>("pTblDatObtenPermiDisp");
            cible.DatesPremiereSpecialite = source.Odp.ObtenirValParamRetou<List<DateTime?>>("pTblDatPremSpec");
            cible.DatesCreationDispensateur = source.Odp.ObtenirValParamRetou<List<DateTime?>>("pTblDcDisp");
            cible.DatesCreationIndividu = source.Odp.ObtenirValParamRetou<List<DateTime?>>("pTblDcIndiv");
            cible.DatesDebutPratique = source.Odp.ObtenirValParamRetou<List<DateTime?>>("pTblDdPrati");
            cible.DatesMAJDispensateur = source.Odp.ObtenirValParamRetou<List<DateTime?>>("pTblDmDisp");
            cible.DatesModificationIndividu = source.Odp.ObtenirValParamRetou<List<DateTime?>>("pTblDmIndiv");
            cible.DroitsAcquisTarifHoraire = source.Odp.ObtenirValParamRetou<List<string>>("pTblDroitAcqTh");
            cible.IdentifiantsUtilisateurCreateur = source.Odp.ObtenirValParamRetou<List<string>>("pTblIdUtilCreatDisp");
            cible.IdentifiantsUtilisteurCreateurIndividu = source.Odp.ObtenirValParamRetou<List<string>>("pTblIdUtilCreatIndiv");
            cible.IdentifiantsUtilisateurModificateur = source.Odp.ObtenirValParamRetou<List<string>>("pTblIdUtilMajDisp");
            cible.IdentifiantUtilisateurModificateurIndividu = source.Odp.ObtenirValParamRetou<List<string>>("pTblIdUtilMajIndiv");
            cible.IndicateursDemandeCourrier = source.Odp.ObtenirValParamRetou<List<string>>("pTblIndDemCouri");
            cible.IndicateursFacturationRecente = source.Odp.ObtenirValParamRetou<List<string>>("pTblIndFactRecen");
            cible.LanguesIndividu = source.Odp.ObtenirValParamRetou<List<string>>("pTblLangIndiv");
            cible.NumeroAssuranceSocialeIndividu = source.Odp.ObtenirValParamRetou<List<long?>>("pTblNasIndiv");
            cible.NombresAnnneesExperienceHorsQuebec = source.Odp.ObtenirValParamRetou<List<double?>>("pTblNbrAnHqGenrl");
            cible.NombresAnneesExperienceQuebecSpecialiste = source.Odp.ObtenirValParamRetou<List<double?>>("pTblNbrAnQcSpec");
            cible.NumerosClasseDispensateur = source.Odp.ObtenirValParamRetou<List<int?>>("pTblNoClaDisp");
            cible.NumerosDispensateur = source.Odp.ObtenirValParamRetou<List<int?>>("pTblNoDisp");
            cible.NomsIndividu = source.Odp.ObtenirValParamRetou<List<string>>("pTblNomIndiv");
            cible.NomsNaissanceIndividu = source.Odp.ObtenirValParamRetou<List<string>>("pTblNomNaissIndiv");
            cible.NomsTronqueIndividu = source.Odp.ObtenirValParamRetou<List<string>>("pTblNomTronIndiv");
            cible.NumerosSequentielDispensateur = source.Odp.ObtenirValParamRetou<List<long?>>("pTblNoSeqDisp");
            cible.NumerosSequentielIndividu = source.Odp.ObtenirValParamRetou<List<long?>>("pTblNoSeqIndiv");
            cible.NumerosSequentielIntervenantGraduation = source.Odp.ObtenirValParamRetou<List<long?>>("pTblNoSeqIntvnGrad");
            cible.PrenomsIndividu = source.Odp.ObtenirValParamRetou<List<string>>("pTblPreIndiv");
            cible.SexeIndividu = source.Odp.ObtenirValParamRetou<List<string>>("pTblSexeIndiv");
            cible.StatutsCivilIndividu = source.Odp.ObtenirValParamRetou<List<string>>("pTblStaCivilIndiv");
            cible.TerritoiresPermis = source.Odp.ObtenirValParamRetou<List<string>>("pTblTerriPermi");
            cible.TitreCiviliteIndividu = source.Odp.ObtenirValParamRetou<List<string>>("pTblTitreCivltIndiv");

            return cible;
        }


        /// <summary>
        /// Map un objet de type RAMQ.PRE.PRE_Entites_cpo.LieuGeographique.Parametre.ObtenirInformationTerritoireCLSCEntre en 
        /// svcObtnInfoLocal.EntreObtnInfoTerriCLSC
        /// </summary>
        /// <param name="source">Objet source</param>
        /// <returns>Objet cible</returns>
        static internal svcObtnInfoLocal.EntreObtnInfoTerriCLSC Mapper(ObtenirInformationTerritoireCLSCEntre source)
        {
            svcObtnInfoLocal.EntreObtnInfoTerriCLSC cible = new svcObtnInfoLocal.EntreObtnInfoTerriCLSC();

            cible.strCodRSS = source.CodeRegionSocioSanitaire;
            cible.strCodTerriCLSC = source.CodeTerritoireCLSC;

            return cible;
        }

        /// <summary>
        /// Map un objet de type svcObtnInfoLocal.SortieObtnInfoTerriCLSC en 
        /// RAMQ.PRE.PRE_Entites_cpo.LieuGeographique.Parametre.ObtenirInformationTerritoireCLSCSorti
        /// </summary>
        /// <param name="source">Objet source</param>
        /// <returns>Objet cible</returns>
        static internal ObtenirInformationTerritoireCLSCSortie Mapper(svcObtnInfoLocal.SortieObtnInfoTerriCLSC source)
        {
            ObtenirInformationTerritoireCLSCSortie cible = new ObtenirInformationTerritoireCLSCSortie();

            cible.InfoMsgTrait = new List<Message.MsgTrait>(
                from informationMessageTrait in source.InfoMsgTrait
                select PRE_OutilComun_cpo.MessageTraitement.MapperVersMessageTraitement(informationMessageTrait));

            cible.NomTerritoires = source.NomTerriCLSC;

            return cible;
        }

        /// <summary>
        /// Map un objet de type Parametre.ObtenirRegroupementsLgeoRssEntre en svcObtnInfoPilotLieuGeo.ObtnListeRegrLgeoRattaRssEntre
        /// </summary>
        /// <param name="source">Objet source</param>
        /// <returns>Objet cible</returns>
        static internal svcObtnInfoPilotLieuGeo.ObtnListeRegrLgeoRattaRssEntre Mapper(ObtenirRegroupementsLgeoRssEntre source)
        {
            svcObtnInfoPilotLieuGeo.ObtnListeRegrLgeoRattaRssEntre cible = new svcObtnInfoPilotLieuGeo.ObtnListeRegrLgeoRattaRssEntre();

            cible.CodeRssRegionSocioSanitaire = source.CodeRssRegionSocioSanitaire;
            cible.DateDebutRecherche = source.DateDebutRecherche;
            cible.DateFinRecherche = source.DateFinRecherche;
            cible.DateRecherche = source.DateRecherche;
            cible.IndObtentionLgeo = source.IndObtentionLgeo;
            cible.NumeroDocumentOfficiel = source.NumeroDocumentOfficiel;
            cible.NumeroSequenceRegrAdminLieuGeo = source.NumeroSequenceRegrAdminLieuGeo;
            cible.TypeRegroupement = source.TypeRegroupement;
            cible.IndObtnUniqmRegrVise = source.IndObtenirUniquementRegroupement;

            return cible;
        }

        /// <summary>
        /// Map un objet de type Parametre.ObtenirInformationTerritoireRLSEntre en svcObtnInfoLocal.EntreObtnInfoTerriRLS
        /// </summary>
        /// <param name="source">Objet source</param>
        /// <returns>Objet cible</returns>
        static internal svcObtnInfoLocal.EntreObtnInfoTerriRLS Mapper(ObtenirInformationTerritoireRLSEntre source)
        {
            svcObtnInfoLocal.EntreObtnInfoTerriRLS cible = new svcObtnInfoLocal.EntreObtnInfoTerriRLS();

            cible.CodRSS = source.CodeRegionSocioSanitaire;
            cible.CodTerriRLSRechr = source.CodeTerritoireRLS;

            return cible;
        }

        /// <summary>
        /// Map un objet de type svcObtnInfoLocal.SortieObtnInfoTerriRLS en Parametre.ObtenirInformationTerritoireRLSSorti
        /// </summary>
        /// <param name="source">Objet source</param>
        static internal ObtenirInformationTerritoireRLSSorti Mapper(svcObtnInfoLocal.SortieObtnInfoTerriRLS source)
        {
            ObtenirInformationTerritoireRLSSorti cible = new ObtenirInformationTerritoireRLSSorti();

            cible.InfoMsgTrait = new List<Message.MsgTrait>(
                from informationMessageTrait in source.InfoMsgTrait
                select PRE_OutilComun_cpo.MessageTraitement.MapperVersMessageTraitement(informationMessageTrait));

            if (source.NomTerriRLS != null)
            {
                cible.NomTerritoires = source.NomTerriRLS;
            }
            else
            {
                cible.NomTerritoires = new List<string>();
            }

            return cible;
        }

        /// <summary>
        /// Map un objet de type svcObtnInfoPilotLieuGeo.ObtnListeRegrLgeoRattaRssSorti en 
        /// RAMQ.PRE.PRE_Entites_cpo.LieuGeographique.Parametre.ObtenirRegroupementsLgeoRssSorti
        /// </summary>
        /// <param name="source">Objet source</param>
        /// <returns>Objet cible</returns>
        static internal ObtenirRegroupementsLgeoRssSorti Mapper(svcObtnInfoPilotLieuGeo.ObtnListeRegrLgeoRattaRssSorti source)
        {
            ObtenirRegroupementsLgeoRssSorti cible = new ObtenirRegroupementsLgeoRssSorti();

            cible.InfoMsgTrait = new List<RAMQ.Message.MsgTrait>(from informationMessageTrait in source.InfoMsgTrait
                                                                 select PRE_OutilComun_cpo.MessageTraitement.MapperVersMessageTraitement(informationMessageTrait));

            cible.LieuxGeographiques = new List<LieuGeographique>(from lieuGeographique in source.LieuxGeographiques
                                                                  select Mappeur.Mapper(lieuGeographique));

            cible.Regroupements = new List<Regroupement>(from regroupement in source.Regroupements
                                                         select Mappeur.Mapper(regroupement));

            return cible;
        }

        /// <summary>
        /// Map un objet de type svcObtnInfoPilotLieuGeo.Regroupement en Entite.Regroupement
        /// </summary>
        /// <param name="source">Objet source</param>
        /// <remarks></remarks>
        static internal LieuGeographique Mapper(svcObtnInfoPilotLieuGeo.LieuGeographique source)
        {
            return new LieuGeographique
            {
                CodeLieuGeographique = source.CodeLieuGeographique,
                DateDebut = source.DateDebut,
                DateFin = source.DateFin,
                DateHeureCreationOccurence = source.DateHeureCreationOccurence,
                DateHeureInactivationOccurence = source.DateHeureInactivationOccurence,
                IdentifiantUtilisateurCreation = source.IdentifianUtilisateurCreation,
                IdUtilInact = source.IdUtilInact,
                NomLieuGeographique = source.NomLieuGeographique,
                NumeroSequence = source.NumeroSequence,
                NumeroSequenceRegroupement = source.NumeroSequenceRegroupement,
                TypeLieuGeographique = source.TypeLieuGeographique
            };
        }

        /// <summary>
        /// Map un objet de type svcObtnInfoPilotLieuGeo.Regroupement en Entite.Regroupement
        /// </summary>
        /// <param name="source">Objet source</param>
        /// <remarks></remarks>
        static internal Regroupement Mapper(svcObtnInfoPilotLieuGeo.Regroupement source)
        {
            return new Regroupement
            {
                CodeLieuGeographique = source.CodeLieuGeographique,
                CodeRegroupement = source.CodeRegroupement,
                DateDebut = source.DateDebut,
                DateFin = source.DateFin,
                DateHeureCreationOccurence = source.DateHeureCreationOccurence,
                DateHeureInactivationOccurence = source.DateHeureInactivationOccurence,
                IdentifiantUtilisateurCreation = source.IdentifiantUtilisateurCreation,
                IdUtilInact = source.IdUtilInact,
                Nom = source.Nom,
                NumeroNiveau = source.NumeroNiveau,
                NumeroSequenceDocumentOfficiel = source.NumeroSequenceDocumentOfficiel,
                NumeroSequenceRegroupement = source.NumeroSequenceRegroupement,
                NumeroSequenceResponsable = source.NumeroSequenceResponsable,
                TypeLieuGeographique = source.TypeLieuGeographique,
                TypeRegroupement = source.TypeRegroupement
            };
        }

        /// <summary>
        /// Map un objet de type VerifierAdmissibiliteProfessionnelFacturerEntre en 
        /// svcInfoDispCnsul.ParamDeterminerAdmisFactuDispEntre
        /// </summary>
        /// <param name="source">Objet source</param>
        /// <returns>Objet cible</returns>
        static internal svcInfoDispCnsul.ParamDeterminerAdmisFactuDispEntre Mapper(VerifierAdmissibiliteProfessionnelFacturerEntre source)
        {
            svcInfoDispCnsul.ParamDeterminerAdmisFactuDispEntre cible = new svcInfoDispCnsul.ParamDeterminerAdmisFactuDispEntre();

            cible.Classe = source.NumeroClasse;
            cible.DDAppliForfa = source.DateDebutPeriode;
            cible.DFAppliForfa = source.DateFinPeriode;
            cible.NoDisp = source.NumeroDispensateur;

            return cible;
        }

        /// <summary>
        /// Map un objet de type svcInfoDispCnsul.ParamDeterminerAdmisFactuDispSortie en 
        /// VerifierAdmissibiliteProfessionnelFacturerSorti
        /// </summary>
        /// <param name="source">Objet source</param>
        /// <returns>Objet cible</returns>
        static internal VerifierAdmissibiliteProfessionnelFacturerSorti Mapper(svcInfoDispCnsul.ParamDeterminerAdmisFactuDispSortie source)
        {
            VerifierAdmissibiliteProfessionnelFacturerSorti cible = new VerifierAdmissibiliteProfessionnelFacturerSorti();

            cible.IndicateurAdmissibilite = source.IndAdmis;
            if (source.PeriodesAdmis != null && source.PeriodesAdmis.Count > 0)
            {
                cible.PeriodesAdmissibilite = new List<AdmissibiliteFacturer>(
                    from admissibilite in source.PeriodesAdmis
                    select Mappeur.Mapper(admissibilite));
            }
            else
            {
                cible.PeriodesAdmissibilite = new List<AdmissibiliteFacturer>();
            }

            if (source.InfoMsgTrait != null)
            {
                cible.InfoMsgTrait = new List<Message.MsgTrait> {
                    PRE_OutilComun_cpo.MessageTraitement.MapperVersMessageTraitement(source.InfoMsgTrait) };
            }

            return cible;
        }

        /// <summary>
        /// Map un objet de type svcInfoDispCnsul.ParamDeterminerAdmisFactuDispSortie en 
        /// VerifierAdmissibiliteProfessionnelFacturerSorti
        /// </summary>
        /// <param name="source"></param>
        /// <remarks></remarks>
        static internal AdmissibiliteFacturer Mapper(svcInfoDispCnsul.AdmisFact source)
        {

            var admissibiliteFacturer = new AdmissibiliteFacturer
            {
                CodeRaisonNonAdmissibilite = source.RsaCodRais,
                DateDebutAdmissibilite = Convert.ToDateTime(source.AdmDd),
                StatutAdmissibilite = source.AdmSta
            };

            if (string.IsNullOrEmpty(source.AdmDf))
            {
                admissibiliteFacturer.DateFinAdmissibilite = null;
            }
            else
            {
                admissibiliteFacturer.DateFinAdmissibilite = Convert.ToDateTime(source.AdmDf);
            }


            return admissibiliteFacturer;
        }

        /// <summary>
        /// Map un objet de type ObtenirDispensateursSelonEntenteEntre en svcInfoDispCnsul.ParamObtnProfNoEntenEntree
        /// </summary>
        /// <param name="source">Objet source</param>
        /// <returns>Objet cible</returns>
        static internal svcInfoDispCnsul.ParamObtnProfNoEntenEntree Mapper(ObtenirDispensateursSelonEntenteEntre source)
        {
            svcInfoDispCnsul.ParamObtnProfNoEntenEntree cible = new svcInfoDispCnsul.ParamObtnProfNoEntenEntree();

            cible.NoEnten = source.NumeroEntente;
            cible.DDPeriode = source.DateDebutPeriode;
            cible.DFPeriode = source.DateFinPeriode;

            return cible;
        }

        /// <summary>
        /// Map un objet de type svcInfoDispCnsul.ParamObtnProfNoEntenSorti en ObtenirDispensateursSelonEntenteSorti
        /// </summary>
        /// <param name="source">Objet source</param>
        /// <returns>Objet cible</returns>
        static internal ObtenirDispensateursSelonEntenteSorti Mapper(svcInfoDispCnsul.ParamObtnProfNoEntenSorti source)
        {
            ObtenirDispensateursSelonEntenteSorti cible = new ObtenirDispensateursSelonEntenteSorti();

            if (source.ColDispProf != null && source.ColDispProf.Count > 0)
            {
                cible.Dispensateurs = new List<ProfessionnelNumEntente>(
                    from dispensateur in source.ColDispProf
                    select Mappeur.Mapper(dispensateur));
            }
            else
            {
                cible.Dispensateurs = new List<ProfessionnelNumEntente>();
            }

            if (source.InfoMsgTrait != null)
            {
                cible.InfoMsgTrait = new List<Message.MsgTrait> {
                    PRE_OutilComun_cpo.MessageTraitement.MapperVersMessageTraitement(source.InfoMsgTrait) };
            }

            return cible;
        }

        /// <summary>
        /// Map un objet de type svcInfoDispCnsul.DispProf en ProfessionnelNumEntente
        /// </summary>
        /// <param name="source"></param>
        /// <remarks></remarks>
        static internal ProfessionnelNumEntente Mapper(svcInfoDispCnsul.DispProf source)
        {

            var professionnelNumEntente = new ProfessionnelNumEntente
            {
                ClasseDispensateur = source.PvcClaDisp,
                CodeRaisonNonAdmissibilite = source.ListePerAdmis.Select(x => x.CodRaisNonAdmis).ToString(),
                DateDebutPeriodeAdmissibilite = Convert.ToDateTime(source.ListePerAdmis.Select(x => x.DDPerAdmis)),
                DateDebutSpecialisation = (DateTime) source.DDSpec,
                DateFinPeriodeAdmissibilite = Convert.ToDateTime(source.ListePerAdmis.Select(x => x.DFPerAdmis)),
                NumeroDispensateur = source.DisNo,
                NumeroSeqDispensateur = source.DisNoSeq,
                NumeroSeqIndividu = source.IndNoSeq,
                StatutAdmissibilite = source.ListePerAdmis.Select(x => x.StaAdmis).ToString()
            };

            return professionnelNumEntente;
        }







        /// <summary>
        /// Map un objet de type ObtenirDispensateursSelonEntenteEntre en svcInfoDispCnsul.ParamObtnProfNoEntenEntree
        /// </summary>
        /// <param name="source">Objet source</param>
        /// <returns>Objet cible</returns>
        static internal svcInfoDispCnsul.ParamObtnNomPreListeDispEntree Mapper(ObtenirNomPrenomListeDispensateursEntree source)
        {
            svcInfoDispCnsul.ParamObtnNomPreListeDispEntree cible = new svcInfoDispCnsul.ParamObtnNomPreListeDispEntree();

            cible.NomPreListeDispEntree = new List<svcInfoDispCnsul.NomPreListeDispEntree>();

            foreach (var dispensateur in source.InfoDispensateurs)
            {
                cible.NomPreListeDispEntree.Add(new svcInfoDispCnsul.NomPreListeDispEntree()
                {
                    DisNoSeq = (dispensateur.NumeroSequentielDispensateur != null ? dispensateur.NumeroSequentielDispensateur.ToString() : null),
                    PvcClaDisp = (dispensateur.NumeroClasse != null ? dispensateur.NumeroClasse.ToString() : null),
                    NoDisp = (dispensateur.NumeroDispensateur != null ? dispensateur.NumeroDispensateur.ToString() : null),
                    IdDisp = dispensateur.Identifiant,
                    TypIdDisp = dispensateur.TypeIdentifiant,
                    DatServ = (dispensateur.DateService != null ? dispensateur.DateService.ToString() : null)
                });
            }

            return cible;
        }

        /// <summary>
        /// Map un objet de type svcInfoDispCnsul.ParamObtnProfNoEntenSorti en ObtenirDispensateursSelonEntenteSorti
        /// </summary>
        /// <param name="source">Objet source</param>
        /// <returns>Objet cible</returns>
        static internal ObtenirNomPrenomListeDispensateursSorti Mapper(svcInfoDispCnsul.ParamObtnNomPreListeDispSortie source)
        {
            ObtenirNomPrenomListeDispensateursSorti cible = new ObtenirNomPrenomListeDispensateursSorti();

            if (source.NomPreListeDispSortie != null && source.NomPreListeDispSortie.Count > 0)
            {
                cible.InfoDispensateurs = new List<NomPrenomDispSorti>(
                    from dispensateur in source.NomPreListeDispSortie
                    select Mappeur.Mapper(dispensateur));
            }
            else
            {
                cible.InfoDispensateurs = new List<NomPrenomDispSorti>();
            }

            if (source.InfoMsgTrait != null)
            {
                cible.InfoMsgTrait = new List<Message.MsgTrait> {
                    PRE_OutilComun_cpo.MessageTraitement.MapperVersMessageTraitement(source.InfoMsgTrait) };
            }

            return cible;
        }

        /// <summary>
        /// Map un objet de type svcInfoDispCnsul.NomPreListeDispSortie en NomPrenomDispSorti
        /// </summary>
        /// <param name="source"></param>
        /// <remarks></remarks>
        static internal NomPrenomDispSorti Mapper(svcInfoDispCnsul.NomPreListeDispSortie source)
        {

            var nomPrenomDisp = new NomPrenomDispSorti
            {
                NumeroClasse = Convert.ToInt32(source.PvcClaDisp),
                Identifiant = source.IdDisp,
                Nom = source.Nom,
                NumeroSequentielDispensateur = Convert.ToInt64(source.DisNoSeq),
                Prenom = source.Pre,
                TypeIdentifiant = source.TypIdDisp
            };

            return nomPrenomDisp;
        }
    }
}
