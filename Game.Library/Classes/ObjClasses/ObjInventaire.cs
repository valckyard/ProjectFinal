namespace Game.Library.Classes.ObjClasses
{
    public class ObjInventaire
    {
        public ObjArme Arme { get; set; }
        public ObjArmure Armure { get; set; }
        public ObjConsumable ObjetCons { get; set; }

        public ObjInventaire(ObjArmure armure)
        {
            Armure = armure;
        }

        public ObjInventaire(ObjConsumable objetCons)
        {
            ObjetCons = objetCons;
        }

        public ObjInventaire(ObjArme arme)
        {
            Arme = arme;
        }

    }
}