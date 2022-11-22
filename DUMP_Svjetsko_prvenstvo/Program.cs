
using System.Runtime.Versioning;

var listOfPlayers = new Dictionary<string, (string Pozicija, int Rating)>()
{
    {"Luka Modrić",("MF",88) },
    {"Marcelo Brozović",("DF",86) },
    {"Mateo Kovačić",("MF",84) },
    {"Ivan Perišić",("MF",84) },
    { "Andrej Kramarić",("FW", 82) },
    { "Ivan Rakitić",("MF", 82) },
    { "Joško Gvardiol",("DF", 81) },
    { "Mario Pašalić",("FW", 81) },
    { "Lovro Majer",("FW", 80) },
    { "Dominik Livaković",("GK", 80) },

    { "Ante Rebić",("FW", 80) },
    { "Josip Brekalo",("FW", 79) },
    { "Borna Sosa",("DF", 78) },
    { "Nikola Vlašić",("FW", 78) },
    { "Duje Ćaleta-Car",("DF", 78) },
    { "Dejan Lovren",("DF", 78) },
    { "Mislav Oršić",("MF", 77) },
    { "Marko Livaja",("FW", 77) },
    { "Domagoj Vida",("DF", 76) },
    { "Ante Budimir",("FW", 76) }
};

var action="";
var brojacUtakmica = 0;

Dictionary<string, int> igraciDF = new Dictionary<string, int>();
foreach (var item in listOfPlayers)
{
    if (listOfPlayers[item.Key].Pozicija=="DF")
    {
        igraciDF.Add(item.Key,item.Value.Rating);
    }
}

Dictionary<string, int> igraciFW = new Dictionary<string, int>();
foreach (var item in listOfPlayers)
{
    if (listOfPlayers[item.Key].Pozicija == "FW")
    {
        igraciFW.Add(item.Key, item.Value.Rating);
    }
}

Dictionary<string, int> igraciMF = new Dictionary<string, int>();
foreach (var item in listOfPlayers)
{
    if (listOfPlayers[item.Key].Pozicija == "MF")
    {
        igraciMF.Add(item.Key, item.Value.Rating);
    }
}

Dictionary<string, int> igraciGK = new Dictionary<string, int>();
foreach (var item in listOfPlayers)
{
    if (listOfPlayers[item.Key].Pozicija == "GK")
    {
        igraciGK.Add(item.Key, item.Value.Rating);
    }
}


var skupina = new Dictionary<string, (int Bodovi,int PrvaUtakmica,int DrugaUtakmica,int TrecaUtakmica)>()
{
    {"Belgija",(0,0,0,0) },
    {"Kanada",(0, 0, 0, 0) },
    {"Hrvatska",(0, 0, 0, 0) },
    {"Maroko",(0, 0, 0, 0) }
};

Dictionary<string, int> strijelci = new Dictionary<string, int>();




//pocetak
do
{
    Console.Clear();
    Console.WriteLine("Odaberite akciju:");
    Console.WriteLine("1 - Odradi trening\n2 - Odigraj utakmicu\n3 - Statistika\n4 - Kontrola igrača\n0 - Izlaz iz aplikacije");
    action = Console.ReadLine();
} while (action!="1"&& action != "2" && action != "3" && action != "4" && action != "0" );



switch (action)
{
    case "1":
        OdradiTrening();
        break;

    case "2":
        if (brojacUtakmica >= 3)
        {
            Console.WriteLine("Odigrane su sve utakmice");
            PovratakNaGlavniIzbornik();
            break;
        }
        else
        {
            OdigrajUtakmicu();
            break;
        }

    case "3":
        Statistika();
        break;

    case "4":
        KontrolaIgraca();
        break;

    case "0":
        Console.Clear();
        Console.WriteLine("Izasli ste iz aplikacije");
        break;

    default:
        Console.WriteLine("Neispravan unos");
        break;
}



//povratak na glavni izbornik
void PovratakNaGlavniIzbornik()
{
    do
    {
        Console.Clear();
        Console.WriteLine("Odaberite akciju:");
        Console.WriteLine("1 - Odradi trening\n2 - Odigraj utakmicu\n3 - Statistika\n4 - Kontrola igrača\n0 - Izlaz iz aplikacije");
        action = Console.ReadLine();
    } while (action != "1" && action != "2" && action != "3" && action != "4" && action != "0");



    switch (action)
    {
        case "1":
            OdradiTrening();
            break;

        case "2":
            if (brojacUtakmica >= 3)
            {
                Console.WriteLine("Odigrane su sve utakmice");
                var povratak = "";
                do
                {
                    Console.WriteLine("Pritisnite 0 za povratak na glavni izbornik");
                    povratak = Console.ReadLine();
                } while (povratak != "0");
                PovratakNaGlavniIzbornik();
                break;
            }
            else
            {
                OdigrajUtakmicu();
                break;
            }

        case "3":
            Statistika();
            break;

        case "4":
            KontrolaIgraca();
            break;

        case "0":
            Console.Clear();
            Console.WriteLine("Izasli ste iz aplikacije");
            break;

        default:
            Console.WriteLine("Neispravan unos");
            break;
    }
}





//PRVA AKCIJA
void OdradiTrening()
{
    foreach (var player in listOfPlayers)
    {
        //var ratingBefore = igrac.Value.Rating;
        Random rnd = new Random();
        int percentage = rnd.Next(-5,6);
        int noviRating =player.Value.Rating*(100-percentage)/100;
        Console.WriteLine($"{player.Key} početni rating: {player.Value.Rating.ToString()} i rating nakon treninga {noviRating}");
        listOfPlayers[player.Key] = (player.Value.Pozicija,noviRating);
    }

    var povratak = "";
    do
    {
        Console.WriteLine("Pritisnite 0 za povratak na glavni izbornik");
        povratak = Console.ReadLine();
    } while (povratak != "0");
    PovratakNaGlavniIzbornik();

}





//DRUGA AKCIJA
void OdigrajUtakmicu()
{
    brojacUtakmica += 1;


    //popisi igraca po pozicijama
    List<string> igraciUtakmice = new List<string>();

    List<int> listaIgracaDF = new List<int>();
    foreach (var item in igraciDF)
    {
        listaIgracaDF.Add(item.Value);
    }
    listaIgracaDF.Sort();
    var duljinaListeDF = listaIgracaDF.Count();
    for (int i = 1; i < 5; i++)
    {
        foreach (var item in igraciDF)
        {
            if (item.Value == listaIgracaDF[duljinaListeDF - i] && !(igraciUtakmice.Contains(item.Key)))
            {
                igraciUtakmice.Add(item.Key);
            }
        }
    }

    List<int> listaIgracaMF = new List<int>();
    foreach (var item in igraciMF)
    {
        listaIgracaMF.Add(item.Value);
    }
    listaIgracaMF.Sort();
    var duljinaListeMF = listaIgracaMF.Count();
    for (int i = 1; i < 4; i++)
    {
        foreach (var item in igraciMF)
        {
            if (item.Value == listaIgracaMF[duljinaListeMF - i] && !(igraciUtakmice.Contains(item.Key)))
            {
                igraciUtakmice.Add(item.Key);
            }
        }
    }

    List<int> listaIgracaFW = new List<int>();
    foreach (var item in igraciFW)
    {
        listaIgracaFW.Add(item.Value);
    }
    listaIgracaFW.Sort();
    var duljinaListeFW = listaIgracaFW.Count();
    for (int i = 1; i < 4; i++)
    {
        foreach (var item in igraciFW)
        {
            if (item.Value == listaIgracaFW[duljinaListeFW - i] && !(igraciUtakmice.Contains(item.Key)))
            {
                igraciUtakmice.Add(item.Key);
            }
        }
    }

    List<int> listaIgracaGK = new List<int>();
    foreach (var item in igraciGK)
    {
        listaIgracaGK.Add(item.Value);
    }
    listaIgracaGK.Sort();
    var duljinaListeGK = listaIgracaGK.Count();
    foreach (var item in igraciGK)
    {
        if (item.Value == listaIgracaGK[duljinaListeGK - 1] && !(igraciUtakmice.Contains(item.Key)))
        {
            igraciUtakmice.Add(item.Key);
        }
    }

    //rezultati utakmice nakon svakog kola (?valjda se to zove kolo)
    int[] golovi = new int[4];
    for (int i = 0; i < 4; i++)
    {
        Random g = new Random();
        golovi[i] = g.Next(0, 10);
    }

    if (brojacUtakmica==1)//prvo kolo
    {
        if (golovi[0] < golovi[1])
        {
            skupina["Hrvatska"]= (skupina["Hrvatska"].Bodovi + 3, skupina["Hrvatska"].PrvaUtakmica, skupina["Hrvatska"].DrugaUtakmica, skupina["Hrvatska"].TrecaUtakmica);
            foreach (var item in igraciUtakmice)
            {
                listOfPlayers[item] = (listOfPlayers[item].Pozicija, (102 * listOfPlayers[item].Rating) / 100);
            }
        }
        else if (golovi[0] > golovi[1])
        {
            skupina["Maroko"] = (skupina["Maroko"].Bodovi + 3, skupina["Maroko"].PrvaUtakmica, skupina["Maroko"].DrugaUtakmica, skupina["Maroko"].TrecaUtakmica);
            foreach (var item in igraciUtakmice)
            {
                listOfPlayers[item] = (listOfPlayers[item].Pozicija, (98 * listOfPlayers[item].Rating) / 100);
            }
        }
        else
        {
            skupina["Maroko"] = (skupina["Maroko"].Bodovi + 1, skupina["Maroko"].PrvaUtakmica, skupina["Maroko"].DrugaUtakmica, skupina["Maroko"].TrecaUtakmica);
            skupina["Hrvatska"] = (skupina["Hrvatska"].Bodovi + 1, skupina["Hrvatska"].PrvaUtakmica, skupina["Hrvatska"].DrugaUtakmica, skupina["Hrvatska"].TrecaUtakmica);
        }

        if (golovi[2] < golovi[3])
        {
            skupina["Kanada"] = (skupina["Kanada"].Bodovi + 3, skupina["Kanada"].PrvaUtakmica, skupina["Kanada"].DrugaUtakmica, skupina["Kanada"].TrecaUtakmica);
        }
        else if (golovi[2] > golovi[3])
        {
            skupina["Belgija"] = (skupina["Belgija"].Bodovi + 3, skupina["Belgija"].PrvaUtakmica, skupina["Belgija"].DrugaUtakmica, skupina["Belgija"].TrecaUtakmica);
        }
        else
        {
            skupina["Belgija"] = (skupina["Belgija"].Bodovi + 1, skupina["Belgija"].PrvaUtakmica, skupina["Belgija"].DrugaUtakmica, skupina["Belgija"].TrecaUtakmica);
            skupina["Kanada"] = (skupina["Kanada"].Bodovi + 1, skupina["Kanada"].PrvaUtakmica, skupina["Kanada"].DrugaUtakmica, skupina["Kanada"].TrecaUtakmica);
        }

        skupina["Belgija"] = (skupina["Belgija"].Bodovi, skupina["Belgija"].PrvaUtakmica + golovi[2], skupina["Belgija"].DrugaUtakmica, skupina["Belgija"].TrecaUtakmica);
        skupina["Hrvatska"] = (skupina["Hrvatska"].Bodovi, skupina["Hrvatska"].PrvaUtakmica + golovi[1], skupina["Hrvatska"].DrugaUtakmica, skupina["Hrvatska"].TrecaUtakmica);
        skupina["Kanada"] = (skupina["Kanada"].Bodovi, skupina["Kanada"].PrvaUtakmica + golovi[3], skupina["Kanada"].DrugaUtakmica, skupina["Kanada"].TrecaUtakmica);
        skupina["Maroko"] = (skupina["Maroko"].Bodovi, skupina["Maroko"].PrvaUtakmica + golovi[0], skupina["Maroko"].DrugaUtakmica, skupina["Maroko"].TrecaUtakmica);


        for (int i = 0; i < golovi[1]; i++)
        {
            Random rnd = new Random();
            int s = rnd.Next(0, 11);
            string strijelac = igraciUtakmice[s];
            if (!(strijelci.ContainsKey(strijelac)))
            {
                strijelci.Add(strijelac, 1);
            }
            else
            {
                strijelci[strijelac] += 1;
            }
            listOfPlayers[strijelac] = (listOfPlayers[strijelac].Pozicija,(105* listOfPlayers[strijelac].Rating)/100);
        }

        Console.WriteLine($"Rezultati {brojacUtakmica}. kola Skupine F: ");
        Console.WriteLine($"Maroko {golovi[0]} / {golovi[1]} Hrvatska\nBelgija {golovi[2]} / {golovi[3]} Kanada");


    }
    else if (brojacUtakmica==2)//drugo kolo
    {
        if (golovi[0] < golovi[1])
        {
            skupina["Maroko"] = (skupina["Maroko"].Bodovi + 3, skupina["Maroko"].PrvaUtakmica, skupina["Maroko"].DrugaUtakmica, skupina["Maroko"].TrecaUtakmica);
        }
        else if (golovi[0] > golovi[1])
        {
            skupina["Belgija"] = (skupina["Belgija"].Bodovi + 3, skupina["Belgija"].PrvaUtakmica, skupina["Belgija"].DrugaUtakmica, skupina["Belgija"].TrecaUtakmica);
        }
        else
        {
            skupina["Maroko"] = (skupina["Maroko"].Bodovi + 1, skupina["Maroko"].PrvaUtakmica, skupina["Maroko"].DrugaUtakmica, skupina["Maroko"].TrecaUtakmica);
            skupina["Belgija"] = (skupina["Belgija"].Bodovi + 1, skupina["Belgija"].PrvaUtakmica, skupina["Belgija"].DrugaUtakmica, skupina["Belgija"].TrecaUtakmica);
        }

        if (golovi[2] < golovi[3])
        {
            skupina["Kanada"] = (skupina["Kanada"].Bodovi + 3, skupina["Kanada"].PrvaUtakmica, skupina["Kanada"].DrugaUtakmica, skupina["Kanada"].TrecaUtakmica);
            foreach (var item in igraciUtakmice)
            {
                listOfPlayers[item] = (listOfPlayers[item].Pozicija, (98 * listOfPlayers[item].Rating) / 100);
            }
        }
        else if (golovi[2] > golovi[3])
        {
            skupina["Hrvatska"] = (skupina["Hrvatska"].Bodovi + 3, skupina["Hrvatska"].PrvaUtakmica, skupina["Hrvatska"].DrugaUtakmica, skupina["Hrvatska"].TrecaUtakmica);
            foreach (var item in igraciUtakmice)
            {
                listOfPlayers[item] = (listOfPlayers[item].Pozicija, (102 * listOfPlayers[item].Rating) / 100);
            }
        }
        else
        {
            skupina["Hrvatska"] = (skupina["Hrvatska"].Bodovi + 1, skupina["Hrvatska"].PrvaUtakmica, skupina["Hrvatska"].DrugaUtakmica, skupina["Hrvatska"].TrecaUtakmica);
            skupina["Kanada"] = (skupina["Kanada"].Bodovi + 1, skupina["Kanada"].PrvaUtakmica, skupina["Kanada"].DrugaUtakmica, skupina["Kanada"].TrecaUtakmica);
        }

        skupina["Belgija"] = (skupina["Belgija"].Bodovi, skupina["Belgija"].PrvaUtakmica, skupina["Belgija"].DrugaUtakmica + golovi[0], skupina["Belgija"].TrecaUtakmica);
        skupina["Hrvatska"] = (skupina["Hrvatska"].Bodovi, skupina["Hrvatska"].PrvaUtakmica, skupina["Hrvatska"].DrugaUtakmica + golovi[2], skupina["Hrvatska"].TrecaUtakmica);
        skupina["Kanada"] = (skupina["Kanada"].Bodovi, skupina["Kanada"].PrvaUtakmica, skupina["Kanada"].DrugaUtakmica + golovi[3], skupina["Kanada"].TrecaUtakmica);
        skupina["Maroko"] = (skupina["Maroko"].Bodovi, skupina["Maroko"].PrvaUtakmica, skupina["Maroko"].DrugaUtakmica + golovi[1], skupina["Maroko"].TrecaUtakmica);




        for (int i = 0; i < golovi[2]; i++)
        {
            Random rnd = new Random();
            int s = rnd.Next(0, 11);
            string strijelac = igraciUtakmice[s];
            if (!(strijelci.ContainsKey(strijelac)))
            {
                strijelci.Add(strijelac, 1);
            }
            else
            {
                strijelci[strijelac] += 1;
            }
            listOfPlayers[strijelac] = (listOfPlayers[strijelac].Pozicija, (105 * listOfPlayers[strijelac].Rating) / 100);
        }

        Console.WriteLine($"Rezultati {brojacUtakmica}. kola Skupine F: ");
        Console.WriteLine($"Belgija {golovi[0]} / {golovi[1]} Maroko\nHrvatska {golovi[2]} / {golovi[3]} Kanada");

    }
    else//trece kolo
    {
        if (golovi[0] < golovi[1])
        {
            skupina["Belgija"] = (skupina["Belgija"].Bodovi + 3, skupina["Belgija"].PrvaUtakmica, skupina["Belgija"].DrugaUtakmica, skupina["Belgija"].TrecaUtakmica);
            foreach (var item in igraciUtakmice)
            {
                listOfPlayers[item] = (listOfPlayers[item].Pozicija, (98 * listOfPlayers[item].Rating) / 100);
            }
        }
        else if (golovi[0] > golovi[1])
        {
            skupina["Hrvatska"] = (skupina["Hrvatska"].Bodovi + 3, skupina["Hrvatska"].PrvaUtakmica, skupina["Hrvatska"].DrugaUtakmica, skupina["Hrvatska"].TrecaUtakmica);
            foreach (var item in igraciUtakmice)
            {
                listOfPlayers[item] = (listOfPlayers[item].Pozicija, (102 * listOfPlayers[item].Rating) / 100);
            }
        }
        else
        {
            skupina["Belgija"] = (skupina["Belgija"].Bodovi + 1, skupina["Belgija"].PrvaUtakmica, skupina["Belgija"].DrugaUtakmica, skupina["Belgija"].TrecaUtakmica);
            skupina["Hrvatska"] = (skupina["Hrvatska"].Bodovi + 1, skupina["Hrvatska"].PrvaUtakmica, skupina["Hrvatska"].DrugaUtakmica, skupina["Hrvatska"].TrecaUtakmica);
        }

        if (golovi[2] < golovi[3])
        {
            skupina["Maroko"] = (skupina["Maroko"].Bodovi + 3, skupina["Maroko"].PrvaUtakmica, skupina["Maroko"].DrugaUtakmica, skupina["Maroko"].TrecaUtakmica);
        }
        else if (golovi[2] > golovi[3])
        {
            skupina["Kanada"] = (skupina["Kanada"].Bodovi + 3, skupina["Kanada"].PrvaUtakmica, skupina["Kanada"].DrugaUtakmica, skupina["Kanada"].TrecaUtakmica);
        }
        else
        {
            skupina["Maroko"] = (skupina["Maroko"].Bodovi + 1, skupina["Maroko"].PrvaUtakmica, skupina["Maroko"].DrugaUtakmica, skupina["Maroko"].TrecaUtakmica);
            skupina["Kanada"] = (skupina["Kanada"].Bodovi + 1, skupina["Kanada"].PrvaUtakmica, skupina["Kanada"].DrugaUtakmica, skupina["Kanada"].TrecaUtakmica);
        }

        skupina["Belgija"] = (skupina["Belgija"].Bodovi, skupina["Belgija"].PrvaUtakmica, skupina["Belgija"].DrugaUtakmica, skupina["Belgija"].TrecaUtakmica + golovi[1]);
        skupina["Hrvatska"] = (skupina["Hrvatska"].Bodovi, skupina["Hrvatska"].PrvaUtakmica, skupina["Hrvatska"].DrugaUtakmica, skupina["Hrvatska"].TrecaUtakmica + golovi[0]);
        skupina["Kanada"] = (skupina["Kanada"].Bodovi, skupina["Kanada"].PrvaUtakmica, skupina["Kanada"].DrugaUtakmica, skupina["Kanada"].TrecaUtakmica + golovi[2]);
        skupina["Maroko"] = (skupina["Maroko"].Bodovi, skupina["Maroko"].PrvaUtakmica, skupina["Maroko"].DrugaUtakmica, skupina["Maroko"].TrecaUtakmica + golovi[3]);




        for (int i = 0; i < golovi[0]; i++)
        {
            Random rnd = new Random();
            int s = rnd.Next(0, 11);
            string strijelac = igraciUtakmice[s];
            if (!(strijelci.ContainsKey(strijelac)))
            {
                strijelci.Add(strijelac, 1);
            }
            else
            {
                strijelci[strijelac] += 1;
            }
            listOfPlayers[strijelac] = (listOfPlayers[strijelac].Pozicija, (105 * listOfPlayers[strijelac].Rating) / 100);
        }

        Console.WriteLine($"Rezultati {brojacUtakmica}. kola Skupine F: ");
        Console.WriteLine($"Hrvatska {golovi[0]} / {golovi[1]} Belgija\nKanada {golovi[2]} / {golovi[3]} Maroko");

    }

    var povratak = "";
    do
    {
        Console.WriteLine("Pritisnite 0 za povratak na glavni izbornik");
        povratak = Console.ReadLine();
    } while (povratak != "0");
    PovratakNaGlavniIzbornik();

}





//TRECA AKCIJA
void IzbornikStatistika()
{
    string[] unos = new string[12] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11" };
    Console.WriteLine("Odaberite ispis igrača");
    Console.WriteLine("1-Ispis igrača kako su spremljeni\n" +
        "2-Ispis po ratingu ulazno\n" +
        "3-Ispis po ratingu silazno\n" +
        "4-Ispis igrača po imenu i prezimenu\n" +
        "5-Ispis igrača po ratingu\n" +
        "6-Ispis igrača po poziciji\n" +
        "7-Ispis trenutnih prvih 11 igrača\n" +
        "8-Ispis strijelaca i koliko golova imaju\n" +
        "9-Ispis svih reultata ekipe\n" +
        "10-Ispis rezultata svih ekipa\n" +
        "11-Ispis tablice grupe\n" +
        "0-Povratak na glavni izbornik");
    var odabir = "";
    do
    {
        odabir = Console.ReadLine();
    } while (!unos.Contains(odabir));

    switch (odabir)
    {
        case "1":
            foreach (var player in listOfPlayers)
            {
                Console.WriteLine(player.Key);
            }
            Povratak();
            break;

        case "2":
            IspisRatingUzlazno();
            Povratak();
            break;

        case "3":
            IspisRatingSilazno();
            Povratak();
            break;

        case "4":
            IspisIgracaPoImenu();
            Povratak();
            break;

        case "5":
            IspisIgracaPoRatingu();
            Povratak();
            break;

        case "6":
            IspisIgracaPoPoziciji();
            Povratak();
            break;

        case "7":
            IspisPrvePostave();
            Povratak();
            break;

        case "8":
            foreach (var s in strijelci)
            {
                Console.WriteLine($"Strijelac: {s.Key}, golovi: {s.Value}");
            }
            Povratak();
            break;

        case "9":
            IspisRezultataEkipe();
            Povratak();
            break;

        case "10":
            foreach (var drzava in skupina)
            {
                Console.WriteLine($"{drzava.Key}\n" +
                    $"bodovi: {skupina[drzava.Key].Bodovi}\n" +
                    $"golovi po utakmicama: {skupina[drzava.Key].PrvaUtakmica}, {skupina[drzava.Key].DrugaUtakmica}, {skupina[drzava.Key].TrecaUtakmica}");
            }
            Povratak();
            break;

        case "11":
            IspisTabliceSkupine();
            Povratak();
            break;

        case "0":
            PovratakNaGlavniIzbornik();
            break;

        default:
            Console.WriteLine("Krivi unos");
            break;
    }

}



void Statistika()
{
    string[] unos = new string[12] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11" };
    Console.WriteLine("Odaberite ispis igrača");
    Console.WriteLine("1-Ispis igrača kako su spremljeni\n" +
        "2-Ispis po ratingu ulazno\n" +
        "3-Ispis po ratingu silazno\n" +
        "4-Ispis igrača po imenu i prezimenu\n" +
        "5-Ispis igrača po ratingu\n" +
        "6-Ispis igrača po poziciji\n" +
        "7-Ispis trenutnih prvih 11 igrača\n" +
        "8-Ispis strijelaca i koliko golova imaju\n" +
        "9-Ispis svih reultata ekipe\n" +
        "10-Ispis rezultata svih ekipa\n" +
        "11-Ispis tablice grupe\n" +
        "0-Povratak na glavni izbornik");
    var odabir = "";
    do
    {
        odabir = Console.ReadLine();
    } while (!unos.Contains(odabir));

    switch (odabir)
    {
        case "1":
            foreach (var player in listOfPlayers)
            {
                Console.WriteLine(player.Key);
            }
            Povratak();
            break;

        case "2":
            IspisRatingUzlazno();
            Povratak();
            break;

        case "3":
            IspisRatingSilazno();
            Povratak();
            break;

        case "4":
            IspisIgracaPoImenu();
            Povratak();
            break;

        case "5":
            IspisIgracaPoRatingu();
            Povratak();
            break;

        case "6":
            IspisIgracaPoPoziciji();
            Povratak();
            break;

        case "7":
            IspisPrvePostave();
            Povratak();
            break;

        case "8":
            foreach (var s in strijelci)
            {
                Console.WriteLine($"Strijelac: {s.Key}, golovi: {s.Value}");
            }
            Povratak();
            break;

        case "9":
            IspisRezultataEkipe();
            Povratak();
            break;

        case "10":
            foreach (var drzava in skupina)
            {
                Console.WriteLine($"{drzava.Key}\n" +
                    $"bodovi: {skupina[drzava.Key].Bodovi}\n" +
                    $"golovi po utakmicama: {skupina[drzava.Key].PrvaUtakmica}, {skupina[drzava.Key].DrugaUtakmica}, {skupina[drzava.Key].TrecaUtakmica}");
            }
            Povratak();
            break;

        case "11":
            IspisTabliceSkupine();
            Povratak();
            break;

        case "0":
            PovratakNaGlavniIzbornik();
            break;

        default:
            Console.WriteLine("Krivi unos");
            break;
    }

}

void Povratak()
{
    var povratak = "";
    do
    {
        Console.WriteLine("Pritisnite 0 za povratak na izbornik Statistika");
        povratak = Console.ReadLine();
    } while (povratak != "0");
    IzbornikStatistika();
}

void IspisRatingUzlazno()
{
    var listaRatinga =new List<int>();
    foreach (var player in listOfPlayers)
    {
        listaRatinga.Add(listOfPlayers[player.Key].Rating);
    }
    listaRatinga.Sort();
    var duljinaListe = listaRatinga.Count();
    var najmanjiRating = listaRatinga[0];
    var najveciRating = listaRatinga[duljinaListe - 1];
    for (int i = najmanjiRating; i < najveciRating; i++)
    {
        foreach (var player in listOfPlayers)
        {
            if (player.Value.Rating==i)
            {
                Console.WriteLine($"{player.Key} ima rating {i}");
            }
        }
    }
}

void IspisRatingSilazno()
{
    var listaRatinga = new List<int>();
    foreach (var player in listOfPlayers)
    {
        listaRatinga.Add(player.Value.Rating);
    }
    listaRatinga.Sort();
    var duljinaListe = listaRatinga.Count();
    var najmanjiRating = listaRatinga[0];
    var najveciRating = listaRatinga[duljinaListe - 1];
    for (int i = najveciRating; i > najmanjiRating; i--)
    {
        foreach (var player in listOfPlayers)
        {
            if (player.Value.Rating == i)
            {
                Console.WriteLine($"{player.Key} ima rating {i}");
            }
        }
    }
}

void IspisIgracaPoImenu()
{
    var unos = "";
    do
    {
        Console.WriteLine("Unesite ime i prezime igraca za prikaz njegovog ratinga i pozicije:");
        unos = Console.ReadLine();
    } while (!listOfPlayers.ContainsKey(unos));

    foreach (var player in listOfPlayers)
    {
        if (player.Key==unos)
        {
            Console.WriteLine($"{unos}\nRating: {player.Value.Rating}, pozicija: {player.Value.Pozicija}");
        }
    }
}

void IspisIgracaPoRatingu()
{
    var unos = -1;
    do
    {
        Console.WriteLine("Unesite rating");
        try
        {
            unos = int.Parse(Console.ReadLine());
            break;
        }
        catch (Exception)
        {
            Console.WriteLine("Unos mora biti broj");
            IspisIgracaPoRatingu();
        }
    } while (unos<0||unos>100);

    Console.WriteLine("Igraci s ratingom "+unos);
    foreach (var player in listOfPlayers)
    {
        if (player.Value.Rating==unos)
        {
            Console.WriteLine(player.Key);
        }
    }
}


void IspisIgracaPoPoziciji()
{
    var unos = "";
    do
    {
        Console.WriteLine("Unesite poziciju(GK, DF, MF ili FW):");
        unos = Console.ReadLine();
    } while (unos!="GK"&unos!="FW"&unos!="MF"&unos!="DF");

    Console.WriteLine("Igraci na poziciji " + unos);
    foreach (var player in listOfPlayers)
    {
        if (player.Value.Pozicija == unos)
        {
            Console.WriteLine(player.Key);
        }
    }
}


void IspisPrvePostave()
{
    var listaDF=new List<int>();
    foreach (var player in igraciDF)
    {
        listaDF.Add(player.Value);
    }
    listaDF.Sort();
    var listaIgracaDF=new List<string>();
    var duljinaListe1 = listaDF.Count();
    var najmanjiRating1 = listaDF[0];
    var najveciRating1 = listaDF[duljinaListe1 - 1];
    for (int i = najveciRating1; i < najmanjiRating1; i--)
    {
        foreach (var player in igraciDF)
        {
            if (player.Value == i)
            {
                listaIgracaDF.Add(player.Key);
            }
        }
    }

    var listaMF = new List<int>();
    foreach (var player in igraciMF)
    {
        listaMF.Add(player.Value);
    }
    listaMF.Sort();
    var listaIgracaMF = new List<string>();
    var duljinaListe2 = listaMF.Count();
    var najmanjiRating2 = listaMF[0];
    var najveciRating2 = listaMF[duljinaListe2 - 1];
    for (int i = najveciRating2; i < najmanjiRating2; i--)
    {
        foreach (var player in igraciMF)
        {
            if (player.Value == i)
            {
                listaIgracaMF.Add(player.Key);
            }
        }
    }

    var listaFW = new List<int>();
    foreach (var player in igraciFW)
    {
        listaFW.Add(player.Value);
    }
    listaFW.Sort();
    var listaIgracaFW = new List<string>();
    var duljinaListe3 = listaFW.Count();
    var najmanjiRating3 = listaFW[0];
    var najveciRating3 = listaFW[duljinaListe3 - 1];
    for (int i = najveciRating3; i < najmanjiRating3; i--)
    {
        foreach (var player in igraciFW)
        {
            if (player.Value == i)
            {
                listaIgracaFW.Add(player.Key);
            }
        }
    }

    var r = -1;
    foreach (var player in igraciGK)
    {
        if (player.Value>r)
        {
            r = player.Value;
        }
    }
    var gk = "";
    foreach (var item in igraciGK)
    {
        if (item.Value==r)
        {
            gk=item.Key;
            break;
        }
    }

    if (listaIgracaDF.Count()<4 || listaIgracaFW.Count()<3 || listaIgracaMF.Count()<3 || gk=="")
    {
        Console.WriteLine("Nema dovoljno igraca za igru u formaciji 4-3-3");
    }
    else
    {
        var listaPrvePostave = new List<string>();
        for (int i = 0; i < 4; i++)
        {
            listaPrvePostave.Add(listaIgracaDF[i]);
        }
        for (int i = 0; i < 3; i++)
        {
            listaPrvePostave.Add(listaIgracaFW[i]);
        }
        for (int i = 0; i < 3; i++)
        {
            listaPrvePostave.Add(listaIgracaMF[i]);
        }
        listaPrvePostave.Add(gk);

        foreach (var player in listaPrvePostave)
        {
            Console.WriteLine(player);
        }
    }


    
}

void IspisRezultataEkipe()
{
    var unos = "";
    do
    {
        Console.WriteLine("Unesite ime države za prikaz njenih rezultata(Belgija, Hrvatska, Kanada ili Maroko)");
        unos = Console.ReadLine();

    } while (!skupina.ContainsKey(unos));

    Console.WriteLine($"{unos} rezultati:\n" +
        $"Bodovi: {skupina[unos].Bodovi}, Prva Utakmica: {skupina[unos].PrvaUtakmica}, Druga utakmica: {skupina[unos].DrugaUtakmica}, Treca utakmica: {skupina[unos].TrecaUtakmica}");

}


void IspisTabliceSkupine()
{
    Console.WriteLine("Ispis tablice grupe po bodovima silazno");
    for (int i = 9; i > -1; i--)
    {
        foreach (var ekipa in skupina)
        {
            if (ekipa.Value.Bodovi==i)
            {
                Console.WriteLine($"{ekipa.Key} Bodovi: {ekipa.Value.Bodovi}, golovi po utakmicama: {ekipa.Value.PrvaUtakmica}, {ekipa.Value.DrugaUtakmica}, {ekipa.Value.TrecaUtakmica}");
            }
        }
    }
}





// CETVRTA AKCIJA
void KontrolaIgraca()
{
    var unos = "";
    do
    {
        Console.WriteLine("Odaberite radnju\n1 - Unos novog igrača\n2 - Brisanje igrača\n3 - Uređivanje igrača");
        unos = Console.ReadLine();
    } while (unos!="1"& unos!="2" & unos!="3"& unos!="0");


    switch (unos)
    {
        case "1":
            UnosNovogIgraca();
            PovratakKI();
            break;

        case "2":
            BrisanjeIgraca();
            PovratakKI();
            break;

        case "3":
            UredivanjeIgraca();
            PovratakKI();
            break;

        case "0":
            PovratakNaGlavniIzbornik();
            break;

        default:
            Console.WriteLine("Neispravan unos. Trebate unijeti 1, 2, 3 ili 0!");
            break;
    }
}


void IzbornikKontrolaIgraca()
{
    var unos = "";
    do
    {
        Console.WriteLine("Odaberite radnju\n1 - Unos novog igrača\n2 - Brisanje igrača\n3 - Uređivanje igrača");
        unos = Console.ReadLine();
    } while (unos != "1" & unos != "2" & unos != "3" & unos != "0");


    switch (unos)
    {
        case "1":
            UnosNovogIgraca();
            PovratakKI();
            break;

        case "2":
            BrisanjeIgraca();
            PovratakKI();
            break;

        case "3":
            UredivanjeIgraca();
            PovratakKI();
            break;

        case "0":
            PovratakNaGlavniIzbornik();
            break;

        default:
            Console.WriteLine("Neispravan unos. Trebate unijeti 1, 2, 3 ili 0!");
            break;
    }
}

void UnosNovogIgraca()
{
    var ime = "";
    do
    {
        Console.WriteLine("Unesite ime i prezime igraca: ");
        ime= Console.ReadLine();
    } while (ime=="");

    var p = "";
    do
    {
        Console.WriteLine("Unesite poziciju igraca(GK, DF, MF ili FW): ");
        p = Console.ReadLine();
    } while (p!="GK" & p!="DF" & p!="MF" & p!="FW");

    var r = -1;
    do
    {
        Console.WriteLine("Unesite rating igraca: ");
        try
        {
            r = int.Parse(Console.ReadLine());
            break;
        }
        catch (Exception)
        {
            Console.WriteLine("rating mora biti broj od 0 do 100");
            throw;
        }
    } while (r<0||r>100);

    if (listOfPlayers.Count<26)
    {
        listOfPlayers.Add(ime, (p, r));
    }
    else
        Console.WriteLine("Ne mozete dodati igraca jer ih ima vec 26");

}

void BrisanjeIgraca()
{
    var ime = "";
    do
    {
        Console.WriteLine("Unesite ime i prezime igraca kojega zelite izbrisati: ");
        ime = Console.ReadLine();
    } while (!listOfPlayers.ContainsKey(ime));

    listOfPlayers.Remove(ime);
}

void UredivanjeIgraca()
{
    var inputedName = "";
    do
    {
        Console.WriteLine("Unesite ime i prezime igraca kojeg zelite urediti");
        inputedName = Console.ReadLine();
    } while (!listOfPlayers.ContainsKey(inputedName));
    var unos = "";
    do
    {
        Console.WriteLine("1-Uredi ime i prezime igraca\n2-Uredi poziciju igraca\n3-Uredi rating igraca");
        unos = Console.ReadLine();
    } while (unos!="1" & unos!="2" & unos!="3" & unos!="0");

    switch (unos)
    {
        case "1":
            UrediIme(inputedName);
            PovratakUI(inputedName);
            break;

        case "2":
            UrediPoziciju(inputedName);
            PovratakUI(inputedName);
            break;

        case "3":
            UrediRating(inputedName);
            PovratakUI(inputedName);
            break;

        case "0":
            PovratakKI();
            break;

        default:
            Console.WriteLine("Trebate unijeti 1, 2, 3 ili 0");
            break;
    }

}

void PovratakUI(string inputName)
{
    var povratak = "";
    do
    {
        Console.WriteLine("Pritisnite 0 za povratak na izbornik Uredi igraca");
        povratak = Console.ReadLine();
    } while (povratak != "0");
    IzbornikUredivanjeIgraca(inputName);
}

void IzbornikUredivanjeIgraca(string unesenoIme)
{
    /*var inputedName = "";
    do
    {
        Console.WriteLine("Unesite ime i prezime igraca kojeg zelite urediti");
        inputedName = Console.ReadLine();
    } while (!listOfPlayers.ContainsKey(inputedName));*/
    var unos = "";
    do
    {
        Console.WriteLine("1-Uredi ime i prezime igraca\n2-Uredi poziciju igraca\n3-Uredi rating igraca");
        unos = Console.ReadLine();
    } while (unos != "1" & unos != "2" & unos != "3" & unos != "0");

    switch (unos)
    {
        case "1":
            UrediIme(unesenoIme);
            PovratakUI(unesenoIme);
            break;

        case "2":
            UrediPoziciju(unesenoIme);
            PovratakUI(unesenoIme);
            break;

        case "3":
            UrediRating(unesenoIme);
            PovratakUI(unesenoIme);
            break;

        case "0":
            PovratakKI();
            break;

        default:
            Console.WriteLine("Trebate unijeti 1, 2, 3 ili 0");
            break;
    }
}


void PovratakKI()
{
    var povratak = "";
    do
    {
        Console.WriteLine("Pritisnite 0 za povratak na izbornik Kontrola igraca");
        povratak = Console.ReadLine();
    } while (povratak != "0");
    IzbornikKontrolaIgraca();
}

void UrediIme(string imeIgraca)
{
    var novoIme = "";
    do
    {
        Console.WriteLine("Unesite ime i prezime");
        novoIme= Console.ReadLine();
    } while (novoIme =="");
    listOfPlayers.Add(novoIme, (listOfPlayers[imeIgraca].Pozicija, listOfPlayers[imeIgraca].Rating));
    listOfPlayers.Remove(imeIgraca);

}

void UrediPoziciju(string imeIgraca)
{
    var novaPozicija = "";
    do
    {
        Console.WriteLine("Unesite poziciju");
        novaPozicija= Console.ReadLine();
    } while (novaPozicija!="GK" & novaPozicija!="DF" & novaPozicija!="MF" & novaPozicija!="FW");

    var rating = listOfPlayers[imeIgraca].Rating;
    listOfPlayers.Remove(imeIgraca);
    listOfPlayers.Add(imeIgraca, (novaPozicija, rating));
    
}

void UrediRating(string imeIgraca)
{
    var noviRating = -1;
    do
    {
        Console.WriteLine("Unesite novi rating(0-100)");
        try
        {
            noviRating = int.Parse(Console.ReadLine());
            break;
        }
        catch (Exception)
        {
            Console.WriteLine("Morate unijeti broj");
            throw;
        }
    } while (noviRating<0 || noviRating>100);

    var pozicija = listOfPlayers[imeIgraca].Pozicija;
    listOfPlayers.Remove(imeIgraca);
    listOfPlayers.Add(imeIgraca, (pozicija, noviRating));
}
