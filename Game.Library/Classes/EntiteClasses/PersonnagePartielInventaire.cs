using System;
using System.Linq;
using Game.Library.Classes.ObjClasses;

namespace Game.Library.Classes.EntiteClasses
{
    public partial class Personnage
    {
        public void MenuInventaire()
        {
            AfficherInventaire();
            Console.Write(
                $"Que voulez vous faire ? \n 1 -- Equipper \n 2 -- Voir Les Statistiques \n 3 -- Sortir de L'Inventaire \n Choix : ");
            int x;
            while (int.TryParse(Console.ReadLine(), out x) == false)
            {
            }

            if (x < 1 & x > Inventaire.Count)
            {
                MenuInventaire();
            }

            switch (x)
            {
                case 1:
                    EquiperArmeArmure();
                    break;
                case 2:
                    AfficherStatsMenu();
                    break;
                case 3:
                    break;
                default:
                    MenuInventaire();
                    break;
            }
        }

        private void AfficherStatsMenu()
        {
            Console.Write($"Quel Objet ? \n Choix : ");
            int y = 0;
            while (int.TryParse(Console.ReadLine(), out y) == false)
            {
            }

            if (y < 1 | y > Inventaire.Count) MenuInventaire();

            // afficher item stats
            ObjInventaire choisi = Inventaire.ElementAt(y - 1);
            AfficherStatsItem(choisi);
            MenuInventaire();
        }

        public void AfficherStatsItem(ObjInventaire choisi)
        {
            if (choisi.Armure != null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n------------------------------------------------------\n" +
                                  $"Nom : {choisi.Armure.NomObjet}\n" +
                                  $"Element : {choisi.Armure.TypeElement}\nDefense : {choisi.Armure.Defense}" +
                                  $"\n------------------------------------------------------\n");
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            if (choisi.Arme != null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n------------------------------------------------------\nNom : {choisi.Arme.NomObjet} \n" +
                                  $"Element : {choisi.Arme.TypeElement}\nPuissance : {choisi.Arme.Puissance}" +
                                  $"\n------------------------------------------------------\n");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            if (choisi.ObjetCons != null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n------------------------------------------------------\nNom : {choisi.ObjetCons.NomObjet}" +
                                  $" \nType : {choisi.ObjetCons.TypeConsumable}\n" +
                                  $"Element : {choisi.ObjetCons.TypeElement}\nPuissance : {choisi.ObjetCons.Puissance}" +
                                  $"\n------------------------------------------------------\n");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        public void EquiperArmeArmure()
        {
            int count = 1;
            foreach (var objet in Inventaire)
            {
                if (objet.Armure != null)
                {
                    Console.WriteLine($"{count} -- {objet.Armure.NomObjet}");
                }

                if (objet.Arme != null)
                {
                    Console.WriteLine($"{count} -- {objet.Arme.NomObjet}");
                }

                ++count;
            }

            Console.Write($"Que voulez vous faire ? \n 1 -- Equipper \n 2 -- Retour a l'Inventaire \n Choix : ");
            int x = 0;
            while (int.TryParse(Console.ReadLine(), out x) == false)
            {
            }

            if (x < 1 | x > 2)
            {
                EquiperArmeArmure();
            }
            else
                switch (x)
                {
                    case 1:
                        Console.Write($"Quelle Arme ou Armure ? \n Choix : ");
                        int y = 0;
                        while (int.TryParse(Console.ReadLine(), out y) == false)
                        {
                        }

                        if (y < 1 | y > Inventaire.Count)
                        {
                            EquiperArmeArmure();
                        }


                        if (Inventaire.ElementAt(y - 1).Armure != null)
                        {
                            Inventaire.Add(new ObjInventaire(Armure));
                            Armure = Inventaire.ElementAt(y - 1).Armure;
                            Inventaire.RemoveAt(y - 1);
                        }

                        if (Inventaire.ElementAt(y - 1).Arme != null)
                        {
                            Inventaire.Add(new ObjInventaire(Arme));
                            Arme = Inventaire.ElementAt(y - 1).Arme;
                            Inventaire.RemoveAt(y - 1);
                        }
                        else
                        {
                            Console.WriteLine("Choix Invalide");
                        }


                        MenuInventaire();

                        break;
                    case 2:
                        MenuInventaire();
                        break;
                }
        }

        private void AfficherInventaire()
        {
            int count = 1;
            foreach (var objet in Inventaire)
            {
                if (objet.ObjetCons != null)
                {
                    Console.WriteLine($"{count} -- {objet.ObjetCons.NomObjet}");
                }

                if (objet.Arme != null)
                {
                    Console.WriteLine($"{count} -- {objet.Arme.NomObjet}");
                }

                if (objet.Armure != null)
                {
                    Console.WriteLine($"{count} -- {objet.Armure.NomObjet}");
                }

                ++count;
            }
        }
    }
}
