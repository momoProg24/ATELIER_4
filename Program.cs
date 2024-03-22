using System;
using Atelier_4;

<<<<<<< HEAD
static void TestFabriques()
{
    var p = new FabriqueBoites().Créer("mono J'aime mon \"prof\"");
    Console.WriteLine(new Boite(p));
    p = new FabriqueBoites().Créer("cv\nmono J'aime mon \"prof\"\nmono moi itou");
    Console.WriteLine(new Boite(p));
    /*
    p = new FabriqueBoites().Créer("ch\nmono J'aime mon \"prof\"\nmono moi itou");
    Console.WriteLine(new Boite(p));
    */
    p = new FabriqueBoites().Créer(
       "ch\ncv\nmono J'aime mon \"prof\"\nmono moi itou\nmono eh ben");
    Console.WriteLine(new Boite(p));
    p = new FabriqueBoites().Créer(
       "ch\ncv\nmc\nmono J'aime mon \"prof\"\nmono moi itou\nmono eh ben");
    Console.WriteLine(new Boite(p));
}
=======
//Boite b = new();
//Console.WriteLine(b);
//Console.WriteLine(new Boite("yo"));
string texte = @"Man! Hey!!!
ceci est un test
multiligne";
string autTexte = "Ceci\nitou, genre";
Boite b0 = new(texte);
Boite b1 = new(autTexte);
//Console.WriteLine(b0);
//Console.WriteLine(b1);
//ComboVertical cv = new(b0, b1);
//Console.WriteLine(new Boite(cv));
>>>>>>> main


<<<<<<< HEAD
TestFabriques();
=======
//Console.WriteLine(
//   new Boite(new ComboVertical(new Boite(), new Boite()))
//);
//Console.WriteLine(
//   new Boite(new ComboVertical(new Boite("Yip"), new Boite()))
//);
//Console.WriteLine(
//   new Boite(new ComboVertical(new Boite(), new Boite("Yap")))
//);
>>>>>>> main
