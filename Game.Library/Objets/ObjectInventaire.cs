namespace Game.Library.Objets
{
    public class ObjectInventaire
    {
        public ArmeObject Arme { get; set; }
        public ArmureObject Armure { get; set; }
        public ConsumableObject ObjetCons { get; set; }

        public ObjectInventaire(ArmureObject armure)
        {
            Armure = armure;
        }

        public ObjectInventaire(ConsumableObject objetCons)
        {
            ObjetCons = objetCons;
        }

        public ObjectInventaire(ArmeObject arme)
        {
            Arme = arme;
        }
    }
}