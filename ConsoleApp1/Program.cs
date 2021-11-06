
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
            string Prueba1 = "C:\\Users\\randr\\OneDrive\\Escritorio\\Pruebala.txt";//TEXTO QUE SE QUIERE CIFRAR
            string respuesa = "C:\\Users\\randr\\OneDrive\\Escritorio\\des.txt";//EL TXT DONDE SE VA A GUARDAR
            clase.Read_File(Prueba1, respuesa);

        }
        
    }
}
