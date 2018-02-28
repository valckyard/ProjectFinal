using Game.Library.Enums;

namespace Game.Library.Objets
{
    public class Sort
    {

        public string NomSort { get; set; }
        public ElementType TypeElementType { get; set; }
        public int Puissance { get; set; }
        public int CoutMp { get; set; }

        public Sort(string nomSort, ElementType typeElementType, int puissance, int coutMp)
        {
            NomSort = nomSort;
            TypeElementType = typeElementType;
            Puissance = puissance;
            CoutMp = coutMp;
        }

        public Sort()
        {
        }
    }
}


    