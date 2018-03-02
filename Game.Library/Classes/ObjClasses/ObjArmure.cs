using Game.Library.Enums;

namespace Game.Library.Classes.ObjClasses
{
    public class ObjArmure
    {
        public string NomObjet { get; set; }
        public TypeElement TypeElement { get; set; }
        public int Defense { get; set; }

        public ObjArmure()
        {
        }

        public ObjArmure(string nomObjet, TypeElement typeElement, int defense)
        {
            NomObjet = nomObjet;
            TypeElement = typeElement;
            Defense = defense;
        }
    }
}