using Game.Library.Classes.EntiteClasses;

namespace Game.Library.Classes
{
    public class Noeud
    {
        public string Intitule;
        public Ennemi Ennemi;
        public Personnage EnnemiP;
        public string ReponseEnfant;

        public Noeud(string intitule, string reponseEnfant)
        {
            Intitule = intitule;
            ReponseEnfant = reponseEnfant;
        }


        public void Init()
        {
            //intitule


            //check ennemi == null
            //choix joueur

        }

        public void ChoixJoueur()
        {
            //afficher

            //readkey
            // value Q
            // int Q

        }
    }
}