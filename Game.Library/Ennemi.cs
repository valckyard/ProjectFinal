namespace Game.Library
{
    public class Ennemi
    {
        public TypeEnnemi TypeEnnemi { get; set; }
        public Elements TypElements { get; set; }
        public int Puissance { get; set; }
        public int Defense { get; set; }
        public int Vitesse { get; set; }

        public Ennemi(){}
    }
}