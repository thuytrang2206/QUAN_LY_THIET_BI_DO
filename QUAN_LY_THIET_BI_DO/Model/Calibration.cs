namespace QUAN_LY_THIET_BI_DO.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CALIBRATION")]
    public partial class CALIBRATION
    {
        [Key]
        [StringLength(50)]
        public string PART_NO { get; set; }

        [Column(TypeName = "date")]
        public DateTime CALI_DATE { get; set; }

        [Column(TypeName = "date")]
        public DateTime CALI_RECOMMEND { get; set; }
        public bool STATUS { get; set; }
    }
}
