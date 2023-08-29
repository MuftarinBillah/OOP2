using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entity
{
    public class Eproduct
    {

        public string ProdId { set; get; }

        public string ProdNam { set; get; }

        public Int32 ProdPrice { set; get; }

        public Int32 ProdQty { set; get; }

        public string ProdCat { set; get; }

    }
}
