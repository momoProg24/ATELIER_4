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

namespace Atelier_4
{
    enum État { début, milieu, fin };
    internal class ComboVertical : IBoite
    {
        public ComboVertical(IBoite boiteA, IBoite boiteB) 
        {
            BoiteA = boiteA.Cloner();
            BoiteB = boiteB.Cloner();
        }

        public int Largeur {  get; set; }

        public int Hauteur { get; set; }

        public IBoite BoiteA { get; set; }

        public IBoite BoiteB { get; set; }

        public État GetPositionActuel(int idx)
        {
            if(idx == 1) return État.début;
            if(idx == Hauteur / 2) return État.milieu;
            if(idx == Hauteur) return État.fin;
            return État.début;
        }

        class Énumérateur : IEnumerator<string>
        {
            IBoite B1 { get; set; }
            IBoite B2 { get; set; }

            IEnumerator<string> currentEnum {  get; set; }
            
            bool isMillieu = false;

            public string Current { 
                get {
                    if (isMillieu) return new string('-', Math.Max(B1.Largeur, B2.Largeur));
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
                throw new NotImplementedException();
            }

            public bool MoveNext()
            {
                if (currentEnum.MoveNext()) return true;
                else
                {
                    list.RemoveAt(0);
                    if (list.Count == 1)
                    {
                        isMillieu = true;
                        currentEnum = B2.GetEnumerator();
                        if (currentEnum.MoveNext())
                        {
                            isMillieu = false;
                            return true;
                        }
                        else return false;
                    }
                    else return false;
                }
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }
        }

        public bool EstVide => throw new NotImplementedException();

        public IBoite Cloner()
        {
            return new Boite(this);
        }

        public IEnumerator<string> GetEnumerator()
        {
            return new Énumérateur(BoiteA, BoiteB);
        }

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
