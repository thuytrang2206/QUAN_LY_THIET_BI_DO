
namespace QUAN_LY_THIET_BI_DO.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HISTORY_CALIBRATION")]
    public partial class HISTORY_CALIBRATION
    {
        [Key]
        public int ID  { get; set; }
        public string PART_NO { get; set; }
        public string PART_NAME { get; set; }
        public string SERIAL { get; set; }
        [Column(TypeName = "date")]
        public DateTime DATE_CHECK { get; set; }
    }
}
