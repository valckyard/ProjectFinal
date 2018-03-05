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
                        Console.WriteLine($"{persJoueur.Nom} Attaque !");
                        Attaque(persJoueur, ref persEnnemi);
                        break;

                    case AttaqueCondition.Defense:
                        Console.WriteLine($"{persEnnemi.Nom} Attaque !");
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
                    win = true;
                }
            }

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
                Thread.Sleep(250);

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
                    Console.WriteLine($"{persJ.Nom} Attaque !");

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
                    Thread.Sleep(250);
                }



                if (cond == AttaqueCondition.Defense)
                {
                    Console.WriteLine($"{baddie.Name} Attaque !");
                    var typeatt = TypeAttaqueEnnemi(baddie);


                    switch (typeatt)
                    {
                        case AttaqueChoisie.AttaqueArme:
                            persJ.RecevoirFrappeDeEnnemi(baddie);
                            break;
                    }
                    //WaitAfterAtt
                    Thread.Sleep(250);
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
                }
            }

            persJ.AddXpEnnemi(baddie);
            persJ.CheckLevelPlayer();
            baddie.Loot(ref persJ);
        }

        public static void GameOver()
        {
            Console.WriteLine($"  ▄▄ •  ▄▄▄· • ▌ ▄ ·. ▄▄▄ .          ▌ ▐·▄▄▄ .▄▄▄      ▄▄\n "+
                               " ▐█ ▀ ▪▐█ ▀█ ·██ ▐███▪▀▄.▀·   ▪     ▪█·█▌▀▄.▀·▀▄ █·    ██▌\n"+
                               "▄█ ▀█▄▄█▀▀█ ▐█ ▌▐▌▐█·▐▀▀▪▄     ▄█▀▄ ▐█▐█•▐▀▀▪▄▐▀▀▄     ▐█·\n"+
                               "▐█▄▪▐█▐█ ▪▐▌██ ██▌▐█▌▐█▄▄▌    ▐█▌.▐▌ ███ ▐█▄▄▌▐█•█▌    .▀ \n"+
                               "·▀▀▀▀  ▀  ▀ ▀▀  █▪▀▀▀ ▀▀▀      ▀█▄▀▪. ▀   ▀▀▀ .▀  ▀     ▀ ");
            Console.WriteLine($"\n\nPress Any Key to Exit......");
            Console.ReadKey();
            Environment.Exit(1);
        }
    }
}