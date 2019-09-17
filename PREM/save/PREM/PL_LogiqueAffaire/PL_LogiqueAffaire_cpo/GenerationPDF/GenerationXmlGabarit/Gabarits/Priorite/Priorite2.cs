﻿using System;
using System.Xml.Serialization;

namespace RAMQ.PRE.PL_LogiqueAffaire_cpo.GenerationPDF.GenerationXmlGabarit.Gabarits.Priorite
{
    /// <summary> 
    ///  Classe représentant la priorité 2 dans le fichier XML
    /// </summary>
    /// <remarks>
    ///  Auteur : Alexis Garon-Michaud <br/>
    ///  Date   : Mars 2017
    /// </remarks>
    [Serializable]
    public class Priorite2
    {
        /// <summary>
        /// Numéro
        /// </summary>
        [XmlAttribute]
        public int Numero { get; set; } = 2;

        /// <summary>
        /// Ligne1
        /// </summary>
        public Ligne1 Ligne1 { get; set; } = new Ligne1();
    }
}