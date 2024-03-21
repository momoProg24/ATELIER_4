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
            IBoite B1 { get; set; }
            IBoite B2 { get; set; }

            public string Current
            {
                get {
                    string contenuA = B1.GetEnumerator().Current == null ? new string(' ', B2.Largeur) : B1.GetEnumerator().Current;
                    string contenuB = B2.GetEnumerator().Current == null ? new string(' ', B1.Largeur) : B2.GetEnumerator().Current;
                    return contenuA + "|" + contenuB;
                }
            }

            object IEnumerator.Current => throw new NotImplementedException();

            public int indice = -1;

            public Énumérateur(IBoite b1, IBoite b2)
            {
                B1 = b1;
                B2 = b2;
            }

            public void Dispose()
            {

            }

            public bool MoveNext() => B1.GetEnumerator().MoveNext() || B2.GetEnumerator().MoveNext() ? true : false;

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
