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

                PerAdmis nouvPer = new PerAdmis
                {
                 
                    Dd = new DateTime(2018, 3, 10),
                    Statut = "NA",
                    CodRaisNonAdmis = "NPAR"
                };
                AjusEngagAjouNonPartnEntre ajusEngagAjouNonPartnEntre = new AjusEngagAjouNonPartnEntre();
                ajusEngagAjouNonPartnEntre.NoSeqIntervenant = 6106;//7964;//13253;//14989;//13138;//14989;//10378;                
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

        public string Call_DecesNonPartn()
        {
            
            string msg = string.Empty;
            try
            {
 
                AjusEngagDecesEntre ajusEngagDecesEntre = new AjusEngagDecesEntre();
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

                #region cas OK 
                /*
                //-dispensatieur num:167110
                
                PerAdmis perAdmiAnnu = new PerAdmis
                {
                    //Dd = new DateTime(2018, 05, 20),
                    //Dd = new DateTime(2018, 2, 10),
                    Dd = new DateTime(2018, 4, 10),
                    //Dd = new DateTime(2018, 4, 15),
                    Statut = "NA",
                    CodRaisNonAdmis = "NPAR"
                };
                AjusEngagAnnuNonPartnEntre ajusEngagAnuuNonPartnEntre = new AjusEngagAnnuNonPartnEntre();
                ajusEngagAnuuNonPartnEntre.NoSeqIntervenant = 7004;//12783;//14989;//5566;//4658;
                ajusEngagAnuuNonPartnEntre.NoSeqPerAdmis = 1;
                //ajusEngagAnuuNonPartnEntre.DmAdmis = new DateTime(2018, 7, 3);
                ajusEngagAnuuNonPartnEntre.DmAdmis = new DateTime(2018, 7, 5);
                ajusEngagAnuuNonPartnEntre.TypeIntervenant = "DIS";
                ajusEngagAnuuNonPartnEntre.PerAdmisAnnu = perAdmiAnnu;
                */
                #endregion
                /*
                PerAdmis perAdmiAnnu = new PerAdmis
                {
                    //Dd = new DateTime(2018, 05, 20),
                    //Dd = new DateTime(2018, 2, 10),
                    Dd = new DateTime(2018, 5, 10),
                    //Dd = new DateTime(2018, 4, 15),
                    Statut="NA",
                    CodRaisNonAdmis="NPAR"
                };
                AjusEngagAnnuNonPartnEntre ajusEngagAnuuNonPartnEntre = new AjusEngagAnnuNonPartnEntre();
                ajusEngagAnuuNonPartnEntre.NoSeqIntervenant = 10316;//12783;//14989;//5566;//4658;
                ajusEngagAnuuNonPartnEntre.NoSeqPerAdmis = 1;
                //ajusEngagAnuuNonPartnEntre.DmAdmis = new DateTime(2018, 7, 3);
                ajusEngagAnuuNonPartnEntre.DmAdmis = new DateTime(2018, 7, 10);
                ajusEngagAnuuNonPartnEntre.TypeIntervenant = "DIS";
                ajusEngagAnuuNonPartnEntre.PerAdmisAnnu = perAdmiAnnu;

                */

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


                #region cas en suspsen bug#9

                #region cas 1
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

                #region cas 2
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

                #region cas 3 ..envoi mail
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

                #region 4  - avis(1) Annul et derogation
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

                #region 5 - courriel 
                /* date deces apres date NP*/
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
                

                /* date deces avant date NP
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

                #region 6  - plusieurs avis(un seul statut : AUT) annul et derogation
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

                #region 7  - plusieurs avis( plusieurs statut : AUT SUS) annul et derogation -ok  mais non roule
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
                #endregion

                #region complexe
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
    }
}