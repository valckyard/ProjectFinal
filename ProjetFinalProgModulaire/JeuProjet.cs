using System;
using System.Collections.Generic;
using System.Linq;
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
        public static Dictionary<string, Noeud> DicStory;
        public static Personnage Player;

        public JeuProjet()
        { }

        public void Init()
        {
            LoadAllContent();
            Player = CreationPersonnage();

            //Console.WriteLine("Nom "+Player.Nom);
            //Console.WriteLine(Player.Classe);
            //Console.WriteLine(Player.Race);
            //Console.WriteLine(Player.Arme.NomObjet);
            //Console.WriteLine(Player.Armure.NomObjet);
            //Console.WriteLine("Niv "+Player.Niveau);
            //Console.WriteLine("MP "+Player.MpActuel);
            //Console.WriteLine("MPMax " +Player.MpMax);
            //Console.WriteLine("Att "+Player.Puissance);
            //Console.WriteLine("Def "+Player.Defense);
            //Console.WriteLine("EXP " +Player.Experience);
            //Console.WriteLine("HP "+Player.PvActuels);
            //Console.WriteLine("Vit "+Player.Vitesse);
            //Console.WriteLine("PM "+Player.PuissanceMagique);
            //Console.WriteLine(Player.SeuilExperience);
            //Console.WriteLine(Player.ValeurExp);

            //Permet que le premier noeud soit choisi au debut
            int choixJoueur = 0;

            var valueKey = DicStory.Keys.ElementAt(0);
            //Affiche lintitule du noeud


            //Validation du combat 
            while (valueKey != "MORT")
            {


                if (DicStory[valueKey].ChoixReponses.Count != 1)
                {
                    Console.Clear();
                    Console.WriteLine((DicStory[valueKey].Intitule) + "\n\n");
                    //Affiche les choix de reponse possible

                    if ((DicStory[valueKey].Ennemi == null && DicStory[valueKey].EnnemiP == null) &&
                        DicStory[valueKey].ChoixReponses[2].Length > 50)
                    {
                        Console.WriteLine(
                            "Pas d'ennemis et Chortoix 2 long alors Dead"); //POurrait permettre un aleatoir de continuer avec rep 1...
                        Console.ReadKey();
                        valueKey = DicStory[valueKey].ChoixReponses[1];

                    }
                    else
                    {
                        foreach (var choix in DicStory[valueKey].ChoixReponses)
                        {
                            Console.Write("\n" + choix.Key + "." + choix.Value);

                        }
                        Console.Write("\nQue désirez-vous faire ?  ");
                        choixJoueur = int.Parse(Console.ReadLine());
                        Console.WriteLine(choixJoueur);
                        valueKey = DicStory[valueKey].ChoixReponses[choixJoueur];
                    }



                }
                else
                {
                    Console.WriteLine((DicStory[valueKey].Intitule) + "\n\n");
                    Console.ReadKey();
                    valueKey = DicStory[valueKey].ChoixReponses[1];

                }
            }

            //Assigne a valuekey la prochaine cle a chercher.

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


