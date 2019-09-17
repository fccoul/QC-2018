using RAMQ.PRE.PRE_Entites_cpo.Securite.Entite;
using RAMQ.PRE.PRE_Entites_cpo.Securite.Parametre;

namespace RAMQ.PRE.PRE_OutilComun_cpo.Utilitaire
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// </remarks>
	public class Mappeur
    {
        /// <summary>
        /// Map un objet de type svcRechrRegleAcces.RegleAccesContxDS en 
        /// RechercherContexteRegleAccesSorti
        /// </summary>
        /// <param name="source">Objet source</param>
        /// <returns>Objet cible</returns>
        static internal RechercherContexteRegleAccesSorti Mapper(svcRechrRegleAcces.RegleAccesContxDroitDS source)
        {
            RechercherContexteRegleAccesSorti cible = new RechercherContexteRegleAccesSorti();

            foreach (var regleAcces in source.RegleAccesContxDroitDT)
            {
                cible.ContextesDroitAcces.Add(new ContexteRegleAcces
                {
                    CodeContexteDroitAcces = regleAcces.cod_contx_droit_acces,
                    IdContexteRegleAcces = regleAcces.id_contx_regle_acces,
                    NumeroSequentielDroitAcces = regleAcces.no_seq_droit_acces

                });
            }

            return cible;
        }

        /// <summary>
        /// Map un objet de type RechercherContexteRegleAccesEntre en 
        /// svcRechrRegleAcces.InfoRegleAccesContxDS
        /// </summary>
        /// <param name="source">Objet source</param>
        /// <returns>Objet cible</returns>
        static internal svcRechrRegleAcces.InfoRegleAccesContxDS Mapper(RechercherContexteRegleAccesEntre source)
        {
            svcRechrRegleAcces.InfoRegleAccesContxDS cible = new svcRechrRegleAcces.InfoRegleAccesContxDS();

            svcRechrRegleAcces.InfoRegleAccesContxDS.ParamDTRow row = default(svcRechrRegleAcces.InfoRegleAccesContxDS.ParamDTRow);
            row = cible.ParamDT.NewParamDTRow();

            row.cod_appli = source.CodeApplication;
            row.id_util = source.IdentifiantUtilisateur;

            cible.ParamDT.AddParamDTRow(row);

            return cible;
        }
    }
}