using System;
using System.Linq;
using System.Runtime.InteropServices;
using Game.Library.Classes.ObjClasses;

namespace Game.Library.Classes.EntiteClasses
{
    public partial class Personnage
    {
        public void MenuInventaire()
        {
            Console.Clear();
            AfficherInventaire();
            Console.Write(
                $"Que voulez vous faire ?\n" +
                $"     1 -- Equipper \n" +
                $"     2 -- Voir Les Statistiques\n" +
                $"     3 -- Sortir de L'Inventaire \n" +
                $"     Choix : ");
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
            Console.Clear();
            AfficherInventaire();
            Console.Write($"Quel Objet ?\n     Choix : ");
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
            Console.Clear();
            int count = 0;
            if (choisi.Armure != null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"╔═════════════════════════════════════════════════╗\n");
                ++count;

                Console.SetCursorPosition(0, count);
                Console.Write($"║ Nom     : {choisi.Armure.NomObjet}");
                Console.SetCursorPosition(50, count);
                Console.Write("║");
                ++count;

                Console.SetCursorPosition(0, count);
                Console.Write($"║ Element : {choisi.Armure.TypeElement}");
                Console.SetCursorPosition(50, count);
                Console.Write("║");
                ++count;

                Console.SetCursorPosition(0, count);
                Console.Write($"║ Defense : {choisi.Armure.Defense}");
                Console.SetCursorPosition(50, count);
                Console.Write("║");
                ++count;
                Console.SetCursorPosition(0, count);
                Console.Write("╚═════════════════════════════════════════════════╝\n");
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            if (choisi.Arme != null)
            {

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"╔═════════════════════════════════════════════════╗\n");
                ++count;

                Console.SetCursorPosition(0, count);
                Console.Write($"║ Nom        : {choisi.Arme.NomObjet}");
                Console.SetCursorPosition(50, count);
                Console.Write("║");
                ++count;

                Console.SetCursorPosition(0, count);
                Console.Write($"║ Element   : {choisi.Arme.TypeElement}");
                Console.SetCursorPosition(50, count);
                Console.Write("║");
                ++count;

                Console.SetCursorPosition(0, count);
                Console.Write($"║ Puissance : {choisi.Arme.Puissance}");
                Console.SetCursorPosition(50, count);
                Console.Write("║");
                ++count;
                Console.SetCursorPosition(0, count);
                Console.Write("╚═════════════════════════════════════════════════╝\n");
                Console.ForegroundColor = ConsoleColor.Gray;  
            }
            if (choisi.ObjetCons != null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"╔═════════════════════════════════════════════════╗\n");
                ++count;

                Console.SetCursorPosition(0, count);
                Console.Write($"║ Nom      : {choisi.ObjetCons.NomObjet}");
                Console.SetCursorPosition(50, count);
                Console.Write("║");
                ++count;

                Console.SetCursorPosition(0, count);
                Console.Write($"║ Element   : {choisi.ObjetCons.TypeElement}");
                Console.SetCursorPosition(50, count);
                Console.Write("║");
                ++count;

                Console.SetCursorPosition(0, count);
                Console.Write($"║ Type      : {choisi.ObjetCons.TypeConsumable}");
                Console.SetCursorPosition(50, count);
                Console.Write("║");
                ++count;

                Console.SetCursorPosition(0, count);
                Console.Write($"║ Puissance : {choisi.ObjetCons.Puissance}");
                Console.SetCursorPosition(50, count);
                Console.Write("║");
                ++count;

                Console.SetCursorPosition(0, count);
                Console.Write("╚═════════════════════════════════════════════════╝\n");
                Console.ForegroundColor = ConsoleColor.Gray;

            }
            Console.WriteLine("\nAppuyez sur Entree pour retourner au menu !");
            Console.ReadLine();
        }

        public void EquiperArmeArmure()
        {
            int count = 1;
            foreach (var objet in Inventaire)
            {
                if (objet.Armure != null)
                {
                    Console.WriteLine($"||{count}\t-- {objet.Armure.NomObjet}\t||");
                }

                if (objet.Arme != null)
                {
                    Console.WriteLine($"||{count}\t-- {objet.Arme.NomObjet}\t||");
                }

                ++count;
            }

            Console.Write($"Que voulez vous faire ?\n" +
                          $"     1 -- Equipper \n"+
                          $"     2 -- Retour a l'Inventaire\n" +
                          $"     Choix : ");
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
                        Console.Write($"Quelle Arme ou Armure ? \n" +
                                      $"Choix : ");
                        int y = 0;
                        while (int.TryParse(Console.ReadLine(), out y) == false)
                        {
                        }

                        if (y < 1 | y > Inventaire.Count)
                        {
                            EquiperArmeArmure();
                        }
                        Console.Clear();

                        if (Inventaire.ElementAt(y - 1).Armure != null)
                        {
                            Inventaire.Add(new ObjInventaire(Armure));
                            Armure = Inventaire.ElementAt(y - 1).Armure;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"\nVous Equippez l'Armure : {Armure.NomObjet} !\n");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Inventaire.RemoveAt(y - 1);
                        }

                        if (Inventaire.ElementAt(y - 1).Arme != null)
                        {
                            Inventaire.Add(new ObjInventaire(Arme));
                            Arme = Inventaire.ElementAt(y - 1).Arme;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"\nVous Equippez l'Arme : {Arme.NomObjet} !\n");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Inventaire.RemoveAt(y - 1);
                        }
                        else
                        {
                            Console.WriteLine("Choix Invalide\n");
                        }
                        Console.WriteLine("Appuyez sur Entree pour retourner au menu !");
                        Console.ReadLine();

                        MenuInventaire();

                        break;
                    case 2:
                        MenuInventaire();
                        break;
                }
        }

        private void AfficherInventaire()
        {
            Console.ForegroundColor = ConsoleColor.White;
            int count = 0;
            Console.SetCursorPosition(0, count);
            Console.WriteLine($"╔═════════════════════════════════════════════════╗");
            ++count;
            foreach (var objet in Inventaire)
            {
        
                if (objet.ObjetCons != null)
                {
                    Console.SetCursorPosition(0,count);
                    Console.WriteLine($"║ {count}  -- {objet.ObjetCons.NomObjet}");
                    Console.SetCursorPosition(50,count);
                    Console.Write("║");
                }

                if (objet.Arme != null)
                {
                    Console.SetCursorPosition(0,count);
                    Console.WriteLine($"║ {count}  -- {objet.Arme.NomObjet}");
                    Console.SetCursorPosition(50, count);
                    Console.Write("║");
                }

                if (objet.Armure != null)
                {
                    Console.SetCursorPosition(0,count);
                    Console.WriteLine($"║ {count}  -- {objet.Armure.NomObjet}");
                    Console.SetCursorPosition(50, count);
                    Console.Write("║");
                }

                ++count;
               

            }
            Console.SetCursorPosition(0, count);
            Console.WriteLine($"╚═════════════════════════════════════════════════╝");
            ++count;
            Console.SetCursorPosition(0, count);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
