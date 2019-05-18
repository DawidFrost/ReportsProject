namespace ProjektRaport.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Validators;

    public partial class ReportModel : DbContext
    {
        public ReportModel()
            : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<Changes> Changes { get; set; }
        public virtual DbSet<Report> Report { get; set; }
        public virtual DbSet<Workers> Workers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Changes>()
                .Property(e => e.TimeRange)
                .IsUnicode(false);

            modelBuilder.Entity<Changes>()
                .HasMany(e => e.Report)
                .WithRequired(e => e.Changes)
                .HasForeignKey(e => e.ChangeID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Report>()
                .Property(e => e.IncidentNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Report>()
                .Property(e => e.ContentIncident)
                .IsUnicode(false);

            modelBuilder.Entity<Report>()
                .Property(e => e.ActionToken)
                .IsUnicode(false);

            modelBuilder.Entity<Report>()
                .Property(e => e.DeviceNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Report>()
                .Property(e => e.DeviceName)
                .IsUnicode(false);

            modelBuilder.Entity<Workers>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Workers>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Workers>()
                .HasMany(e => e.Changes)
                .WithRequired(e => e.Workers)
                .HasForeignKey(e => e.FristWorker)
                .WillCascadeOnDelete(false);


            modelBuilder.Entity<Workers>()
                .HasMany(e => e.Changes1)
                .WithRequired(e => e.Workers1)
                .HasForeignKey(e => e.SecondWorker)
                .WillCascadeOnDelete(false);
        }
    }

    namespace ProjektRaport.Models
    {
        using System;
        using System.Collections.Generic;
        using System.ComponentModel.DataAnnotations;
        using System.ComponentModel.DataAnnotations.Schema;
        using System.Data.Entity.Spatial;

        [Table("Report")]
        public partial class Report
        {
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public int ID { get; set; }

            public int ChangeID { get; set; }

            [Required]
            [StringLength(11)]
            public string IncidentNumber { get; set; }

            [Required]
            [StringLength(500)]
            public string ContentIncident { get; set; }

            [Required]
            [StringLength(500)]
            public string ActionToken { get; set; }

            [Required]
            [StringLength(11)]
            public string DeviceNumber { get; set; }

            [Required]
            [StringLength(11)]
            public string DeviceName { get; set; }

            public int ActionTime { get; set; }

            public virtual Changes Changes { get; set; }
        }
    }

    namespace ProjektRaport.Models
    {
        using System;
        using System.Collections.Generic;
        using System.ComponentModel.DataAnnotations;
        using System.ComponentModel.DataAnnotations.Schema;
        using System.Data.Entity.Spatial;

        public partial class Changes
        {
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
            public Changes()
            {
                Report = new HashSet<Report>();
            }

            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public int ID { get; set; }

            public int FristWorker { get; set; }

            public int? SecondWorker { get; set; }

            [Required]
            [StringLength(11)]
            public string TimeRange { get; set; }

            [Column(TypeName = "Date")]
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{dd/MM/yyyy}", ApplyFormatInEditMode = true)]
            public DateTime Date { get; set; }

            public virtual Workers Workers { get; set; }

            public virtual Workers Workers1 { get; set; }

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
            public virtual ICollection<Report> Report { get; set; }
        }
    }
    namespace ProjektRaport.Models
    {
        using System;
        using System.Collections.Generic;
        using System.ComponentModel.DataAnnotations;
        using System.ComponentModel.DataAnnotations.Schema;
        using System.Data.Entity.Spatial;

        public partial class Workers
        {
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
            public Workers()
            {
                Changes = new HashSet<Changes>();
           
            }

            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public int Id { get; set; }

            [Required]
            [FirstCharIsBig]
            [StringLength(12)]
            public string FirstName { get; set; }

            [Required]
            [FirstCharIsBig]
            [StringLength(12)]
            public string LastName { get; set; }

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
            public virtual ICollection<Changes> Changes { get; set; }

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
            public virtual ICollection<Changes> Changes1 { get; set; }
        }
        public class WorkersChangesReport
        {
            public Report report { get; set; }
            public Changes changes { get; set; }

            public Workers workers { get; set; }
          
        }
    }

    /////
}
