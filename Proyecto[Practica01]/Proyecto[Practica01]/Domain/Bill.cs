using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Practica01_.Domain
{
    public class Bill
    {
        private int idBill;
        private string client;
        private int payMethod;
        private List<BillDetail> details;

        public int IdBill { get; set; }
        //public DateTime Date { get; set; }
        public string Client { get; set; }
        //public List<BillDetail> Details { get; set; }
        public int PayMethod { get; set; }


        public Bill(BillDetail d)
        {
            details = new List<BillDetail>();
            details.Add(d);
        }

        public void AddDetail(BillDetail d)
        {
            details.Add(d);
        }

        public void RemoveDetail(int id)
        {
            details.RemoveAt(id);
        }

        public List<BillDetail> GetList()
        {
            return details;
        }
    }
}

