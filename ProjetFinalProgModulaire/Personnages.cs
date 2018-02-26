using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinalProgModulaire
{
    public class PERSONNAGES
    {
        public int Niveau { get; set; }
        public string Race { get; set; }
        public string Nom { get; set; }
        public int PtsVieActuel { get; set; }
        public int PtsVieMax { get; set; }
        public int PtsAttaque { get; set; }
        public int Magie { get; set; }
        public int PtsDefense { get; set; }
        public int PtsVitesse { get; set; }
        public int PtsExperience { get; set; }
        public int SeuilExperience { get; set; }
        public List<SORTS> ListeSorts {get;set;}
        public string ObjectTenu { get; set; }

        public string ObjetTenu { get; set; }
        public int PtsExperienceFourni { get; set; }

        public PERSONNAGES(int niveau, string race, string nom, int ptsVieActuel, int ptsVieMax, int ptsAttaque,
            int magie, int ptsDefense, int ptsVitesse, int ptsExperience, int seuilExperience,
            List<SORTS> listesorts, string objetTenu)
        {
            Niveau = niveau;
            Race = race;
            Nom = nom;
            PtsVieActuel = ptsVieActuel;
            PtsVieMax = ptsVieMax;
            PtsAttaque = ptsAttaque;
            Magie = magie;
            PtsDefense = ptsDefense;
            PtsVitesse = ptsVitesse;
            PtsExperience = ptsExperience;
            SeuilExperience = seuilExperience;
            List<SORTS> listeSorts =  listesorts;
            ObjectTenu = objetTenu;
            PtsExperienceFourni = 0;
        }
    }

    public class SORTS
    {
        public SORTS()
        {
        }
    }
}
    