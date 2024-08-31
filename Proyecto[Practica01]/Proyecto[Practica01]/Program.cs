using Proyecto_Practica01_.Bussines;
using Proyecto_Practica01_.Domain;

namespace Proyecto_Practica01_
{
    public class Program
    {
        static void Main()
        {
            Service manager = new Service();

            Console.WriteLine("Ingrese la tarea que desea ralizar:\n1.Insertar una factura\n2.Salir");
            int result = Convert.ToInt32(Console.ReadLine());

            while (result != 1 && result != 2)
            {
                Console.WriteLine("Ingresó un valor inválido, ingreselo otra vez, por favor\n1.Insertar una factura\n2.Salir");
                result = Convert.ToInt32(Console.ReadLine());
            }

            while (result == 1) 
            {
                //Factura
                Console.WriteLine("Ingrese el método de pago:\n1.Efectivo\n2.Transferencia\n3.QR\n4.Tarjeta de débito\n5.Tarjeta de crédito");
                int payMethod = Convert.ToInt32(Console.ReadLine());
                while (payMethod < 1 && payMethod > 5)
                {
                    Console.WriteLine("Ingresó un valor inválido, ingreselo otra vez, por favor:");
                    payMethod = Convert.ToInt32(Console.ReadLine());
                }
                Console.WriteLine("Ingrese el nombre completo del cliente:");
                string client = Console.ReadLine();

                //Detalle
                Console.WriteLine("Ingrese un detalle de factura:\nArtículo:\n1.Fideos\n2.Alfajor\n3.Chupetín");
                int article = Convert.ToInt32(Console.ReadLine());
                while (article < 1 && article > 3)
                {
                    Console.WriteLine("Ingresó un valor inválido, ingreselo otra vez, por favor:");
                    article = Convert.ToInt32(Console.ReadLine());
                }

                Console.WriteLine("Ingrese la cantidad que se venderá:");
                int count = Convert.ToInt32(Console.ReadLine());

                BillDetail d = new BillDetail();
                d.Article = article;
                d.Count = count;
                Bill b = new Bill(d);
                b.Client = client;
                b.PayMethod = payMethod;

                //Otro detalle
                Console.WriteLine("¿Desea agregar otro detalle?\n1.Sí\n2.No");
                int anotherDetail = Convert.ToInt32(Console.ReadLine());

                while (anotherDetail !=1 && anotherDetail != 2)
                {
                    Console.WriteLine("Ingresó un valor inválido, ingreselo otra vez, por favor\n1.Insertar otro detalle\n2.No insertar más detalles");
                    anotherDetail = Convert.ToInt32(Console.ReadLine());
                }
                while(anotherDetail == 1)
                {
                    Console.WriteLine("Ingrese un artículo\n1.Fideos\n2.Alfajor\n3.Chupetín");
                    article = Convert.ToInt32(Console.ReadLine());
                    while (article < 1 && article > 3)
                    {
                        Console.WriteLine("Ingresó un valor inválido, ingreselo otra vez, por favor:");
                        article = Convert.ToInt32(Console.ReadLine());
                    }

                    Console.WriteLine("Ingrese la cantidad que se venderá:");
                    count = Convert.ToInt32(Console.ReadLine());

                    BillDetail d1 = new BillDetail();
                    d1.Article = article;
                    d1.Count = count;
                    b.AddDetail(d1);

                    Console.WriteLine("¿Desea agregar otro detalle?\n1.Sí\n2.No");
                    anotherDetail = Convert.ToInt32(Console.ReadLine());

                    while (anotherDetail != 1 && anotherDetail != 2)
                    {
                        Console.WriteLine("Ingresó un valor inválido, ingreselo otra vez, por favor\n1.Insertar otro detalle\n2.No insertar más detalles");
                        anotherDetail = Convert.ToInt32(Console.ReadLine());
                    }

                }

                int affectedRows = manager.InsertBill(b);
                if (affectedRows > 0)
                {
                    Console.WriteLine("Se ingresó la factura correctamente");
                }
                else
                {
                    Console.WriteLine("Error al ingresar la factura");
                }

                Console.WriteLine("¿Desea Ingresar otra factura?\n1.Sí\n2.No, salir");
                result = Convert.ToInt32(Console.ReadLine());

                while (result != 1 && result != 2)
                {
                    Console.WriteLine("Ingresó un valor inválido, ingreselo otra vez, por favor\n1.Insertar una factura\n2.Salir");
                    result = Convert.ToInt32(Console.ReadLine());
                }



            }
        }
    }
}
