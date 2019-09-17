using RAMQ.Attribut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Entite
{
    /// <summary> 
    ///  Période d'engagement
    /// </summary>
    /// <remarks>
    ///  Auteur : Franck COULIBALY <br/>
    ///  Date   : Juillet 2018
    /// </remarks>
    public class AdmissibilitePeriode
    {

        /// <summary>
        /// Numéro de séquentiel du medecin omnipraticien
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "INT_NO_SEQ")]
        public long NumeroSequenceDisp { get; set; }

        /// <summary>
        /// Statut d'admissibilité
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "ADM_STA")]
        public string ADM_STA { get; set; }

        /// <summary>
        /// Raison du statut
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "RSA_COD_RAIS")]
        public string Rsa_Cod_Rais { get; set; }

        /// <summary>
        /// Date de début de la periode d'admissibilité
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "ADM_DD")]
        public DateTime? Adm_DD{ get; set; }

        /// <summary>
        /// Date de fin de la periode d'admissibilité
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "ADM_DF")]
        public DateTime? Adm_DF { get; set; }
    }
}