using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Library.Classes.ObjClasses;

namespace Game.Library.Classes
{
    public class ClasseLootTable
    {
        public List<ObjInventaire> Table { get; set; }
        public List<ObjArme> ListArme { get; set; }
        public List<ObjArmure> ListArmure { get; set; }
        public List<ObjConsumable> ListConsumables { get; set; }

        public ClasseLootTable(List<ObjArme> listArme, List<ObjArmure> listArmure, List<ObjConsumable> listConsumables)
        {
            ListArme = listArme;
            ListArmure = listArmure;
            ListConsumables = listConsumables;

            Table = new List<ObjInventaire>();
            foreach (var arme in ListArme)
            {
                Table.Add(new ObjInventaire(arme));

            }

            foreach (var armure in ListArmure)
            {
                Table.Add(new ObjInventaire(armure));
            }

            foreach (var item in ListConsumables)
            {
                Table.Add(new ObjInventaire(item));
            }
        }
    }
}
