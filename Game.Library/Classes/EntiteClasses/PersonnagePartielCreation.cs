using System;
using System.Collections.Generic;
using Game.Library.Classes.ObjClasses;
using Game.Library.Enums;

namespace Game.Library.Classes.EntiteClasses
{

    public partial class Personnage
    {
       public static Random Rand = new Random();

        public void CharacterCreation()
        {
           
            Nom = $"Placeholder_" + Rand.Next(500,1000);
            Classe = (PersonnageClasse) Rand.Next(0, 3);
            Race = (PersonnageRace) Rand.Next(0,3);

            var tPuissanceMagique = Rand.Next(10, 21);
            var tPtsAttaque = Rand.Next(10, 21);
            var tPtsVieMax = 100;
            var tPointsMagieMax = 50;
            var tPtsVitesse = Rand.Next(10, 20);
            var tPtsDefense = Rand.Next(5, 16);
            var tNiveau = 0;
            var tPtsExperience = 0;
            var tSeuilExperience = 200;


            switch (Race)
            {
                case PersonnageRace.Humain:
                    PuissanceMagique = tPuissanceMagique;
                    Puissance = tPtsAttaque;
                    PvMax = tPtsVieMax;
                    PvActuels = PvMax;
                    MpMax = tPointsMagieMax;
                    MpActuel = MpMax;
                    Vitesse = tPtsVitesse;
                    Defense = tPtsDefense;
                    Niveau = tNiveau;
                    Experience = tPtsExperience;
                    SeuilExperience = tSeuilExperience;

                    Arme = null;
                    ListeSorts = new List<Sort>();
                    Inventaire = new List<ObjInventaire>();
                    //Multiplier / DividerClass
                    ModifClasse();
                    break;

                case PersonnageRace.Nain:
                    PuissanceMagique = tPuissanceMagique -5;
                    Puissance = tPtsAttaque + 10 ;
                    PvMax = tPtsVieMax +20;
                    PvActuels = PvMax;
                    MpMax = tPointsMagieMax -20;
                    MpActuel = MpMax;
                    Vitesse = tPtsVitesse -5;
                    Defense = tPtsDefense +5 ;
                    Niveau = tNiveau;
                    Experience = tPtsExperience;
                    SeuilExperience = tSeuilExperience;

                    Arme = null;
                    ListeSorts = new List<Sort>();
                    Inventaire = new List<ObjInventaire>();
                    //Multiplier / DividerClass
                    ModifClasse();
                    break;

                
                case PersonnageRace.Elfe:
                    PuissanceMagique = tPuissanceMagique +5;
                    Puissance = tPtsAttaque - 10;
                    PvMax = tPtsVieMax - 20;
                    PvActuels = PvMax;
                    MpMax = tPointsMagieMax + 20;
                    MpActuel = MpMax;
                    Vitesse = tPtsVitesse - 5;
                    Defense = tPtsDefense + 5;
                    Niveau = tNiveau;
                    Experience = tPtsExperience;
                    SeuilExperience = tSeuilExperience;

                    Arme = null;
                    ListeSorts = new List<Sort>();
                    Inventaire = new List<ObjInventaire>();
                    //Multiplier / DividerClass
                    ModifClasse();
                    break;
            }

        }

        public void ModifClasse()
        {
            switch (Classe)
            {
                case PersonnageClasse.Barbare:
                    PuissanceMagique *= 0.25;
                    MpMax = (int)(MpMax * 0.25);
                    MpActuel = MpMax;
                    Puissance *= 1.50;
                    Vitesse *= 0.75;
                    Defense *= 0.75;
                    PvMax = (int)(PvMax * 1.35);
                    PvActuels = PvMax;
                    break;
                case PersonnageClasse.Guerrier:
                    PuissanceMagique *= 0.50;
                    MpMax = (int)(MpMax * 0.50);
                    MpActuel = MpMax;
                    Puissance *= 1.25;
                    Vitesse *= 1.20;
                    Defense *= 1.20;
                    PvMax = (int)(PvMax * 1.15);
                    PvActuels = PvMax;
                    break;
                case PersonnageClasse.Magicien:
                    PuissanceMagique *= 1.50;
                    MpMax = (int)(MpMax * 1.50);
                    MpActuel = MpMax;
                    Puissance *= 0.50;
                    Vitesse *= 0.60;
                    Defense *= 0.50;
                    PvMax = (int)(PvMax * 0.75);
                    PvActuels = PvMax;
                    break;
            }
        }

    }
}
