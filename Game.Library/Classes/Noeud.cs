using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using Game.Library.Classes.EntiteClasses;
using Game.Library.Methodes;

namespace Game.Library.Classes
{
    public class Noeud
    {
        public string Intitule { get; set; }
        public string CombatString { get; set; }
        public Ennemi Ennemi { get; set; }
        public Personnage EnnemiP { get; set; }
        public bool MortOuRandom { get; set; }
        public Dictionary<int, string> ChoixReponses { get; set; }

        public Noeud()
        {
        }

        public Noeud(string intitule, Ennemi ennemi, Personnage ennemiP, bool mortOuRandom,
            Dictionary<int, string> choixReponses)
        {
            MortOuRandom = mortOuRandom; 
            Intitule = intitule;
            Ennemi = ennemi;
            EnnemiP = ennemiP;
            ChoixReponses = choixReponses;
        }

        public void Init(ref Personnage personnage)
        {
            AskForInventory(ref personnage);

            
            if (Ennemi != null)
            {
                var baddie = Ennemi;
                Console.WriteLine("\n"+CombatString+"\n");
                MethodeCombat.AttaqueEnnemi(ref personnage, ref baddie);
            }

            if (EnnemiP != null)
            {
                var baddie = EnnemiP;
                Console.WriteLine(CombatString+"\n");
                MethodeCombat.CombatPersonnage(ref personnage, ref baddie);
            }
            Console.Clear();
            Console.WriteLine("\n"+Intitule + "\n");
        }

        private static void AskForInventory(ref Personnage personnage)
        {
            do
            {
                Console.Write($"\nVoulez-Vous Acceder a l'Inventaire ? O/N ");
                var cki = Console.ReadKey();

                if (cki.Key == ConsoleKey.N)
                {
                    Console.Clear();
                    break;
                }

                if (cki.Key == ConsoleKey.O)
                {
                    personnage.MenuInventaire();
                    Console.Clear();
                    break;
                }
            } while (true);
        }

        public string ChoixJoueur(ref Personnage personnage)
        {
            Random rand = new Random();
            
            if (MortOuRandom)
            {
                if (ChoixReponses.Count == 1)
                {
                    return ChoixReponses.ElementAt(0).Value;
                }
                else
                {
                    int z = rand.Next(1, ChoixReponses.Count + 1);

                    if (z == ChoixReponses.Count)
                    {
                        Console.WriteLine(ChoixReponses.ElementAt(1).Value);
                        Console.ReadLine();
                        return "Mort";
                    }
                    foreach (var reponse in ChoixReponses)
                    {
                        if(z== reponse.Key)
                        {
                        
                            return reponse.Value;
                        }
                    }
                }
            }
            else // !MortOuRandom
            {
                foreach (var kv in ChoixReponses)
                {
                    Console.Write($"{kv.Key} -- ");
                    Console.WriteLine($"{kv.Value}");
                }
            }

           int x = InputChoice.Choice(ChoixReponses.Count);

            string newkey = null;
            foreach (var c in ChoixReponses)
            {
                if (c.Key == x)
                {
                    newkey = c.Value;
                    break;
                }
            }

            return newkey;
        }

    
    }
}