namespace Nichicon_PrintLabel.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Nichicon_HistoriesSerial1
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string QR_Code { get; set; }

        [StringLength(50)]
        public string Product_Customer { get; set; }

        [StringLength(50)]
        public string Model { get; set; }

        [StringLength(50)]
        public string Serial { get; set; }

        [StringLength(50)]
        public string Country { get; set; }
    }
}
