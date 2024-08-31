using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Practica01_.Domain
{
    public class Article
    {
        private int idArticle;
        private string name;
        private float unitaryPrice;

        public int IdArticle { get; set; }
        public string Name { get; set; }
        public float UnitaryPrice { get; set; }
    }
}
