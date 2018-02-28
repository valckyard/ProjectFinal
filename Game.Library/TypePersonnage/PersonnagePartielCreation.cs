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
            Nom = $"Placeholder_" + rand.Next(500,1000);
            Classe = (Classe) rand.Next(0, 3);
            Race = (Race) rand.Next(0,3);

            var tPuissanceMagique = rand.Next(10, 21);
            var tPtsAttaque = rand.Next(10, 21);
            var tPtsVieMax = 100;
            var tPointsMagieMax = 50;
            var tPtsVitesse = rand.Next(10, 20);
            var tPtsDefense = rand.Next(5, 16);
            var tNiveau = 0;
            var tPtsExperience = 0;
            var tSeuilExperience = 200;


            switch (Race)
            {
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

                case Race.Nain:
                    PuissanceMagique = tPuissanceMagique -5;
                    PtsAttaque = tPtsAttaque + 10 ;
                    PtsVieMax = tPtsVieMax +20;
                    PtsVieActuel = PtsVieMax;
                    PointsMagieMax = tPointsMagieMax -20;
                    PointsMagieActuel = PointsMagieMax;
                    PtsVitesse = tPtsVitesse -5;
                    PtsDefense = tPtsDefense +5 ;
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
                    PuissanceMagique = tPuissanceMagique +5;
                    PtsAttaque = tPtsAttaque - 10;
                    PtsVieMax = tPtsVieMax - 20;
                    PtsVieActuel = PtsVieMax;
                    PointsMagieMax = tPointsMagieMax + 20;
                    PointsMagieActuel = PointsMagieMax;
                    PtsVitesse = tPtsVitesse - 5;
                    PtsDefense = tPtsDefense + 5;
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
                    PuissanceMagique *= 0.25;
                    PointsMagieMax = (int)(PointsMagieMax * 0.25);
                    PointsMagieActuel = PointsMagieMax;
                    PtsAttaque *= 1.50;
                    PtsVitesse *= 0.75;
                    PtsDefense *= 0.75;
                    PtsVieMax = (int)(PtsVieMax * 1.35);
                    PtsVieActuel = PtsVieMax;
                    break;
                case Classe.Guerrier:
                    PuissanceMagique *= 0.50;
                    PointsMagieMax = (int)(PointsMagieMax * 0.50);
                    PointsMagieActuel = PointsMagieMax;
                    PtsAttaque *= 1.25;
                    PtsVitesse *= 1.20;
                    PtsDefense *= 1.20;
                    PtsVieMax = (int)(PtsVieMax * 1.15);
                    PtsVieActuel = PtsVieMax;
                    break;
                case Classe.Magicien:
                    PuissanceMagique *= 1.50;
                    PointsMagieMax = (int)(PointsMagieMax * 1.50);
                    PointsMagieActuel = PointsMagieMax;
                    PtsAttaque *= 0.50;
                    PtsVitesse *= 0.60;
                    PtsDefense *= 0.50;
                    PtsVieMax = (int)(PtsVieMax * 0.75);
                    PtsVieActuel = PtsVieMax;
                    break;
            }
        }

    }
}
