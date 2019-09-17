using RAMQ.Attribut;
using RAMQ.ClasseBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre
{
    /// <summary>
    /// Classe de paramètres de sortie pour le service du noyau « Modifier la raison de fermeture du statut de l'engagement  ».
    /// </summary>
    /// <remarks>
    /// Auteur : Franck Coulibaly <br/>
    /// Date   : Avril 2018
    /// </remarks>
	public class ModifierRaisFermStatutEngagSorti : ParametreSorti
    {
        /// <summary>
        /// Date et heure de l'occurence
        /// </summary>
        [ValeurEntite(ElementName = "pDatDhcOcc", Direction = ParameterDirection.Output)]
        public DateTime? DateHeureOccurence { get; set; }


    }
}