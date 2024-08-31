using Proyecto_Practica01_.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Practica01_.Data
{
    public class RegisterADO : IRegister
    {
        public int InsertBill(Bill b)
        {
            int affectedRows;

            DataHelper helper;
            helper = DataHelper.GetHelper();

            affectedRows = helper.InsertBill(b);

            return affectedRows;
        }
    }
}
