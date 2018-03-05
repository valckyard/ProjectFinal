﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Game.Library.Enums;
using Game.Library.Methodes;

namespace Game.Library.Classes.EntiteClasses
{
    public partial class Personnage
    {
        private readonly Random _rand = new Random();
        //############################################ FRAPPE MAGIQUE ##########################################################//
        //############################################ FRAPPE MAGIQUE ##########################################################//
        //############################################ FRAPPE MAGIQUE ##########################################################//

        private Sort ChoixSort()
        {
            if (ListeSorts.Count != 0)
            {
               
                var sortchoisi = new Sort();
                var spellbook = new Dictionary<int, Sort>();
                int x = 1;
                foreach (var s in ListeSorts)
                {
                    spellbook.Add(x, s);
                 
                    x++;
                }

                int spellreponse = _rand.Next(0, ListeSorts.Count)+1;

                foreach (var sort in spellbook)
                {
                    if (spellreponse == sort.Key)
                    {
                        sortchoisi = sort.Value;
                    }
                }

                return sortchoisi;
            }

            return null;
        }



        public bool LancerSortVsEnnemi(ref Ennemi baddie, Sort itemSort)
        {
            Sort sort;
            if(itemSort == null)
            sort = ChoixSort();
            else
            sort = itemSort;


            if (sort != null)
                if (MpActuel >= sort.CoutMp)
                {
                    if (sort.TypeElement != TypeElement.Lumiere)
                    {
                        MpActuel -= sort.CoutMp;
                        if (sort.CoutMp ==0)
                            Console.WriteLine($"\n{Nom} utilise {sort.NomSort} sur {baddie.Name} le {baddie.TypeEnnemi}");
                        else
                        Console.WriteLine($"\n{Nom} lance le sort {sort.NomSort} a {baddie.Name} le {baddie.TypeEnnemi}");

                        double dmg = DammageCalculatorMagicEnnemi(baddie, sort);

                        Console.WriteLine($"{baddie.Name} prends {dmg} de dommage dans la geule!\n");
                        baddie.Pv -= (int) dmg;
                        return true;
                    }
                    else // ElementType.Lumiere
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        MpActuel -= sort.CoutMp;
                        if (sort.CoutMp == 0)
                            Console.WriteLine($"\n{Nom} utilise {sort.NomSort} !");

                        else
                            Console.WriteLine($"\n{Nom} lance le sort {sort.NomSort} !");

                        int heal = (int) PuissanceMagique * sort.Puissance;
                        PvActuels += heal;
                        if (PvActuels > PvMax)
                        {
                            PvActuels = PvMax;
                        }

                        Console.WriteLine($"{Nom} se soigne de {heal} Points de vie !\n\n");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        return true;
                    }
                }
                else
                {
                    Console.WriteLine(
                        $"\n{Nom} pas lancer le sort {sort.NomSort} il coute {sort.CoutMp} MP et il n'a que {MpActuel} MP\n");
                    return false;
                }

            return false;
        }

        public bool LancerSortVsPerso(ref Personnage defenseur, Sort itemSort)
        {
            Sort sort;
            if (itemSort == null)
                sort = ChoixSort();
            else
                sort = itemSort;

            if (sort != null)
                if (MpActuel >= sort.CoutMp)
                {
                    if (sort.TypeElement != TypeElement.Lumiere)
                    {
                        MpActuel -= sort.CoutMp;
                        if (sort.CoutMp == 0)
                            Console.WriteLine($"\n{Nom} utilise {sort.NomSort} a {defenseur.Nom} le {defenseur.Race}");
                        else
                            Console.WriteLine($"\n{Nom} lance le sort {sort.NomSort} a {defenseur.Nom} le {defenseur.Race}");


                        double dmg = DammageCalculatorMagicPerso(defenseur, sort);

                        Console.WriteLine($"{defenseur.Nom} prends {dmg} de dommage dans la geule!\n");
                        defenseur.PvActuels -= (int) dmg;
                        return true;
                    }
                    else // ElementType.Lumiere
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        MpActuel -= sort.CoutMp;
                        if (sort.CoutMp == 0)
                            Console.WriteLine($"\n{Nom} utilise {sort.NomSort} !");

                        else
                            Console.WriteLine($"\n{Nom} lance le sort {sort.NomSort} !");
                        int heal = (int) PuissanceMagique * sort.Puissance;
                        PvActuels += heal;
                        if (PvActuels > PvMax)
                        {
                            PvActuels = PvMax;
                        }

                        Console.WriteLine($"{Nom} se soigne de {heal} Points de vie !\n");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        return true;
                    }
                }
                else
                {
                    Console.WriteLine(
                        $"\n{Nom} pas lancer le sort {sort.NomSort} il coute {sort.CoutMp} MP et il n'a que {MpActuel} MP\n");
                    return false;
                }

            return false;
        }


        //############################################ FRAPPE PHYSIQUE ##########################################################//
        //############################################ FRAPPE PHYSIQUE ##########################################################//
        //############################################ FRAPPE PHYSIQUE ##########################################################//


        public void FrapperEnnemi(ref Ennemi baddie)
        {
            Console.WriteLine($"\n{Nom} frappe avec {Arme.NomObjet}  {baddie.Name} le {baddie.TypeEnnemi}");

            //Calc
            double dmg = DammageCalculatorEnnemi(baddie, AttaqueCondition.Attaque);
            //Calc

            Console.WriteLine($"{baddie.Name} prends {(int) dmg} de dommage dans la geule!\n");
            baddie.Pv -= (int) dmg;
        }

        public void RecevoirFrappeDeEnnemi(Ennemi baddie)
        {
            Console.WriteLine($"\n{baddie.Name} frappe {Nom} le {Race}");

            //Calc
            double dmg = DammageCalculatorEnnemi(baddie, AttaqueCondition.Defense);
            //Calc

            Console.WriteLine($"{Nom} prends {dmg} de dommage dans la geule!\n");
            PvActuels -= (int) dmg;
        }

        //Parfait pour Personnage a personnage
        public void FrapperPersonnage(ref Personnage perso)
        {
            Console.WriteLine($"\n{Nom} frappe avec {Arme.NomObjet}  {perso.Nom} le {perso.Race}");

            //Calc
            double dmg = DammageCalculatorPerso(perso, AttaqueCondition.Attaque);
            //Calc

            Console.WriteLine($"{perso.Nom} prends {dmg} de dommage dans la geule!\n");
            perso.PvActuels -= (int) dmg;
        }


        //############################################ DAMAGE CALCULATORS ##########################################################//
        //############################################ DAMAGE CALCULATORS ##########################################################//
        //############################################ DAMAGE CALCULATORS ##########################################################//


        public double DammageCalculatorEnnemi(Ennemi ennemi, AttaqueCondition condition)
        {
            var rand = new Random();
            double Dmg = 0;
            double chance = (rand.Next(-30, 31) / 100);
            switch (condition)
            {
                case AttaqueCondition.Attaque:

                    double mulDMGAtt = MethodeCombat.Dommage(Arme.TypeElement, ennemi.TypeElement);
                    Dmg = ((Puissance + Arme.Puissance) - ennemi.Defense) * mulDMGAtt;
                    Dmg = Dmg + (Dmg * chance);
                    return Dmg;

                case AttaqueCondition.Defense:
                    double mulDMGDef = MethodeCombat.Dommage(ennemi.TypeElement, Arme.TypeElement);
                    Dmg = (ennemi.Puissance - (Defense + Armure.Defense)) * mulDMGDef;
                    Dmg = Dmg + (Dmg * chance);
                    return Dmg;
            }

            return 0;
        }

        public double DammageCalculatorPerso(Personnage personnageE, AttaqueCondition condition)
        {
            var rand = new Random();
            double Dmg = 0;
            double chance = (rand.Next(-30, 31) / 100);

            switch (condition)
            {
                case AttaqueCondition.Attaque:

                    double mulDMGAtt = MethodeCombat.Dommage(Arme.TypeElement, personnageE.Armure.TypeElement);
                    Dmg = ((Puissance + Arme.Puissance) - personnageE.Defense + personnageE.Armure.Defense) *
                          mulDMGAtt;
                    Dmg = Dmg + (Dmg * chance);
                    return Dmg;

                case AttaqueCondition.Defense:
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