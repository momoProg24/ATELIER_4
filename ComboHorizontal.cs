using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atelier_4
{
    internal class ComboHorizontal: IBoite
    {
        public ComboHorizontal(IBoite boiteA, IBoite boiteB)
        {
            BoiteA = boiteA.Cloner();
            BoiteB = boiteB.Cloner();

            int hauteurMax = Math.Max(boiteA.Hauteur, boiteB.Hauteur);
            boiteA.Hauteur = hauteurMax;
            boiteB.Hauteur = hauteurMax;

            Hauteur = hauteurMax;
            Largeur = boiteA.Largeur + boiteB.Largeur + 1;

            boiteA.Redimensionner(Hauteur, boiteA.Largeur);
            boiteB.Redimensionner(Hauteur, Largeur - boiteA.Largeur - 1);
        }

        public int Largeur { get; set; }

        public int Hauteur { get; set; }

        public IBoite BoiteA { get; set; }

        public IBoite BoiteB { get; set; }

        class Énumérateur : IEnumerator<string>
        {
            IEnumerator<string> E1 { get; set; }
            IEnumerator<string> E2 { get; set; }

            public string Current
            {
                get {
                    string contenuA = E1.Current == null ? "" : E1.Current;
                    string contenuB = E2.Current == null ? "" : E2.Current;
                    return contenuA + "|" + contenuB;
                }
            }

            object IEnumerator.Current => throw new NotImplementedException();

            public int indice = -1;

            public Énumérateur(IBoite b1, IBoite b2)
            {
                E1 = b1.GetEnumerator();
                E2 = b2.GetEnumerator();
            }

            public void Dispose()
            {

            }

           public bool MoveNext()
            {
                bool responseB1 = E1.MoveNext();
                bool responseB2 = E2.MoveNext();
                if (responseB1 || responseB2)
                    return true;
                return false;
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }
        }

        public bool EstVide => throw new NotImplementedException();

        public IBoite Cloner() => new Boite(this);

        public IEnumerator<string> GetEnumerator() => new Énumérateur(BoiteA, BoiteB);

        public IEnumerator<string> GetÉnumérateur()
        {
            throw new NotImplementedException();
        }

        public void Redimensionner(int hauteur, int largeur)
        {
            BoiteA.Redimensionner(hauteur, largeur);
            BoiteB.Redimensionner(hauteur, largeur);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
