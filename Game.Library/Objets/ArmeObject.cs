using Game.Library.Enums;

namespace Game.Library.Objets
{
    public class ArmeObject
    {
        public string NomObjet { get; set; }
        public ElementType TypeElement { get; set; }
        public int Puissance { get; set; }

        public ArmeObject()
        {
        }

        public ArmeObject(string nomObjet, ElementType typeElement, int puissance)
        {
            NomObjet = nomObjet;
            TypeElement = typeElement;
            Puissance = puissance;
        }
    }
}


    