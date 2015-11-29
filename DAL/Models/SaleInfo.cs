using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class SaleInfo
    {
        public int ID_Sale { get; set; }
        public string SaleDate { get; set; }
        public Nullable<int> ID_Manager { get; set; }
        public Nullable<int> ID_Client { get; set; }
        public Nullable<int> ID_Product { get; set; }
    }
}
