using System;
using System.Collections.Generic;
using System.Linq;

namespace Atelier_4
{
    public class FabriqueBoites
    {
        public IBoite Créer(string données)
        {
            var lignes = données.Split('\n');
            foreach (var ligne in lignes)
            {
                if (ligne.StartsWith("mono"))
                {
                    // Construction d'un Mono à partir du texte
                    string texte = ligne.Substring(5).Trim();
                    return new Mono(texte);
                }
                else if (ligne.Trim() == "ch")
                {
                    // Construction d'un ComboHorizontal à partir des deux boîtes suivantes
                    var boiteA = Créer(lignes[lignes.ToList().IndexOf(ligne) + 1]);
                    var boiteB = Créer(lignes[lignes.ToList().IndexOf(ligne) + 2]);
                    return new ComboHorizontal(boiteA, boiteB);
                }
                else if (ligne.Trim() == "cv")
                {
                    // Construction d'un ComboVertical à partir des deux boîtes suivantes
                    var boiteA = Créer(lignes[lignes.ToList().IndexOf(ligne)]);
                    var boiteB = Créer(lignes[lignes.ToList().IndexOf(ligne) + 2]);
                    return new ComboVertical(boiteA, boiteB);
                }
            }
            throw new ArgumentException("Données invalides : aucun préfixe trouvé.");
        }
    }
}
