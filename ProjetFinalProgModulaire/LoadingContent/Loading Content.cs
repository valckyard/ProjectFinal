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

        public static List<ClassNoeud> LoadingNoeuds()
        {
            var newList = new List<ClassNoeud>
            {
                new ClassNoeud("Je prends un taxi ou je me rends au Bistro !!!", false, "Taxi !!"),//
                new ClassNoeud("Je décide d'aller pêcher dans la fontaine du vieux Port", false, "Je vais prendre une bière"),
                new ClassNoeud("", true, "Après un combat aussi sanglant, allons prendreu une bière" )//KEY "Taxi"

            };
            return newList;
        }

    }
}
