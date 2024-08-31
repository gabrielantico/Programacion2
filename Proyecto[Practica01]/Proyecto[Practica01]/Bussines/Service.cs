using Proyecto_Practica01_.Data;
using Proyecto_Practica01_.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Practica01_.Bussines
{
    public class Service
    {
        private RegisterADO oRegister;

        public Service()
        {
            oRegister = new RegisterADO();
        }

        public int InsertBill(Bill b)
        {
            return oRegister.InsertBill(b);
        }
    }
}
