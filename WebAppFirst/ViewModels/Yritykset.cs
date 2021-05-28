using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebAppFirst.Models;

namespace WebAppFirst.ViewModels
{
    public class Yritykset
    {
        public Yritykset()
        {
            this.Orders = new HashSet<Yritykset>();
        }

        public int ShipperID { get; set; }
        public Nullable<int> RegionID { get; set; }
        [Display(Name = "Yritys")]
        public string CompanyName { get; set; }
        public string Phone { get; set; }

     
        public string RegionDescription { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Yritykset> Orders { get; set; }
        public virtual Region Region { get; set; }
    }
}