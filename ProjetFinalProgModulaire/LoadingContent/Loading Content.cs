using System;
using System.Collections.Generic;
using Game.Library;
using Game.Library.Classes;
using Game.Library.Classes.ObjClasses;
using Game.Library.Enums;
using Game.Library.Methodes;

namespace ProjetFinalProgModulaire
{
    public class LoadingContent
    {
        public static List<ObjArme> LoadingArmes()
        {
            var newList = new List<ObjArme>
            {
                new ObjArme("Mains Nues", TypeElement.Physique, 0),
                new ObjArme("Gourdin", TypeElement.Physique, 1),
                new ObjArme("Poings Americains", TypeElement.Physique, 1),
                new ObjArme("Dague", TypeElement.Physique, 2),
                new ObjArme("Dague Maudite", TypeElement.Physique, -1),
                new ObjArme("Dague de Feu", TypeElement.Feu, 0)
            };
            return newList;
        }

        public static List<Sort> LoadingSpells()
        {
            var newList = new List<Sort>
            {
                new Sort("Fleche de Crayons", TypeElement.Physique, 2, 5),
                new Sort("Jet de Gatorade", TypeElement.Eau, 2, 5),
                new Sort("Connection internet echoue", TypeElement.Etheral, 2, 5),
                new Sort("Sortir un Red Bull Generation Zel d'un Chapeau", TypeElement.Lumiere, 1, 5)
            };
            return newList;
        }
        public static List<ObjArmure> LoadingArmures()
        {
            var newList = new List<ObjArmure>
            {
                new ObjArmure("Vetements", TypeElement.Physique, 0),
                new ObjArmure("Pack Sac", TypeElement.Physique, 1),
                new ObjArmure("Mateau d'Hiver", TypeElement.Physique, 1),
                new ObjArmure("Mateau de Cuir", TypeElement.Physique, 2),
                new ObjArmure("Boxers", TypeElement.Physique, -1),
                new ObjArmure("Manteau de Pluie", TypeElement.Eau, 0)
            };
            return newList;
        }

        public static List<ObjConsumable> LoadingConsumableObjects()
        {
            var newList = new List<ObjConsumable>
            {
                new ObjConsumable("Red Bull", TypeConsumable.Potion, TypeElement.Lumiere, 1)
            };
            return newList;
        }

        public static Dictionary<string,Noeud> LoadingNoeuds()
        {
            var dicnoeud = new Dictionary<int,string>()
            {
                new Noeud("Je prends un taxi ou je me rends au Bistro !!!", null, null,
                    new Dictionary<int, string>(){1,"taxi"},{2,"Sentier"})
            };
            
        }

    }
}
