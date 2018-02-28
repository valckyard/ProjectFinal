using Game.Library.Enums;

namespace Game.Library.Objets
{
    public class ArmeObject
    {
        public string NomObjet { get; set; }
        public ElementType TypeElementType { get; set; }
        public int Puissance { get; set; }

        public ArmeObject()
        {
        }

        public ArmeObject(string nomObjet, ElementType typeElementType, int puissance)
        {
            NomObjet = nomObjet;
            TypeElementType = typeElementType;
            Puissance = puissance;
        }
    }
}


    