using System.Collections.Generic;
using Game.Library;

namespace ProjetFinalProgModulaire
{
    public class JeuProjet
    {
        public static List<Objet> ListeObjets;
        public static List<Sort> ListeSorts;
        public static Personnages Player;

        public JeuProjet()
        { }

        public void Init()
        {

            Player = CreationPersonnage();
            ListeObjets = LoadingContent.LoadingItems();
            ListeSorts = LoadingContent.LoadingSpells();
            
            
            //Histoire modules
            //SWITCH Decision /Hotel/Arena/Rencontre/Aventure#Quetes
            // |
            // V
            //Combat module


            //loop

        }

        private static Personnages CreationPersonnage()
        {
            var player = new Personnages();
            //demander infos

            return player;
        }

    }
}


    