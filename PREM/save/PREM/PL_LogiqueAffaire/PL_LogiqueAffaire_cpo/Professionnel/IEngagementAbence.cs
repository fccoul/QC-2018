using RAMQ.PRE.PRE_Entites_cpo.Professionnel.Parametre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAMQ.PRE.PL_LogiqueAffaire_cpo.Professionnel
{
    /// <summary> 
    ///  Interface pour la recherche ddes engagements et peridoe absence.
    /// </summary>
    /// <remarks>
    ///  Auteur : Franck COULIBALY <br/>
    ///  Date   : Juin 2018
    /// </remarks>
    public interface IEngagementAbence
    {
        /// <summary>
        /// Permet l'obtention des périodes d'engagement et absences du professionnel de la santé
        /// </summary>
        /// <param name="intrant"></param>
        /// <returns>Liste des engagements et absences d'avis></returns>
        ObtenirVuePeriodeEngagementSorti ObtenirPeriodeEngagementsAbsenceProfessionnel(ObtenirVuePeriodeEngagementEntre intrant);
    }
}
