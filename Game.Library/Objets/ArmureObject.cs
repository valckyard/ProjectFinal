using Game.Library.Enums;

namespace Game.Library.Objets
{
    public class ArmureObject
    {
        public string NomObjet { get; set; }
        public ElementType TypeElementType { get; set; }
        public int Defense { get; set; }

        public ArmureObject()
        {
        }

        public ArmureObject(string nomObjet, ElementType typeElementType, int defense)
        {
            NomObjet = nomObjet;
            TypeElementType = typeElementType;
            Defense = defense;
        }
    }
}