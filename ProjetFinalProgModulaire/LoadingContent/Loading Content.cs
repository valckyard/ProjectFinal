using System;
using System.Collections.Generic;
using Game.Library;
using Game.Library.Classes;
using Game.Library.Classes.ObjClasses;
using Game.Library.Enums;
using Game.Library.Methodes;

namespace ProjetFinalProgModulaire
{
    public class LoadingContent
    {
        public static List<ObjArme> LoadingArmes()
        {
            var newList = new List<ObjArme>
            {
                new ObjArme("Mains Nues", TypeElement.Physique, 0),
                new ObjArme("Gourdin", TypeElement.Physique, 1),
                new ObjArme("Poings Americains", TypeElement.Physique, 1),
                new ObjArme("Dague", TypeElement.Physique, 2),
                new ObjArme("Dague Maudite", TypeElement.Physique, -1),
                new ObjArme("Dague de Feu", TypeElement.Feu, 0)
            };
            return newList;
        }

        public static List<Sort> LoadingSpells()
        {
            var newList = new List<Sort>
            {
                new Sort("Fleche de Crayons", TypeElement.Physique, 2, 5),
                new Sort("Jet de Gatorade", TypeElement.Eau, 2, 5),
                new Sort("Connection internet echoue", TypeElement.Etheral, 2, 5),
                new Sort("Sortir un Red Bull Generation Zel d'un Chapeau", TypeElement.Lumiere, 1, 5)
            };
            return newList;
        }
        public static List<ObjArmure> LoadingArmures()
        {
            var newList = new List<ObjArmure>
            {
                new ObjArmure("Vetements", TypeElement.Physique, 0),
                new ObjArmure("Pack Sac", TypeElement.Physique, 1),
                new ObjArmure("Mateau d'Hiver", TypeElement.Physique, 1),
                new ObjArmure("Mateau de Cuir", TypeElement.Physique, 2),
                new ObjArmure("Boxers", TypeElement.Physique, -1),
                new ObjArmure("Manteau de Pluie", TypeElement.Eau, 0)
            };
            return newList;
        }

        public static List<ObjConsumable> LoadingConsumableObjects()
        {
            var newList = new List<ObjConsumable>
            {
                new ObjConsumable("Red Bull", TypeConsumable.Potion, TypeElement.Lumiere, 1)
            };
            return newList;
        }

        public static Dictionary<string,Noeud> LoadingNoeuds()
        {
            var dicnoeud = new Dictionary<string,Noeud>()
            {
                //Apres introduction histoire voici la premiere question --- TAXI OU SENTIER
                //
                { "a", new Noeud("Je prends un taxi ou je prend la sentier sur la gauche!!!", null, null,
                                    new Dictionary<int, string>()
                                    {
                                        { 1,"taxi"},
                                        { 2,"Sentier"}
                                    }
                               )
                },

                //Vous avez décidé de prendre le taxi            -- COMBAT TO ADD       --  RACINE OU Boul. Univ
                {"Taxi", new Noeud("Vous avancez jusqu'au boulevard et vous crié: TAXI!!. En vitesse ...", null, null,
                                    new Dictionary<int, string>()
                                    {
                                        { 1,"Racine"},
                                        { 2,"Boul.Université"}
                                    }
                               )
                },

                //   Marche
                {"Sentier", new Noeud("Arrivé a la fontaine ......", null, null,
                        new Dictionary<int, string>()
                        {
                            { 1,"Hangard"},
                            { 2,"Terrain Vague"}
                        }
                    )
                },

                //   
                {"Racine", new Noeud("Homme milieu de la rue", null, null,
                        new Dictionary<int, string>()
                        {
                            { 1,"Stop"},
                            { 2,"Continue"}
                        }
                    )
                },

                //   
                {"boul.Université", new Noeud("panne de taxi", null, null,
                        new Dictionary<int, string>()
                        {
                            { 1,"Argumente"},
                            { 2,"Continue mon chemin"}
                        }
                    )
                },

                
                //   
                {"Hangard", new Noeud("Contourne hangard entend du bruit provenant du bateau", null, null,
                        new Dictionary<int, string>()
                        {
                            { 1,"La Majolaine"},
                            { 2,"La Cathedrale"}
                        }
                    )
                },

                
                //   
                {"Terrain Vague", new Noeud("Terrain miné !!!", null, null,
                        new Dictionary<int, string>()
                        {
                            { 1,"MORT"},
                        }
                    )
                },

                
                //    -- Combat
                {"Stop", new Noeud("Vous sortez du taxi et vous vous avancer vers....", null, null,
                        new Dictionary<int, string>()
                        {
                            { 1,""},
                            { 2,""}
                        }
                    )
                },

                //
                {"Continue", new Noeud("Vous criez au chauffeur de npas", null, null,
                        new Dictionary<int, string>()
                        {
                            { 1,"CHOIX"},
                            { 2,"CHOIX"}
                        }
                    )
                },
                // Combat
                {"Argumente", new Noeud(" Une altercation avec le chauffeur de taxi", null, null,
                        new Dictionary<int, string>()
                        {
                            { 1,"Redemarrer taxi"},
                            { 2,"A pied"}
                        }
                    )
                },

                
                //   
                {"Continue son chemin", new Noeud("Arrive ", null, null,
                        new Dictionary<int, string>()
                        {
                            { 1,"CHOIX"},
                            { 2,"CHOIX"}
                        }
                    )
                },
                
                
                //  
                {"La Marjolaine", new Noeud("Entre bateau, fight bateau derive pendant la bagarre derive s'échouecture", null, null,
                        new Dictionary<int, string>()
                        {
                            { 1,"A"},
                        }
                    )
                },

                
                //   
                {"La Cathedrale", new Noeud("", null, null,
                        new Dictionary<int, string>()
                        {
                            { 1,"CHOIX"},
                            { 2,"CHOIX"}
                        }
                    )
                },


                
                //Templates   
                {"Combat", new Noeud("", null, null,
                        new Dictionary<int, string>()
                        {
                            { 1,"CHOIX"},

                            { 2,"CHOIX"}
                        }
                    )
                },


                
                //Templates   
                {"Passe mon chemin", new Noeud("", null, null,
                        new Dictionary<int, string>()
                        {
                            { 1,"CHOIX"},

                            { 2,"CHOIX"}
                        }
                    )
                },


                
                //Templates   
                {"Redemarrer taxi", new Noeud("", null, null,
                        new Dictionary<int, string>()
                        {
                            { 1,"MORT"},

                            { 2,"MORT"}
                        }
                    )
                },


                
                //Templates   
                {"A pied", new Noeud("", null, null,
                        new Dictionary<int, string>()
                        {
                            { 1,""},

                            { 2,"CHOIX"}
                        }
                    )
                },


                
                //Templates   
                {"", new Noeud("", null, null,
                        new Dictionary<int, string>()
                        {
                            { 1,"CHOIX"},

                            { 2,"CHOIX"}
                        }
                    )
                },


                //Templates   
                {"", new Noeud("", null, null,
                        new Dictionary<int, string>()
                        {
                            { 1,"CHOIX"},

                            { 2,"CHOIX"}
                        }
                    )
                },

            };
            return dicnoeud;

        }

    }
}
