namespace QUAN_LY_THIET_BI_DO.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DEVICE")]
    public partial class DEVICE
    {
        [Key]
        [StringLength(300)]
        public string PART_NO { get; set; }

        [Required]
        [StringLength(300)]
        public string PART_NAME { get; set; }

        [Required]
        [StringLength(64)]
        public string SAP_BARCODE { get; set; }

        [Required]
        [StringLength(64)]
        public string MODEL { get; set; }

        [Required]
        [StringLength(64)]
        public string SERIAL { get; set; }

        [Required]
        [StringLength(64)]
        public string MANUFACTORY { get; set; }

        public int CALI_CYCLE { get; set; }

        [Column(TypeName = "date")]
        public DateTime REGISTRATION_DATE { get; set; }

        [StringLength(64)]
        public string DEPT_CONTROL { get; set; }

        [Required]
        [StringLength(64)]
        public string PLACE_USE { get; set; }

        [Required]
        [StringLength(64)]
        public string CONTROL_MNG { get; set; }

        [Required]
        [StringLength(64)]
        public string MAKER { get; set; }

        [Required]
        [StringLength(100)]
        public string ENQUIP_STATE { get; set; }

        [Required]
        [StringLength(64)]
        public string RMK { get; set; }

        public bool STATUS { get; set; }

        [Required]
        [StringLength(200)]
        public string PAYMENT { get; set; }

        [Required]
        [StringLength(64)]
        public string LINE { get; set; }

        [Required]
        [StringLength(300)]
        public string FCT_NO { get; set; }

        [Required]
        [StringLength(300)]
        public string MODEL_UMC { get; set; }

        [StringLength(500)]
        public string PDF_FILE { get; set; }

    }
}
