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
            Console.WriteLine(Player.Nom);
            Console.WriteLine(Player.Classe);
            Console.WriteLine(Player.Arme.NomObjet);
            Console.WriteLine(Player.Armure.NomObjet);
            Console.WriteLine(Player.Niveau);
            Console.WriteLine(Player.PointsMagieActuel);
            Console.WriteLine(Player.PointsMagieMax);
            Console.WriteLine(Player.PtsAttaque);
            Console.WriteLine(Player.PtsDefense);
            Console.WriteLine(Player.PtsExperience);
            Console.WriteLine(Player.PtsVieActuel);
            Console.WriteLine(Player.PtsVitesse);
            Console.WriteLine(Player.PuissanceMagique);
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


    