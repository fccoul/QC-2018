#region Imports
using Oracle.DataAccess.Client;
using RAMQ.AccesDonnees.BDOracle;
using RAMQ.Message;
using RAMQ.PRE.PRE_Entites_cpo.Professionnel.Parametre;
using RAMQ.PRE.PRE_FournAccesDonne_cpo;
using RAMQ.PRE.PRE_SysExt_cpo.FIP.EPZ3.Parametre;
using System;
using System.Data;
using outilCommun = RAMQ.PRE.PRE_OutilComun_cpo;

#endregion

namespace RAMQ.PRE.PRE_SysExt_cpo.FIP.EPZ3
{

    /// <summary> 
    ///  Encapsulation des appels à "EPZ3_InfoDispCnsul"
    /// </summary>
    public class InfoDispCnsul : IInfoDispCnsul
    {

        #region Attributs privées
        
        /// <summary>
        ///  Propriete servant à faire les appels à la base de données.
        /// </summary>
        private IAccesDonnesOra ClientAccesDonnesOra
        {
            get
            {
                return _funcAccesDonnesOra();
            }
        }
        private readonly Func<IAccesDonnesOra> _funcAccesDonnesOra;
        private readonly IResolutionMessage _resolutionMessage;

        #endregion

        #region Constructeur

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <remarks></remarks>
        public InfoDispCnsul()
        {
        }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <remarks></remarks>
        public InfoDispCnsul(Func<IAccesDonnesOra> clientAccesDonnesOra,
                             IResolutionMessage resolutionMessage)
        {
            if (clientAccesDonnesOra == null)
            {
                throw new ArgumentNullException($"Le paramètre : {nameof(clientAccesDonnesOra)} ne peut être null.");
            }
            
            _funcAccesDonnesOra = clientAccesDonnesOra;
            _resolutionMessage = resolutionMessage;
        }

        #endregion

        #region Méthodes publiques

        /// <summary>
        /// Obtenir les informations sur la relation dispensateur individu
        /// </summary>
        /// <param name="intrant">Paramètres d'entrées</param>
        /// <returns>Un objet contenant la liste des informations sur la relation dispensateur/individu</returns>
        /// <remarks>
        /// À cause de la limitation de l'index des tableaux de sortie dans COC2_V4 lorsqu'on passe une classe de paramètres,
        /// les tableaux sont déclarés manuellement et on utilise l'ancienne façon d'appeler Oracle.
        /// </remarks>
        public ObtnRelDispIndivSorti ObtenirRelDispIndiv(ObtnRelDispIndivEntre intrant)
        {

            const int NombreMaximalOccurence = 50000;
            ObtnRelDispIndivSorti extrant = new ObtnRelDispIndivSorti();

            using (ProcOra procOracle = new ProcOra())
            {

                procOracle.Nom = Constantes.FIP.ObtenirRelationDispensateurIndividu;

                //Paramètres de sortie
                procOracle.Ajouter("pVchrCodRetou", OracleDbType.Varchar2, 500, ParameterDirection.Output, null);
                procOracle.AjouterTablo("pTblNoSeqDisp", NombreMaximalOccurence, OracleDbType.Int64, 10, ParameterDirection.Output);
                procOracle.AjouterTablo("pTblNoDisp", NombreMaximalOccurence, OracleDbType.Int32, 5, ParameterDirection.Output);
                procOracle.AjouterTablo("pTblNoSeqIndiv", NombreMaximalOccurence, OracleDbType.Int64, 10, ParameterDirection.Output);
                procOracle.AjouterTablo("pTblNoClaDisp", NombreMaximalOccurence, OracleDbType.Int32, 1, ParameterDirection.Output);
                procOracle.AjouterTablo("pTblTerriPermi", NombreMaximalOccurence, OracleDbType.Varchar2, 2, ParameterDirection.Output);
                procOracle.AjouterTablo("pTblChifrPrvDisp", NombreMaximalOccurence, OracleDbType.Int32, 1, ParameterDirection.Output);
                procOracle.AjouterTablo("pTblCodPrfsn", NombreMaximalOccurence, OracleDbType.Varchar2, 3, ParameterDirection.Output);
                procOracle.AjouterTablo("pTblDcDisp", NombreMaximalOccurence, OracleDbType.Date, 50, ParameterDirection.Output);
                procOracle.AjouterTablo("pTblIdUtilCreatDisp", NombreMaximalOccurence, OracleDbType.Varchar2, 9, ParameterDirection.Output);
                procOracle.AjouterTablo("pTblDatObtenPermiDisp", NombreMaximalOccurence, OracleDbType.Date, 50, ParameterDirection.Output);
                procOracle.AjouterTablo("pTblDatInscrRamqDisp", NombreMaximalOccurence, OracleDbType.Date, 50, ParameterDirection.Output);
                procOracle.AjouterTablo("pTblAnGradDisp", NombreMaximalOccurence, OracleDbType.Int32, 4, ParameterDirection.Output);
                procOracle.AjouterTablo("pTblNoSeqIntvnGrad", NombreMaximalOccurence, OracleDbType.Int64, 10, ParameterDirection.Output);
                procOracle.AjouterTablo("pTblIndDemCouri", NombreMaximalOccurence, OracleDbType.Varchar2, 3, ParameterDirection.Output);
                procOracle.AjouterTablo("pTblIndFactRecen", NombreMaximalOccurence, OracleDbType.Varchar2, 3, ParameterDirection.Output);
                procOracle.AjouterTablo("pTblDatPremSpec", NombreMaximalOccurence, OracleDbType.Date, 50, ParameterDirection.Output);
                procOracle.AjouterTablo("pTblDdPrati", NombreMaximalOccurence, OracleDbType.Date, 50, ParameterDirection.Output);
                procOracle.AjouterTablo("pTblNbrAnHqGenrl", NombreMaximalOccurence, OracleDbType.Decimal, 8, ParameterDirection.Output);
                procOracle.AjouterTablo("pTblNbrAnQcSpec", NombreMaximalOccurence, OracleDbType.Decimal, 8, ParameterDirection.Output);
                procOracle.AjouterTablo("pTblDroitAcqTh", NombreMaximalOccurence, OracleDbType.Varchar2, 3, ParameterDirection.Output);
                procOracle.AjouterTablo("pTblDmDisp", NombreMaximalOccurence, OracleDbType.Date, 50, ParameterDirection.Output);
                procOracle.AjouterTablo("pTblIdUtilMajDisp", NombreMaximalOccurence, OracleDbType.Varchar2, 9, ParameterDirection.Output);
                procOracle.AjouterTablo("pTblNomTronIndiv", NombreMaximalOccurence, OracleDbType.Varchar2, 4, ParameterDirection.Output);
                procOracle.AjouterTablo("pTblPreIndiv", NombreMaximalOccurence, OracleDbType.Varchar2, 20, ParameterDirection.Output);
                procOracle.AjouterTablo("pTblNomIndiv", NombreMaximalOccurence, OracleDbType.Varchar2, 30, ParameterDirection.Output);
                procOracle.AjouterTablo("pTblNasIndiv", NombreMaximalOccurence, OracleDbType.Int32, 9, ParameterDirection.Output);
                procOracle.AjouterTablo("pTblDcIndiv", NombreMaximalOccurence, OracleDbType.Date, 50, ParameterDirection.Output);
                procOracle.AjouterTablo("pTblIdUtilCreatIndiv", NombreMaximalOccurence, OracleDbType.Varchar2, 9, ParameterDirection.Output);
                procOracle.AjouterTablo("pTblLangIndiv", NombreMaximalOccurence, OracleDbType.Varchar2, 3, ParameterDirection.Output);
                procOracle.AjouterTablo("pTblTitreCivltIndiv", NombreMaximalOccurence, OracleDbType.Varchar2, 3, ParameterDirection.Output);
                procOracle.AjouterTablo("pTblSexeIndiv", NombreMaximalOccurence, OracleDbType.Varchar2, 3, ParameterDirection.Output);
                procOracle.AjouterTablo("pTblDatNaissIndiv", NombreMaximalOccurence, OracleDbType.Date, 50, ParameterDirection.Output);
                procOracle.AjouterTablo("pTblNomNaissIndiv", NombreMaximalOccurence, OracleDbType.Varchar2, 30, ParameterDirection.Output);
                procOracle.AjouterTablo("pTblStaCivilIndiv", NombreMaximalOccurence, OracleDbType.Varchar2, 3, ParameterDirection.Output);
                procOracle.AjouterTablo("pTblDatDecesIndiv", NombreMaximalOccurence, OracleDbType.Date, 50, ParameterDirection.Output);
                procOracle.AjouterTablo("pTblDmIndiv", NombreMaximalOccurence, OracleDbType.Date, 50, ParameterDirection.Output);
                procOracle.AjouterTablo("pTblIdUtilMajIndiv", NombreMaximalOccurence, OracleDbType.Varchar2, 9, ParameterDirection.Output);

                //Paramètres en entrée
                procOracle.Ajouter("pNumPvcClaDisp", OracleDbType.Int32, 1, ParameterDirection.Input, intrant.NumeroClasseDispensateur);
                procOracle.Ajouter("pNumDisNo", OracleDbType.Int32, 5, ParameterDirection.Input, intrant.NumeroDispensateur);
                procOracle.Ajouter("pNumDisNoSeq", OracleDbType.Int64, 10, ParameterDirection.Input, intrant.NumeroSequentielDispensateur);
                procOracle.Ajouter("pNumIndNoSeq", OracleDbType.Int64, 10, ParameterDirection.Input, intrant.NumeroSequentielIndividu);
                procOracle.Ajouter("pDatDatServ", OracleDbType.Date, ParameterDirection.Input, intrant.DateService);

                ClientAccesDonnesOra.Odp.InitialiserProc(procOracle);
                ClientAccesDonnesOra.Odp.ExecuterProc();
            }

            extrant = Utilitaire.Mappeur.Mapper(ClientAccesDonnesOra);
            
            if (extrant.NumerosSequentielDispensateur.Count == 0)
            {
                extrant.InfoMsgTrait.Add(new MsgTrait(_resolutionMessage,
                                                      outilCommun.Constantes.CodeApplication,
                                                      outilCommun.Constantes.CodeRetour.E_149062_NumeroPratiqueSaisieInexistant,
                                                      new string[] { }));
            }
            return extrant;
        }

        /// <summary>
        /// Permet d'obtenir les périodes de pratique d'un professionnel
        /// </summary>
        /// <param name="intrant">Pramètres d'entrées</param>
        /// <returns>Un objet contenant la liste des périodes de pratique d'un professionnel</returns>
        /// <remarks></remarks>
        public ObtenirPeriodePratiqueProfessionnelSorti ObtenirPeriodePratiqueProfessionnel(ObtenirPeriodePratiqueProfessionnelEntre intrant)
        {          
            //TODO: trouver une façon d'enlever le new en passant quand même les paramètres du FIP et non de PRE  
            return new AccesDonne(_funcAccesDonnesOra,
                                  Constantes.FIP.CodeApplication,
                                  Constantes.FIP.ErreurImprevu).ExecuterProcedure<ObtenirPeriodePratiqueProfessionnelEntre,
                                                                                  ObtenirPeriodePratiqueProfessionnelSorti>
                                  (intrant, Constantes.FIP.ObtenirPeriodePratiqueProfessionnel);
        }

        /// <summary>
        /// Permet d'obtenir les information sur l'admissibilité d'un professionnel à facturer
        /// </summary>
        /// <param name="intrant">Paramètre d'entrées</param>
        /// <returns>Un objet contenant les informations d'admissibilité</returns>
        /// <remarks></remarks>
        public VerifierAdmissibiliteProfessionnelFacturerSorti VerifierAdmissibiliteProfessionnel(VerifierAdmissibiliteProfessionnelFacturerEntre intrant)
        {
            svcInfoDispCnsul.ParamDeterminerAdmisFactuDispSortie extrantEPZ3 = new svcInfoDispCnsul.ParamDeterminerAdmisFactuDispSortie();
            svcInfoDispCnsul.ParamDeterminerAdmisFactuDispEntre intrantEPZ3 = new svcInfoDispCnsul.ParamDeterminerAdmisFactuDispEntre();
            VerifierAdmissibiliteProfessionnelFacturerSorti extrant = new VerifierAdmissibiliteProfessionnelFacturerSorti();

            intrantEPZ3 = Utilitaire.Mappeur.Mapper(intrant);

            extrantEPZ3 = outilCommun.UtilitaireService.AppelerService<svcInfoDispCnsul.InfoDispCnsulSoap,
                                                                       svcInfoDispCnsul.InfoDispCnsulSoapClient,
                                                                       svcInfoDispCnsul.ParamDeterminerAdmisFactuDispSortie>
                                                                       (x => x.DeterminerAdmisFactuDisp(intrantEPZ3));

            extrant = Utilitaire.Mappeur.Mapper(extrantEPZ3);

            return extrant;
        }

        /// <summary>
        /// Permet d'obtenir les dispensateurs selon un numéro d'entente
        /// </summary>
        /// <param name="intrant">Paramètre d'entrées</param>
        /// <returns>Un objet contenant les informations des dispensateurs</returns>
        public ObtenirDispensateursSelonEntenteSorti ObtenirDispensateursSelonEntente(ObtenirDispensateursSelonEntenteEntre intrant)
        {
            svcInfoDispCnsul.ParamObtnProfNoEntenEntree intrantEPZ3 = new svcInfoDispCnsul.ParamObtnProfNoEntenEntree();
            svcInfoDispCnsul.ParamObtnProfNoEntenSorti extrantEPZ3 = new svcInfoDispCnsul.ParamObtnProfNoEntenSorti();
            ObtenirDispensateursSelonEntenteSorti extrant = new ObtenirDispensateursSelonEntenteSorti();

            intrantEPZ3 = Utilitaire.Mappeur.Mapper(intrant);

            extrantEPZ3 = outilCommun.UtilitaireService.AppelerService<svcInfoDispCnsul.InfoDispCnsulSoap,
                                                                       svcInfoDispCnsul.InfoDispCnsulSoapClient,
                                                                       svcInfoDispCnsul.ParamObtnProfNoEntenSorti>
                                                                       (x => x.ObtenirProfNoEnten(intrantEPZ3));

            extrant = Utilitaire.Mappeur.Mapper(extrantEPZ3);

            return extrant;
        }

        /// <summary>
        /// Permet d'obtenir les noms et prenoms d'une liste de dispensateurs
        /// </summary>
        /// <param name="intrant">Paramètre d'entrées</param>
        /// <returns>Un objet contenant les informations des dispensateurs</returns>
        public ObtenirNomPrenomListeDispensateursSorti ObtenirNomPrenomListeDispensateur(ObtenirNomPrenomListeDispensateursEntree intrant)
        {
            svcInfoDispCnsul.ParamObtnNomPreListeDispEntree intrantEPZ3 = new svcInfoDispCnsul.ParamObtnNomPreListeDispEntree();
            svcInfoDispCnsul.ParamObtnNomPreListeDispSortie extrantEPZ3 = new svcInfoDispCnsul.ParamObtnNomPreListeDispSortie();
            ObtenirNomPrenomListeDispensateursSorti extrant = new ObtenirNomPrenomListeDispensateursSorti();

            intrantEPZ3 = Utilitaire.Mappeur.Mapper(intrant);

            extrantEPZ3 = outilCommun.UtilitaireService.AppelerService<svcInfoDispCnsul.InfoDispCnsulSoap,
                                                                       svcInfoDispCnsul.InfoDispCnsulSoapClient,
                                                                       svcInfoDispCnsul.ParamObtnNomPreListeDispSortie>
                                                                       (x => x.ObtenirNomPreListeDisp(intrantEPZ3));

            extrant = Utilitaire.Mappeur.Mapper(extrantEPZ3);

            return extrant;
        }

        /// <summary>
        /// Obtenir les informations personnelles sur un dispensateur
        /// </summary>
        /// <param name="intrant">Paramètres d'entrées</param>
        /// <returns>Un objet contenant la liste des informations personnelles d'un dispensateur</returns>
        /// <remarks></remarks>
        public ObtenirInfoPerslDispSorti ObtenirInfoPerslDisp(ObtenirInfoPerslDispEntre intrant)
        {
            return new AccesDonne(_funcAccesDonnesOra,
                                  Constantes.FIP.CodeApplication,
                                  Constantes.FIP.ErreurImprevu).ExecuterProcedure<ObtenirInfoPerslDispEntre,
                                                                                  ObtenirInfoPerslDispSorti>
                                  (intrant, Constantes.FIP.ObtenirInfoPersonnellesDispensateur);
        }

        #endregion

    }
}
