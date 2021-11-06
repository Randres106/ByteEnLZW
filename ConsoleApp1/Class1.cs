using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class Class1
    {
        public byte[] MensajeCaracteres=new byte[12000000];
        public int contador = 0;
        public void Read_File(string ArchivoNuevo, string ArchivoCodificado)
        {
            BitArray NuevoByte = new BitArray(8);
            string ceros = "";

            byte[] Arreglo = new byte[12000000];
            byte[] ArregloPrueba = new byte[12000000];

            long Caracteres = 0;
            int contador = 0;
            using (Stream Text = new FileStream(ArchivoNuevo, FileMode.OpenOrCreate, FileAccess.Read))
            {
                Caracteres = Text.Length;
            }
            using (BinaryReader reader = new BinaryReader(File.Open(ArchivoNuevo, FileMode.Open)))
            {
                foreach (byte nuevo in reader.ReadBytes((int)Caracteres))
                {
                    ArregloPrueba[contador] = nuevo;
                    contador++;
                }
            }

            string[] ArregoString = new string[contador]; //Arreglo con los byte de todo el archivo
            List<string> MensajeCompleto = new List<string>();
            List<string> DiccionarioLista = new List<string>();

            for (int i = 0; i < Caracteres; i++)
            {
                ArregoString[i] = ArregloPrueba[i].ToString();
                MensajeCompleto.Add(ArregloPrueba[i].ToString());
            }

            string[] Diccionario = ArregoString.Distinct().ToArray();//Diccionario inicial del ArregloLZW   `           
            var NumMax = ArregloPrueba.Max();

            for (int i = 0; i < Diccionario.Length; i++)
            {
                DiccionarioLista.Add(Diccionario[i]);
            }

            Compresion(DiccionarioLista, MensajeCompleto, MensajeCompleto[0]);

            using (BinaryWriter writer = new BinaryWriter(File.Open(ArchivoCodificado, FileMode.Create)))
            {
                for (int i = 0; i < Caracteres; i++)
                {
                    writer.Write(MensajeCaracteres[i]);
                }
            }
        }
        public void Compresion(List<string> Diccionario, List<string> Mensaje, string Letras) 
        {
            if (Mensaje.Count!=0)
            {
                if (VerificarEnElDiccioanrio(Diccionario, Letras))
                {
                    int posicion = Posicion(Mensaje, Letras);
                    string letras = Letras + " " + Mensaje[posicion + 1];
                    Compresion(Diccionario, Mensaje, letras);
                }
                else
                {
                    Diccionario.Add(Letras);

                    string[] LetrasSeparadas = Letras.Split(" ");

                    for (int i = 0; i < LetrasSeparadas.Length - 1; i++)
                    {
                        Mensaje.RemoveAt(0);
                        MensajeCaracteres[contador] = Convert.ToByte(Posicion(Diccionario, LetrasSeparadas[i]));
                        contador++;
                    }

                    Compresion(Diccionario, Mensaje, Mensaje[0]);

                }
            }
        }
        public int Posicion(List<string> Mensaje, string letras)
        {
            for (int i = 0; i < Mensaje.Count; i++)
            {
                if (Mensaje[i]==letras)
                {
                    return i;
                }
            }
            return default;
        }

        public bool VerificarEnElDiccioanrio(List<string> Diccionario, string numeros) 
        {
            for (int i = 0; i < Diccionario.Count; i++)
            {
                if (Diccionario[i] == numeros)
                {
                    return true;
                }
            }
            return false;
        }
        public void Descompresion() 
        {

        }
    }
}
