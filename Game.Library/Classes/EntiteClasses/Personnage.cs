using System;
using System.Collections.Generic;
using Game.Library.Classes.ObjClasses;
using Game.Library.Enums;

namespace Game.Library.Classes.EntiteClasses
{
    public partial class Personnage
    {
        //Characteristiques
        public PersonnageRace Race { get; set; }
        public PersonnageClasse Classe { get; set; }
        public string Nom { get; set; }

        //Experience
        public int Niveau { get; set; }
        public double ValeurExp { get; set; }
        public double Experience { get; set; }
        public double SeuilExperience { get; set; }

        //Stats
        public int PvActuels { get; set; }
        public int PvMax { get; set; }

        public int MpMax { get; set; }
        public int MpActuel { get; set; }

        public double Puissance { get; set; }
        public double PuissanceMagique { get; set; }
        public double Defense { get; set; }
        public double Vitesse { get; set; }

        //Options d'attaque
        public List<Sort> ListeSorts { get; set; }
        public ObjArme Arme { get; set; }
        public ObjArmure Armure { get; set; }

        //inventaire
        public List<ObjInventaire> Inventaire { get; set; }


        public Personnage(PersonnageRace race, PersonnageClasse classe, string nom, int pvMax, int mpMax, int puissance,
            int puissanceMagique, int defense, int vitesse)
        {
            //Characteristiques
            Race = race;
            Nom = nom;
            Classe = classe;

            //Experience
            Niveau = 0;
            Experience = 0;
            //SeuilExperience;
            ValeurExp = Experience / 3;

            //Stats
            PvActuels = pvMax;
            PvMax = pvMax;

            MpMax = mpMax;
            MpActuel = mpMax;

            Puissance = puissance;
            PuissanceMagique = puissanceMagique;
            Defense = defense;
            Vitesse = vitesse;


            //Equipement
            ListeSorts = new List<Sort>();
            Arme = null;
        }

        // Constructeur Vide
        public Personnage()
        {
            ListeSorts = new List<Sort>();
        }

       


        public void CheckLevelPlayer()
        {
            if (Experience >= SeuilExperience)
            {
                Experience -= SeuilExperience;
                SeuilExperience = SeuilExperience * 1.5;
                Console.WriteLine("LEVEL UP!");
                ++Niveau;
                Console.WriteLine($"Vous etes maintenant niveau {Niveau}");
                StatsOnLevel();

                // spell add
            }
        }

        public void StatsOnLevel()
        {
            PuissanceMagique = PuissanceMagique * 1.1616;
            Puissance = Puissance * 1.1616;
            PvMax = (int)(PvMax * 1.1616);
           
            //ajoute les pts gagne en bonus health
            PvActuels += (int)(PvMax * 0.1616);
            MpMax = (int)(MpMax * 1.1616);
            MpActuel += (int)(MpMax * 0.1616);
            Defense = Defense * 1.1616;
            Vitesse = Vitesse * 1.1616;
        }

        private Sort ChoixSort()
        {
            if (ListeSorts.Count != 0)
            {
                var rand = new Random();
                var sortchoisi = new Sort();
                var spellbook = new Dictionary<int, Sort>();
                int x = 1;
                foreach (var s in ListeSorts)
                {
                    spellbook.Add(x, s);
                    //Console.WriteLine($"{x} -- {s.NomSort}, Cout : {s.CoutMp} , Puissance : {s.Puissance}, Element : {s.TypeElement}");
                    x++;
                }

                //Console.WriteLine("Quel sort voulez vous utiliser ?");
                int spellreponse = rand.Next(1, ListeSorts.Count); // en read
                //while (int.TryParse(Console.ReadLine(), out spellreponse) == false)
                //{
                //}

                //if (spellreponse > ListeSorts.Count & spellreponse < 1)
                //    ChoixSort();

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

        public bool UtiliserItemVsEnnemi(ref Ennemi baddie)
        {
            if (Inventaire.Count != 0)
            {
                var rand = new Random();

                var item = new ObjConsumable();
                var newList = new List<ObjConsumable>();
                foreach (var i in Inventaire)
                {
                    if (i.ObjetCons != null)
                    {
                        newList.Add(i.ObjetCons);
                    }
                }

                item = newList[rand.Next(0, newList.Count)];

                var sort = item.ItemToSpell();
                LancerSortVsEnnemi(ref baddie);
                return true;


            }

            return false;
        }

        public bool UtiliserItemVsPerso(ref Personnage defenseur)
        {
            if (Inventaire.Count != 0)
            {
                var rand = new Random();

                var item = new ObjConsumable();
                var newList = new List<ObjConsumable>();
                foreach (var i in Inventaire)
                {
                    if (i.ObjetCons != null)
                    {
                        newList.Add(i.ObjetCons);
                    }
                }

                item = newList[rand.Next(0, newList.Count)];

                var sort = item.ItemToSpell();
                LancerSortVsPerso(ref defenseur);
                return true;


            }

            return false;
        }
    }
}