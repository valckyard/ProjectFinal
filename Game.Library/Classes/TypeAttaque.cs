using System;
using Game.Library.Enums;

namespace Game.Library.Classes
{
    
    public class ClasseTypeAttaque
    {
        public int AttaqueArme { get; set; }
        public int AttaqueSort { get; set; }
        public int Item { get; set; }
        public AttaqueChoisie Choix { get; set; }

        public ClasseTypeAttaque(int attaqueArme, int attaqueSort, int item)
        {
            AttaqueArme = attaqueArme;
            AttaqueSort = attaqueSort;
            Item = item;
        }

        public ClasseTypeAttaque()
        {
        }


        public AttaqueChoisie RandomType()
        {
            var random = new Random();

            int randomc = random.Next(0, 101);

            int spellAtt = AttaqueArme + AttaqueSort;


            if (randomc <= AttaqueArme)
            {
                return Choix = AttaqueChoisie.AttaqueArme;
            }

            if (randomc <= spellAtt & randomc > AttaqueArme)
            {
                return Choix = AttaqueChoisie.AttaqueSort;
            }

            else
            { return Choix = AttaqueChoisie.Item;}

        }
    }
}
    