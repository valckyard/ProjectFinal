using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Game.Library.Enums;
using Game.Library.Methodes;
using Game.Library.Objets;

namespace Game.Library.TypePersonnage
{
    public partial class Personnage
    {
        //############################################ FRAPPE MAGIQUE ##########################################################//
        //############################################ FRAPPE MAGIQUE ##########################################################//
        //############################################ FRAPPE MAGIQUE ##########################################################//


        public bool LancerSortVsEnnemi(ref Ennemi baddie)
        {
            var sort = ChoixSort();
            if (sort != null)
                if (MpActuel >= sort.CoutMp)
                {
                    if (sort.TypeElement != ElementType.Lumiere)
                    {
                        MpActuel -= sort.CoutMp;
                        Console.WriteLine($"{Nom} lance le sort {sort.NomSort} a {baddie.Name} le {baddie.TypeEnnemi}");

                        double dmg = DammageCalculatorMagicEnnemi(baddie, sort);

                        Console.WriteLine($"{baddie.Name} prends {dmg} de dommage dans la geule!");
                        baddie.Pv -= (int) dmg;
                        return true;
                    }
                    else // ElementType.Lumiere
                    {
                        MpActuel -= sort.CoutMp;
                        Console.WriteLine($"{Nom} lance le sort {sort.NomSort} sur lui meme !");
                        int heal = (int) PuissanceMagique * sort.Puissance;
                        PvActuels += heal;
                        if (PvActuels > PvMax)
                        {
                            PvActuels = PvMax;
                        }

                        Console.WriteLine($"{Nom} se soigne de {heal} Points de vie !");
                        return true;
                    }
                }
                else
                {
                    Console.WriteLine(
                        $"{Nom} pas lancer le sort {sort.NomSort} il coute {sort.CoutMp} MP et il n'a que {MpActuel} MP");
                    return false;
                }

            return false;
        }

        public bool LancerSortVsPerso(ref Personnage defenseur)
        {
            var sort = ChoixSort();
            if (sort != null)
                if (MpActuel >= sort.CoutMp)
                {
                    if (sort.TypeElement != ElementType.Lumiere)
                    {
                        MpActuel -= sort.CoutMp;
                        Console.WriteLine($"{Nom} lance le sort {sort.NomSort} a {defenseur.Nom} le {defenseur.Race}");

                        double dmg = DammageCalculatorMagicPerso(defenseur, sort);

                        Console.WriteLine($"{defenseur.Nom} prends {dmg} de dommage dans la geule!");
                        defenseur.PvActuels -= (int) dmg;
                        return true;
                    }
                    else // ElementType.Lumiere
                    {
                        MpActuel -= sort.CoutMp;
                        Console.WriteLine($"{Nom} lance le sort {sort.NomSort} sur lui meme !");
                        int heal = (int) PuissanceMagique * sort.Puissance;
                        PvActuels += heal;
                        if (PvActuels > PvMax)
                        {
                            PvActuels = PvMax;
                        }

                        Console.WriteLine($"{Nom} se soigne de {heal} Points de vie !");
                        return true;
                    }
                }
                else
                {
                    Console.WriteLine(
                        $"{Nom} pas lancer le sort {sort.NomSort} il coute {sort.CoutMp} MP et il n'a que {MpActuel} MP");
                    return false;
                }

            return false;
        }


        //############################################ FRAPPE PHYSIQUE ##########################################################//
        //############################################ FRAPPE PHYSIQUE ##########################################################//
        //############################################ FRAPPE PHYSIQUE ##########################################################//


        public void FrapperEnnemi(ref Ennemi baddie)
        {
            Console.WriteLine($"{Nom} frappe avec {Arme.NomObjet}  {baddie.Name} le {baddie.TypeEnnemi}");

            //Calc
            double dmg = DammageCalculatorEnnemi(baddie, ConditionAttaque.Attaque);
            //Calc

            Console.WriteLine($"{baddie.Name} prends {(int) dmg} de dommage dans la geule!");
            baddie.Pv -= (int) dmg;
        }

        public void RecevoirFrappeDeEnnemi(Ennemi baddie)
        {
            Console.WriteLine($"{baddie.Name} frappe {Nom} le {Race}");

            //Calc
            double dmg = DammageCalculatorEnnemi(baddie, ConditionAttaque.Defense);
            //Calc

            Console.WriteLine($"{Nom} prends {dmg} de dommage dans la geule!");
            PvActuels -= (int) dmg;
        }

        //Parfait pour Personnage a personnage
        public void FrapperPersonnage(ref Personnage perso)
        {
            Console.WriteLine($"{Nom} frappe avec {Arme.NomObjet}  {perso.Nom} le {perso.Race}");

            //Calc
            double dmg = DammageCalculatorPerso(perso, ConditionAttaque.Attaque);
            //Calc

            Console.WriteLine($"{perso.Nom} prends {dmg} de dommage dans la geule!");
            perso.PvActuels -= (int) dmg;
        }


        //############################################ DAMAGE CALCULATORS ##########################################################//
        //############################################ DAMAGE CALCULATORS ##########################################################//
        //############################################ DAMAGE CALCULATORS ##########################################################//


        public double DammageCalculatorEnnemi(Ennemi ennemi, ConditionAttaque condition)
        {
            var rand = new Random();
            double Dmg = 0;
            double chance = (rand.Next(-30, 31) / 100);
            switch (condition)
            {
                case ConditionAttaque.Attaque:

                    double mulDMGAtt = MethodeCombat.Dommage(Arme.TypeElement, ennemi.TypeElement);
                    Dmg = ((Puissance + Arme.Puissance) - ennemi.Defense) * mulDMGAtt;
                    Dmg = Dmg + (Dmg * chance);
                    return Dmg;

                case ConditionAttaque.Defense:
                    double mulDMGDef = MethodeCombat.Dommage(ennemi.TypeElement, Arme.TypeElement);
                    Dmg = (ennemi.Puissance - (Defense + Armure.Defense)) * mulDMGDef;
                    Dmg = Dmg + (Dmg * chance);
                    return Dmg;
            }

            return 0;
        }

        public double DammageCalculatorPerso(Personnage personnageE, ConditionAttaque condition)
        {
            var rand = new Random();
            double Dmg = 0;
            double chance = (rand.Next(-30, 31) / 100);

            switch (condition)
            {
                case ConditionAttaque.Attaque:

                    double mulDMGAtt = MethodeCombat.Dommage(Arme.TypeElement, personnageE.Armure.TypeElement);
                    Dmg = ((Puissance + Arme.Puissance) - personnageE.Defense + personnageE.Armure.Defense) *
                          mulDMGAtt;
                    Dmg = Dmg + (Dmg * chance);
                    return Dmg;

                case ConditionAttaque.Defense:
                    double mulDMGDef = MethodeCombat.Dommage(personnageE.Arme.TypeElement, Armure.TypeElement);
                    Dmg = (personnageE.Puissance - (Defense + Armure.Defense)) * mulDMGDef;
                    Dmg = Dmg + (Dmg * chance);
                    return Dmg;
            }

            return 0;
        }


        public double DammageCalculatorMagicPerso(Personnage defenseur, Sort sort)
        {
            var rand = new Random();
            double Dmg = 0;
            double chance = (rand.Next(-30, 31) / 100);

            double mulDMGAtt = MethodeCombat.Dommage(sort.TypeElement, defenseur.Armure.TypeElement);
            Dmg = ((PuissanceMagique * sort.Puissance) - (defenseur.Defense + defenseur.Armure.Defense)) * mulDMGAtt;
            Dmg = Dmg + (Dmg * chance);
            return Dmg;
        }

        public double DammageCalculatorMagicEnnemi(Ennemi baddie, Sort sort)
        {
            var rand = new Random();
            double Dmg = 0;
            double chance = (rand.Next(-30, 31) / 100);

            double mulDMGAtt = MethodeCombat.Dommage(sort.TypeElement, baddie.TypeElement);
            Dmg = ((PuissanceMagique * sort.Puissance) - (baddie.Defense)) * mulDMGAtt;
            Dmg = Dmg + (Dmg * chance);
            return Dmg;
        }
    }
}