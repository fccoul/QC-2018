using RAMQ.PRE.PLC2_CnsulProfiPremqProf_cpo.Parametres;
using RAMQ.PRE.PRE_Entites_cpo.Pratique.Parametre;
using System.Collections.Generic;
using System.Linq;

namespace RAMQ.PRE.PLC2_CnsulProfiPremqProf_cpo.Utilitaire
{

    /// <summary> 
    ///  Mappeur
    /// </summary>
    /// <remarks>
    ///  Auteur : Jean-Benoit Drouin-Cloutier <br/>
    ///  Date   : Octobre 2016
    /// </remarks>
    internal class Mappeur
    {
        /// <summary>
        ///  Map un objet PRE_Entites_cpo.PeriodePratique.Parametre.ObtenirPeriodePratiqueProfessionnelEntre en PRE_SysExt_cpo.FIP.EPZ3.Parametre.ObtenirPeriodePratiqueProfessionnelEntre
        /// </summary>
        /// <Parametre name="source">Objet source</Parametre>
        /// <Parametre name="cible">Objet cible</Parametre>
        /// <remarks></remarks>
        static internal void Mapper(PRE_Entites_cpo.PeriodePratique.Parametre.ObtenirPeriodePratiqueProfessionnelEntre source, 
                                    ref PRE_SysExt_cpo.FIP.EPZ3.Parametre.ObtenirPeriodePratiqueProfessionnelEntre cible)
        {
            if (cible == null)
            {
                cible = new PRE_SysExt_cpo.FIP.EPZ3.Parametre.ObtenirPeriodePratiqueProfessionnelEntre();
            }

            cible.NumeroSequenceDispensateur = source.NumeroSequenceDispensateur;
            cible.NumeroTypePratique = source.NumeroTypePratique;

        }




        /// <summary>
        ///  Map un objet PRE_SysExt_cpo.FIP.EPZ3.Parametre.ObtenirPeriodePratiqueProfessionnelSorti en PRE_Entites_cpo.PeriodePratique.Parametre.ObtenirPeriodePratiqueProfessionnelSorti
        /// </summary>
        /// <Parametre name="source">Objet source</Parametre>
        /// <Parametre name="cible">Objet cible</Parametre>
        /// <remarks></remarks>
        static internal void Mapper(PRE_SysExt_cpo.FIP.EPZ3.Parametre.ObtenirPeriodePratiqueProfessionnelSorti source, 
                                    ref PRE_Entites_cpo.PeriodePratique.Parametre.ObtenirPeriodePratiqueProfessionnelSorti cible)
        {
            if (cible == null)
            {
                cible = new PRE_Entites_cpo.PeriodePratique.Parametre.ObtenirPeriodePratiqueProfessionnelSorti();
            }

            if (cible.InfoMsgTrait == null)
            {
                cible.InfoMsgTrait = new List<Message.MsgTrait>();
            }

            cible.InfoMsgTrait = source.InfoMsgTrait;
            cible.DateDerniereFacturation = source.DateDerniereFacturation;
            cible.DatePremiereFacturation = source.DatePremiereFacturation;
            cible.NumeroSequencePratique = source.NumeroSequencePratique;
            cible.NumeroTypePratique = source.NumeroTypePratique;

        }


        //internal static void Mapper(CalculerNombreJourneeFacturationEntre source, CalculerNbrJrFactProfsEntre cible)
        //{
        //    if (cible == null)
        //    {
        //        cible = new CalculerNbrJrFactProfsEntre();
        //    }

        //    cible.CodeLieuGeographique = source.CodeLieuGeographique;
        //    cible.CodeRSS = source.CodeRSS;
        //    cible.DateDebut = source.DateDebut;
        //    cible.DateFin = source.DateFin;
        //    cible.NumeroSeqEngagement = source.NumeroSequentielEngagement;
        //    cible.NumeroSeqRegrAdmn = source.NumeroRegroupement.ToString();
        //    cible.NumerosSequentielsProfs = new List<long>() { source.NumeroSequentielProfessionnel };
        //    cible.TypeLieuGeographique = source.TypeLieuGeographique;
        //}


        //static internal void Mapper(CalculerNombreJourneeFacturationSorti source, ref CalculerNbrJrFactProfsSorti cible)
        //{
        //    if (cible == null)
        //    {
        //        cible = new CalculerNbrJrFactProfsSorti();
        //    }

        //    if (cible.InfoMsgTrait == null)
        //    {
        //        cible.InfoMsgTrait = new List<Message.MsgTrait>();
        //    }

        //    cible.InfoMsgTrait = source.InfoMsgTrait;
        //    cible.JourneesFactAvis = source.JourneesFacturerAvis;
        //    cible.JourneesFactDroitsAcquis = source.JourneesFacturerDroitsAcquis;
        //    cible.JourneesFactRSS = source.JourneesFacturerRSS;
        //    cible.JourneesFactTerritoire = source.JourneesFacturerTerritoire;
        //    cible.PourcentagesProfs = source.PourcentagesProfessionnnels;
        //    cible.SommairesProfs = source.SommairesProfessionnels;
           
        //}

        //static internal void Mapper(CalculerNbrJrFactProfsEntre source, ref CalculerNombreJourneeFacturationEntre cible)
        //{

        //    if (cible == null)
        //    {
        //        cible = new CalculerNombreJourneeFacturationEntre();
        //    }

        //    cible.CodeLieuGeographique = source.CodeLieuGeographique;
        //    cible.CodeRSS = source.CodeRSS;
        //    cible.DateDebut = source.DateDebut;
        //    cible.DateFin = source.DateFin;
        //    cible.NumeroSequentielEngagement = source.NumeroSeqEngagement;
        //    cible.NumeroRegroupement = !string.IsNullOrEmpty(source.NumeroSeqRegrAdmn) ? long.Parse(source.NumeroSeqRegrAdmn) : 0 ;
        //    cible.NumeroSequentielProfessionnel = source.NumerosSequentielsProfs.First();
        //    cible.TypeLieuGeographique= source.TypeLieuGeographique;

        //}

        //internal static void Mapper(CalculerNbrJrFactProfsSorti source, CalculerNombreJourneeFacturationSorti cible)
        //{
        //    if (cible == null)
        //    {
        //        cible = new CalculerNombreJourneeFacturationSorti();
        //    }

        //    if (cible.InfoMsgTrait == null)
        //    {
        //        cible.InfoMsgTrait = new List<Message.MsgTrait>();
        //    }

        //    cible.InfoMsgTrait = source.InfoMsgTrait;
        //    cible.JourneesFacturerAvis = source.JourneesFactAvis;
        //    cible.JourneesFacturerDroitsAcquis = source.JourneesFactDroitsAcquis;
        //    cible.JourneesFacturerRSS = source.JourneesFactRSS;
        //    cible.JourneesFacturerTerritoire = source.JourneesFactTerritoire;
        //    cible.PourcentagesProfessionnnels = source.PourcentagesProfs;
        //    cible.SommairesProfessionnels = source.SommairesProfs;
        //}
    }

}
