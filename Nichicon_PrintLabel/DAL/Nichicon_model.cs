namespace Nichicon_PrintLabel.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Nichicon_model
    {
        [StringLength(50)]
        public string ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Model_Name { get; set; }

        [StringLength(50)]
        public string Product_Name { get; set; }

        [StringLength(50)]
        public string Product_ManagerName { get; set; }

        [StringLength(50)]
        public string Code_productcustomer { get; set; }

        [StringLength(50)]
        public string Users { get; set; }

        public bool? Status { get; set; }
    }
}
