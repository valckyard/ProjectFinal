using Game.Library.Enums;

namespace Game.Library.Classes.ObjClasses
{
    public class ObjArme
    {
        public string NomObjet { get; set; }
        public TypeElement TypeElement { get; set; }
        public int Puissance { get; set; }

        public ObjArme()
        {
        }

        public ObjArme(string nomObjet, TypeElement typeElement, int puissance)
        {
            NomObjet = nomObjet;
            TypeElement = typeElement;
            Puissance = puissance;
        }
    }
}


    