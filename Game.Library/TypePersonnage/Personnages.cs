using System;
using System.Collections.Generic;
using Game.Library.Enums;
using Game.Library.Methodes;
using Game.Library.Objets;

namespace Game.Library.TypePersonnage
{
    public class Personnages
    {
        //Characteristiques
        public Race Race { get; set; }
        public Classe Classe { get; set; }
        public string Nom { get; set; }

        //Experience
        public int Niveau { get; set; }
        public double ValeurPtsExperiences { get; set; }
        public double PtsExperience { get; set; }
        public double SeuilExperience { get; set; }

        //Stats
        public int PtsVieActuel { get; set; }
        public int PtsVieMax { get; set; }

        public int PointsMagieMax { get; set; }
        public int PointsMagieActuel { get; set; }

        public double PtsAttaque { get; set; }
        public double PuissanceMagique { get; set; }
        public double PtsDefense { get; set; }
        public double PtsVitesse { get; set; }

        //Options d'attaque
        public List<Sort> ListeSorts { get; set; }
        public ArmeObject Arme { get; set; }
        public ArmureObject Armure { get; set; }

        //inventaire
        public List<ObjectInventaire> Inventaire { get; set; }


        public Personnages(Race race, Classe classe, string nom, int ptsVieMax, int pointsMagieMax, int ptsAttaque,
            int puissanceMagique, int ptsDefense, int ptsVitesse)
        {
            //Characteristiques
            Race = race;
            Nom = nom;
            Classe = classe;

            //Experience
            Niveau = 0;
            PtsExperience = 0;
            //SeuilExperience;
            ValeurPtsExperiences = PtsExperience / 3;

            //Stats
            PtsVieActuel = ptsVieMax;
            PtsVieMax = ptsVieMax;

            PointsMagieMax = pointsMagieMax;
            PointsMagieActuel = pointsMagieMax;

            PtsAttaque = ptsAttaque;
            PuissanceMagique = puissanceMagique;
            PtsDefense = ptsDefense;
            PtsVitesse = ptsVitesse;


            //Equipement
            ListeSorts = new List<Sort>();
            Arme = null;
        }

        // Constructeur Vide
        public Personnages()
        {
            ListeSorts = new List<Sort>();
        }

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


        public void CheckLevelPlayer()
        {
            if (PtsExperience >= SeuilExperience)
            {
                PtsExperience -= SeuilExperience;
                SeuilExperience = SeuilExperience * 1.5;
                ++Niveau;
                StatsOnLevel();

                // spell add
            }
        }

        public void StatsOnLevel()
        {
            PuissanceMagique = PuissanceMagique * 1.1616;
            PtsAttaque = PtsAttaque * 1.1616;
            PtsVieMax = (int)(PtsVieMax * 1.1616);
           
            //ajoute les pts gagne en bonus health
            PtsVieActuel += (int)(PtsVieMax * 0.1616);
            PointsMagieMax = (int)(PointsMagieMax * 1.1616);
            PointsMagieActuel += (int)(PointsMagieMax * 0.1616);
            PtsDefense = PtsDefense * 1.1616;
            PtsVitesse = PtsVitesse * 1.1616;
        }

        private Sort ChoixSort()
        {
            var sortchoisi = new Sort();
            var spellbook = new Dictionary<int, Sort>();
            int x = 1;
            foreach (var s in ListeSorts)
            {
                spellbook.Add(x, s);
                Console.WriteLine($"{x} -- {s.NomSort}, Cout : {s.CoutMp} , Puissance : {s.Puissance}, Element : {s.TypeElementType}");
                x++;
            }

            Console.WriteLine("Quel sort voulez vous utiliser ?");
            int spellreponse; // en read
            while (int.TryParse(Console.ReadLine(), out spellreponse) == false)
            {
            }

            if (spellreponse > 4 & spellreponse < 1)
                ChoixSort();

            foreach (var sort in spellbook)
            {
                if (spellreponse == sort.Key)
                {
                    sortchoisi = sort.Value;
                }
            }
            return sortchoisi;
        }


        public void CharacterCreation()
        {
            var rand = new Random();
            Race = Race.Nain; // decision
            Classe = Classe.Magicien; // desision



            switch (Race)
            {
                case Race.Nain:
                    PuissanceMagique = rand.Next();
                    PtsAttaque = rand.Next();
                    PtsVieMax = rand.Next();
                    PtsVieActuel = PtsVieMax;
                    PointsMagieMax = rand.Next();
                    PointsMagieActuel = PointsMagieMax;
                    PtsVitesse = rand.Next();
                    PtsDefense = rand.Next();
                    Niveau = 0;
                    PtsExperience = 0;
                    SeuilExperience = 200;

                    Arme = null;
                    ListeSorts = new List<Sort>();
                    Inventaire = new List<ObjectInventaire>();
                    //Multiplier / DividerClass
                    ModifClasse();
                    break;
                case Race.Programmateur:
                    PuissanceMagique = rand.Next();
                    PtsAttaque = rand.Next();
                    PtsVieMax = rand.Next();
                    PtsVieActuel = PtsVieMax;
                    PointsMagieMax = rand.Next();
                    PointsMagieActuel = PointsMagieMax;
                    PtsVitesse = rand.Next();
                    PtsDefense = rand.Next();
                    Niveau = 0;
                    PtsExperience = 0;
                    SeuilExperience = 200;

                    Arme = null;
                    ListeSorts = new List<Sort>();
                    Inventaire = new List<ObjectInventaire>();
                    //Multiplier / DividerClass
                    ModifClasse();
                    break;
                case Race.Humain:
                    PuissanceMagique = rand.Next();
                    PtsAttaque = rand.Next();
                    PtsVieMax = rand.Next();
                    PtsVieActuel = PtsVieMax;
                    PointsMagieMax = rand.Next();
                    PointsMagieActuel = PointsMagieMax;
                    PtsVitesse = rand.Next();
                    PtsDefense = rand.Next();
                    Niveau = 0;
                    PtsExperience = 0;
                    SeuilExperience = 200;

                    Arme = null;
                    ListeSorts = new List<Sort>();
                    Inventaire = new List<ObjectInventaire>();
                    //Multiplier / DividerClass
                    ModifClasse();
                    break;
                case Race.Elfe:
                    PuissanceMagique = rand.Next();
                    PtsAttaque = rand.Next();
                    PtsVieMax = rand.Next();
                    PtsVieActuel = PtsVieMax;
                    PointsMagieMax = rand.Next();
                    PointsMagieActuel = PointsMagieMax;
                    PtsVitesse = rand.Next();
                    PtsDefense = rand.Next();
                    Niveau = 0;
                    PtsExperience = 0;
                    SeuilExperience = 200;

                    Arme = null;
                    ListeSorts = new List<Sort>();
                    Inventaire = new List<ObjectInventaire>();
                    //Multiplier / DividerClass
                    ModifClasse();
                    break;
            }
            
        }

        public void ModifClasse()
        {
            switch (Classe)
            {
                case Classe.Barbare:
                    break;
                case Classe.Guerrier:
                    break;
                case Classe.Magicien:
                    break;
                case Classe.Pretre:
                    break;
            }
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