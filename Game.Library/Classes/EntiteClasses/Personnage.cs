using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        public double ExperienceTotale { get; set; }

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

            ExperienceTotale = 0;
            ValeurExp = 0;
            //SeuilExperience;

            //Stats
            PvMax = pvMax;
            PvActuels = pvMax;

            MpMax = mpMax;
            MpActuel = mpMax;

            Puissance = puissance;
            PuissanceMagique = puissanceMagique;
            Defense = defense;
            Vitesse = vitesse;


            //Equipement
            ListeSorts = new List<Sort>();
            Inventaire = new List<ObjInventaire>();
            Arme = null;
        }

        // Constructeur Vide
        public Personnage()
        {
            ExperienceTotale = 0;
            ValeurExp = 0;
            ListeSorts = new List<Sort>();
            Inventaire = new List<ObjInventaire>();
        }

        public void AddXpEnnemi(Ennemi ennemi)
        {
            ExperienceTotale += ennemi.ValeurExp;
            Experience += ennemi.ValeurExp;
        }

        public void AddXpPersonnage(Personnage ennemi)
        {
            ExperienceTotale += ennemi.ValeurExp;
            Experience += ennemi.ValeurExp;
        }


        public void CheckLevelPlayer()
        {
            ValeurExp = ExperienceTotale / 3;

            while (Experience >= SeuilExperience)
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
            PvMax = (int) (PvMax * 1.1616);

            //ajoute les pts gagne en bonus health
            PvActuels += (int) (PvMax * 0.1616);
            MpMax = (int) (MpMax * 1.1616);
            MpActuel += (int) (MpMax * 0.1616);
            Defense = Defense * 1.1616;
            Vitesse = Vitesse * 1.1616;
        }


        public bool UtiliserItemVsEnnemi(ref Ennemi baddie)
        {
            if (Inventaire.Count != 0)
            {
                var rand = new Random();
                var newList = new List<ObjConsumable>();
                foreach (var i in Inventaire.ToList())
                {
                    if (i.ObjetCons != null)
                    {
                        newList.Add(i.ObjetCons);
                        Inventaire.Remove(i);
                    }
                }

                if (newList.Count != 0)
                {
                    var item = newList[rand.Next(0, newList.Count)];
                    newList.Remove(item);

                    if (newList.Count != 0)
                    {
                        foreach (var objConsumable in newList)
                        {
                            Inventaire.Add(new ObjInventaire(objConsumable));
                        }
                    }

                    var sort = item.ItemToSpell();
                    LancerSortVsEnnemi(ref baddie, sort);
                    return true;
                }
            }

            return false;
        }

        public bool UtiliserItemVsPerso(ref Personnage defenseur)
        {
            if (Inventaire.Count != 0)
            {
                var rand = new Random();
                var newList = new List<ObjConsumable>();
                foreach (var i in Inventaire.ToList())
                {
                    if (i.ObjetCons != null)
                    {
                        newList.Add(i.ObjetCons);
                        Inventaire.Remove(i);
                    }
                }

                if (newList.Count != 0)
                {
                    var item = newList[rand.Next(0, newList.Count)];
                    newList.Remove(item);

                    if (newList.Count != 0)
                    {
                        foreach (var objConsumable in newList)
                        {
                            Inventaire.Add(new ObjInventaire(objConsumable));
                        }
                    }

                    var sort = item.ItemToSpell();
                    LancerSortVsPerso(ref defenseur, sort);
                    return true;
                }
            }

            return false;
        }

       
    }
}