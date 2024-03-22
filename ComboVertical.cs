using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Boites
{
    internal class ComboVertical : IBoite
    {
        public ComboVertical(IBoite boiteA, IBoite boiteB) 
        {
            BoiteA = boiteA.Cloner();
            BoiteB = boiteB.Cloner();

            int largeurMax = Math.Max(boiteA.Largeur, boiteB.Largeur);
            boiteA.Largeur = largeurMax;
            boiteB.Largeur = largeurMax;

            Largeur = largeurMax;
            Hauteur = boiteA.Hauteur + 1 + boiteB.Hauteur;

            boiteA.Redimensionner(boiteA.Hauteur, Largeur);
            boiteB.Redimensionner(Hauteur - boiteA.Hauteur - 1, Largeur);
        }

        public int Largeur {  get; set; }

        public int Hauteur { get; set; }

        public IBoite BoiteA { get; set; }

        public IBoite BoiteB { get; set; }

        class Énumérateur : IEnumerator<string>
        {
            IBoite B1 { get; set; }
            IBoite B2 { get; set; }

            IEnumerator<string> currentEnum {  get; set; }
            
            bool isMillieu = false;

            public string Current { 
                get {
                    if (isMillieu) 
                    {
                        isMillieu = false;
                        return new string('-', Math.Max(B1.Largeur, B2.Largeur)); 
                    }
                    else return currentEnum.Current;
                }
                set { Current = value; }
             }

            object IEnumerator.Current => throw new NotImplementedException();

            List<IBoite> list = new List<IBoite>();

            public int indice = 1;

            public Énumérateur(IBoite b1, IBoite b2)
            {
                B1 = b1;
                list.Add(b1);
                B2 = b2;
                list.Add(b2);
                currentEnum = B1.GetEnumerator();
            }

            public void Dispose()
            {
                
            }

            public bool MoveNext()
            {
                if (currentEnum.MoveNext()) return true;
                else if (list.Count > 1)
                {
                    list.RemoveAt(0);
                    if (list.Count == 1)
                    {
                        isMillieu = true;
                        currentEnum = B2.GetEnumerator();
                        return true;
                    }
                    else return false;
                }
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
