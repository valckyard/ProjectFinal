using System;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using Game.Library.Enums;
using Game.Library.TypePersonnage;

namespace Game.Library.Methodes
{
    public class MethodeCombat
    {
        public static double Dommage(ElementType elementattaque, ElementType elementdefense)
        {
            switch (elementattaque)
            {
                case ElementType.Physique:
                    if (elementdefense == ElementType.Etheral)
                    {
                        return 0.5;
                    }
                    else
                    {
                        return 1;
                    }

                case ElementType.Etheral:

                    return 1;

                case ElementType.Air:

                    if (elementdefense == ElementType.Eau)
                    {
                        return 1.5;
                    }
                    else if (elementdefense == ElementType.Terre)
                    {
                        return 0.5;
                    }
                    else
                    {
                        return 1;
                    }

                case ElementType.Feu:
                    if (elementdefense == ElementType.Terre)
                    {
                        return 1.5;
                    }
                    else if (elementdefense == ElementType.Eau)
                    {
                        return 0.5;
                    }
                    else
                    {
                        return 1;
                    }
                case ElementType.Eau:
                    if (elementdefense == ElementType.Feu)
                    {
                        return 1.5;
                    }
                    else if (elementdefense == ElementType.Air)
                    {
                        return 0.5;
                    }
                    else
                    {
                        return 1;
                    }
                case ElementType.Terre:
                    if (elementdefense == ElementType.Feu)
                    {
                        return 0.5;
                    }
                    else if (elementdefense == ElementType.Air)
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

        public static AttaqueChoisie TypeAttaquePersonnage(Personnages perso)
        {
            var attType = new TypeAttaque
            {
                AttaqueArme = 60,
                AttaqueSort = 30,
                Item = 10
            };


            switch (perso.Race)
            {
                case Race.Humain:
                    attType = TypeAttSwitchClasse(perso.Classe, attType);
                    break;
                case Race.Nain:
                    attType = TypeAttSwitchClasse(perso.Classe, attType);
                    break;
                case Race.Elfe:
                    attType = TypeAttSwitchClasse(perso.Classe, attType);
                    break;
            }

            attType.RandomType();
            return attType.Choix;
        }

        public static TypeAttaque TypeAttSwitchClasse(Classe perso, TypeAttaque chances)
        {
            switch (perso)
            {
                case Classe.Barbare:
                    break;
                case Classe.Guerrier:
                    break;
                case Classe.Magicien:
                    break;
            }

            return chances;
        }

        public static void AttaquePersonnage(ref Personnages persJoueur, ref Personnages persEnnemi)
        {
            bool win = false;

            var cond = persJoueur.PtsVitesse > persEnnemi.PtsVitesse ? ConditionAttaque.Attaque : ConditionAttaque.Defense;

            while (!win)
            {

                switch (cond)
                {
                    case ConditionAttaque.Attaque:
                        Attaque(persJoueur, ref persEnnemi);
                        break;

                    case ConditionAttaque.Defense:
                        Attaque(persEnnemi, ref persJoueur);
                        break;

                }
              

                cond = cond == ConditionAttaque.Attaque ? ConditionAttaque.Defense : ConditionAttaque.Attaque;


                if (!(persJoueur.PtsVieActuel <= 0 | persEnnemi.PtsVieActuel <= 0)) continue;
                if (persJoueur.PtsVieActuel <= 0)
                {
                    GameOver();
                }
                else
                {
                    win = true;
                }
            }

            // Attaquant.AddXP(Defenseur.ValeurPtsExperiences);
            persJoueur.CheckLevelPlayer();
        }


        private static void Attaque(Personnages attaquant, ref Personnages defenseur)
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
                        successoption = attaquant.LancerSortVsPerso(ref defenseur);
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


        public static void AttaqueEnnemi(ref Personnages persJ, ref Ennemi baddie)
        {
            bool win = false;
            var cond = persJ.PtsVitesse > baddie.Vitesse ? ConditionAttaque.Attaque : ConditionAttaque.Defense;

            while (!win)
            {

                if (cond == ConditionAttaque.Attaque)
                {


                    bool successoption = true;
                    var typeatt = TypeAttaquePersonnage(persJ);


                    switch (typeatt)
                    {
                        case AttaqueChoisie.AttaqueArme:
                            persJ.FrapperEnnemi(ref baddie);
                            break;
                        case AttaqueChoisie.AttaqueSort:
                            successoption = persJ.LancerSortVsEnnemi(ref baddie);
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



                if (cond == ConditionAttaque.Defense)
                {
                    var typeatt = TypeAttaqueEnnemi(baddie);


                    switch (typeatt)
                    {
                        case AttaqueChoisie.AttaqueArme:
                            persJ.RecevoirFrappeDeEnnemi(baddie);
                            break;
                    }
                }


                cond = cond == ConditionAttaque.Attaque ? ConditionAttaque.Defense : ConditionAttaque.Attaque;


                if (!(persJ.PtsVieActuel <= 0 | baddie.PtsVie <= 0)) continue;
                if (persJ.PtsVieActuel <= 0)
                {
                    GameOver();
                }
                else
                {
                    win = true;
                }
            }

            // Attaquant.AddXP(baddie.ValeurPtsExperiences);
            persJ.CheckLevelPlayer();
        }

        public static void GameOver()
        {
            Console.WriteLine("ta perdu sti");
        }
    }
}