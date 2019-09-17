using System.Web.Optimization;

namespace RAMQ.PRE.PL_Prem_iut
{
    /// <summary>
    /// 
    /// </summary>
    public class BundleConfig
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bundles"></param>
        public static void RegisterBundles(BundleCollection bundles)
        {
            BundleTable.Bundles.Add(new StyleBundle("~/bundles/PREMCSS").Include("~/Contents/css/bootstrap-datepicker.css")
                                                                        .Include("~/Contents/css/dataTables.bootstrap.css")
                                                                        .Include("~/Contents/css/select2.css")
                                                                        .Include("~/Contents/css/PREM.css"));
            BundleTable.Bundles.Add(new StyleBundle("~/bundles/PLE1CSS").Include("~/Contents/css/PLE1.css"));
            BundleTable.Bundles.Add(new StyleBundle("~/bundles/PLC2CSS").Include("~/Contents/css/PLC2.css"));
            BundleTable.Bundles.Add(new StyleBundle("~/bundles/PLC1CSS").Include("~/Contents/css/PLC1.css"));
            BundleTable.Bundles.Add(new StyleBundle("~/bundles/PLA1CSS").Include("~/Contents/css/PLA1.css"));

            BundleTable.Bundles.Add(new StyleBundle("~/bundles/PLA2CSS").Include("~/Contents/css/PLA2.css")
                                                                        .Include("~/Contents/css/PREM.css"));

            BundleTable.Bundles.Add(new StyleBundle("~/bundles/PLACSS").Include("~/Contents/css/PLA.css"));

            BundleTable.Bundles.Add(new ScriptBundle("~/bundles/PREMJS").Include("~/Contents/scripts/PREM.js")
                                                                        .Include("~/Contents/scripts/jquery.mask.js")
                                                                        .Include("~/Contents/scripts/bootstrap-datepicker.js")
                                                                        .Include("~/Contents/scripts/bootstrap-datepicker.fr.js")
                                                                        .Include("~/Contents/scripts/DataTables/jquery.dataTables.min.js")
                                                                        .Include("~/Contents/scripts/DataTables/dataTables.bootstrap.min.js")
                                                                        .Include("~/Contents/scripts/select2/select2.full.min.js")
                                                                        .Include("~/Contents/scripts/select2/i18n/fr.js"));

            //Ajout des scripts pour PLA1
            BundleTable.Bundles.Add(new ScriptBundle("~/bundles/PLA1_Attente").Include("~/Contents/scripts/PLA1/PLA1_Attente.js"));
            BundleTable.Bundles.Add(new ScriptBundle("~/bundles/PLA1_Confirmation").Include("~/Contents/scripts/PLA1/PLA1_Confirmation.js"));
            BundleTable.Bundles.Add(new ScriptBundle("~/bundles/PLA1_Modifier").Include("~/Contents/scripts/PLA1/PLA1_Modifier.js"));
            BundleTable.Bundles.Add(new ScriptBundle("~/bundles/PLA1_Transmettre").Include("~/Contents/scripts/PLA1/PLA1_Transmettre.js"));

            //Ajout des scripts pour PLA2
            BundleTable.Bundles.Add(new ScriptBundle("~/bundles/PLA2_AjouterModifierAnnulerSuspension").Include("~/Contents/scripts/PLA2/PLA2_AjouterModifierAnnulerSuspension.js"));
            BundleTable.Bundles.Add(new ScriptBundle("~/bundles/PLA2_AnnulerDerogation").Include("~/Contents/scripts/PLA2/PLA2_AnnulerDerogation.js"));
            BundleTable.Bundles.Add(new ScriptBundle("~/bundles/PLA2_ConfirmationDerogation").Include("~/Contents/scripts/PLA2/PLA2_ConfirmationDerogation.js"));
            BundleTable.Bundles.Add(new ScriptBundle("~/bundles/PLA2_GererSuspension").Include("~/Contents/scripts/PLA2/PLA2_GererSuspension.js"));
            BundleTable.Bundles.Add(new ScriptBundle("~/bundles/PLA2_TransmettreDerogation").Include("~/Contents/scripts/PLA2/PLA2_TransmettreDerogation.js"));

            //Ajout des scripts pour PLA5
            BundleTable.Bundles.Add(new ScriptBundle("~/bundles/PLA5_JS").Include("~/Contents/scripts/PLA5/PLA5_Global.js"));

            //Ajout des scripts pour PLC1
            BundleTable.Bundles.Add(new ScriptBundle("~/bundles/PLC1")
                .Include("~/Contents/scripts/PLC1/PLC1.js"));

            //Ajout des scripts pour PLC2
            BundleTable.Bundles.Add(new ScriptBundle("~/bundles/PLC2")
                .Include("~/Contents/scripts/PLC2/PLC2.js")
                .Include("~/Contents/scripts/PLC2/PLC2_HistoriqueEngagement.js")
                .Include("~/Contents/scripts/PLC2/PLC2_RepartitionPratique.js")
                .Include("~/Contents/scripts/PLC2/PLC2_PratiqueExclusive.js")
                .Include("~/Contents/scripts/PLC2/PLC2_RegionPratiquePartielleRestreinte.js")
                .Include("~/Contents/scripts/PLC2/PLC2_ReductionRemuneration.js"));

            //Ajout des scripts pour PLE1
            BundleTable.Bundles.Add(new ScriptBundle("~/bundles/PLE1")
                .Include("~/Contents/scripts/PLE1/PLE1.js"));
        }
    }
}