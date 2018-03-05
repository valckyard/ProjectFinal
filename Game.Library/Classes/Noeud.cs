using System;
using System.Collections.Generic;
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
                Methodes.MethodeCombat.AttaqueEnnemi(ref personnage, ref baddie);
            }

            if (EnnemiP != null)
            {
                var baddie = EnnemiP;
                Console.WriteLine(CombatString+"\n");
                Methodes.MethodeCombat.AttaquePersonnage(ref personnage, ref baddie);
            }
            
            Console.WriteLine("\n"+Intitule + "\n");
        }

        private static void AskForInventory(ref Personnage personnage)
        {
            Console.Clear();
            do
            {
                Console.WriteLine("Voulez-Vous Acceder a l'Inventaire ? O/N");
                var cki = Console.ReadKey();
                if (cki.Key == ConsoleKey.N)
                break;
                

                if (cki.Key != ConsoleKey.O) continue;
                personnage.MenuInventaire();
                Console.Clear();
                break;
            } while (true);
        }

        public string ChoixJoueur(ref Personnage personnage)
        {
            Random rand = new Random();
            if (MortOuRandom)
            {
                if (ChoixReponses.Count == 1)
                {
                    return ChoixReponses.Values.ToString();
                }
                else
                {
                    int z = rand.Next(1, ChoixReponses.Count + 1);

                    foreach (var reponse in ChoixReponses)
                    {
                        if (z == ChoixReponses.Count)
                        {
                            Console.WriteLine(reponse.Value);
                            Console.WriteLine("\nAppuyez sur une touche pour continuer\n");
                            Console.ReadKey();
                            return "Mort";
                        }
                        else
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