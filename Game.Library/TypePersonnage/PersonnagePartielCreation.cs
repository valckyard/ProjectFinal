using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Library.Enums;
using Game.Library.Objets;

namespace Game.Library.TypePersonnage
{

    public partial class Personnages
    {
        public void CharacterCreation()
        {
            var rand = new Random();
            Race = Race.Nain; // decision
            Classe = Classe.Magicien; // desision

            var tPuissanceMagique = rand.Next(10, 21);
            var tPtsAttaque = rand.Next(10, 21);
            var tPtsVieMax = rand.Next(50, 71);
            var tPointsMagieMax = rand.Next(20, 31);
            var tPtsVitesse = rand.Next(10, 20);
            var tPtsDefense = rand.Next(5, 16);
            var tNiveau = 0;
            var tPtsExperience = 0;
            var tSeuilExperience = 200;


            switch (Race)
            {
                case Race.Nain:
                    PuissanceMagique = tPuissanceMagique;
                    PtsAttaque = tPtsAttaque;
                    PtsVieMax = tPtsVieMax;
                    PtsVieActuel = PtsVieMax;
                    PointsMagieMax = tPointsMagieMax;
                    PointsMagieActuel = PointsMagieMax;
                    PtsVitesse = tPtsVitesse;
                    PtsDefense = tPtsDefense;
                    Niveau = tNiveau;
                    PtsExperience = tPtsExperience;
                    SeuilExperience = tSeuilExperience;

                    Arme = null;
                    ListeSorts = new List<Sort>();
                    Inventaire = new List<ObjectInventaire>();
                    //Multiplier / DividerClass
                    ModifClasse();
                    break;

                case Race.Humain:
                    PuissanceMagique = tPuissanceMagique;
                    PtsAttaque = tPtsAttaque;
                    PtsVieMax = tPtsVieMax;
                    PtsVieActuel = PtsVieMax;
                    PointsMagieMax = tPointsMagieMax;
                    PointsMagieActuel = PointsMagieMax;
                    PtsVitesse = tPtsVitesse;
                    PtsDefense = tPtsDefense;
                    Niveau = tNiveau;
                    PtsExperience = tPtsExperience;
                    SeuilExperience = tSeuilExperience;

                    Arme = null;
                    ListeSorts = new List<Sort>();
                    Inventaire = new List<ObjectInventaire>();
                    //Multiplier / DividerClass
                    ModifClasse();
                    break;
                case Race.Elfe:
                    PuissanceMagique = tPuissanceMagique;
                    PtsAttaque = tPtsAttaque;
                    PtsVieMax = tPtsVieMax;
                    PtsVieActuel = PtsVieMax;
                    PointsMagieMax = tPointsMagieMax;
                    PointsMagieActuel = PointsMagieMax;
                    PtsVitesse = tPtsVitesse;
                    PtsDefense = tPtsDefense;
                    Niveau = tNiveau;
                    PtsExperience = tPtsExperience;
                    SeuilExperience = tSeuilExperience;

                    Arme = null;
                    ListeSorts = new List<Sort>();
                    Inventaire = new List<ObjectInventaire>();
                    //Multiplier / DividerClass
                    ModifClasse();
                    break;
            }

        }

        public void ModifClasse()
        {
            switch (Classe)
            {
                case Classe.Barbare:
                    break;
                case Classe.Guerrier:
                    break;
                case Classe.Magicien:
                    break;
                case Classe.Pretre:
                    break;
            }
        }




    }
}
