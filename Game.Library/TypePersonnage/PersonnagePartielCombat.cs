using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Library.Enums;
using Game.Library.Methodes;

namespace Game.Library.TypePersonnage
{
   public partial class Personnages
    {


        public bool LancerSort(ref Ennemi baddie)
        {
            var sort = ChoixSort();
            if (PointsMagieActuel >= sort.CoutMp)
            {
                if (sort.TypeElementType != ElementType.Lumiere)
                {
                    PointsMagieActuel -= sort.CoutMp;
                    Console.WriteLine($"{Nom} lance le sort {sort.NomSort} a {baddie.Name} le {baddie.TypeEnnemi}");

                    //Calc
                    int dmg = 1; //CalculateDmgMagique(PuissanceMagique, sort, Ennemi);
                    double dmgmultiplier = MethodeCombat.Dommage(sort.TypeElementType, baddie.TypElementType); // integrer calc
                    //Calc

                    Console.WriteLine($"{baddie.Name} prends {dmg} de dommage dans la geule!");
                    baddie.PtsVie -= dmg;
                    //check death
                    return true;
                }
                else // ElementType.Lumiere
                {
                    PointsMagieActuel -= sort.CoutMp;
                    Console.WriteLine($"{Nom} lance le sort {sort.NomSort} sur lui meme !");
                    int heal = (int)PuissanceMagique * sort.Puissance;
                    PtsVieActuel += heal;
                    if (PtsVieActuel > PtsVieMax)
                    {
                        PtsVieActuel = PtsVieMax;
                    }
                    Console.WriteLine($"{Nom} se soigne de {heal} Points de vie !");
                    return true;
                }
            }
            else
            {
                Console.WriteLine($"Vous ne pouvez pas lancer le sort {sort.NomSort} il coute {sort.CoutMp} MP et vous n'avez que {PointsMagieActuel} MP");
                return false;
            }
        }



        public void Frapper(ref Ennemi baddie)
        {
            Console.WriteLine($"{Nom} frappe avec {Arme.NomObjet}  {baddie.Name} le {baddie.TypeEnnemi}");

            //Calc
            double dmg = DammageCalculator(baddie, ConditionAttaque.Attaque);
            //Calc

            Console.WriteLine($"{baddie.Name} prends {(int)dmg} de dommage dans la geule!");
            baddie.PtsVie -= (int)dmg;
        }



        public void FrapperPersonnage(ref Personnages perso)
        {
            Console.WriteLine($"{Nom} frappe avec {Arme.NomObjet}  {perso.Nom} le {perso.Race}");

            //Calc
            double dmg = DammageCalculatorPerso(perso, ConditionAttaque.Attaque);
            //Calc

            Console.WriteLine($"{perso.Nom} prends {dmg} de dommage dans la geule!");
            perso.PtsVieActuel -= (int)dmg;
        }



        public void RecevoirFrappe(Ennemi baddie)
        {
            Console.WriteLine($"{baddie.Name} frappe {Nom} le {Race}");

            //Calc
            double dmgmultiplier = MethodeCombat.Dommage(baddie.TypElementType, ElementType.Physique);
            int dmg = 1; //CalculateDmgObjet(baddie.Puissance);
            //Calc

            Console.WriteLine($"{Nom} prends {dmg} de dommage dans la geule!");
            PtsVieActuel -= dmg;
        }




        public void RecevoirFrappePersonnage(Personnages perso)
        {
            Console.WriteLine($"{perso.Nom} frappe {Nom} le {Race}");

            //Calc
            double dmgmultiplier = MethodeCombat.Dommage(perso.Arme.TypeElement, ElementType.Physique);
            int dmg = 1; //CalculateDmgObjet(perso.Puissance, Perso.Arme);
            //Calc

            Console.WriteLine($"{Nom} prends {dmg} de dommage dans la geule!");
            PtsVieActuel -= dmg;
        }


        public double DammageCalculator(Ennemi ennemi, ConditionAttaque condition)
        {
            var rand = new Random();
            double Dmg = 0;
            double chance = (rand.Next(-30, 31) / 100);
            switch (condition)
            {
                case ConditionAttaque.Attaque:

                    double mulDMGAtt = MethodeCombat.Dommage(Arme.TypeElement, ennemi.TypElementType);
                    Dmg = ((PtsAttaque + Arme.Puissance) - ennemi.Defense) * mulDMGAtt;
                    Dmg = Dmg + (Dmg * chance);
                    return Dmg;

                case ConditionAttaque.Defense:
                    double mulDMGDef = MethodeCombat.Dommage(ennemi.TypElementType, Arme.TypeElement);
                    Dmg = (ennemi.Puissance - (PtsDefense + Armure.Defense)) * mulDMGDef;
                    Dmg = Dmg + (Dmg * chance);
                    return Dmg;
            }
            return 0;
        }

        public double DammageCalculatorPerso(Personnages personnageE, ConditionAttaque condition)
        {
            var rand = new Random();
            double Dmg = 0;
            double chance = (rand.Next(-30, 31) / 100);

            switch (condition)
            {
                case ConditionAttaque.Attaque:

                    double mulDMGAtt = MethodeCombat.Dommage(Arme.TypeElement, personnageE.Armure.TypeElement);
                    Dmg = ((PtsAttaque + Arme.Puissance) - personnageE.PtsDefense + personnageE.Armure.Defense) * mulDMGAtt;
                    Dmg = Dmg + (Dmg * chance);
                    return Dmg;

                case ConditionAttaque.Defense:
                    double mulDMGDef = MethodeCombat.Dommage(personnageE.Arme.TypeElement, Armure.TypeElement);
                    Dmg = (personnageE.PtsAttaque - (PtsDefense + Armure.Defense)) * mulDMGDef;
                    Dmg = Dmg + (Dmg * chance);
                    return Dmg;
            }
            return 0;
        }
    }
}
