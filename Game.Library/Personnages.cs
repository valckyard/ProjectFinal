using System.Collections.Generic;

namespace Game.Library
{
    public class PERSONNAGES
    {
        //Characteristiques
        public string Race { get; set; }
        public string Nom { get; set; }

        //Experience
        public int Niveau { get; set; }
        public double ValeurPtsExperiences { get; set; }
        public double PtsExperience { get; set; }
        public double SeuilExperience { get; set; }

        //Stats
        public int PtsVieActuel { get; set; }
        public int PtsVieMax { get; set; }

        public int PointsMagieMax { get; set; }
        public int PointsMagieActuel { get; set; }

        public int PtsAttaque { get; set; }
        public int PuissanceMagique { get; set; }
        public int PtsDefense { get; set; }
        public int PtsVitesse { get; set; }

        //Options d'attaque
        public List<SORT> ListeSorts {get;set;}
        public string ObjectTenu { get; set; }


        public PERSONNAGES(string race, string nom, int ptsVieMax,int pointsMagieMax, int ptsAttaque,
            int puissanceMagique, int ptsDefense, int ptsVitesse)
        {
            //Characteristiques
            Race = race;
            Nom = nom;

            //Experience
            Niveau = 0;
            PtsExperience = 0;
            //SeuilExperience;
            ValeurPtsExperiences = PtsExperience / 3;

            //Stats
            PtsVieActuel = ptsVieMax;
            PtsVieMax = ptsVieMax;

            PointsMagieMax = pointsMagieMax;
            PointsMagieActuel = pointsMagieMax;

            PtsAttaque = ptsAttaque;
            PuissanceMagique = puissanceMagique;
            PtsDefense = ptsDefense;
            PtsVitesse = ptsVitesse;


            //Equipement
            ListeSorts =  new List<SORT>();
            ObjectTenu = null;
}

        // Constructeur Vide
        public PERSONNAGES()
        {
            ListeSorts = new List<SORT>();
        }
    }
}
    