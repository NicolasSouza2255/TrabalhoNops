using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentificandoNOPsCerto
{
    class Manipulacao
    {

        public List<string> Teste1(List<string> l, int P)
        {
            List<string> Lista = new List<string>();
            for (int i = 0; i < P; i++)
                Lista.Add(l[i]);

            return Lista;
        }

        public List<string> Teste2(List<string> l, int P)
        {
            List<string> Lista2 = new List<string>();
            Lista2.Add("NOP");
            for (int i = P; i < l.Count; i++)
                Lista2.Add(l[i]);

            return Lista2;
        }

        public List<string> Escrever(List<string> l, int i)
        {
            List<string> Ant = Teste2(l, i);
            List<string> Prox = Teste1(l, i);

            Prox.AddRange(Ant);
            l = Prox;
            return l;
        }

        public void MostrarNop(List<string> lines)
        {
            foreach (string ins in lines)
                Console.WriteLine(ins);

            using (StreamWriter outputFile = new StreamWriter("Resposta.txt"))
            {
                {
                    foreach (string line in lines)
                        outputFile.WriteLine(line);
                }
            }

        }

    }
}
