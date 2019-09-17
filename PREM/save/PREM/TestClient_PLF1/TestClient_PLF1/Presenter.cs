using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

using TestClient_PLF1.ServiceReference1;

namespace TestClient_PLF1
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// </remarks>
	public class Presenter
    {
        ServiceReference1.ServTraitEveneAutreSysClient _proxy;
        public Presenter()
        {
            _proxy= new ServiceReference1.ServTraitEveneAutreSysClient();
        }

        public string Call_AjusterEngagAjouNonPartn()
        {
            ClassUser cu = new ClassUser();
            string test = cu.Pwd;
            string msg = string.Empty;
            try
            {
                #region - OK
                /*
                PerAdmis nouvPer = new PerAdmis
                {
                    //Dd = new DateTime(2018,4, 20),
                    // Dd = new DateTime(2018,6, 25),
                    //Dd = new DateTime(2018,6,5),
                    // Dd = new DateTime(2018,6,6),
                    Dd = new DateTime(2018, 4, 10),
                    Statut ="NA",
                    CodRaisNonAdmis= "NPAR"
                };
                AjusEngagAjouNonPartnEntre ajusEngagAjouNonPartnEntre = new AjusEngagAjouNonPartnEntre();
                ajusEngagAjouNonPartnEntre.NoSeqIntervenant = 7004;//7964;//13253;//14989;//13138;//14989;//10378;                
                ajusEngagAjouNonPartnEntre.NouvPerAdmis=nouvPer;
                ajusEngagAjouNonPartnEntre.TypeIntervenant = "DIS";
                ajusEngagAjouNonPartnEntre.NoSeqPerAdmis = 1;
                //ajusEngagAjouNonPartnEntre.DmAdmis = new DateTime(2018, 6, 28);
                //ajusEngagAjouNonPartnEntre.DmAdmis = new DateTime(2018, 7, 5);
                ajusEngagAjouNonPartnEntre.DmAdmis = new DateTime(2018, 7, 6);
                
                */
                #endregion

                #region case 1
                /*
                PerAdmis nouvPer = new PerAdmis
                {

                    Dd = new DateTime(2018, 7, 24),
                    Statut = "NA",
                    CodRaisNonAdmis = "NPAR"
                };
                AjusEngagAjouNonPartnEntre ajusEngagAjouNonPartnEntre = new AjusEngagAjouNonPartnEntre();
                ajusEngagAjouNonPartnEntre.NoSeqIntervenant = 72853;
                ajusEngagAjouNonPartnEntre.NouvPerAdmis = nouvPer;
                ajusEngagAjouNonPartnEntre.TypeIntervenant = "DIS";
                ajusEngagAjouNonPartnEntre.NoSeqPerAdmis = 1;

                ajusEngagAjouNonPartnEntre.DmAdmis = new DateTime(2018, 5, 24);
                */
                #endregion

                #region case 2
                /*
                PerAdmis nouvPer = new PerAdmis
                {
                    
                    Dd = new DateTime(2018, 7, 23),
                    Statut = "NA",
                    CodRaisNonAdmis = "NPAR"
                };
                AjusEngagAjouNonPartnEntre ajusEngagAjouNonPartnEntre = new AjusEngagAjouNonPartnEntre();
                ajusEngagAjouNonPartnEntre.NoSeqIntervenant = 64552;             
                ajusEngagAjouNonPartnEntre.NouvPerAdmis = nouvPer;
                ajusEngagAjouNonPartnEntre.TypeIntervenant = "DIS";
                ajusEngagAjouNonPartnEntre.NoSeqPerAdmis = 1;
                
                ajusEngagAjouNonPartnEntre.DmAdmis = new DateTime(2018, 7,23);
                */
                #endregion

                #region case 3
                /*
                PerAdmis nouvPer = new PerAdmis
                {

                    Dd = new DateTime(2018, 7, 18),
                    Statut = "NA",
                    CodRaisNonAdmis = "NPAR"
                };
                AjusEngagAjouNonPartnEntre ajusEngagAjouNonPartnEntre = new AjusEngagAjouNonPartnEntre();
                ajusEngagAjouNonPartnEntre.NoSeqIntervenant = 72853;
                ajusEngagAjouNonPartnEntre.NouvPerAdmis = nouvPer;
                ajusEngagAjouNonPartnEntre.TypeIntervenant = "DIS";
                ajusEngagAjouNonPartnEntre.NoSeqPerAdmis = 1;

                ajusEngagAjouNonPartnEntre.DmAdmis = new DateTime(2018, 5, 24);
                */
                #endregion

            
                //----------------------

                PerAdmis nouvPer = new PerAdmis
                {
                 
                    Dd = new DateTime(2014, 7, 20),
                    Statut = "NA",
                    CodRaisNonAdmis = "NPAR"
                };
                AjusEngagAjouNonPartnEntre ajusEngagAjouNonPartnEntre = new AjusEngagAjouNonPartnEntre();
                ajusEngagAjouNonPartnEntre.NoSeqIntervenant = 87755;//7964;//13253;//14989;//13138;//14989;//10378;                
                ajusEngagAjouNonPartnEntre.NouvPerAdmis = nouvPer;
                ajusEngagAjouNonPartnEntre.TypeIntervenant = "DIS";
                ajusEngagAjouNonPartnEntre.NoSeqPerAdmis = 1;
                //ajusEngagAjouNonPartnEntre.DmAdmis = new DateTime(2018, 6, 28);
                //ajusEngagAjouNonPartnEntre.DmAdmis = new DateTime(2018, 7, 5);
                ajusEngagAjouNonPartnEntre.DmAdmis = new DateTime(2018, 7, 6);
           
                

                ((ClientCredentials)_proxy.ClientCredentials).Windows.AllowedImpersonationLevel = TokenImpersonationLevel.Impersonation;                           
                var res = _proxy.AjusterEngagAjouNonPartn(ajusEngagAjouNonPartnEntre);

              // msg = !res.InfoMsgTrait.Any() ? "OK-Traitement terminé avec succès !" : string.Join(", ", res.InfoMsgTrait.ToArray());
                msg = !res.InfoMsgTrait.Any() ? "OK-Traitement terminé avec succès !" : string.Join(", ", ((MsgTrait) res.InfoMsgTrait[0]).TxtMsgFran);
                 
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                //throw;
            }
            return msg;
        }

        public string Call_AjusterEngagModifNonPartn()
        {
            ClassUser cu = new ClassUser();
            string test = cu.Pwd;
            string msg = string.Empty;
            try
            {

                #region case 0
                /*
                PerAdmis perAmisModif = new PerAdmis
                {

                    Dd = new DateTime(2018, 3, 22),
                    Statut = "NA",
                    CodRaisNonAdmis = "NPAR"
                };

                PerAdmis perAmisOrigin= new PerAdmis
                {

                    Dd = new DateTime(2018, 2, 20),
                    Statut = "NA",
                    CodRaisNonAdmis = "NPAR"
                };

                AjusEngagModifNonPartnEntre ajusEngagAjouNonPartnEntre = new AjusEngagModifNonPartnEntre();
                ajusEngagAjouNonPartnEntre.NoSeqIntervenant = 6624;    
                ajusEngagAjouNonPartnEntre.PerAdmisModif = perAmisModif;
                ajusEngagAjouNonPartnEntre.PerAdmisOrign = perAmisOrigin;
                ajusEngagAjouNonPartnEntre.TypeIntervenant = "DIS";
                ajusEngagAjouNonPartnEntre.NoSeqPerAdmis = 1;             
                ajusEngagAjouNonPartnEntre.DmAdmis = new DateTime(2018, 7, 16);
                */

                #endregion

                #region case 1
                /*
               PerAdmis perAmisModif = new PerAdmis
               {

                   Dd = new DateTime(2018, 7, 22),
                   Statut = "NA",
                   CodRaisNonAdmis = "NPAR"
               };

               PerAdmis perAmisOrigin = new PerAdmis
               {

                   Dd = new DateTime(2018, 7, 10),
                   Statut = "NA",
                   CodRaisNonAdmis = "NPAR"
               };

               AjusEngagModifNonPartnEntre ajusEngagAjouNonPartnEntre = new AjusEngagModifNonPartnEntre();
               ajusEngagAjouNonPartnEntre.NoSeqIntervenant = 4973;
               ajusEngagAjouNonPartnEntre.PerAdmisModif = perAmisModif;
               ajusEngagAjouNonPartnEntre.PerAdmisOrign = perAmisOrigin;
               ajusEngagAjouNonPartnEntre.TypeIntervenant = "DIS";
               ajusEngagAjouNonPartnEntre.NoSeqPerAdmis = 1;
               ajusEngagAjouNonPartnEntre.DmAdmis = new DateTime(2018, 7, 23);
               */

                #endregion

                #region case 2
                /*
                PerAdmis perAmisModif = new PerAdmis
                {

                    Dd = new DateTime(2016, 12, 24),
                    Statut = "NA",
                    CodRaisNonAdmis = "NPAR"
                };

                PerAdmis perAmisOrigin = new PerAdmis
                {

                    Dd = new DateTime(2014, 07, 20),
                    Statut = "NA",
                    CodRaisNonAdmis = "NPAR"
                };

                AjusEngagModifNonPartnEntre ajusEngagAjouNonPartnEntre = new AjusEngagModifNonPartnEntre();
                ajusEngagAjouNonPartnEntre.NoSeqIntervenant = 87755;
                ajusEngagAjouNonPartnEntre.PerAdmisModif = perAmisModif;
                ajusEngagAjouNonPartnEntre.PerAdmisOrign = perAmisOrigin;
                ajusEngagAjouNonPartnEntre.TypeIntervenant = "DIS";
                ajusEngagAjouNonPartnEntre.NoSeqPerAdmis = 1;
                ajusEngagAjouNonPartnEntre.DmAdmis = new DateTime(2018, 7, 23);
                */
                #endregion

                #region case 3
                PerAdmis perAmisModif = new PerAdmis
                {

                    Dd = new DateTime(2018, 8, 10),
                    Statut = "NA",
                    CodRaisNonAdmis = "NPAR"
                };

                PerAdmis perAmisOrigin = new PerAdmis
                {

                    Dd = new DateTime(2018, 07, 1),
                    Statut = "NA",
                    CodRaisNonAdmis = "NPAR"
                };

                AjusEngagModifNonPartnEntre ajusEngagAjouNonPartnEntre = new AjusEngagModifNonPartnEntre();
                ajusEngagAjouNonPartnEntre.NoSeqIntervenant = 13262;
                ajusEngagAjouNonPartnEntre.PerAdmisModif = perAmisModif;
                ajusEngagAjouNonPartnEntre.PerAdmisOrign = perAmisOrigin;
                ajusEngagAjouNonPartnEntre.TypeIntervenant = "DIS";
                ajusEngagAjouNonPartnEntre.NoSeqPerAdmis = 1;
                ajusEngagAjouNonPartnEntre.DmAdmis = new DateTime(2018, 8, 8);
                #endregion

                ((ClientCredentials)_proxy.ClientCredentials).Windows.AllowedImpersonationLevel = TokenImpersonationLevel.Impersonation;
                var res = _proxy.AjusterEngagModifNonPartn(ajusEngagAjouNonPartnEntre);

               
                msg = !res.InfoMsgTrait.Any() ? "OK-Traitement terminé avec succès !" : string.Join(", ", ((MsgTrait)res.InfoMsgTrait[0]).TxtMsgFran);

            }
            catch (Exception ex)
            {
                msg = ex.Message;
                //throw;
            }
            return msg;
        }
        public string Call_DecesNonPartn()
        {
            
            string msg = string.Empty;
            try
            {
 
                AjusEngagDecesEntre ajusEngagDecesEntre = new AjusEngagDecesEntre();
                #region old
                /*
                Individu infoDispModif = new Individu
                {
                    //DateDeces = new DateTime(2018, 5, 1),
                    //Dc = new DateTime(1990, 1, 1),
                    //Dm = new DateTime(2018, 6, 26),
                    //IdUtilCreat = "test",
                    //IdUtilMaj = "test",
                    Langue = "FRA",
                    NoSeq = 6127,
                    Sexe = "MAS",
                    //StatutCivil = "1",
                    TitreCivilite = "DR"
                };

                Individu infoDispOrig = new Individu
                {
                    //Dc = new DateTime(1990, 1, 1),
                    // Dm = new DateTime(1990, 1, 1),
                    DateDeces = new DateTime(2018,7,1),
                    //IdUtilCreat = "test",
                    //IdUtilMaj = "test",
                    Langue = "FRA",
                    NoSeq = 6127,
                    Sexe = "MAS",
                    //StatutCivil="1",
                    TitreCivilite = "DR"
                };
                */
                #endregion

                #region case 1
                /*
                Individu infoDispModif = new Individu
                {                     
                    Langue = "FRA",
                    NoSeq = 58158,
                    Sexe = "MAS",                    
                    TitreCivilite = "DR"
                };

                Individu infoDispOrig = new Individu
                {
                    
                    DateDeces = new DateTime(2018, 5, 1),                   
                    Langue = "FRA",
                    NoSeq = 58158,
                    Sexe = "MAS",                    
                    TitreCivilite = "DR"
                };
                */
                #endregion

                #region case 2 -Annulation date deces
                /*
                Individu infoDispModif = new Individu
                {
                    Langue = "FRA",
                    NoSeq = 13327,
                    Sexe = "MAS",
                    TitreCivilite = "DR"
                };

                Individu infoDispOrig = new Individu
                {

                    DateDeces = new DateTime(2018, 5, 1),
                    Langue = "FRA",
                    NoSeq = 13327,
                    Sexe = "MAS",
                    TitreCivilite = "DR"
                };
                */
                #endregion

                #region - annulation courriel -engagement actif
                /*
                Individu infoDispModif = new Individu
                {
                    Langue = "FRA",
                    NoSeq = 28005,
                    Sexe = "MAS",
                    TitreCivilite = "DR"
                };

                Individu infoDispOrig = new Individu
                {

                    DateDeces = new DateTime(2018, 4, 1),
                    Langue = "FRA",
                    NoSeq = 28005,
                    Sexe = "MAS",
                    TitreCivilite = "DR"
                };
                */
                #endregion

                #region - case bug#21
                
                Individu infoDispModif = new Individu
                {
                    DateDeces = new DateTime(2018, 3, 3),
                    Langue = "FRA",
                    NoSeq = 3014,
                    Sexe = "MAS",
                    TitreCivilite = "DR"
                };

                Individu infoDispOrig = new Individu
                {

                    //DateDeces = new DateTime(2018, 4, 1),
                    Langue = "FRA",
                    NoSeq = 3014,
                    Sexe = "MAS",
                    TitreCivilite = "DR"
                };
                
                #endregion

                ajusEngagDecesEntre.InfoOrignIndiv = infoDispOrig;
                ajusEngagDecesEntre.InfoModifIndiv = infoDispModif;       


                ((ClientCredentials)_proxy.ClientCredentials).Windows.AllowedImpersonationLevel = TokenImpersonationLevel.Impersonation;


                var res = _proxy.AjusterEngagDeces(ajusEngagDecesEntre);

                //msg = !res.InfoMsgTrait.Any() ? "OK-Traitement terminé avec succès !" : string.Join(", ", res.InfoMsgTrait.ToArray());
                msg = !res.InfoMsgTrait.Any() ? "OK-Traitement terminé avec succès !" : string.Join(", ", ((MsgTrait)res.InfoMsgTrait[0]).TxtMsgFran);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                //throw;
            }
            return msg;
        }

    

        public string Call_SepcialiteNonPartn()
        {

            string msg = string.Empty;
            try
            {

                #region case
                /*
                AjusEngagDdSpecInscrEntre ajusEngagDdSpecInscrEntre = new AjusEngagDdSpecInscrEntre();
                Dispensateur infoDispModif = new Dispensateur
                {
                    AnneeGraduation = 1943,
                    ChiffrePreuve = 3,
                    Classe = 1,
                    DateInscriptionRAMQ = null,//new DateTime(2007, 7, 8),
                    DateObtentionPermis = new DateTime(1970, 11, 1),
                    Dc = null,//new DateTime(2001, 6, 29),
                    //DdPratique = new DateTime(2001, 7, 1),
                    DdPratique = new DateTime(1970, 11, 1),
                    //DdSpecialite=new DateTime(2017,8,1),
                    //DdSpecialite = new DateTime(2018, 5, 3),// new DateTime(2018,5,10),
                    DdSpecialite = new DateTime(2018, 7, 15),// new DateTime(2018,5,10),
                    IdUtilCreat = "MOI",
                    IndEnvoiCourrier="NON",
                    IndFacturationRecente="NON",
                    NoSeq = 1899,//62047,
                    NoSeqIndiv = 1899,//58385,
                    NoSeqUniversite= 5075,//5085,
                    NombreAnPratiqueHq =0,//1,
                    Numero= 46058,//1111,
                    Profession ="MED",
                    TerritoirePermis="QC" 
                };

                Dispensateur infoDispOrig = new Dispensateur
                {
                    AnneeGraduation = 1943,//1999,
                    ChiffrePreuve = 3,
                    Classe = 1,
                    DateInscriptionRAMQ = null,//new DateTime(2007, 7, 8),
                    //DateObtentionPermis = new DateTime(2001, 7, 1),
                    DateObtentionPermis = new DateTime(1970, 11, 1),
                    Dc = null,//new DateTime(2001, 6, 29),
                    //DdPratique = new DateTime(2001, 7, 1),
                    DdPratique = new DateTime(1970, 11, 1),
                    DdSpecialite = new DateTime(2018, 6, 1),
                    IdUtilCreat = "",
                    IndEnvoiCourrier = "NON",
                    IndFacturationRecente = "NON",
                    NoSeq = 1899,//62047,
                    NoSeqIndiv = 1899,//58385,
                    NoSeqUniversite = 5075,//5085,
                    //NombreAnPratiqueHq = 1,
                    NombreAnPratiqueHq = 0,
                    Numero = 46058,//1111,
                    Profession = "MED",
                    TerritoirePermis = "QC"
                };
                */
                #endregion

                #region case 1 - avec modification date 1ere specilaite
                /*
                AjusEngagDdSpecInscrEntre ajusEngagDdSpecInscrEntre = new AjusEngagDdSpecInscrEntre();
                Dispensateur infoDispModif = new Dispensateur
                {
                     
                    ChiffrePreuve = 3,
                    Classe = 1,                           
                    DdSpecialite = new DateTime(2018, 7, 25),                    
                    NoSeq = 6680,
                    NoSeqIndiv = 6680,                    
                    NombreAnPratiqueHq = 0,
                    Numero = 66100
                   
                };

                Dispensateur infoDispOrig = new Dispensateur
                {
                    
                    ChiffrePreuve = 3,
                    Classe = 1,                  
                  
                    DdSpecialite = new DateTime(2018, 3, 30),
                   
                    NoSeq = 6680,
                    NoSeqIndiv = 6680,
                    //NoSeqUniversite = 5075,                    
                    Numero = 66100
                   
                };
                */
                #endregion

                #region case 2 - envoi courriel -engagement actif
                AjusEngagDdSpecInscrEntre ajusEngagDdSpecInscrEntre = new AjusEngagDdSpecInscrEntre();
                Dispensateur infoDispModif = new Dispensateur
                {

                    ChiffrePreuve = 0,
                    Classe = 0,
                    DdSpecialite = new DateTime(2018, 7, 25),
                    NoSeq = 17565,
                    NoSeqIndiv = 17565,
                    NombreAnPratiqueHq = 1,
                    Numero = 84195

                };

                Dispensateur infoDispOrig = new Dispensateur
                {

                    ChiffrePreuve = 0,
                    Classe = 0,

                    DdSpecialite = new DateTime(2018, 1, 1),

                    NoSeq = 17565,
                    NoSeqIndiv = 17565,
                    //NoSeqUniversite = 5075,                    
                    Numero = 84195

                };
                #endregion

                ajusEngagDdSpecInscrEntre.InfoDispOrign = infoDispOrig;
                ajusEngagDdSpecInscrEntre.InfoDispModif = infoDispModif;

                ((ClientCredentials)_proxy.ClientCredentials).Windows.AllowedImpersonationLevel = TokenImpersonationLevel.Impersonation;

                var res = _proxy.AjusterEngagDdSpecInscr(ajusEngagDdSpecInscrEntre);

                //msg = !res.InfoMsgTrait.Any() ? "OK-Traitement terminé avec succès !" : string.Join(", ", res.InfoMsgTrait.ToArray());
                msg = !res.InfoMsgTrait.Any() ? "OK-Traitement terminé avec succès !" : string.Join(", ", ((MsgTrait)res.InfoMsgTrait[0]).TxtMsgFran);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                //throw;
            }
            return msg;
        }

       


        public string Call_AjusterEngagAnnuleNonPartn()
        {
            ClassUser cu = new ClassUser();
            string test = cu.Pwd;
            string msg = string.Empty;
            try
            {

                #region cas simple
                /*
                PerAdmis perAdmiAnnu = new PerAdmis
                {

                    Dd = new DateTime(2018, 4, 20),
                    Statut = "NA",
                    CodRaisNonAdmis = "NPAR"
                };
                AjusEngagAnnuNonPartnEntre ajusEngagAnuuNonPartnEntre = new AjusEngagAnnuNonPartnEntre();
                ajusEngagAnuuNonPartnEntre.NoSeqIntervenant = 14989;
                ajusEngagAnuuNonPartnEntre.NoSeqPerAdmis = 1;
                ajusEngagAnuuNonPartnEntre.DmAdmis = new DateTime(2018, 7, 10);
                ajusEngagAnuuNonPartnEntre.TypeIntervenant = "DIS";
                ajusEngagAnuuNonPartnEntre.PerAdmisAnnu = perAdmiAnnu;
                */
                #endregion

                #region others
                /*
                PerAdmis perAdmiAnnu = new PerAdmis
                {

                    Dd = new DateTime(2018, 3, 10),
                    //Dd = new DateTime(2018, 10, 13),
                    //Dd = new DateTime(2018, 4, 20),
                    //Dd = new DateTime(2018, 5, 11),               
                    Statut = "NA",
                    CodRaisNonAdmis = "NPAR"
                };
                AjusEngagAnnuNonPartnEntre ajusEngagAnuuNonPartnEntre = new AjusEngagAnnuNonPartnEntre();
                ajusEngagAnuuNonPartnEntre.NoSeqIntervenant = 6106;//1899;//14989;//85306;// 6106;
                ajusEngagAnuuNonPartnEntre.NoSeqPerAdmis = 1;
                ajusEngagAnuuNonPartnEntre.DmAdmis = new DateTime(2018, 7, 10);
                ajusEngagAnuuNonPartnEntre.TypeIntervenant = "DIS";
                ajusEngagAnuuNonPartnEntre.PerAdmisAnnu = perAdmiAnnu;
                */
                #endregion
                
                #region case 1
                /*
                PerAdmis perAdmiAnnu = new PerAdmis
                {
                 
                    Dd = new DateTime(2018, 5, 10),
                    
                    Statut="NA",
                    CodRaisNonAdmis="NPAR"
                };
                AjusEngagAnnuNonPartnEntre ajusEngagAnuuNonPartnEntre = new AjusEngagAnnuNonPartnEntre();
                ajusEngagAnuuNonPartnEntre.NoSeqIntervenant = 10316; 
                ajusEngagAnuuNonPartnEntre.NoSeqPerAdmis = 1;
                 
                ajusEngagAnuuNonPartnEntre.DmAdmis = new DateTime(2018, 7, 10);
                ajusEngagAnuuNonPartnEntre.TypeIntervenant = "DIS";
                ajusEngagAnuuNonPartnEntre.PerAdmisAnnu = perAdmiAnnu;
                */
                #endregion

                #region case 2 

                //-dispensatieur num:167110
                /*
                PerAdmis perAdmiAnnu = new PerAdmis
                {

                    Dd = new DateTime(2018, 4, 20),

                    Statut = "NA",
                    CodRaisNonAdmis = "NPAR"
                };
                AjusEngagAnnuNonPartnEntre ajusEngagAnuuNonPartnEntre = new AjusEngagAnnuNonPartnEntre();
                ajusEngagAnuuNonPartnEntre.NoSeqIntervenant = 14989;
                ajusEngagAnuuNonPartnEntre.NoSeqPerAdmis = 1;

                ajusEngagAnuuNonPartnEntre.DmAdmis = new DateTime(2018, 7, 5);
                ajusEngagAnuuNonPartnEntre.TypeIntervenant = "DIS";
                ajusEngagAnuuNonPartnEntre.PerAdmisAnnu = perAdmiAnnu;
                */
                #endregion

                #region case 3
                /*
                PerAdmis perAdmiAnnu = new PerAdmis
                {

                    Dd = new DateTime(2018, 3, 1),

                    Statut = "NA",
                    CodRaisNonAdmis = "NPAR"
                };
                AjusEngagAnnuNonPartnEntre ajusEngagAnuuNonPartnEntre = new AjusEngagAnnuNonPartnEntre();
                ajusEngagAnuuNonPartnEntre.NoSeqIntervenant = 14963;
                ajusEngagAnuuNonPartnEntre.NoSeqPerAdmis = 1;
                ajusEngagAnuuNonPartnEntre.DmAdmis = new DateTime(2018, 7, 12);
                ajusEngagAnuuNonPartnEntre.TypeIntervenant = "DIS";
                ajusEngagAnuuNonPartnEntre.PerAdmisAnnu = perAdmiAnnu;
                */

                #endregion

                #region case 4
                /*
                PerAdmis perAdmiAnnu = new PerAdmis
                {

                    Dd = new DateTime(2018, 6, 20),

                    Statut = "NA",
                    CodRaisNonAdmis = "NPAR"
                };
                AjusEngagAnnuNonPartnEntre ajusEngagAnuuNonPartnEntre = new AjusEngagAnnuNonPartnEntre();
                ajusEngagAnuuNonPartnEntre.NoSeqIntervenant = 10843;
                ajusEngagAnuuNonPartnEntre.NoSeqPerAdmis = 1;
                ajusEngagAnuuNonPartnEntre.DmAdmis = new DateTime(2018, 7, 12);
                ajusEngagAnuuNonPartnEntre.TypeIntervenant = "DIS";
                ajusEngagAnuuNonPartnEntre.PerAdmisAnnu = perAdmiAnnu;
                */
                #endregion

                #region case 5 - courriel 
                /* date deces apres date NP*/
                /*
                PerAdmis perAdmiAnnu = new PerAdmis
                {

                    Dd = new DateTime(2018, 3, 13),

                    Statut = "NA",
                    CodRaisNonAdmis = "NPAR"
                };
                AjusEngagAnnuNonPartnEntre ajusEngagAnuuNonPartnEntre = new AjusEngagAnnuNonPartnEntre();
                ajusEngagAnuuNonPartnEntre.NoSeqIntervenant = 17445;
                ajusEngagAnuuNonPartnEntre.NoSeqPerAdmis = 1;
                ajusEngagAnuuNonPartnEntre.DmAdmis = new DateTime(2018, 7, 13);
                ajusEngagAnuuNonPartnEntre.TypeIntervenant = "DIS";
                ajusEngagAnuuNonPartnEntre.PerAdmisAnnu = perAdmiAnnu;
                */

                /* date deces avant date NP*/

                #endregion

                #region case 6  - avis(1) Annul et derogation
                /*
                PerAdmis perAdmiAnnu = new PerAdmis
                {

                    Dd = new DateTime(2018, 3, 13),

                    Statut = "NA",
                    CodRaisNonAdmis = "NPAR"
                };
                AjusEngagAnnuNonPartnEntre ajusEngagAnuuNonPartnEntre = new AjusEngagAnnuNonPartnEntre();
                ajusEngagAnuuNonPartnEntre.NoSeqIntervenant = 12411;
                ajusEngagAnuuNonPartnEntre.NoSeqPerAdmis = 1;
                ajusEngagAnuuNonPartnEntre.DmAdmis = new DateTime(2018, 7, 13);
                ajusEngagAnuuNonPartnEntre.TypeIntervenant = "DIS";
                ajusEngagAnuuNonPartnEntre.PerAdmisAnnu = perAdmiAnnu;
                */
                #endregion

                #region case 7 ..envoi mail
                /*
                PerAdmis perAdmiAnnu = new PerAdmis
                {

                    Dd = new DateTime(2018, 6, 22),

                    Statut = "NA",
                    CodRaisNonAdmis = "NPAR"
                };
                AjusEngagAnnuNonPartnEntre ajusEngagAnuuNonPartnEntre = new AjusEngagAnnuNonPartnEntre();
                ajusEngagAnuuNonPartnEntre.NoSeqIntervenant = 17445;
                ajusEngagAnuuNonPartnEntre.NoSeqPerAdmis = 1;
                ajusEngagAnuuNonPartnEntre.DmAdmis = new DateTime(2018, 7, 11);
                ajusEngagAnuuNonPartnEntre.TypeIntervenant = "DIS";
                ajusEngagAnuuNonPartnEntre.PerAdmisAnnu = perAdmiAnnu;
                */
                #endregion

                #region case 8
                /*
               PerAdmis perAdmiAnnu = new PerAdmis
               {

                   Dd = new DateTime(2018, 5, 1),

                   Statut = "NA",
                   CodRaisNonAdmis = "NPAR"
               };
               AjusEngagAnnuNonPartnEntre ajusEngagAnuuNonPartnEntre = new AjusEngagAnnuNonPartnEntre();
               ajusEngagAnuuNonPartnEntre.NoSeqIntervenant = 87552;
               ajusEngagAnuuNonPartnEntre.NoSeqPerAdmis = 1;
               ajusEngagAnuuNonPartnEntre.DmAdmis = new DateTime(2018, 7, 13);
               ajusEngagAnuuNonPartnEntre.TypeIntervenant = "DIS";
               ajusEngagAnuuNonPartnEntre.PerAdmisAnnu = perAdmiAnnu;
               */
                #endregion

                #region case 9  - plusieurs avis(un seul statut : AUT) annul et derogation
                /*
                PerAdmis perAdmiAnnu = new PerAdmis
                {

                    Dd = new DateTime(2018, 1, 20),

                    Statut = "NA",
                    CodRaisNonAdmis = "NPAR"
                };
                AjusEngagAnnuNonPartnEntre ajusEngagAnuuNonPartnEntre = new AjusEngagAnnuNonPartnEntre();
                ajusEngagAnuuNonPartnEntre.NoSeqIntervenant = 64739;
                ajusEngagAnuuNonPartnEntre.NoSeqPerAdmis = 1;
                ajusEngagAnuuNonPartnEntre.DmAdmis = new DateTime(2018, 7, 13);
                ajusEngagAnuuNonPartnEntre.TypeIntervenant = "DIS";
                ajusEngagAnuuNonPartnEntre.PerAdmisAnnu = perAdmiAnnu;
                */
                #endregion

                #region case 10  - plusieurs avis( plusieurs statut : AUT SUS) annul et derogation -ok  mais non roule
                /*
                PerAdmis perAdmiAnnu = new PerAdmis
                {

                    Dd = new DateTime(2018, 1, 30),

                    Statut = "NA",
                    CodRaisNonAdmis = "NPAR"
                };
                AjusEngagAnnuNonPartnEntre ajusEngagAnuuNonPartnEntre = new AjusEngagAnnuNonPartnEntre();
                ajusEngagAnuuNonPartnEntre.NoSeqIntervenant = 5947;
                ajusEngagAnuuNonPartnEntre.NoSeqPerAdmis = 1;
                ajusEngagAnuuNonPartnEntre.DmAdmis = new DateTime(2018, 7, 13);
                ajusEngagAnuuNonPartnEntre.TypeIntervenant = "DIS";
                ajusEngagAnuuNonPartnEntre.PerAdmisAnnu = perAdmiAnnu;
                */
                #endregion

                #region case 12
                /*
                PerAdmis perAdmiAnnu = new PerAdmis
                {

                    Dd = new DateTime(2017, 7, 1),
                    Statut = "NA",
                    CodRaisNonAdmis = "NPAR"
                };
                AjusEngagAnnuNonPartnEntre ajusEngagAnuuNonPartnEntre = new AjusEngagAnnuNonPartnEntre();
                ajusEngagAnuuNonPartnEntre.NoSeqIntervenant = 5460; 
                ajusEngagAnuuNonPartnEntre.NoSeqPerAdmis = 1;
                ajusEngagAnuuNonPartnEntre.DmAdmis = new DateTime(2018, 7, 10);
                ajusEngagAnuuNonPartnEntre.TypeIntervenant = "DIS";
                ajusEngagAnuuNonPartnEntre.PerAdmisAnnu = perAdmiAnnu;
                
                */

                #endregion

                #region case 13
                /*
                PerAdmis perAdmiAnnu = new PerAdmis
                {

                    Dd = new DateTime(2018, 5, 16),
                    Statut = "NA",
                    CodRaisNonAdmis = "NPAR"
                };
                AjusEngagAnnuNonPartnEntre ajusEngagAnuuNonPartnEntre = new AjusEngagAnnuNonPartnEntre();
                ajusEngagAnuuNonPartnEntre.NoSeqIntervenant = 64180;
                ajusEngagAnuuNonPartnEntre.NoSeqPerAdmis = 1;
                ajusEngagAnuuNonPartnEntre.DmAdmis = new DateTime(2018, 7, 16);
                ajusEngagAnuuNonPartnEntre.TypeIntervenant = "DIS";
                ajusEngagAnuuNonPartnEntre.PerAdmisAnnu = perAdmiAnnu;
                */
                #endregion

                #region case 14
                /*
                PerAdmis perAdmiAnnu = new PerAdmis
                {

                    Dd = new DateTime(2018, 3, 10),
                    Statut = "NA",
                    CodRaisNonAdmis = "NPAR"
                };
                AjusEngagAnnuNonPartnEntre ajusEngagAnuuNonPartnEntre = new AjusEngagAnnuNonPartnEntre();
                ajusEngagAnuuNonPartnEntre.NoSeqIntervenant = 63689;
                ajusEngagAnuuNonPartnEntre.NoSeqPerAdmis = 1;
                ajusEngagAnuuNonPartnEntre.DmAdmis = new DateTime(2018, 7, 17);
                ajusEngagAnuuNonPartnEntre.TypeIntervenant = "DIS";
                ajusEngagAnuuNonPartnEntre.PerAdmisAnnu = perAdmiAnnu;
                */
                #endregion


                #region spontane
                       
                     PerAdmis perAdmiAnnu = new PerAdmis
                     {

                         Dd = new DateTime(2018, 5, 28),
                         Statut = "NA",
                         CodRaisNonAdmis = "NPAR"
                     };
                AjusEngagAnnuNonPartnEntre ajusEngagAnuuNonPartnEntre = new AjusEngagAnnuNonPartnEntre();
                ajusEngagAnuuNonPartnEntre.NoSeqIntervenant = 14989;
                ajusEngagAnuuNonPartnEntre.NoSeqPerAdmis = 1;
                ajusEngagAnuuNonPartnEntre.DmAdmis = new DateTime(2018, 7, 10);
                ajusEngagAnuuNonPartnEntre.TypeIntervenant = "DIS";
                ajusEngagAnuuNonPartnEntre.PerAdmisAnnu = perAdmiAnnu;
                
                #endregion

                ((ClientCredentials)_proxy.ClientCredentials).Windows.AllowedImpersonationLevel = TokenImpersonationLevel.Impersonation;
                var res = _proxy.AjusterEngagAnnuNonPartn(ajusEngagAnuuNonPartnEntre);

              

                // msg = !res.InfoMsgTrait.Any() ? "OK-Traitement terminé avec succès !" : string.Join(", ", res.InfoMsgTrait.ToArray());
                msg = !res.InfoMsgTrait.Any() ? "OK-Traitement terminé avec succès !" : string.Join(", ", ((MsgTrait)res.InfoMsgTrait[0]).TxtMsgFran);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                //throw;
            }
            return msg;
        }

      

        #region Biztalk
        public string Call_SepcialiteNonPartnBiztalk()
        {

            string msg = string.Empty;
            try
            {



                #region case 2 - envoi courriel -engagement actif
                AjusEngagDdSpecInscrEntreBizTalk ajusEngagDdSpecInscrEntre = new AjusEngagDdSpecInscrEntreBizTalk();
                DispensateurBizTalk infoDispModif = new DispensateurBizTalk
                {

                    ChiffrePreuve = "0",
                    Classe = "0",
                    DdSpecialite = "2018-07-25",
                    NoSeq = "17565",
                    NoSeqIndiv = "17565",
                    NombreAnPratiqueHq = "1",
                    Numero = "84195"

                };

                DispensateurBizTalk infoDispOrig = new DispensateurBizTalk
                {

                    ChiffrePreuve = "0",
                    Classe = "0",

                    DdSpecialite = "2018-01-01",

                    NoSeq = "17565",
                    NoSeqIndiv = "17565",
                    //NoSeqUniversite = 5075,                    
                    Numero = "84195"

                };
                #endregion

                ajusEngagDdSpecInscrEntre.InfoDispOrign = infoDispOrig;
                ajusEngagDdSpecInscrEntre.InfoDispModif = infoDispModif;

                ((ClientCredentials)_proxy.ClientCredentials).Windows.AllowedImpersonationLevel = TokenImpersonationLevel.Impersonation;

                var res = _proxy.AjusterEngagDdSpecInscrBizTalk(ajusEngagDdSpecInscrEntre);

                //msg = !res.InfoMsgTrait.Any() ? "OK-Traitement terminé avec succès !" : string.Join(", ", res.InfoMsgTrait.ToArray());
                msg = !res.InfoMsgTrait.Any() ? "OK-Traitement terminé avec succès !" : string.Join(", ", ((MsgTrait)res.InfoMsgTrait[0]).TxtMsgFran);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                //throw;
            }
            return msg;
        }

        public string Call_DecesNonPartnBiztalk()
        {

            string msg = string.Empty;
            try
            {

                AjusEngagDecesEntreBizTalk ajusEngagDecesEntre = new AjusEngagDecesEntreBizTalk();


                #region - case bug#21
                /*
                IndividuBizTalk infoDispModif = new IndividuBizTalk
                {
                    DateDeces = "2018-02-02",
                    Langue = "FRA",
                    NoSeq = "71479",
                    Sexe = "FEM",
                    TitreCivilite = "DRE"
                };

                IndividuBizTalk infoDispOrig = new IndividuBizTalk
                {

                    //DateDeces = "2018-02-02",
                    Langue = "FRA",
                    NoSeq = "71479",
                    Sexe = "FEM",
                    TitreCivilite = "DRE"
                };
                */
                #endregion

                #region - case bug#22

                IndividuBizTalk infoDispModif = new IndividuBizTalk
                {
                    DateDeces = "2017-09-01",
                    Langue = "FRA",
                    NoSeq = "62514",
                    Sexe = "FEM",
                    TitreCivilite = "DRE"
                };

                IndividuBizTalk infoDispOrig = new IndividuBizTalk
                {

                    DateDeces = "2018-01-01",
                    Langue = "FRA",
                    NoSeq = "62514",
                    Sexe = "FEM",
                    TitreCivilite = "DRE"
                };

                #endregion

                ajusEngagDecesEntre.InfoOrignIndiv = infoDispOrig;
                ajusEngagDecesEntre.InfoModifIndiv = infoDispModif;


                ((ClientCredentials)_proxy.ClientCredentials).Windows.AllowedImpersonationLevel = TokenImpersonationLevel.Impersonation;


                var res = _proxy.AjusterEngagDecesBizTalk(ajusEngagDecesEntre);

                //msg = !res.InfoMsgTrait.Any() ? "OK-Traitement terminé avec succès !" : string.Join(", ", res.InfoMsgTrait.ToArray());
                msg = !res.InfoMsgTrait.Any() ? "OK-Traitement terminé avec succès !" : string.Join(", ", ((MsgTrait)res.InfoMsgTrait[0]).TxtMsgFran);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                //throw;
            }
            return msg;
        }
        public string Call_AjusterEngagAjouNonPartnBiztalk()
        {
            ClassUser cu = new ClassUser();
            string test = cu.Pwd;
            string msg = string.Empty;
            try
            {


                PerAdmisBizTalk nouvPer = new PerAdmisBizTalk
                {

                    Dd = "2018-08-25",
                    Statut = "NA",
                    CodRaisNonAdmis = "NPAR"
                };
                AjusEngagAjouNonPartnEntreBizTalk ajusEngagAjouNonPartnEntre = new AjusEngagAjouNonPartnEntreBizTalk();
                ajusEngagAjouNonPartnEntre.NoSeqIntervenant = "17753";
                ajusEngagAjouNonPartnEntre.NouvPerAdmis = nouvPer;
                ajusEngagAjouNonPartnEntre.TypeIntervenant = "DIS";
                ajusEngagAjouNonPartnEntre.NoSeqPerAdmis = "1";

                //ajusEngagAjouNonPartnEntre.DmAdmis = new DateTime(2018, 7, 6);



                ((ClientCredentials)_proxy.ClientCredentials).Windows.AllowedImpersonationLevel = TokenImpersonationLevel.Impersonation;
                var res = _proxy.AjusterEngagAjouNonPartnBiztalk(ajusEngagAjouNonPartnEntre);

                // msg = !res.InfoMsgTrait.Any() ? "OK-Traitement terminé avec succès !" : string.Join(", ", res.InfoMsgTrait.ToArray());
                msg = !res.InfoMsgTrait.Any() ? "OK-Traitement terminé avec succès !" : string.Join(", ", ((MsgTrait)res.InfoMsgTrait[0]).TxtMsgFran);

            }
            catch (Exception ex)
            {
                msg = ex.Message;
                //throw;
            }
            return msg;
        }


        public string Call_AjusterAvisConformiteMedResidents()
        {
            string msg = string.Empty;

            try
            {

                ParamEntreAjusterAvisConformiteMedResidents ajusEngagResidentEntre = new ParamEntreAjusterAvisConformiteMedResidents();
                #region - case 

                ajusEngagResidentEntre.IndNoSeq = 80699;
                ajusEngagResidentEntre.DisNoSeq = 88607;
                ajusEngagResidentEntre.PvcClaDisp = 1;

                #endregion

                ((ClientCredentials)_proxy.ClientCredentials).Windows.AllowedImpersonationLevel = TokenImpersonationLevel.Impersonation;


                var res = _proxy.AjusterAvisConformiteMedResidents(ajusEngagResidentEntre);

                //msg = !res.InfoMsgTrait.Any() ? "OK-Traitement terminé avec succès !" : string.Join(", ", res.InfoMsgTrait.ToArray());
                msg = !res.InfoMsgTrait.Any() ? "OK-Traitement terminé avec succès !" : string.Join(", ", ((MsgTrait)res.InfoMsgTrait[0]).TxtMsgFran);

            }
            catch (Exception ex)
            {
                msg = ex.Message;
                
            }

            return msg;
        }
        #endregion
    }
}