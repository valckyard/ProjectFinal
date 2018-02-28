using Game.Library.Enums;

namespace Game.Library
{
    public class Ennemi
    {
        public string Name { get; set; }
        public TypeEnnemi TypeEnnemi { get; set; }
        public Elements TypElement { get; set; }
        public int PtsVie { get; set; }
        public int Puissance { get; set; }
        public int Defense { get; set; }
        public int Vitesse { get; set; }

        public Ennemi(){}

        public Ennemi(string name,TypeEnnemi typeEnnemi,int hp, Element typElement, int puissance, int defense, int vitesse)
        {
            Name = name;
            PtsVie = hp;
            TypeEnnemi = typeEnnemi;
            TypElement = typElement;
            Puissance = puissance;
            Defense = defense;
            Vitesse = vitesse;
        }
    }
}