using System;
using System.Collections.Generic;
using Game.Library;
using Game.Library.Classes;
using Game.Library.Classes.ObjClasses;
using Game.Library.Methodes;
using ProjetFinalProgModulaire;
using Personnage = Game.Library.Classes.EntiteClasses.Personnage;

namespace ProjetFinalProgModulaire
{
    public class JeuProjet
    {
        public static List<ObjArme> ListeArmes;
        public static List<Sort> ListeSorts;
        public static List<ObjArmure> ListeArmures;
        public static List<ObjConsumable> ListeConsumables;
        public static List<ClassNoeud> ListeNoeuds;
        public static Personnage Player;

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
     

            //Histoire modules
            //SWITCH Decision /Hotel/Arena/Rencontre/Aventure#Quetes
            // |
            // V
            //Combat module
            
            Dictionary<string, List<ClassNoeud>> story = new Dictionary<string, List<ClassNoeud>>();
            
            //loop
        }

        private static void LoadAllContent()
        {
            ListeArmes = LoadingContent.LoadingArmes();
            ListeSorts = LoadingContent.LoadingSpells();
            ListeArmures = LoadingContent.LoadingArmures();
            ListeConsumables = LoadingContent.LoadingConsumableObjects();
            ListeNoeuds = LoadingContent.LoadingNoeuds();
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


    