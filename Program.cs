using Boites;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

static void TestFabriques()
{

    var p = new FabriqueBoites().Créer("mono J'aime mon \"prof\"");
    Console.WriteLine(new Boite(p));


    p = new FabriqueBoites().Créer("cv\nmono J'aime mon \"prof\"\nmono moi itou");
    Console.WriteLine(new Boite(p));

    p = new FabriqueBoites().Créer("ch\nmono J'aime mon \"prof\"\nmono moi itou");
    Console.WriteLine(new Boite(p));
}

TestFabriques();