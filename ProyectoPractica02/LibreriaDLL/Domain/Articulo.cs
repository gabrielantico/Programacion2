namespace LibreriaDLL.Domain
{
    public class Articulo
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public decimal PreUnitario { get; set; }

        public override string ToString()
        {
            return "[" + Codigo + "] " + Nombre + " Precio: " + PreUnitario;
        }
    }
}
