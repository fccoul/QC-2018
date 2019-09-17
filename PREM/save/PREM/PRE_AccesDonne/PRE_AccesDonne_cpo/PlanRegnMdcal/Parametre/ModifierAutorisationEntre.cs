using RAMQ.Attribut;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre
{
    /// <summary> 
    ///  Classe de paramètres d'entrées pour le service du noyau « Modifier une Autorisation d'un professionnel de la santé ».
    /// </summary>
    /// <remarks>
    ///  Auteur : Franck COULIBALY <br/>
    ///  Date   : Mai 2018
    /// </remarks>
    public class ModifierAutorisationEntre
    {
        /// <summary>
        /// Numéro séquantiel de l'autorisation
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pNumNoSeqAutorisation", Direction = ParameterDirection.Input)]
        public long NumeroSequentiel { get; set; }

        /// <summary>
        /// Numéro séquantiel du dispensateur
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pNumNoSeqDispensateur", Direction = ParameterDirection.Input)]
        public long? NumeroSequentielDispensateur { get; set; }

        /// <summary>
        ///  Type de lieu géographique
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pVchrTypLGEO", Direction = ParameterDirection.Input)]
        public string TypeLgeo { get; set; }

        /// <summary>
        /// Code de lieu géographique
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pVchrCodLGEO", Direction = ParameterDirection.Input)]
        public string CodeLgeo { get; set; }

        /// <summary>
        /// Numero de sequence de regroupement administratif de lieu géographique
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pNumNoSeqRegrAdmnLgeo", Direction = ParameterDirection.Input)]
        public long? NumeroSeqRegrAdmnLgeo { get; set; }


        /// <summary>
        /// Type de l'autorisation
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pVchrTypAutorPremq", Direction = ParameterDirection.Input)]
        public string TypeAutor { get; set; }

        /// <summary>
        /// Date debut de l'autorisation
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pDatDatDebutAutorisation", Direction = ParameterDirection.Input)]
        public DateTime? DateDebut { get; set; }

        /// <summary>
        /// Date de fin de l'autorisation
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pDatDatFinAutorisation", Direction = ParameterDirection.Input)]
        public DateTime? DateFin { get; set; }

        /// <summary>
        /// Code qui identifie la région socio-sanitaire
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pVchrCodRss", Direction = ParameterDirection.Input)]
        public string CodRss { get; set; }

        /// <summary>
        /// Code de raison du statut de l'autorisation
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pVchrCodeRaisonStatut", Direction = ParameterDirection.Input)]
        public string CodeRaisonStatut { get; set; }

        /// <summary>
        /// Identifiant de la MAJ
        /// </summary>
        /// <remarks>Optionnel</remarks>
        [ValeurEntite(ElementName = "pVchrIdentifiantMAJ", Direction = ParameterDirection.Input)]
        public string IdentifiantMAJ { get; set; }
    }
}