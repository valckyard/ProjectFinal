using System;
using System.Collections.Generic;
using System.Threading;
using Game.Library.Classes;
using Game.Library.Classes.ObjClasses;
using Game.Library.Enums;
using Game.Library.Methodes;
using ProjetFinalProgModulaire;
using static Game.Library.Classes.EntiteClasses.Personnage;
using Personnage = Game.Library.Classes.EntiteClasses.Personnage;

namespace TestConsoleJeu
{
    public class JeuProjetTest
    {
        public static List<ObjArme> ListeArmes;
        public static List<Sort> ListeSorts;
        public static List<ObjArmure> ListeArmures;
        public static List<ObjConsumable> ListeConsumables;
        public static List<ObjInventaire> LootTable;
        public static Dictionary<string,Noeud> DicStory;
        public static Personnage Player;
        public static Personnage Player2;

        public JeuProjetTest()
        { }

        public void Init()
        {
            LoadAllContent();
            Player = new Personnage();
            Player = CreationPersonnage();
            
           Player2 = new Personnage(PersonnageRace.Humain,PersonnageClasse.Magicien,"Pablo",100,5,5,5,5,5);
            Player2.Arme = new ObjArme("PabStick", TypeElement.Air, 2);
            Player2.Armure = new ObjArmure("Pab String",TypeElement.Air,2);
            Console.WriteLine("Nom "+Player.Nom);
            Console.WriteLine(Player.Classe);
            Console.WriteLine(Player.Race);
            Console.WriteLine(Player.Arme.NomObjet);
            Console.WriteLine(Player.Armure.NomObjet);
            Console.WriteLine("Niv "+Player.Niveau);
            Console.WriteLine("MP "+Player.MpActuel);
            Console.WriteLine("MPMax " +Player.MpMax);
            Console.WriteLine("Att "+Player.Puissance);
            Console.WriteLine("Def "+Player.Defense);
            Console.WriteLine("EXP " +Player.Experience);
            Console.WriteLine("HP "+Player.PvActuels);
            Console.WriteLine("Vit "+Player.Vitesse);
            Console.WriteLine("PM "+Player.PuissanceMagique);
            Console.WriteLine(Player.SeuilExperience);
            Console.WriteLine(Player.ValeurExp);

           MethodeCombat.AttaquePersonnage(ref Player, ref Player2);
            //Histoire modules
            //SWITCH Decision /Hotel/Arena/Rencontre/Aventure#Quetes
            // |
            // V
            //Combat module


            //loop
        }

        private static void LoadAllContent()
        {
            ListeArmes = LoadingContent.LoadingArmes();
            ListeSorts = LoadingContent.LoadingSpells();
            ListeArmures = LoadingContent.LoadingArmures();
            ListeConsumables = LoadingContent.LoadingConsumableObjects();
            LootTable = LootTableCompile();
            //DicStory = LoadingContent.LoadingNoeuds();

        }

        public static List<ObjInventaire> LootTableCompile()
        {
            var newList = new List<ObjInventaire>();
            foreach (var arme in ListeArmes)
            {
                newList.Add(new ObjInventaire(arme));

            }

            foreach (var armure in ListeArmures)
            {
                newList.Add(new ObjInventaire(armure));
            }

            foreach (var item in ListeConsumables)
            {
                newList.Add(new ObjInventaire(item));
            }

            return newList;
        }

        public static void Loot(ref Personnage joueur, int lootchances)
        {
            ObjInventaire loot = null;
            var rand = new Random();
            var chances = rand.Next(0, 101);
            if (chances > lootchances)
            {
                loot = LootTable[rand.Next(0, LootTable.Count)];
            }

            if (loot != null)
            {
                joueur.Inventaire.Add(loot);

               
            }

            else
            {
                Console.WriteLine("L'ennemi n'avais aucun objet de valeur!");
            }
        }

        private static Personnage CreationPersonnage()
        {
            Player = new Personnage();
            //demander infos
            Player.CharacterCreation();
            foreach (var arme in ListeArmes)
            {
                if (arme.NomObjet == "Mains Nues")
                {
                    Player.Arme = arme;
                    break;
                }
            }

            foreach (var armure in ListeArmures)
            {
                if (armure.NomObjet == "Vetements")
                {
                    Player.Armure = armure;
                    break;
                }
            }

            return Player;
        }

    }
}


    