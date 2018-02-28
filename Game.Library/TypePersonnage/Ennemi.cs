using Game.Library.Enums;

namespace Game.Library.TypePersonnage
{
    public class Ennemi
    {
        public string Name { get; set; }
        public TypeEnnemi TypeEnnemi { get; set; }
        public ElementType TypElementType { get; set; }
        public int PtsVie { get; set; }
        public int Puissance { get; set; }
        public int Defense { get; set; }
        public int Vitesse { get; set; }

        public Ennemi(){}

        public Ennemi(string name,TypeEnnemi typeEnnemi,int hp, ElementType typElementType, int puissance, int defense, int vitesse)
        {
            Name = name;
            PtsVie = hp;
            TypeEnnemi = typeEnnemi;
            TypElementType = typElementType;
            Puissance = puissance;
            Defense = defense;
            Vitesse = vitesse;
        }
    }
}