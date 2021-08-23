namespace Nichicon_PrintLabel.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Nichicon_ItemSeiral1
    {
        [Key]
        [StringLength(50)]
        public string Model_Name { get; set; }

        [StringLength(50)]
        public string BarCode_Last { get; set; }

        [StringLength(50)]
        public string Product { get; set; }

        [StringLength(50)]
        public string Product_manager { get; set; }

        public DateTime? Create_Date { get; set; }

        [StringLength(50)]
        public string Code_productcustomer { get; set; }
    }
}
