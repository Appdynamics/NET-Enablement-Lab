namespace JobManagement
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Job
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int jobid { get; set; }

        [Required]
        [StringLength(100)]
        public string guid { get; set; }

        [Required]
        [StringLength(100)]
        public string type { get; set; }

        public int status { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string data { get; set; }
    }
}
