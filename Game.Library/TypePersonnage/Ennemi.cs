using Game.Library.Enums;

namespace Game.Library.TypePersonnage
{
    public class Ennemi
    {
        public string Name { get; set; }
        public TypeEnnemi TypeEnnemi { get; set; }
        public ElementType TypeElement { get; set; }
        public int Pv { get; set; }
        public int Puissance { get; set; }
        public int Defense { get; set; }
        public int Vitesse { get; set; }

        public Ennemi(){}

        public Ennemi(string name,TypeEnnemi typeEnnemi,int hp, ElementType typeElement, int puissance, int defense, int vitesse)
        {
            Name = name;
            Pv = hp;
            TypeEnnemi = typeEnnemi;
            TypeElement = typeElement;
            Puissance = puissance;
            Defense = defense;
            Vitesse = vitesse;
        }
    }
}