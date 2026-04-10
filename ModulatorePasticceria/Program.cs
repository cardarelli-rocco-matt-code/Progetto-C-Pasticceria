using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
class Program
{

    static string TrovaRicetta(string[] ricettario, int indice)
    {
        return ricettario[indice];
    }

    static List<string> Ingredienti(string ricetta)
    {
        switch (ricetta)
        {

        }
    }

    static List<string> CalcolaSpesa(List<string> ingredienti, List<string> dispensa)
    {
        List<string> spesa = new List<string>();

        foreach (var ingrediente in ingredienti)
        {
            if (!dispensa.Contains(ingrediente))
            {
                spesa.Add(ingrediente);
            }
        }

        return spesa;
    }
    static void Main()
    {
        string[] recipe = {
            "Torta al Cioccolato e Panna",
            "Tiramisù",
            "Bavarese alle Fragole",
            "Cheesecake",
            "Cannoli Siciliani",
            "Millefoglie",
            "Profiteroles",
            "Strudel di Mele",
            "Crostate",
            "Pan di Spagna"
        };

        string[] ListIngredient = { "farina","uova", "zucchero", "cioccolato", 
            "panna", "biscotti", "mascarpone", "caffe", 
            "fragole", "gelatina", "burro", "formaggio", 
            "ricotta", "pasta sfoglia", "crema", "mele", 
            "cannella", "marmellata."};

        List<string> dispense = new List<string> { "uova", "cioccolato", "mascarpone", "farina", "lievito" };

        string ricetta = TrovaRicetta(listingredient, scelta);
        List<string> ingredienti = EstraiIngredienti(ricetta);

        List<string> FinalList = CalcolaSpesa(ingredienti, dispensa);

        Console.WriteLine("\nLista della spesa:");
        foreach (var item in listaSpesa)
        {
            Console.WriteLine("- " + item);
        }
    }
}