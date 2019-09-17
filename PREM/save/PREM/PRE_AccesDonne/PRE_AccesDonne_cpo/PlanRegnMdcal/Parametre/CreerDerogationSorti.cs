using RAMQ.Attribut;
using RAMQ.ClasseBase;
using System;
using System.Data;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre
{

    /// <summary> 
    ///  Classe de paramètres de sortie pour le service du noyau « Créer une dérogation ».
    /// </summary>
    /// <remarks>
    ///  Auteur : Sébastien Bourdages<br/>
    ///  Date   : Janvier 2017
    /// </remarks>
    public class CreerDerogationSorti : ParamSorti
    {
        /// <summary>
        /// Numéro séquentiel de la dérogation.
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pnumNoSeqDerogPratiProf", Direction = ParameterDirection.Output)]
        public long NumeroSequentielDerogation { get; set; }

        /// <summary>
        /// Date et heure de la création de l'occurence.
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pDatDHCreatOccurence", Direction = ParameterDirection.Output)]
        public DateTime DateHeureCreationOccurence { get; set; }
    }
}