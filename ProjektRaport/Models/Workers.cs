//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using ProjektRaport.Validators;
namespace ProjektRaport.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Workers
    {
        internal ICollection<object> changes;
        internal ICollection<object> changes1;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Workers()
        {
            this.Changes = new HashSet<Changes>();
            this.Changes1 = new HashSet<Changes>();
        }
    
        public int Id { get; set; }

        [FirstCharIsBig]
        public string FirstName { get; set; }
        [FirstCharIsBig]
        public string LastName { get; set; }
        public string UserId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Changes> Changes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Changes> Changes1 { get; set; }
    }
}