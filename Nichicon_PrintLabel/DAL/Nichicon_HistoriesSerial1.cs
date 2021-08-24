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

        public string QR_Code { get; set; }
        public string Product_Customer { get; set; }
        public string Model { get; set; }
        public string Serial { get; set; }
        public string Country { get; set; }
    }

}
