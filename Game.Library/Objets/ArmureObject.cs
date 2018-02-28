using Game.Library.Enums;

namespace Game.Library.Objets
{
    public class ArmureObject
    {
        public string NomObjet { get; set; }
        public ElementType TypeElement { get; set; }
        public int Defense { get; set; }

        public ArmureObject()
        {
        }

        public ArmureObject(string nomObjet, ElementType typeElement, int defense)
        {
            NomObjet = nomObjet;
            TypeElement = typeElement;
            Defense = defense;
        }
    }
}