using Game.Library.Enums;

namespace Game.Library
{
    public class Objet
    {
        public string NomObjet { get; set; }
        public Elements TypeElement { get; set; }
        public int Puissance { get; set; }

        public Objet()
        {
        }

        public Objet(string nomObjet, Elements typeElement, int puissance)
        {
            NomObjet = nomObjet;
            TypeElement = typeElement;
            Puissance = puissance;
        }
    }
}


    