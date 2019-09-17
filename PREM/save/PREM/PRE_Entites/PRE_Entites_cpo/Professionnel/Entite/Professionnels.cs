using RAMQ.ClasseBase;
using System.Collections.Generic;

namespace RAMQ.PRE.PRE_Entites_cpo.Professionnel.Entite
{
    /// <summary>
    /// 
    /// </summary>
    public class Professionnels : ParamSorti
    {

        /// <summary>
        /// Constructeur
        /// </summary>
        public Professionnels()
        {
            LesProfessionnels = new List<Professionnel>();
        }

        /// <summary>
        /// Liste de professionnels
        /// </summary>
        public List<Professionnel> LesProfessionnels { get; set; }

    }
}