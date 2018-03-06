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
                    Console.Clear();
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
            Console.Write($"     Quel Objet ?\n     Choix : ");
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
            Console.Clear();
            int count = 1;
            int counta = 0;

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"╔═════════════════════════════════════════════════╗\n");
            ++counta;
            foreach (var objet in Inventaire)
            {
                if (objet.Armure != null)
                {
                    Console.SetCursorPosition(0, counta);
                    Console.Write($"║ {count} -- {objet.Armure.NomObjet}");
                    Console.SetCursorPosition(50, counta);
                    Console.Write("║");
                    ++counta;
                }

                if (objet.Arme != null)
                {
                    Console.SetCursorPosition(0, counta);
                    Console.Write($"║ {count} -- {objet.Arme.NomObjet}");
                    Console.SetCursorPosition(50, counta);
                    Console.Write("║");
                    ++counta;
                }

                ++count;
            }
            Console.SetCursorPosition(0, counta);
            Console.Write("╚═════════════════════════════════════════════════╝\n");
            Console.ForegroundColor = ConsoleColor.Gray;
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
                        Console.Write($"\n     Quelle Arme ou Armure ? \n" +
                                      $"     Choix : ");
                        int y = 0;
                        while (int.TryParse(Console.ReadLine(), out y) == false)
                        {
                        }

                        if (y < 1 | y > Inventaire.Count)
                        {
                            EquiperArmeArmure();
                        }


                        AfficheEquipedNew(y);

                        break;
                    case 2:
                        MenuInventaire();
                        break;
                }
        }

        private void AfficheEquipedNew(int y)
        {
            Console.Clear();
            bool happenned = false;




            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"╔═════════════════════════════════════════════════╗\n");
            int counteq = 1;

            //Si inventaire vide skip tout cela
            if (Inventaire.Count != 0)
            {

                if (Inventaire.ElementAt(y - 1).Armure == null && Inventaire.ElementAt(y - 1).Arme == null)
                {
                    Console.SetCursorPosition(0, counteq);
                    Console.Write($"║ Choix Invalide !");
                    Console.SetCursorPosition(50, counteq);
                    Console.Write("║");
                    ++counteq;
                }

                if (Inventaire.ElementAt(y - 1).Armure != null & !happenned)
                {
                    Inventaire.Add(new ObjInventaire(Armure));

                    Console.SetCursorPosition(0, counteq);
                    Console.Write($"║ Vous Retirez l'Armure : ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{Armure.NomObjet} !");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(50, counteq);
                    Console.Write("║");
                    ++counteq;
                    Console.SetCursorPosition(0, counteq);
                    Console.Write($"║ Et vous la mettez dans votre Inventaire !");
                    Console.SetCursorPosition(50, counteq);
                    Console.Write("║");
                    ++counteq;
                    Console.SetCursorPosition(0, counteq);
                    Console.Write($"║ ");
                    Console.SetCursorPosition(50, counteq);
                    Console.Write("║");
                    ++counteq;

                    Armure = Inventaire.ElementAt(y - 1).Armure;

                    Console.SetCursorPosition(0, counteq);
                    Console.Write($"║ Et Vous Equippez l'Armure : ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{Armure.NomObjet} !");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(50, counteq);
                    Console.Write("║");

                    Inventaire.RemoveAt(y - 1);
                    ++counteq;

                    happenned = true;
                }

                if (Inventaire.ElementAt(y - 1).Arme != null & !happenned)
                {
                    Inventaire.Add(new ObjInventaire(Arme));

                    Console.SetCursorPosition(0, counteq);
                    Console.Write($"║ Vous Retirez l'Arme : ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{Arme.NomObjet} !");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(50, counteq);
                    Console.Write("║");
                    ++counteq;
                    Console.SetCursorPosition(0, counteq);
                    Console.Write($"║ Et vous la mettez dans votre Inventaire !");
                    Console.SetCursorPosition(50, counteq);
                    Console.Write("║");
                    ++counteq;
                    Console.SetCursorPosition(0, counteq);
                    Console.Write($"║ ");
                    Console.SetCursorPosition(50, counteq);
                    Console.Write("║");
                    ++counteq;

                    Arme = Inventaire.ElementAt(y - 1).Arme;

                    Console.SetCursorPosition(0, counteq);
                    Console.Write($"║ Et Vous Equippez l'Arme : ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{Arme.NomObjet} !");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(50, counteq);
                    Console.Write("║");

                    Inventaire.RemoveAt(y - 1);

                    ++counteq;

                    happenned = true;
                }
            }


            Console.SetCursorPosition(0, counteq);
            Console.Write("╚═════════════════════════════════════════════════╝\n");
            counteq += 2;
            Console.ForegroundColor = ConsoleColor.Gray;


            Console.SetCursorPosition(0, counteq);
            Console.WriteLine("Appuyez sur Entree pour retourner au menu !");
            Console.ReadLine();

            MenuInventaire();
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
