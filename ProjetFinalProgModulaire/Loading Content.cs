using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Library;
using Game.Library.Enums;

namespace ProjetFinalProgModulaire
{
    public class LoadingContent
    {
        public static List<Objet> LoadingItems()
        {
            var newList = new List<Objet>
            {
                new Objet("Mains Nues", Element.Physique, 0),
                new Objet("Gourdin", Element.Physique, 1),
                new Objet("Poings Americains", Element.Physique, 1),
                new Objet("Dague", Element.Physique, 2),
                new Objet("Dague Maudite", Element.Physique, -1),
                new Objet("Dague de Feu", Element.Feu, 0)
            };

            

            return newList;
        }

        public static List<Sort> LoadingSpells()
        {
            var newList = new List<Sort>
            {
                new Sort("Fleche de Crayons", Element.Physique, 2, 5),
                new Sort("Jet de Gatorade", Element.Eau, 2, 5),
                new Sort("Connection internet echoue", Element.Etheral, 2, 5)
            };



            return newList;
        }

    }
}
