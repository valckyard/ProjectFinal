using System;
using System.Collections.Generic;
using Game.Library;
using Game.Library.Objets;
using Game.Library.TypePersonnage;
using ProjetFinalProgModulaire;

namespace ProjetFinalProgModulaire
{
    public class JeuProjet
    {
        public static List<ArmeObject> ListeArmes;
        public static List<Sort> ListeSorts;
        public static List<ArmureObject> ListeArmures;
        public static List<ConsumableObject> ListeConsumables;
        public static Personnages Player;

        public JeuProjet()
        { }

        public void Init()
        {
            LoadAllContent();
            Player = CreationPersonnage();

            Console.WriteLine("Nom "+Player.Nom);
            Console.WriteLine(Player.Classe);
            Console.WriteLine(Player.Race);
            Console.WriteLine(Player.Arme.NomObjet);
            Console.WriteLine(Player.Armure.NomObjet);
            Console.WriteLine("Niv "+Player.Niveau);
            Console.WriteLine("MP "+Player.PointsMagieActuel);
            Console.WriteLine("MPMax " +Player.PointsMagieMax);
            Console.WriteLine("Att "+Player.PtsAttaque);
            Console.WriteLine("Def "+Player.PtsDefense);
            Console.WriteLine("EXP " +Player.PtsExperience);
            Console.WriteLine("HP "+Player.PtsVieActuel);
            Console.WriteLine("Vit "+Player.PtsVitesse);
            Console.WriteLine("PM "+Player.PuissanceMagique);
            Console.WriteLine(Player.SeuilExperience);
            Console.WriteLine(Player.ValeurPtsExperiences);
     

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
        }

        private static Personnages CreationPersonnage()
        {
            Player = new Personnages();
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


    