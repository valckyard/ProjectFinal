using System;
using System.Collections.Generic;
using System.Linq;
using Game.Library;
using ProjetFinalProgModulaire;
using Game.Library.Classes;
using Game.Library.Classes.ObjClasses;
using Game.Library.Enums;
using Game.Library.Methodes;
using ProjetFinalProgModulaire.AffichageManager;
using Lidgren.Network;
using Personnage = Game.Library.Classes.EntiteClasses.Personnage;
using Game.Library.Classes.EntiteClasses;

namespace ProjetFinalProgModulaire
{
    public class JeuProjet
    {
        public static List<ObjArme> ListeArmes;
        public static List<Sort> ListeSorts;
        public static List<ObjArmure> ListeArmures;
        public static List<ObjConsumable> ListeConsumables;
        public static Dictionary<string, Noeud> DicStory;
        public static Personnage Player;

        public JeuProjet()
        { }

        public void Init()
        {

            LoadAllContent();
            Player = CreationPersonnage();
            string depart = "Pont";
            Onrouledesnoeuds(depart);
        }


        public string Onrouledesnoeuds(string monnoeud)
        {
            string newnoeud = null;
            foreach (var kvNoeud in DicStory)
            {
                if(kvNoeud.Key == monnoeud)
                kvNoeud.Value.Init(ref Player);
                newnoeud = kvNoeud.Value.ChoixJoueur(ref Player);
                break;
            }
            return Onrouledesnoeuds(newnoeud);
        }

        private static void LoadAllContent()
        {
            ListeArmes = LoadingContent.LoadingArmes();
            ListeSorts = LoadingContent.LoadingSpells();
            ListeArmures = LoadingContent.LoadingArmures();
            ListeConsumables = LoadingContent.LoadingConsumableObjects();
            DicStory = LoadingContent.LoadingNoeuds();
            
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


