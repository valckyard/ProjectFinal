using Game.Library.Enums;

namespace Game.Library.Objets
{
    public class ConsumableObject
    {
        public string NomObjet { get; set; }
        public ConsumableType TypeConsumable { get; set; }
        public ElementType TypeElement { get; set; }
        public int Puissance { get; set; }

        public ConsumableObject()
        {
        }

        public ConsumableObject(string nomObjet, ConsumableType typeConsumable, ElementType typeElement, int puissance)
        {
            NomObjet = nomObjet;
            TypeConsumable = typeConsumable;
            TypeElement = typeElement;
            Puissance = puissance;
        }
    }
}