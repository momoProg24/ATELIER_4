using Atelier_4;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atelier_4
{
    internal class Boite : IBoite
    {

        IBoite boiteMain;
        public Boite(IBoite boite)
        {
            
        }

        public Boite(string s)
        {
            boiteMain = new Mono(s);
        }
        public int Largeur => boiteMain.Largeur;

        public int Hauteur => throw new NotImplementedException();

        public bool EstVide => throw new NotImplementedException();

        public IBoite Cloner()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            string boite = "";
            boite += "+";
            boite += new string('-', boiteMain.Largeur) + "+";
            boite += '\n';

            foreach (string str in boiteMain)
            {
                boite += "|" + str;
                boite += new string(' ', boiteMain.Largeur - str.Length);
                boite += "|" + '\n';
            }
            boite += "+";
            boite += new string('-', boiteMain.Largeur) + "+";
            boite += "\n";
            return boite;
        }

        public IEnumerator<string> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<string> GetÉnumérateur()
        {
            throw new NotImplementedException();
        }

        public void Redimensionner(int hauteur, int largeur)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
