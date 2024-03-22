using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Boites
{
    internal class Boite : IBoite
    {

        IBoite boiteMain;

        public Boite() 
        {
            boiteMain = new Boite("");
        }

        public Boite(IBoite boite)
        {

            boiteMain = boite;

        }

        public Boite(string s)
        {
            boiteMain = new Mono(s);
        }

        public bool EstVide => throw new NotImplementedException();

        public int Largeur { get { return boiteMain.Largeur; } set { boiteMain.Largeur = value; } }
        public int Hauteur { get { return boiteMain.Hauteur; } set { boiteMain.Hauteur = value; } }

        public IBoite Cloner()
        {
            return new Boite(this);
        }

        public override string ToString()
        {
            string boite = "";
            boite += "+";
            boite += new string('-', boiteMain.Largeur) + "+";
            boite += '\n';

            foreach (string str in boiteMain)
            {
                if (!string.IsNullOrWhiteSpace(str))
                {
                    boite += "|" + str;
                    boite += new string(' ', boiteMain.Largeur - str.Length);
                    boite += "|" + '\n';
                }
            }
            boite += "+";
            boite += new string('-', boiteMain.Largeur) + "+";
            boite += "\n";
            return boite;
        }

        public IEnumerator<string> GetEnumerator()
        {
            return boiteMain.GetEnumerator();
        }

        public IEnumerator<string> GetÉnumérateur()
        {
            throw new NotImplementedException();
        }

        public void Redimensionner(int hauteur, int largeur)
        {
            boiteMain.Redimensionner(hauteur, largeur);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
