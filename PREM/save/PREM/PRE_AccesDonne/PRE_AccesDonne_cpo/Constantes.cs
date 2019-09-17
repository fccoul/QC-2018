namespace RAMQ.PRE.PRE_AccesDonne_cpo
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// </remarks>
	internal sealed class Constantes
    {

        #region Requête SQL ReptnPratiRPPR
        public const string RequeteVueReptnPratiRPPR = @"
            select   no_seq_disp, 
                     dat_serv, 
                     cod_rss,
                     typ_lgeo,
                     cod_lgeo,
                     no_seq_regr_admn_lgeo,
                     jr,
                     typ_serv_reptn_prati	
            from PRE.PRE_VM_JR_FACT_REPTN_RPPR jfrr
            WHERE 
            (
                ({0} IS NULL)
                OR no_seq_disp IN ({1})
            )
            AND 
            (
                (:DateServiceDateDebutPerRechr IS NULL)
                OR (DAT_SERV >= to_date(:DateServiceDateDebutPerRechr,'YYYY-mm-dd hh24:mi:ss'))
            )
            AND 
            (
                (:DateServiceDateFinPerRechr IS NULL)
                OR (DAT_SERV <= to_date(:DateServiceDateFinPerRechr,'YYYY-mm-dd hh24:mi:ss'))
            )
            AND 
            (
                (:CodeRSS IS NULL)
                OR (cod_rss = :CodeRSS)
            )
            AND 
            (
                (:Jours = 0)
                OR (JR = :Jours)
            )
            AND 
            (
                (:TypeServiceRepartitionPratique IS NULL)
                OR (TYP_SERV_REPTN_PRATI = :TypeServiceRepartitionPratique)
            )
            AND (
                (:NombreElementsParPage = 0 OR :NumeroPage = 0)
                OR (ROWNUM >= :NombreElementsParPage * (:NumeroPage - 1) AND ROWNUM <= :NombreElementsParPage * (:NumeroPage))
            )
            ORDER BY 1
            ";
#endregion

        #region Requête SQL ReptnPratiTerri
        public const string RequeteVueReptnPratiTerri = @"
            select   no_seq_disp, 
                     dat_serv, 
                     cod_rss, 
                     typ_lgeo, 
                     cod_lgeo, 
                     no_seq_regr_admn_lgeo, 
                     jr, 
                     typ_serv_reptn_prati 
            from PRE.PRE_VM_JR_FACT_TERRI jrft
            WHERE 
            (
               ({0} IS NULL)
                OR no_seq_disp IN ({1})
            )
            AND 
            (
                (:DateServiceDateDebutPerRechr IS NULL)
                OR (DAT_SERV >= to_date(:DateServiceDateDebutPerRechr,'YYYY-mm-dd hh24:mi:ss'))
            )
            AND 
            (
                (:DateServiceDateFinPerRechr IS NULL)
                OR (DAT_SERV <= to_date(:DateServiceDateFinPerRechr,'YYYY-mm-dd hh24:mi:ss'))
            )
            AND 
            (
                (:CodeRSS IS NULL)
                OR (cod_rss = :CodeRSS)
            )
            AND 
            (
                (:TypeLieuGeo IS NULL)
                OR (typ_lgeo = :TypeLieuGeo)
            )
            AND 
            (
                (:CodeLieuGeo IS NULL)
                OR (cod_lgeo = :CodeLieuGeo)
            )
            AND 
            (
                (:NumeroSeqRegrAdminLieuGeo = 0)
                OR (no_seq_regr_admn_lgeo = :NumeroSeqRegrAdminLieuGeo)
            )
            AND 
            (
                (:Jours = 0)
                OR (JR = :Jours)
            )
            AND 
            (
                (:TypeServiceRepartitionPratique IS NULL)
                OR (TYP_SERV_REPTN_PRATI = :TypeServiceRepartitionPratique)
            )
            AND (
                (:NombreElementsParPage = 0 OR :NumeroPage = 0)
                OR (ROWNUM >= :NombreElementsParPage * (:NumeroPage - 1) AND ROWNUM <= :NombreElementsParPage * (:NumeroPage))
            )
            ORDER BY 1
            ";
#endregion

        #region Requête SQL ReptnPratiRSS
        public const string RequeteVueReptnPratiRSS = @"
            select   no_seq_disp, 
                     dat_serv, 
                     cod_rss, 
                     jr, 
                     typ_serv_reptn_prati
            from PRE.PRE_VM_JR_FACT_COD_RSS t
            WHERE 
            (
                ({0} IS NULL)
                OR no_seq_disp IN ({1})
            )
            AND 
            (
                (:DateServiceDateDebutPerRechr IS NULL)
                OR (DAT_SERV >= to_date(:DateServiceDateDebutPerRechr,'YYYY-mm-dd hh24:mi:ss'))
            )
            AND 
            (
                (:DateServiceDateFinPerRechr IS NULL)
                OR (DAT_SERV <= to_date(:DateServiceDateFinPerRechr,'YYYY-mm-dd hh24:mi:ss'))
            )
            AND 
            (
                (:CodeRSS IS NULL)
                OR (cod_rss = :CodeRSS)
            )
            AND 
            (
                (:Jours = 0)
                OR (JR = :Jours)
            )
            AND 
            (
                (:TypeServiceRepartitionPratique IS NULL)
                OR (TYP_SERV_REPTN_PRATI = :TypeServiceRepartitionPratique)
            )
            AND (
                (:NombreElementsParPage = 0 OR :NumeroPage = 0)
                OR (ROWNUM >= :NombreElementsParPage * (:NumeroPage - 1) AND ROWNUM <= :NombreElementsParPage * (:NumeroPage))
            )
            ORDER BY 1
            ";
        #endregion

        #region Requête SQL ReptnPratiAvis
        public const string RequeteVueReptnPratiAvis = @"
            select  NO_SEQ_DISP,
                    DAT_SERV,
                    COD_RSS,
                    TYP_LGEO,
                    COD_LGEO,
                    NO_SEQ_REGR_ADMN_LGEO,
                    DD_ENGAG_PRATI,
                    DF_ENGAG_PRATI,
                    DD_STA_ENGAG_TERRI,
                    DF_STA_ENGAG_TERRI,
                    STA_ENGAG_TERRI,
                    JR,TYP_SERV_REPTN_PRATI
            from PRE.PRE_VM_JR_FACT_AVIS_CONF jfac
            WHERE  
            (
                ({0} IS NULL)
                OR no_seq_disp IN ({1})
            )
            AND 
            (
                (:DateServiceDebutPerRechr IS NULL)
                OR (dat_serv >= to_date(:DateServiceDebutPerRechr,'YYYY-mm-dd hh24:mi:ss'))
            )
            AND 
            (
                (:DateServiceFinPerRechr IS NULL)
                OR (dat_serv <= to_date(:DateServiceFinPerRechr,'YYYY-mm-dd hh24:mi:ss'))
            )
            AND 
            (
                (:DateDebutEngagDebutPerRechr IS NULL)
                OR (DD_ENGAG_PRATI >= to_date(:DateDebutEngagDebutPerRechr,'YYYY-mm-dd hh24:mi:ss'))
            )
            AND 
            (
                (:DateDebutEngagFinPerRechr IS NULL)
                OR (DD_ENGAG_PRATI <= to_date(:DateDebutEngagFinPerRechr,'YYYY-mm-dd hh24:mi:ss'))
            )
            AND 
            (
                (:DateFinEngagDebutPerRechr IS NULL)
                OR (DF_ENGAG_PRATI >= to_date(:DateFinEngagDebutPerRechr,'YYYY-mm-dd hh24:mi:ss'))
            )
            AND 
            (
                (:DateFinEngagFinPerRechr IS NULL)
                OR (DF_ENGAG_PRATI <= to_date(:DateFinEngagFinPerRechr,'YYYY-mm-dd hh24:mi:ss'))
            )
            AND 
            (
                (:CodeRSS IS NULL)
                OR (cod_rss = :CodeRSS)
            )
            AND 
            (
                (:TypeLieuGeo IS NULL)
                OR (typ_lgeo = :TypeLieuGeo)
            )
            AND 
            (
                (:CodeLieuGeo IS NULL)
                OR (cod_lgeo = :CodeLieuGeo)
            )
            AND 
            (
                (:NumeroSeqRegrAdminLieuGeo IS NULL)
                OR (no_seq_regr_admn_lgeo = :NumeroSeqRegrAdminLieuGeo)
            )
            AND 
            (
                (:StatutEngagTerri IS NULL)
                OR (sta_engag_terri = :StatutEngagTerri)
            )
            AND 
            (
                (:Jours = 0)
                OR (JR = :Jours)
            )
            AND 
            (
                (:TypeServiceRepartitionPratique IS NULL)
                OR (TYP_SERV_REPTN_PRATI = :TypeServiceRepartitionPratique)
            )
            AND (
                (:NombreElementsParPage = 0 OR :NumeroPage = 0)
                OR (ROWNUM >= :NombreElementsParPage * (:NumeroPage - 1) AND ROWNUM <= :NombreElementsParPage * (:NumeroPage))
            )
            ORDER BY 1
            ";


        public const string RequeteObtenirVueListeEngagements =
            @"SELECT no_seq_engag_prati, no_seq_disp, cod_rss, typ_lgeo, cod_lgeo, no_seq_regr_admn_lgeo, sta_engag_terri, dd_engag_prati, df_engag_prati, dd_sta_engag_terri, df_sta_engag_terri
            FROM PRE.PREMQ_V_ENGAG_PRATI_TERRI
            WHERE dh_inact_occ_sta_engag IS NULL
            AND 
            (
                ({0} IS NULL)
                OR no_seq_disp IN ({1})
            )
            AND
            (
                (:CodesRSS IS NULL)
                OR (cod_rss = :CodesRSS)
            )
            AND 
            (
                (:DateDebutEngagementRechr IS NULL)
                OR (dd_sta_engag_terri >= to_date(:DateDebutEngagementRechr,'YYYY-mm-dd hh24:mi:ss'))
            )
            AND 
            (
                (:DateFinEngagementRechr IS NULL)
                OR (df_sta_engag_terri <= to_date(:DateFinEngagementRechr,'YYYY-mm-dd hh24:mi:ss'))
            )
            AND 
            (
                (:StatutEngagement IS NULL)
                OR (sta_engag_terri = :StatutEngagement)
            )";

        public const string RequeteObtenirVuePeriodesEngagements =
            @"SELECT TYPE, NO_SEQ_DISP, DD_ENGAG_PRATI, DF_ENGAG_PRATI, NO_SEQ_ENGAG_PRATI, NO_SEQ_DEROG_PRATI_PROF

            FROM PRE.PREMQ_V_LIST_ENGA_PROF_SANT
            WHERE 
            (
                ({0} IS NULL)
                OR no_seq_disp IN ({1})
            )
            AND 
            (
                (:Type IS NULL)
                OR (TYPE = :Type)
            )";
        #endregion

        #region Vues Liste % JrFac (PLC1)
        public const string RequeteObtenirVueListePrctJrfacAvis =
    @"
                select   an_per_premq, 
                         dis_no_seq, 
                         no_prati, 
                         nom_md, 
                         cod_rss, 
                         typ_terri, 
                         cod_terri, 
                         nom_terri, 
                         no_seq_regr_admn_lgeo, 
                         dd_engag_prati, 
                         df_engag_prati, 
                         nbr_jr_fact_avis, 
                         nbr_jr_fact_hors_avis, 
                         nbr_tot_jr_fact, 
                         prc_fact_effec
                from PRE.PRE_VM_PRC_JR_FACT_AVIS
                WHERE   (:periode IS NULL OR an_per_premq = :periode)
                AND     (:coderss IS NULL OR cod_rss = :coderss)
                AND     (:sousterri IS NULL OR (cod_terri = :sousterri OR no_seq_regr_admn_lgeo = :sousterri))
                AND     (:prcnt IS NULL OR prc_fact_effec < :prcnt)
";

        public const string RequeteObtenirVueListePrctJrfacDerog =
@"
                SELECT AN_PER_PREMQ,
                       DIS_NO_SEQ,
                       NO_PRATI,
                       NOM_MD,
                       TYP_PRATI,
                       DD_DEROG,
                       DF_DEROG,
                       NBR_JR_FACT_DEROG,
                       NBR_TOT_JR_FACT_DEROG,
                       PRC_FACT_EFFEC
                FROM PRE_VM_PRC_JR_FACT_DEROG
                WHERE (:periode IS NULL OR AN_PER_PREMQ = :periode)
                AND   (:typepratique IS NULL OR TYP_PRATI = :typepratique)
                AND   (:prcnt IS NULL OR prc_fact_effec < :prcnt)
";

        public const string RequeteObtenirVueListePrctJrfacTerri =
@"
                SELECT AN_PER_PREMQ,
                       DIS_NO_SEQ,
                       NO_PRATI,
                       NOM_MD,
                       cod_rss, 
                       TYP_REPTN,
                       typ_terri, 
                       cod_terri, 
                       nom_terri, 
                       no_seq_regr_admn_lgeo, 
                       NBR_JR_FACT,
                       NBR_TOT_JR_FACT,
                       PRC_FACT_EFFEC
                FROM PRE_VM_PRC_JR_FACT_TERRI
                WHERE (:periode IS NULL OR an_per_premq = :periode)
                AND   (:coderss IS NULL OR cod_rss = :coderss)
                AND   (:sousterri IS NULL OR (cod_terri = :sousterri OR no_seq_regr_admn_lgeo = :sousterri))
                AND   (:typerepartition IS NULL OR TYP_REPTN = :typerepartition)
";

        public const string RequeteObtenirVueListePrctJrfacRPPR =
@"
                SELECT   an_per_premq, 
                         dis_no_seq, 
                         no_prati, 
                         nom_md, 
                         cod_rss, 
                         dd_engag_prati,
                         df_engag_prati,
                         nbr_jr_fact, 
                         nbr_tot_jr_fact, 
                         prc_fact_effec
                FROM PRE.PRE_VM_PRC_JR_FACT_RPPR
                WHERE (:periode IS NULL OR an_per_premq = :periode)
                AND   (:coderss IS NULL OR cod_rss = :coderss)
                AND   (:nbrtotjrfactmin IS NULL OR nbr_tot_jr_fact > :nbrtotjrfactmin)
                AND   (:prcfacteffecmin IS NULL OR prc_fact_effec > :prcfacteffecmin)
                AND   (:DisNoSeq IS NULL OR dis_no_seq = :DisNoSeq)
";
        #endregion
    }
}