namespace Nichicon_PrintLabel.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Nichicon_Users
    {
        [Key]
        [StringLength(50)]
        public string USER_NAME { get; set; }

        [StringLength(50)]
        public string PASSWORD { get; set; }

        [StringLength(50)]
        public string DES { get; set; }

        [StringLength(50)]
        public string CREATE_BY { get; set; }

        public DateTime? CREATE_DATE { get; set; }
    }
}
