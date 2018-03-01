using Game.Library.Enums;

namespace Game.Library.Objets
{
    public class Sort
    {

        public string NomSort { get; set; }
        public ElementType TypeElement { get; set; }
        public int Puissance { get; set; }
        public int CoutMp { get; set; }

        public Sort(string nomSort, ElementType typeElement, int puissance, int coutMp)
        {
            NomSort = nomSort;
            TypeElement = typeElement;
            Puissance = puissance;
            CoutMp = coutMp;
        }

        public Sort()
        {
        }
    }
}


    