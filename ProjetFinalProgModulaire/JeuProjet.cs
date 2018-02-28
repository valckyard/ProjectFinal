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
           
           Console.WriteLine(Player.ToString());
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

            return Player;
        }

    }
}


    