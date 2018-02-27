namespace Game.Library
{
    public class OBJET
    {
        public string NomObjet { get; set; }
        public Elements TypeElement { get; set; }
        public int Puissance { get; set; }

        public OBJET()
        {
        }

        public OBJET(string nomObjet, Elements typeElement, int puissance)
        {
            NomObjet = nomObjet;
            TypeElement = typeElement;
            Puissance = puissance;
        }
    }
}


    