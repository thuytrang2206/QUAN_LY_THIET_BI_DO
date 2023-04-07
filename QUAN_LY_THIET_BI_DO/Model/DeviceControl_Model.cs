using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QUAN_LY_THIET_BI_DO.Model
{
    public partial class DeviceControl_Model : DbContext
    {
        public DeviceControl_Model()
            : base("name=DeviceControl_Model")
        {
        }

        public virtual DbSet<CALIBRATION> CALIBRATIONs { get; set; }
        public virtual DbSet<DEVICE> DEVICEs { get; set; }
        public virtual DbSet<HISTORY_CALIBRATION> HISTORY_CALIBRATIONs { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
