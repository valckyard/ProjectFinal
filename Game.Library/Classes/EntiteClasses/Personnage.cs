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

        public void MenuInventaire()
        {
            AfficherInventaire();
            Console.Write(
                $"Que voulez vous faire ? \n 1 -- Equipper \n 2 -- Voir Les Statistiques \n 3 -- Sortir de L'Inventaire \n Choix : ");
            int x;
            while (int.TryParse(Console.ReadLine(), out x) == false)
            {
            }

            if (x < 1 & x > Inventaire.Count)
            {
                MenuInventaire();
            }

            switch (x)
            {
                case 1:
                    EquiperArmeArmure();
                    break;
                case 2:
                    AfficherStatsMenu();
                    break;
                case 3:
                    break;
                default:
                    MenuInventaire();
                    break;
            }
        }

        private void AfficherStatsMenu()
        {
            Console.Write($"Quel Objet ? \n Choix : ");
            int y = 0;
            while (int.TryParse(Console.ReadLine(), out y) == false)
            {
            }

            if (y < 1 & y > Inventaire.Count) MenuInventaire();

            // afficher item stats
            ObjInventaire choisi = Inventaire.ElementAt(y - 1);
            AfficherStatsItem(choisi);
            MenuInventaire();
        }

        public void AfficherStatsItem(ObjInventaire choisi)
        {
            if (choisi.Armure != null)
            {
                Console.WriteLine($"Nom : {choisi.Armure.NomObjet}\n" +
                                  $"Element : {choisi.Armure.TypeElement}\nDefense : {choisi.Armure.Defense}");
            }

            if (choisi.Arme != null)
            {
                Console.WriteLine($"Nom : {choisi.Arme.NomObjet} \n" +
                                  $"Element : {choisi.Arme.TypeElement}\nPuissance : {choisi.Arme.Puissance}");
            }
            if (choisi.ObjetCons != null)
            {
                Console.WriteLine($"Nom : {choisi.ObjetCons.NomObjet} \nType : {choisi.ObjetCons.TypeConsumable}\n" +
                                  $"Element : {choisi.ObjetCons.TypeElement}\nPuissance : {choisi.ObjetCons.Puissance}");
            }
            else
            {
                Console.WriteLine("errer 404");
            }
        }

        public void EquiperArmeArmure()
        {
            int count = 1;
            foreach (var objet in Inventaire)
            {
                if (objet.Armure != null)
                {
                    Console.WriteLine($"{count} -- {objet.Armure.NomObjet}");
                }

                if (objet.Arme != null)
                {
                    Console.WriteLine($"{count} -- {objet.Arme.NomObjet}");
                }

                ++count;
            }

            Console.Write($"Que voulez vous faire ? \n 1 -- Equipper \n 2 -- Retour a l'Inventaire \n Choix : ");
            int x =0;
            while (int.TryParse(Console.ReadLine(), out x) == false)
            {
            }

            if (x < 1 | x > 2)
            {
                EquiperArmeArmure();
            }
            else
            switch (x)
            {
                case 1:
                    Console.Write($"Quelle Arme ou Armure ? \n Choix : ");
                    int y =0 ;
                    while (int.TryParse(Console.ReadLine(), out y) == false)
                    {
                    }

                    if (y < 1 & y > Inventaire.Count)
                    {
                        EquiperArmeArmure();
                    }


                    if (Inventaire.ElementAt(y-1).Armure != null)
                    {
                        Inventaire.Add(new ObjInventaire(Armure));
                        Armure = Inventaire.ElementAt(y - 1).Armure;
                        Inventaire.RemoveAt(y-1);
                    }

                    if (Inventaire.ElementAt(y-1).Arme != null)
                    {
                        Inventaire.Add(new ObjInventaire(Arme));
                        Arme = Inventaire.ElementAt(y-1).Arme;
                        Inventaire.RemoveAt(y-1);
                    }
                    else
                    {
                        Console.WriteLine("Choix Invalide");
                    }


                    MenuInventaire();

                    break;
                case 2:
                    MenuInventaire();
                    break;
            }
        }

        private void AfficherInventaire()
        {
            int count = 1;
            foreach (var objet in Inventaire)
            {
                if (objet.ObjetCons != null)
                {
                    Console.WriteLine($"{count} -- {objet.ObjetCons.NomObjet}");
                }

                if (objet.Arme != null)
                {
                    Console.WriteLine($"{count} -- {objet.Arme.NomObjet}");
                }

                if (objet.Armure != null)
                {
                    Console.WriteLine($"{count} -- {objet.Armure.NomObjet}");
                }

                ++count;
            }
        }
    }
}