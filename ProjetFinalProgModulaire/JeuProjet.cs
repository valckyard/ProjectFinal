using System;
using System.Collections.Generic;
using System.Threading;
using Game.Library.Classes;
using Game.Library.Classes.ObjClasses;
using ProjetFinalProgModulaire.AffichageManager;
using Personnage = Game.Library.Classes.EntiteClasses.Personnage;

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
        public static ClasseLootTable LootTable;

        private Thread _infoSender;

        public JeuProjet()
        { }

        public void Init()
        {
            LoadAllContent();
            //Create Random Char ATM
            NewCharacter();

            //start after char creation
            PlayerInterfaceSender();

            IntroDuJeu();
            //Init The Game Loop
            DepartDuJeu();
            FinaleDuJeu();
            Rejouer();
        }

        private void Rejouer()
        {
            Console.WriteLine("Voulez-vous jouer à nouveau ?");
            var rejouer = int.Parse(Console.ReadLine());
        }


        private void FinaleDuJeu()
        {
            Console.WriteLine("Voici maintenant la fin bla bla bla bla ");
        }

        private void IntroDuJeu()
        {
            Console.WriteLine("Le chef du clan Codeum a eu vent que leurs ennemis de toujours, les ScrIkID, ont en leur possession" +
                              "une bombe qui a pour objectif de faire sauter son quartier général. Les informations, provenant " +
                              "d'une source très fiable, précise que la bombe est dissimulé dans le quartier général de ces" +
                              "derniers.La bombe qui est déjà activé et qui est contrôlé à distance par un laptop, sera envoyé" +
                              "tôt demain. Vous avez été engagé pour le clan Codeum afin d'accéder au portable qui lui est" +
                              "dissimulé derrière l'hotel de la Cathdrale dans un trappe sous le plancher.Vous n'avez qu'à changer" +
                              "le code pour que la détonation se fasse quelques secondes après votre départ. Vous acceptez" +
                              "la mission et vous vous mettez en route immédiatement en direction du pont qui traverse la rivière" +
                              "afin de vous rejoindre votre objectif situé sur l'autre rive.");
        }

        private void DepartDuJeu()
        {
            string depart = "Pont";
            OnRouleDesNoeuds(depart);
        }

        private static void NewCharacter()
        {
            Player = CreationPersonnage();
            foreach (var arme in ListeArmes)
            {
                if (arme.NomObjet == "Mains Nues")
                {
                    Player.Arme = arme;
                }
            }

            foreach (var armure in ListeArmures)
            {
                if (armure.NomObjet == "Vetements")
                {
                    Player.Armure = armure;
                }
            }
        }

        private void PlayerInterfaceSender()
        {
            var client = new AffichageMngr();
            client.Init();
            _infoSender = new Thread(client.SendLoop);
            _infoSender.Start();
            Thread.Sleep(300);
        }


        public static string OnRouleDesNoeuds(string monnoeud)
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
            return OnRouleDesNoeuds(newnoeud);
        }

        private static void LoadAllContent()
        {
            ListeArmes = LoadingContent.LoadingArmes();
            ListeSorts = LoadingContent.LoadingSpells();
            ListeArmures = LoadingContent.LoadingArmures();
            ListeConsumables = LoadingContent.LoadingConsumableObjects();
            DicStory = LoadingContent.LoadingNoeuds();
            LootTable = new ClasseLootTable(ListeArmes, ListeArmures, ListeConsumables);

        }

        private static Personnage CreationPersonnage()
        {
            Player = new Personnage();
            //demander infos//
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


