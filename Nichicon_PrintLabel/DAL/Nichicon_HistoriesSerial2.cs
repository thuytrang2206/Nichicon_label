namespace Nichicon_PrintLabel.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Nichicon_HistoriesSerial2
    {
        
        public int ID { get; set; }
        public string QR_Code { get; set; }
        public string Model { get; set; }
        public string Product_Name { get; set; }
        public string Code_productcustomer { get; set; }
        public string Product_Customer { get; set; }
    }
    public class HistoryEntity
    {
        public string QR_Code { get; set; }
        public string Model { get; set; }
        public string Product_Name { get; set; }
        public string Code_productcustomer { get; set; }
        public string Product_Customer { get; set; }
    }
}
