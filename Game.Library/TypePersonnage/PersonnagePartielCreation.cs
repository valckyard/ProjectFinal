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

            switch (Race)
            {
                case Race.Nain:
                    PuissanceMagique = rand.Next();
                    PtsAttaque = rand.Next();
                    PtsVieMax = rand.Next();
                    PtsVieActuel = PtsVieMax;
                    PointsMagieMax = rand.Next();
                    PointsMagieActuel = PointsMagieMax;
                    PtsVitesse = rand.Next();
                    PtsDefense = rand.Next();
                    Niveau = 0;
                    PtsExperience = 0;
                    SeuilExperience = 200;

                    Arme = null;
                    ListeSorts = new List<Sort>();
                    Inventaire = new List<ObjectInventaire>();
                    //Multiplier / DividerClass
                    ModifClasse();
                    break;
                
                case Race.Humain:
                    PuissanceMagique = rand.Next();
                    PtsAttaque = rand.Next();
                    PtsVieMax = rand.Next();
                    PtsVieActuel = PtsVieMax;
                    PointsMagieMax = rand.Next();
                    PointsMagieActuel = PointsMagieMax;
                    PtsVitesse = rand.Next();
                    PtsDefense = rand.Next();
                    Niveau = 0;
                    PtsExperience = 0;
                    SeuilExperience = 200;

                    Arme = null;
                    ListeSorts = new List<Sort>();
                    Inventaire = new List<ObjectInventaire>();
                    //Multiplier / DividerClass
                    ModifClasse();
                    break;
                case Race.Elfe:
                    PuissanceMagique = rand.Next();
                    PtsAttaque = rand.Next();
                    PtsVieMax = rand.Next();
                    PtsVieActuel = PtsVieMax;
                    PointsMagieMax = rand.Next();
                    PointsMagieActuel = PointsMagieMax;
                    PtsVitesse = rand.Next();
                    PtsDefense = rand.Next();
                    Niveau = 0;
                    PtsExperience = 0;
                    SeuilExperience = 200;

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
