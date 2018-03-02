using System.Collections.Generic;
using Game.Library.Classes.EntiteClasses;

namespace Game.Library.Classes
{
    public class Noeud
    {
        public string Intitule { get; set; }
        public Ennemi Ennemi { get; set; }
        public Personnage EnnemiP { get; set; }
        public Dictionary<int,string> ChoixReponses { get; set; }

        public Noeud()
        {
                
        }

        public Noeud(string intitule, Ennemi ennemi, Personnage ennemiP, Dictionary<int, string> choixReponses)
        {
            Intitule = intitule;
            Ennemi = ennemi;
            EnnemiP = ennemiP;
            ChoixReponses = choixReponses;
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