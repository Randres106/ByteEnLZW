
using System;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Class1 clase = new Class1();

            Console.WriteLine("Hello World!");
            string Prueba1 = "C:\\Users\\randr\\OneDrive\\Escritorio\\hard-test.txt";
            string respuesa = "C:\\Users\\randr\\OneDrive\\Escritorio\\Resultado.txt";
            clase.Read_File(Prueba1, respuesa);

        }
        
    }
}
