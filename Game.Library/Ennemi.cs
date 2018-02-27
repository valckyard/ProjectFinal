namespace Game.Library
{
    public class Ennemi
    {
        public string Name { get; set; }
        public TypeEnnemi TypeEnnemi { get; set; }
        public Elements TypElements { get; set; }
        public int Puissance { get; set; }
        public int Defense { get; set; }
        public int Vitesse { get; set; }

        public Ennemi(){}

        public Ennemi(string name,TypeEnnemi typeEnnemi, Elements typElements, int puissance, int defense, int vitesse)
        {
            Name = name;
            TypeEnnemi = typeEnnemi;
            TypElements = typElements;
            Puissance = puissance;
            Defense = defense;
            Vitesse = vitesse;
        }
    }
}