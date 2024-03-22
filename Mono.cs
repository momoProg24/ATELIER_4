using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Atelier_4
{
    internal class Mono : IBoite
    {
        public List<string> msg = new List<string>();

        public Mono(string mot)
        {
            mot = mot.Replace('\r', ' ');
            msg = mot.Split('\n').ToList();
            Largeur = 0;
            foreach (string line in msg)
            {
                if (line.Length > Largeur)
                {
                    Largeur = line.Length; // Mettre à jour la largeur si une ligne plus longue est trouvée
                }
            }
        }
        public int Largeur { get; set; }

        public int Hauteur { get { return msg.Count; } set { } }

        class Énumérateur : IEnumerator<string> // Il va prendre une liste et il va avoir un int Current--MoveNext()
        {
            List<string> list = new List<string>();

            public string Current => list[indice];

            public int indice = -1;

            public Énumérateur(List<string> list)
            {
                this.list = list;
            }

            object IEnumerator.Current => throw new NotImplementedException();

            public void Dispose()
            {

            }

            public bool MoveNext()
            {
                if (indice + 1 < list.Count)
                {
                    indice++;
                    return true;
                }
                return false;
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }
        }

        public bool EstVide => throw new NotImplementedException();

        public IBoite Cloner()
        {
            return new Mono(string.Join("\n", msg));
        }

        public IEnumerator<string> GetEnumerator()
        {
            return new Énumérateur(msg);
        }

        public IEnumerator<string> GetÉnumérateur()
        {
            throw new NotImplementedException();
        }

        public void Redimensionner(int hauteur, int largeur)
        {
            string newMsg = "";
            while(msg.Count < hauteur)
            {
                msg.Add(new string(' ', largeur));
            }
            for(int i = 0; i < msg.Count; i++)
            {
                newMsg = msg[i];
                newMsg.PadRight(largeur, ' ');
                msg[i] = newMsg;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
