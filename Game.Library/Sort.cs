using Game.Library.Enums;

namespace Game.Library
{
    public class Sort
    {

        public string NomSort { get; set; }
        public Element TypeElement { get; set; }
        public int Puissance { get; set; }
        public int CoutMp { get; set; }

        public Sort(string nomSort, Element typeElement, int puissance, int coutMp)
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


    