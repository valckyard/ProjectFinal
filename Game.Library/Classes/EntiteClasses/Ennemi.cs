using System;
using Game.Library.Classes.ObjClasses;
using Game.Library.Enums;

namespace Game.Library.Classes.EntiteClasses
{
    public class Ennemi
    {
        public string Name { get; set; }
        public TypeEnnemi TypeEnnemi { get; set; }
        public TypeElement TypeElement { get; set; }
        public int Pv { get; set; }
        public int Puissance { get; set; }
        public int Defense { get; set; }
        public int Vitesse { get; set; }
        public int ValeurExp { get; set; }
        public int LootChances { get; set; }
        public ClasseLootTable LootTable { get; set; }


        public Ennemi()
        {
        }

        public Ennemi(string name, TypeEnnemi typeEnnemi, int hp, TypeElement typeElement, int puissance, int defense,
            int vitesse, int valeurExp, int lootChances)
        {
            Name = name;
            Pv = hp;
            TypeEnnemi = typeEnnemi;
            TypeElement = typeElement;
            Puissance = puissance;
            Defense = defense;
            Vitesse = vitesse;
            ValeurExp = valeurExp;
            LootChances = lootChances;
        }

        public void Loot(ref Personnage joueur)
        {
            ObjInventaire loot = null;
            var rand = new Random();
            var chances = rand.Next(0, 101);
            if (chances > LootChances)
            {
                loot = LootTable.Table[rand.Next(0, LootTable.Table.Count)];
            }

            if (loot != null)
            {
                joueur.Inventaire.Add(loot);
                if (loot.Arme != null)
                    Console.WriteLine($"\nL'ennemi possedait {loot.Arme} !\nIl a ete ajoute a votre Inventaire !");
                if (loot.Armure != null)
                    Console.WriteLine($"\nL'ennemi possedait {loot.Armure} !\nIl a ete ajoute a votre Inventaire !");
                if (loot.ObjetCons != null)
                    Console.WriteLine($"\nL'ennemi possedait {loot.ObjetCons} !\nIl a ete ajoute a votre Inventaire !");
                else
                {
                    Console.WriteLine("L'ennemi n'avais aucun objet de valeur!");
                }
            }

        }
    }
}