using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Library;

namespace ProjetFinalProgModulaire
{
    public class LoadingContent
    {
        public static List<OBJET> LoadingItems()
        {
            List<OBJET> newList = new List<OBJET>();


            //Basic
            newList.Add(new OBJET("Mains Nues", Elements.Physique, 0));
            newList.Add(new OBJET("Gourdin", Elements.Physique, 1));
            newList.Add(new OBJET("Poings Americains", Elements.Physique, 1));
            newList.Add(new OBJET("Dague", Elements.Physique, 2));

            //Maudite
            newList.Add(new OBJET("Dague Maudite", Elements.Physique, -1));

            //Magique
            newList.Add(new OBJET("Dague de Feu", Elements.Feu, 0));

            return newList;
        }

        public static List<SORT> LoadingSpells()
        {
            List<SORT> newList = new List<SORT>();

            newList.Add(new SORT("Fleche de Crayons",Elements.Physique,2,5));
            newList.Add(new SORT("Jet de Gatorade", Elements.Eau, 2, 5));
            newList.Add(new SORT("Connection internet echoue", Elements.Etheral, 2, 5));


            return newList;
        }

    }
}
