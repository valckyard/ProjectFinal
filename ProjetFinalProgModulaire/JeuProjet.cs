using Game.Library;

namespace ProjetFinalProgModulaire
{
    public class JeuProjet
    {
        public JeuProjet()
        { }

        public void Init()
        {

            var player = CreationPersonnage();
            var listeObjets = LoadingContent.LoadingItems();
            var listeSorts = LoadingContent.LoadingSpells();
            
            
            //Histoire modules
            //SWITCH Decision /Hotel/Arena/Rencontre/Aventure#Quetes
            // |
            // V
            //Combat module


            //loop

        }

        private PERSONNAGES CreationPersonnage()
        {
            PERSONNAGES player = new PERSONNAGES();
            //demander infos

            return player;
        }

    }
}


    