using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System;

class Program
{
    static void MostraMenu(List<string> ricette)
    {
        Console.WriteLine("DOLCI:");
        for (int i = 0; i < ricette.Count; i++)
        {
            string nome = ricette[i].Split('.')[0];
            Console.WriteLine($"{i + 1}) {nome}");
        }
        Console.WriteLine("");
    }

    static int PrendiOrdinazione()
    {
        int scelta = 1;
        int proceed = 0;
        string? conf1;
        int conf2;
        string? input = Console.ReadLine();

        while (proceed == 0)
        {
            while (!int.TryParse(input, out scelta))
            {
                Console.WriteLine("Inserisci un numero valido:");
                input = Console.ReadLine();
            }

            Console.WriteLine("Confermi? (0 - no, 1 - si)");
            conf1 = Console.ReadLine();
            while (!int.TryParse(conf1, out conf2))
            {
                Console.WriteLine("Confermi? (0 - no, 1 - si)");
                conf1 = Console.ReadLine();
            }
            if (conf1 == "1")
                proceed = 1;
            else
                proceed = 0;
        }
        
        Console.WriteLine("");
        return scelta - 1;
    }

    static void PrendiOrdinazione2(List<string> dispensa, List<string> ingredienti)
    {
        Console.WriteLine("Scegli un ingrediente da rimuovere (Nome): ");
        string scelta = (Console.ReadLine());

        if (dispensa.Contains(scelta))
        {
            dispensa.Remove(scelta);   
        }

        if (ingredienti.Contains(scelta))
        {
            ingredienti.Remove(scelta);
        }

    }

    static string TrovaRicetta(List<string> ricette, int indice)
    {
        return ricette[indice];
    }

    static void EatString(string s)
    {
        s = "(Eaten)";
    }

    static List<string> EstraiIngredienti(string ricetta)
    {
        List<string> ingredienti = new List<string>();

        int start = ricetta.IndexOf("Ingredienti:") + "Ingredienti:".Length;
        int end = ricetta.IndexOf("Preparazione:");

        string parteIngredienti = ricetta.Substring(start, end - start);

        string[] items = parteIngredienti.Split(',');

        foreach (var item in items)
        {
            ingredienti.Add(item.Trim());
        }

        return ingredienti;
    }

    static List<string> GeneraListaSpesa(List<string> ingredienti, List<string> dispensa)
    {
        List<string> lista = new List<string>();

        foreach (var ingrediente in ingredienti)
        {
            if (!dispensa.Contains(ingrediente) && !lista.Contains(ingrediente))
            {
                lista.Add(ingrediente);
            }
        }

        return lista;
    }

    static List<string> GeneraListaSpesa2(List<string> ingredienti, List<string> dispensa)
    {
        List<string> lista = new List<string>();

        foreach (var ingrediente in dispensa)
        {
            if (!dispensa.Contains(ingrediente))
                lista.Add(ingrediente);
        }

        foreach (var ingrediente in ingredienti)
        {
            if (!lista.Contains(ingrediente))
            {
                lista.Add(ingrediente);
            }
        }

        return lista;
    }

    static void Main()
    {
        string msg = "";
        int endofcode = 0;
        int fun = 0;
        int confirm = 0;


        List<string> listaSpesa = new List<string>();
        List<string> ingredienti = new List<string>();

        msg = "fa schifo";
        List<string> ricette = new List<string>()
        {
            "Torta al Cioccolato e Panna. Ingredienti: farina, zucchero, uova, cioccolato, panna. Preparazione: mescolare, cuocere.",
            "Tiramisù. Ingredienti: zucchero, uova, biscotti, mascarpone, caffè. Preparazione: unire ingredienti.",
            "Bavarese alle Fragole. Ingredienti: fragole, zucchero, panna, gelatina. Preparazione: mescolare.",
            "Cheesecake. Ingredienti: biscotti, burro, formaggio, zucchero. Preparazione: preparare base.",
            "Cannoli Siciliani. Ingredienti: ricotta, zucchero, farina, uova. Preparazione: friggere.",
            "Millefoglie. Ingredienti: pasta sfoglia, crema, zucchero. Preparazione: stratificare.",
            "Profiteroles. Ingredienti: farina, uova, burro, cioccolato. Preparazione: cuocere.",
            "Panna Cotta. Ingredienti: panna, zucchero, gelatina. Preparazione: raffreddare.",
            "Crostate. Ingredienti: farina, burro, zucchero, marmellata. Preparazione: cuocere.",
            "Gelato alla Vaniglia. Ingredienti: latte, zucchero, vaniglia. Preparazione: congelare."
        };

        string[] ingredientList = {
            "farina", "zucchero", "uova", "cioccolato", "panna", "biscotti",
            "mascarpone", "caffè", "fragole", "gelatina", "burro", "formaggio",
            "ricotta", "pasta sfoglia", "crema", "marmellata", "latte", "vaniglia"
        };

        List<string> dispensa = new List<string>()
        {
            "uova", "cioccolato", "mascarpone", "farina", "lievito"
        };

        do
        {
            Console.WriteLine("Scegliere una delle seguenti funzioni:");
            Console.WriteLine("0 - ESCI");
            Console.WriteLine("1 - Ordina");
            Console.WriteLine("2 - Vedi Lista completa");
            Console.WriteLine("3 - Rimuovi ingrediente");
            fun = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("");
            EatString(msg);

            switch (fun)
            {
                case 0:
                    break;

                case 1:
                    do
                    {
                        MostraMenu(ricette);
                        int scelta = PrendiOrdinazione();
                        string ricetta = TrovaRicetta(ricette, scelta);
                        ingredienti = EstraiIngredienti(ricetta);
                        listaSpesa = GeneraListaSpesa(ingredienti, dispensa);
                        Console.WriteLine("Aggiunti alla lista della spesa:");

                        foreach (var item in listaSpesa)
                        {
                            Console.WriteLine("- " + item);
                        }

                        Console.WriteLine("Vuoi aggiungere un altro ordine? (1 - si, 0 - no");
                        endofcode = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("");
                    } while (endofcode != 0);

                    Console.WriteLine("");
                    break;

                case 2:
                    listaSpesa = GeneraListaSpesa2(ingredienti, dispensa);
                    Console.WriteLine("Lista della spesa completa:");

                    foreach (var item in listaSpesa)
                    {
                        Console.WriteLine("- " + item);
                    }

                    Console.WriteLine("");
                    break;

                case 3:
                    listaSpesa = GeneraListaSpesa2(ingredienti, dispensa);
                    PrendiOrdinazione2(dispensa, ingredienti);
                    Console.WriteLine("");
                    break;


                default:
                    Console.WriteLine("Funzione non Trovata. Riprovare.");
                    Console.WriteLine("");
                    break;

            }
        } while (fun != 0);
    }

    static List<string> EstraiIngredienti2(string ricetta, int choice, List<string> ingredientes, List<string> dispensa)
    {
        List<string> ingredienti = new List<string>();
        string tempvar = "";

        switch (choice)
        {
            case 1:
                if (!dispensa.Contains(tempvar) && !ingredientes.Contains(tempvar))
                    ingredienti.Add(tempvar);
                break;
        }

        return ingredienti;
    }
}
