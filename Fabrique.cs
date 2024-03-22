using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boites
{
    public class FabriqueBoites
    {
        public IBoite Créer(string données)
        {
            return ParseLignes(données);
        }

        public IBoite ParseLignes(string données)
        {
            var lignes = données.Split('\n');
            Queue<string> fileLignes = new Queue<string>(lignes);

            while (fileLignes.Count > 0)
            {
                string ligne = fileLignes.Dequeue().Trim();
                if (ligne.StartsWith("mono"))
                {
                    string texte = ligne.Substring(5).Trim();
                    return new Mono(texte);
                }
                else if (ligne == "ch")
                {
                    var boiteA = ParseLignes(fileLignes.Dequeue());
                    var boiteB = ParseLignes(fileLignes.Dequeue());
                    return new ComboHorizontal(boiteA, boiteB);
                }
                else if (ligne == "cv")
                {
                    var boiteA = ParseLignes(fileLignes.Dequeue());
                    var boiteB = ParseLignes(fileLignes.Dequeue());
                    return new ComboVertical(boiteA, boiteB);
                }
            }

            throw new ArgumentException("Données invalides : aucun préfixe trouvé.");
        }
    }
}