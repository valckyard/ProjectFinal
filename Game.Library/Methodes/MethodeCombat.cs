using System;
using System.Threading;
using Game.Library.Classes;
using Game.Library.Classes.EntiteClasses;
using Game.Library.Enums;
using Personnage = Game.Library.Classes.EntiteClasses.Personnage;

namespace Game.Library.Methodes
{
    public class MethodeCombat
    {
        public static double Dommage(TypeElement elementattaque, TypeElement elementdefense)
        {
            switch (elementattaque)
            {
                case TypeElement.Physique:
                    if (elementdefense == TypeElement.Etheral)
                    {
                        return 0.5;
                    }
                    else
                    {
                        return 1;
                    }

                case TypeElement.Etheral:

                    return 1;

                case TypeElement.Air:

                    if (elementdefense == TypeElement.Eau)
                    {
                        return 1.5;
                    }
                    else if (elementdefense == TypeElement.Terre)
                    {
                        return 0.5;
                    }
                    else
                    {
                        return 1;
                    }

                case TypeElement.Feu:
                    if (elementdefense == TypeElement.Terre)
                    {
                        return 1.5;
                    }
                    else if (elementdefense == TypeElement.Eau)
                    {
                        return 0.5;
                    }
                    else
                    {
                        return 1;
                    }
                case TypeElement.Eau:
                    if (elementdefense == TypeElement.Feu)
                    {
                        return 1.5;
                    }
                    else if (elementdefense == TypeElement.Air)
                    {
                        return 0.5;
                    }
                    else
                    {
                        return 1;
                    }
                case TypeElement.Terre:
                    if (elementdefense == TypeElement.Feu)
                    {
                        return 0.5;
                    }
                    else if (elementdefense == TypeElement.Air)
                    {
                        return 1.5;
                    }
                    else
                    {
                        return 1;
                    }
            }

            return 1;
        }

        public static AttaqueChoisie TypeAttaqueEnnemi(Ennemi baddie)
        {
            return AttaqueChoisie.AttaqueArme;
        }

        public static AttaqueChoisie TypeAttaquePersonnage(Personnage perso)
        {
            var attType = new ClasseTypeAttaque
            {
                AttaqueArme = 60,
                AttaqueSort = 40,
                Item = 10
            };


            switch (perso.Race)
            {
                case PersonnageRace.Humain:
                    attType = TypeAttSwitchClasse(perso.Classe, attType);
                    break;
                case PersonnageRace.Nain:
                    attType = TypeAttSwitchClasse(perso.Classe, attType);
                    break;
                case PersonnageRace.Elfe:
                    attType = TypeAttSwitchClasse(perso.Classe, attType);
                    break;
            }

            attType.RandomType();
            return attType.Choix;
        }

        public static ClasseTypeAttaque TypeAttSwitchClasse(PersonnageClasse perso, ClasseTypeAttaque chances)
        {
            switch (perso)
            {
                case PersonnageClasse.Barbare:
                    break;
                case PersonnageClasse.Guerrier:
                    break;
                case PersonnageClasse.Magicien:
                    break;
            }

            return chances;
        }

        public static void CombatPersonnage(ref Personnage persJoueur,ref Personnage persEnnemi)
        {
            bool win = false;

            var cond = persJoueur.Vitesse > persEnnemi.Vitesse ? AttaqueCondition.Attaque : AttaqueCondition.Defense;

            while (!win)
            {

                switch (cond)
                {
                    case AttaqueCondition.Attaque:
                        Console.WriteLine($"\n{persJoueur.Nom} Attaque !");
                        Console.ForegroundColor = ConsoleColor.White;
                        Attaque(persJoueur, ref persEnnemi);
                        break;

                    case AttaqueCondition.Defense:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"\n{persEnnemi.Nom} Attaque !");
                        Console.ForegroundColor = ConsoleColor.White;
                        Attaque(persEnnemi, ref persJoueur);
                        break;

                }
              

                cond = cond == AttaqueCondition.Attaque ? AttaqueCondition.Defense : AttaqueCondition.Attaque;


                if (!(persJoueur.PvActuels <= 0 | persEnnemi.PvActuels <= 0)) continue;
                if (persJoueur.PvActuels <= 0)
                {
                    GameOver();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"{persJoueur.Nom} a Vaincu {persEnnemi.Nom} !!!!!\nVous avez Gagne !\n");
                    win = true;
                }
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            persJoueur.AddXpPersonnage(persEnnemi);
            persJoueur.CheckLevelPlayer();
            persEnnemi.Loot(ref persJoueur);
        }


        private static void Attaque(Personnage attaquant, ref Personnage defenseur)
        {
            bool successoption = false;

            while (true)
            {
             

                var typeatt = TypeAttaquePersonnage(attaquant);

                switch (typeatt)
                {
                    case AttaqueChoisie.AttaqueArme:
                        attaquant.FrapperPersonnage(ref defenseur);
                        successoption = true;
                        break;
                    case AttaqueChoisie.AttaqueSort:
                        successoption = attaquant.LancerSortVsPerso(ref defenseur,null);
                        break;
                    case AttaqueChoisie.Item:
                        successoption = attaquant.UtiliserItemVsPerso(ref defenseur);
                        break;
                }

                if (!successoption)
                {
                    continue;
                }
                //WaitAfterAtt
                Thread.Sleep(450);

                break;
            }
        }


        public static void AttaqueEnnemi(ref Personnage persJ, ref Ennemi baddie)
        {
            bool win = false;
            var cond = persJ.Vitesse > baddie.Vitesse ? AttaqueCondition.Attaque : AttaqueCondition.Defense;
            while (!win)
            {

                if (cond == AttaqueCondition.Attaque)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\n{persJ.Nom} Attaque !");
                    Console.ForegroundColor = ConsoleColor.White;
                    bool successoption = true;
                    var typeatt = TypeAttaquePersonnage(persJ);


                    switch (typeatt)
                    {
                        case AttaqueChoisie.AttaqueArme:
                            persJ.FrapperEnnemi(ref baddie);
                            break;
                        case AttaqueChoisie.AttaqueSort:
                            successoption = persJ.LancerSortVsEnnemi(ref baddie, null);
                            break;
                        case AttaqueChoisie.Item:
                            successoption = persJ.UtiliserItemVsEnnemi(ref baddie);
                            break;
                    }



                    if (!successoption)
                    {
                        continue;
                    }
                    //WaitAfterAtt
                    Thread.Sleep(450);
                }



                if (cond == AttaqueCondition.Defense)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n{baddie.Name} Attaque !");
                    Console.ForegroundColor = ConsoleColor.White;
                    var typeatt = TypeAttaqueEnnemi(baddie);


                    switch (typeatt)
                    {
                        case AttaqueChoisie.AttaqueArme:
                            persJ.RecevoirFrappeDeEnnemi(baddie);
                            break;
                    }
                    //WaitAfterAtt
                    Thread.Sleep(450);
                }


                cond = cond == AttaqueCondition.Attaque ? AttaqueCondition.Defense : AttaqueCondition.Attaque;

                if (!(persJ.PvActuels <= 0 | baddie.Pv <= 0)) continue;
                if (persJ.PvActuels <= 0)
                {
                    GameOver();
                }
                else
                {
                    win = true;
      
                    Console.WriteLine($"{persJ.Nom} a Vaincu {baddie.Name} !!!!!\nVous avez Gagne !");
                    Console.WriteLine("\nAppuyez sur une touche pour continuer....!");
                    Console.ReadLine();
                    Console.Clear();
                }
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            persJ.AddXpEnnemi(baddie);
            persJ.CheckLevelPlayer();
            baddie.Loot(ref persJ);
        }

        public static void GameOver()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"  ▄▄ •  ▄▄▄· • ▌ ▄ ·. ▄▄▄ .          ▌ ▐·▄▄▄ .▄▄▄      ▄▄\n " +
                               " ▐█ ▀ ▪▐█ ▀█ ·██ ▐███▪▀▄.▀·   ▪     ▪█·█▌▀▄.▀·▀▄ █·    ██▌\n"+
                               "▄█ ▀█▄▄█▀▀█ ▐█ ▌▐▌▐█·▐▀▀▪▄     ▄█▀▄ ▐█▐█•▐▀▀▪▄▐▀▀▄     ▐█·\n"+
                               "▐█▄▪▐█▐█ ▪▐▌██ ██▌▐█▌▐█▄▄▌    ▐█▌.▐▌ ███ ▐█▄▄▌▐█•█▌    .▀ \n"+
                               "·▀▀▀▀  ▀  ▀ ▀▀  █▪▀▀▀ ▀▀▀      ▀█▄▀▪. ▀   ▀▀▀ .▀  ▀     ▀ ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"\n\nPress Any Key to Exit......");
            Console.ReadKey();
            Environment.Exit(1);
        }
    }
}