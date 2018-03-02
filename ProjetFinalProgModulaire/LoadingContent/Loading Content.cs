using System.Collections.Generic;
using Game.Library;
using Game.Library.Enums;
using Game.Library.Methodes;
using Game.Library.Objets;

namespace ProjetFinalProgModulaire
{
    public class LoadingContent
    {
        public static List<ArmeObject> LoadingArmes()
        {
            var newList = new List<ArmeObject>
            {
                new ArmeObject("Mains Nues", ElementType.Physique, 0),
                new ArmeObject("Gourdin", ElementType.Physique, 1),
                new ArmeObject("Poings Americains", ElementType.Physique, 1),
                new ArmeObject("Dague", ElementType.Physique, 2),
                new ArmeObject("Dague Maudite", ElementType.Physique, -1),
                new ArmeObject("Dague de Feu", ElementType.Feu, 0)
            };
            return newList;
        }

        public static List<Sort> LoadingSpells()
        {
            var newList = new List<Sort>
            {
                new Sort("Fleche de Crayons", ElementType.Physique, 2, 5),
                new Sort("Jet de Gatorade", ElementType.Eau, 2, 5),
                new Sort("Connection internet echoue", ElementType.Etheral, 2, 5),
                new Sort("Sortir un Red Bull Generation Zel d'un Chapeau", ElementType.Lumiere, 1, 5)
            };
            return newList;
        }
        public static List<ArmureObject> LoadingArmures()
        {
            var newList = new List<ArmureObject>
            {
                new ArmureObject("Vetements", ElementType.Physique, 0),
                new ArmureObject("Pack Sac", ElementType.Physique, 1),
                new ArmureObject("Mateau d'Hiver", ElementType.Physique, 1),
                new ArmureObject("Mateau de Cuir", ElementType.Physique, 2),
                new ArmureObject("Boxers", ElementType.Physique, -1),
                new ArmureObject("Manteau de Pluie", ElementType.Eau, 0)
            };
            return newList;
        }

        public static List<ConsumableObject> LoadingConsumableObjects()
        {
            var newList = new List<ConsumableObject>
            {
                new ConsumableObject("Red Bull", ConsumableType.Potion, ElementType.Lumiere, 1)
            };
            return newList;
        }

        public static List<Noeud> LoadingNoeuds()
        {
            var newList = new List<Noeud>
            {
                new Noeud("Je prends un taxi ou je me rends au Bistro !!!", false, "Taxi !!"),//
                new Noeud("Je décide d'aller pêcher dans la fontaine du vieux Port", false, "Je vais prendre une bière"),
                new Noeud("", true, "Après un combat aussi sanglant, allons prendreu une bière" )//KEY "Taxi"

            };
            return newList;
        }

    }
}
