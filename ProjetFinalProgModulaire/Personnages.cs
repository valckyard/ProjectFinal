using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinalProgModulaire
{
    struct PERSONNAGES
    {
        public int niveau;
        public string race;
        public string nom;
        public int ptsVieActuel;
        public int ptsVieMax;
        public int ptsAttaque;
        public int magie;
        public int ptsDefense;
        public int ptsVitesse;
        public int ptsExperience;
        public int seuilExperience;
        public int List<SORTS> listeSorts;
        public string objetTenu;
        public int ptsExperienceFourni;
        
        public Personnages(int _niveau, string _race, string _nom, int _ptsVieActuel, int _ptsVieMax, int _ptsAttaque, int _magie, int _ptsDefense, int _ptsVitesse, int _ptsExperience, int _seuilExperience, int List<SORTS> _listeSorts, string _objetTenu, int _ptsExperienceFourni)
        {
            niveau = _niveau;
            race = _race;
            nom = _nom;
            ptsVieActuel = _ptsVieActuel;
            ptsVieMax = _ptsVieMax;
            ptsAttaque = _ptsAttaque;
            magie = _magie;
            ptsDefense = _ptsDefense;
            ptsVitesse = _ptsVitesse;
            ptsExperience = _ptsExperience;
            seuilExperience = _seuilExperience
            List<SORTS> listeSorts = List <SORTS> _listeSorts;
            ng objetTenu;
            ptsExperienceFourni;
        }