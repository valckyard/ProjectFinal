using Game.Library.Enums;

namespace Game.Library.Classes.ObjClasses
{
    public class ObjConsumable
    {
        public string NomObjet { get; set; }
        public TypeConsumable TypeConsumable { get; set; }
        public TypeElement TypeElement { get; set; }
        public int Puissance { get; set; }

        public ObjConsumable()
        {
        }

        public ObjConsumable(string nomObjet, TypeConsumable typeConsumable, TypeElement typeElement, int puissance)
        {
            NomObjet = nomObjet;
            TypeConsumable = typeConsumable;
            TypeElement = typeElement;
            Puissance = puissance;
        }

        public Sort ItemToSpell()
        {
            var sort = new Sort(NomObjet,TypeElement,Puissance,0);

            return sort;
        }

    }
}