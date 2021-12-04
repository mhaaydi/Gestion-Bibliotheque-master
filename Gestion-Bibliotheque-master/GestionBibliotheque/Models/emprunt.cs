//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GestionBibliotheque.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class emprunt
    {
        public int Id { get; set; }
        [DisplayName("Id Ouvrage")]
        public int idouvrage { get; set; }
        [DisplayName("Id Etudiant")]
        public int idetudiant { get; set; }
        [DisplayName("Date d'emprunt")]
        [DataType(DataType.Date)]
        public System.DateTime dateemprunt { get; set; }
        [DisplayName("Date de retour")]
        public Nullable<System.DateTime> dateretour { get; set; }
    
        public virtual ouvrage ouvrage { get; set; }
        public virtual etudiant etudiant { get; set; }
    }
}
