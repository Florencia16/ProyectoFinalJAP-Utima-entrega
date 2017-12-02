using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerceraEntrega.BL
{
    public static class InputUtils
    {

        public static string leerString()
        {
            string result = Console.ReadLine();
            while (result == null || result == "")
            {
                Console.WriteLine("El valor ingresado es incorrecto");
                result = Console.ReadLine();
            }
            return result;
        }

        public static int leerInt()
        {
            int resultado = 0;
            string result = Console.ReadLine();
            while (result == null || result == "" || !int.TryParse(result, out resultado))
            {
                Console.WriteLine("El valor ingresado es incorrecto.");
                result = Console.ReadLine();
            }
            return resultado;
        }

        public static int leerInt(int inicio, int fin)
        {
            int resultado = 0;
            string result = Console.ReadLine();
            while (result == null || result == "" || !int.TryParse(result, out resultado) || resultado < inicio || resultado > fin)
            {
                Console.WriteLine("El valor ingresado es incorrecto.");
                result = Console.ReadLine();
            }
            return resultado;
        }

        public static int leerId()
        {
            int resultado = 0;
            string result = Console.ReadLine();
            while (result == null || result == "" || !int.TryParse(result, out resultado) || resultado <= 0)
            {
                Console.WriteLine("El valor ingresado es incorrecto.");
                result = Console.ReadLine();
            }
            return resultado;
        }

        public static int leerNivel()
        {
            int resultado = 0;
            string result = Console.ReadLine();
            while (result == null || result == "" || !int.TryParse(result, out resultado) || resultado <= 0)
            {
                Console.WriteLine("El valor ingresado es incorrecto.");
                result = Console.ReadLine();
            }
            return resultado;
        }

       

    }
}
