using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;
using Game.Library.Classes;
using Game.Library.Classes.EntiteClasses;
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
        public static Thread Affichage;
        public static ClasseLootTable Table;

        public JeuProjetTest()
        { }

        public void Init()
        {


            LoadAllContent();
            Table = new ClasseLootTable(ListeArmes,ListeArmures,ListeConsumables);
            


            Player = new Personnage(PersonnageRace.Humain, PersonnageClasse.Magicien, "Alex", 100, 100, 19, 5, 5,
                5)
            {
                Arme = new ObjArme("yeaaa", TypeElement.Air, 3),
                Armure = new ObjArmure("PasUneArmure", TypeElement.Air, 2),
                SeuilExperience = 200,
                ListeSorts = ListeSorts
            };
            Player.Inventaire.Add(new ObjInventaire(new ObjConsumable("pete", TypeConsumable.Potion, TypeElement.Lumiere, 7)));
            Player.Inventaire.Add(new ObjInventaire(new ObjConsumable("pete", TypeConsumable.Potion, TypeElement.Lumiere, 7)));
            Player.Inventaire.Add(new ObjInventaire(ListeConsumables[0]));

            foreach (var listeArme in ListeArmes)
            {
                Player.Inventaire.Add(new ObjInventaire(listeArme));
            }

            foreach (var listeArme in ListeArmures)
            {
                Player.Inventaire.Add(new ObjInventaire(listeArme));
            }

            var suif = new Ennemi("Vache Enrage", TypeEnnemi.PerchaudeEnchantee, 30, TypeElement.Eau, 10, 10, 10, 3000,
                90);
            suif.LootTable = Table;

            var Client = new AffichageManager.AffichageManagerTest();
            Client.Init();
            Affichage = new Thread(Client.SendLoop);
            Affichage.Start();
            Thread.Sleep(300);
   
            
           Player2 = new Personnage(PersonnageRace.Humain,PersonnageClasse.Magicien,"Pablo",100,5,5,5,5,5);
            Player2.Arme = new ObjArme("PabStick", TypeElement.Air, 2);
            Player2.ValeurExp = 3000;
            Player2.Armure = new ObjArmure("Pab String",TypeElement.Air,2);
            Player2.LootTable = Table;
            Player2.LootChances = 90;
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
            Console.ReadLine();
            Console.Clear();


            Player.MenuInventaire();


            MethodeCombat.CombatPersonnage(ref Player, ref Player2);
            Console.ReadLine();
            MethodeCombat.AttaqueEnnemi(ref Player, ref suif);



            Onrouledesnoeuds("Taxi");

           Affichage.Abort();
            //Histoire modules
            //SWITCH Decision /Hotel/Arena/Rencontre/Aventure#Quetes
            // |
            // V
            //Combat module
            

            //loop
        }
        public static string Onrouledesnoeuds(string monnoeud)
        {
            string newnoeud = null;
            foreach (var kvNoeud in DicStory)
            {
                if (kvNoeud.Key == monnoeud)
                {
                    kvNoeud.Value.Init(ref Player);
                    newnoeud = kvNoeud.Value.ChoixJoueur(ref Player);
                    break;
                }


            }
            
            return Onrouledesnoeuds(newnoeud);
        }

        private static void LoadAllContent()
        {
            ListeArmes = LoadingContent.LoadingArmes();
            ListeSorts = LoadingContent.LoadingSpells();
            ListeArmures = LoadingContent.LoadingArmures();
            ListeConsumables = LoadingContent.LoadingConsumableObjects();
            LootTable = LootTableCompile();
            DicStory = LoadingContent.LoadingNoeuds();

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

        public static void AffichageStats()
        {
            var timetoget = DateTime.Now.AddMilliseconds(300);

            while (true)
            {
                var timenow = DateTime.Now;
                if (timenow >= timetoget)
                {
                    Console.SetCursorPosition(0,8);
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.Write("-----------------------\n||");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(" HP:" + Player.PvActuels + "/" + Player.PvMax);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(" MP :" + Player.MpActuel + "/" + Player.MpMax);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("||\n-----------------------");
                    Console.SetCursorPosition(0, 0);
                    timetoget = DateTime.Now.AddMilliseconds(300);
                }

            }

        }

    }
}


    