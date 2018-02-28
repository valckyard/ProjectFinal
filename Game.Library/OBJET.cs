using Game.Library.Enums;

namespace Game.Library
{
    public class Objet
    {
        public string NomObjet { get; set; }
        public Element TypeElement { get; set; }
        public int Puissance { get; set; }

        public Objet()
        {
        }

        public Objet(string nomObjet, Element typeElement, int puissance)
        {
            NomObjet = nomObjet;
            TypeElement = typeElement;
            Puissance = puissance;
        }
    }
}


    