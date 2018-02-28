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
                new Objet("Mains Nues", Elements.Physique, 0),
                new Objet("Gourdin", Elements.Physique, 1),
                new Objet("Poings Americains", Elements.Physique, 1),
                new Objet("Dague", Elements.Physique, 2),
                new Objet("Dague Maudite", Elements.Physique, -1),
                new Objet("Dague de Feu", Elements.Feu, 0)
            };

            

            return newList;
        }

        public static List<Sort> LoadingSpells()
        {
            var newList = new List<Sort>
            {
                new Sort("Fleche de Crayons", Elements.Physique, 2, 5),
                new Sort("Jet de Gatorade", Elements.Eau, 2, 5),
                new Sort("Connection internet echoue", Elements.Etheral, 2, 5),
                new Sort("Red Bull Generation Zel", Elements.Lumiere, 1, 5)
            };



            return newList;
        }

    }
}
