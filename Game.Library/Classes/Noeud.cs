using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Game.Library.Classes.EntiteClasses;

namespace Game.Library.Classes
{
    public class Noeud
    {
        public string Intitule { get; set; }
        public string CombatString { get; set; }
        public Ennemi Ennemi { get; set; }
        public Personnage EnnemiP { get; set; }
        public Dictionary<int,string> ChoixReponses { get; set; }

        public Noeud()
        {
                
        }

        public Noeud(string intitule, Ennemi ennemi, Personnage ennemiP, Dictionary<int, string> choixReponses)
        {
            Intitule = intitule;
            Ennemi = ennemi;
            EnnemiP = ennemiP;
            ChoixReponses = choixReponses;
        }

        public void Init(ref Personnage personnage)
        {
            if (Ennemi != null)
            {
                var baddie = Ennemi;
                Console.WriteLine(CombatString);
                Methodes.MethodeCombat.AttaqueEnnemi(ref personnage,ref baddie);
            }

            if (EnnemiP != null)
            {
                var baddie = EnnemiP;
                Console.WriteLine(CombatString);
                Methodes.MethodeCombat.AttaquePersonnage(ref personnage,ref baddie);
            }

            Console.WriteLine(Intitule);
            ChoixJoueur(ref personnage);
        }

        public string ChoixJoueur(ref Personnage personnage)
        {
            foreach (var kv in ChoixReponses)
            {
                Console.Write($"{kv.Key} -- ");
                Console.WriteLine($"{kv.Value}");
            }

            int x;
            while (int.TryParse(Console.ReadLine(),out x)== false)
            {
                
            }

            if (x<1 & x>ChoixReponses.Count)
            {
                ChoixJoueur(ref personnage);
            }

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