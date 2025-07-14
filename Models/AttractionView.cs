using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeoulStay.Models
{
    public class AttractionView
    {
        public int attractionId { get; set; }
        public string attractionName { get; set; }
        public string area { get; set;}
        public decimal? distance { get; set;}
        public long? byCar { get; set;}
        public long? onFoot { get; set;}


    }
}
