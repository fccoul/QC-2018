namespace RAMQ.PRE.PRE_Entites_cpo.EngagementPratique.Entite
{
    /// <summary> 
    ///  Entité contenant les information d'un territoire
    /// </summary>
    /// <remarks>
    ///  Auteur : Jean-Benoit Drouin-Cloutier <br/>
    ///  Date   : Septembre 2016
    /// </remarks>
	public class InformationTerritoire
    {

        private string _type;

        /// <summary>
        /// Nom du territoire
        /// </summary>
        public string Nom { get; set; }

        /// <summary>
        /// Type de territoire
        /// </summary>
        public string Type
        {
            get
            {
                if (string.IsNullOrEmpty(_type) && !string.IsNullOrEmpty(Nom))
                {
                    if (Nom.ToLower().StartsWith("regroupement"))
                    {
                        _type = "Regroupement";
                    }
                    else if (Nom.ToLower().StartsWith("territoire"))
                    {
                        _type = "Territoire";
                    }
                    else if (Nom.ToLower().StartsWith("rls"))
                    {
                        _type = "RLS";
                    }
                    else
                    {
                        _type = "RSS";
                    }
                }
                else
                {
                    return _type;
                }

                return _type;

            }
            set
            {
                _type = value;
            }
        }

        /// <summary>
        /// Code du lieu géographique
        /// </summary>
        public string CodeLieuGeographique { get; set; }

        /// <summary>
        /// Numéro séquentiel regroupement
        /// </summary>
        public long? NumeroSequentielRegroupement { get; set; }
    }
}