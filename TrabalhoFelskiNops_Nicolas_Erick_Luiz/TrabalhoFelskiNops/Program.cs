using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace IdentificandoNOPsCerto
{
    class Program
    {
        static void Main(string[] args)
        {

            Verificador Ver = new Verificador();
            Manipulacao Fun = new Manipulacao();

            string textFile = @"ArquivoTeste.txt";

            string[] Vet = File.ReadAllLines(textFile, Encoding.UTF8);
            List<string> lines = Vet.ToList();
            for (int i = 0; i < lines.Count; i++)
            {
                string line = lines[i];
                if (Ver.ValidarRegistrador(line))
                {
                    lines = Fun.Escrever(lines, i);
                    Ver.Nop = false;
                }
            }

            Fun.MostrarNop(lines);
        }
    }
}
