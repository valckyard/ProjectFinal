﻿using System;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
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
                AttaqueSort = 30,
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

        public static void AttaquePersonnage(ref Personnage persJoueur,Personnage persEnnemi)
        {
            bool win = false;

            var cond = persJoueur.Vitesse > persEnnemi.Vitesse ? AttaqueCondition.Attaque : AttaqueCondition.Defense;

            while (!win)
            {

                switch (cond)
                {
                    case AttaqueCondition.Attaque:
                        Attaque(persJoueur, ref persEnnemi);
                        break;

                    case AttaqueCondition.Defense:
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
        }


        private static void Attaque(Personnage attaquant, ref Personnage defenseur)
        {
            while (true)
            {
                var typeatt = TypeAttaquePersonnage(attaquant);
                bool successoption = true;

                switch (typeatt)
                {
                    case AttaqueChoisie.AttaqueArme:
                        attaquant.FrapperPersonnage(ref defenseur);
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

                break;
            }
        }


        public static void AttaqueEnnemi(ref Personnage persJ,Ennemi baddie)
        {
            bool win = false;
            var cond = persJ.Vitesse > baddie.Vitesse ? AttaqueCondition.Attaque : AttaqueCondition.Defense;

            while (!win)
            {

                if (cond == AttaqueCondition.Attaque)
                {


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

                    break;
                }



                if (cond == AttaqueCondition.Defense)
                {
                    var typeatt = TypeAttaqueEnnemi(baddie);


                    switch (typeatt)
                    {
                        case AttaqueChoisie.AttaqueArme:
                            persJ.RecevoirFrappeDeEnnemi(baddie);
                            break;
                    }
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
        }

        public static void GameOver()
        {
            Console.WriteLine("ta perdu sti");
        }
    }
}