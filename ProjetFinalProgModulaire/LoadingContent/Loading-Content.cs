using System.Collections.Generic;
using System.Linq;
using Game.Library.Classes;
using Game.Library.Classes.EntiteClasses;
using Game.Library.Classes.ObjClasses;
using Game.Library.Enums;

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

        public static Dictionary<string, Noeud> LoadingNoeuds()
        {
            var ennemi1 =
                new Ennemi("Gourdée", TypeEnnemi.PerchaudeEnchantee, 90, TypeElement.Eau, 20, 12, 2, 2, 10)
                {
                    ValeurExp = 200,
                    LootTable = JeuProjet.LootTable
                };

            var ennemi2 = 
                new Ennemi("Damien", TypeEnnemi.Chien, 90, TypeElement.Physique, 20, 12, 2, 2, 90)
                {
                    ValeurExp = 200,
                    LootTable = JeuProjet.LootTable

                };

            var ennemi3 =
                new Ennemi("Zoreye", TypeEnnemi.Lievre, 90, TypeElement.Terre, 20, 12, 2, 2, 2)
                {
                    ValeurExp = 200,
                    LootTable = JeuProjet.LootTable

                };

            var ennemi4 =
                new Ennemi("Suzie", TypeEnnemi.Perdrix, 90, TypeElement.Air, 20, 12, 2, 2, 2)
                {
                    ValeurExp = 200,
                    LootTable = JeuProjet.LootTable

                };

            var ennemi5 =
                new Ennemi("Xamien", TypeEnnemi.Chien, 90, TypeElement.Etheral, 20, 12, 2, 2, 2)
                {
                    ValeurExp = 200,
                    LootTable = JeuProjet.LootTable

                };

            var ennemi6 =
                new Ennemi("Raster", TypeEnnemi.Lievre, 90, TypeElement.Lumiere, 20, 12, 2, 2, 2)
                {
                    ValeurExp = 200,
                    LootTable = JeuProjet.LootTable

                };

            var ennemi7 =
                new Ennemi("Fraprix", TypeEnnemi.Perdrix, 90, TypeElement.Feu, 20, 12, 2, 2, 2)
                {
                    ValeurExp = 200,
                    LootTable = JeuProjet.LootTable
                };



            //PersonnageRace race, PersonnageClasse classe, string nom, int pvMax, int mpMax, int puissance,
            //int puissanceMagique, int defense, int vitesse)
            var perso1 = new Personnage(PersonnageRace.Humain, PersonnageClasse.Barbare, "Normare", 100, 20, 25, 9, 15,4)
            {
                    Armure = LoadingArmures().ElementAt(3),
                    Arme = LoadingArmes().ElementAt(2),
                    ValeurExp = 200,
                    LootChances = 10,
                    LootTable = JeuProjet.LootTable
            };
            
            
            
            var perso2 = new Personnage(PersonnageRace.Elfe, PersonnageClasse.Magicien, "Magicelfe", 100, 20, 25, 9, 15, 4)
            {
                Armure = LoadingArmures().ElementAt(3),
                Arme = LoadingArmes().ElementAt(2),
                ValeurExp = 200,
                LootChances = 10,
                LootTable = JeuProjet.LootTable


            };
            var perso3 = new Personnage(PersonnageRace.Nain, PersonnageClasse.Barbare, "Nornain", 100, 20, 25, 9, 15, 4)
            {
                Armure = LoadingArmures().ElementAt(3),
                Arme = LoadingArmes().ElementAt(2),
                ValeurExp = 200,
                LootChances = 10,
                LootTable = JeuProjet.LootTable

            };
            var perso4 = new Personnage(PersonnageRace.Humain, PersonnageClasse.Guerrier, "Hubier", 100, 20, 25, 9, 15, 4)
            {
                Armure = LoadingArmures().ElementAt(3),
                Arme = LoadingArmes().ElementAt(2),
                ValeurExp = 200,
                LootChances = 10,
                LootTable = JeuProjet.LootTable

            };
            
            var perso5 = new Personnage(PersonnageRace.Elfe, PersonnageClasse.Magicien, "Momien", 100, 20, 25, 9, 15, 4)
            {
                Armure = LoadingArmures().ElementAt(3),
                Arme = LoadingArmes().ElementAt(2),
                ValeurExp = 200,
                LootChances = 10,
                LootTable = JeuProjet.LootTable

            };
            var perso6 = new Personnage(PersonnageRace.Nain, PersonnageClasse.Guerrier, "Naguerre", 100, 20, 25, 9, 15, 4)
            {
                Armure = LoadingArmures().ElementAt(3),
                Arme = LoadingArmes().ElementAt(2),
                ValeurExp = 200,
                LootChances = 10,
                LootTable = JeuProjet.LootTable

            };
            var perso7 = new Personnage(PersonnageRace.Humain, PersonnageClasse.Magicien, "Hogick", 100, 20, 25, 9, 15, 4)
            {
                Armure = LoadingArmures().ElementAt(3),
                Arme = LoadingArmes().ElementAt(2),
                ValeurExp = 200,
                LootChances = 10,
                LootTable = JeuProjet.LootTable

            };
            var perso8 = new Personnage(PersonnageRace.Elfe, PersonnageClasse.Barbare, "Elsbar", 100, 20, 25, 9, 15, 4)
            {
                Armure = LoadingArmures().ElementAt(3),
                Arme = LoadingArmes().ElementAt(2),
                ValeurExp = 200,
                LootChances = 10,
                LootTable = JeuProjet.LootTable

            };


            var dicnoeud = new Dictionary<string, Noeud>()
            {
                //Apres introduction histoire voici la premiere question --- TAXI OU SENTIER
                //#01
                { "Pont", new Noeud("Vous avez traversé la rivière et vous arrivez au bout du pont.\n" +
                                    "Devant vous,vous avez un boulevard où vous pourriez appeler un taxi ou\n" +
                                    "vous préférez prendre le sentier, plus discret sur votre gauche qui longe\n" +
                                    " la rivière.", null, null, false,
                                    new Dictionary<int, string>()
                                    {
                                        { 1,"Taxi"},
                                        { 2,"Sentier"}
                                    }
                               )
                },

                //#02 Vous avez décidé de prendre le taxi                --  RACINE OU Boul. Univ
                {"Taxi", new Noeud("Vous avancez jusqu'au boulevard et vous appelez un taxi !!. En vitesse, vous embarquez. le taxi." +
                                   " Vous decidez de passer par le boul.Université qui vous permettrait de contourner\n" +
                                   " la ville et ainsi arriver derrière votre objectif ou vous préférez passer\n" +
                                   " directement dans la Ville par la rue Racine." ,null, null, false,
                                    new Dictionary<int, string>()
                                    {
                                        { 1,"Racine"},
                                        { 2,"Boul.Université"}
                                    }
                               )
                },

                //#03  Marche  -- Combat
                {"Sentier", new Noeud("Vous marchez dans le sentier et après quelques minutes, vous arrivez devant une\n" +
                                      "fontaine d'eau. Vous regardez au loin sur votre droite, vous voyez un terrain\n" +
                                      "vague l'autre coté du boulevard ou tout semble tranquille ou vous décidez\n" +
                                      "de contourner le grand hangard", null, null, false,
                        new Dictionary<int, string>()
                        {
                            { 1,"Hangard"},
                            { 2,"Terrain Vague"}
                        }
                    )
                },

                //#04  
                {"Racine", new Noeud("Vous arrivez à la hauteur de la rue Racine et vous tournez à gauche. " +
                                     "Il y a une voie de libre et un homme est en plein milieu de celle-ci." +
                                     "Cela ressemble à un guet-apen. Vous ordonnez au chauffeur d'arrêter ou au contraire" +
                                     "vous lui ordonner de continuer et risquer d'écraser l'homme s'il ne se tasse pas" +
                                     "à temp.", null, null, false,
                        new Dictionary<int, string>()
                        {
                            { 1,"Arrêter"},
                            { 2,"Continuer"}
                        }
                    )
                },

                //#05  
                {"Boul.Université", new Noeud("Après un peu plus de 200m la taxi tombe en panne. Vous regardez le chauffeur\n" +
                                              "d'un air suspicieux.....", null, null, false,
                        new Dictionary<int, string>()
                        {
                            { 1,"Argumente"},
                            { 2,"A pied"}
                        }
                    )
                },

                
                //#06 
                {"Hangard", new Noeud("Vous contournez le très long hangard sans être repéré. Arrivez au bout, vous entendez du bruit\n" +
                                    "sur le bateau sur votre gauche.", null, null, false,
                            new Dictionary<int, string>()
                            {
                                { 1,"La Marjolaine"},
                                { 2,"Vers La Cathedrale"}
                            }
                     )
                },

                
                //#07 
                {"Terrain Vague", new Noeud("Vous vous diriger vers la droite où vous suivez le chemin de pierre.\n" +
                                            "Arrivez au boulevard, vous remarquez que c'est le calme plat de l'autre côté de\n" +
                                            "la route. Vous trouvez que c'est trop tranquille justement, mais, vous avez\n" +
                                            "une mission à accomplir.\n\n" +
                                            "Dès que la circulation vous le permet, vous courez afin de traverser le \n" +
                                            "boulevard le plus rapidement possible. Rendu de l'autre côté, vous avancez\n" +
                                            "tranquillement sur le terrain en direction de votre objectif final\n" +
                                            "qui se trouve tout en haut au sommet du haut de la ville. Vous apercez des escaliers" +
                                            "devant vous que vous vous empressez d'atteindre.\n\n",
                                            ennemi2, null, true,
                        new Dictionary<int, string>()
                        {
                            {1,"Escalier"},
                            {2,"Malheureusement pour vous, vous auriez du écouter votre instinct, vous êtes\n" +
                               "en plein champ de mine. Lorsque vous vous en rendez compte, il est trop tard,\n" +
                               "vous avez le pied sur une d'entre elle qui vous explose en pleine gueule."}
                        }
                    )
                },

                
                //#08 -- Combat
                {"Arrêter", new Noeud("Vous sortez du taxi et vous vous avancer vers l'homme d'un pas très prudent. Arrivé à" +
                                      "sa hauteur vous lui marcher sur le pied et d'un seul coup il se relève devant vous.",
                                      null, perso2, true,
                        new Dictionary<int, string>()
                        {
                            { 1,"A pied"},
                            { 2,"Vous aviez raison de vous méfier malheureusement pour vous, vous êtes entouré rapidement pour " +
                                "une douzaine de barbares  n'avez aucune chance"}
                        }
                    )
                },


                //#09
                {"Continuer", new Noeud("Vous criez au chauffeur de pas s'arrêter ou vous lui trancherez la gorge sans hésitez." +
                                        "Incapable de peut-être tuer un homme innocent, le chauffeur braque à gauche, perd" +
                                        "la maitrise de son taxi et vous n'avez aucun chance en entrant à plein vitesse dans" +
                                        "le mur de brique de l'immeuble devant vous.", null, perso1, true,
                        new Dictionary<int, string>()
                        {
                            { 1,"MORT"}
                        }
                    )
                },
                //#10 Combat
                {"Argumente", new Noeud("Vous sortez tous les deux du taxi et vous lui criez qu'il n'est qu'un imbécile!!!", ennemi1, null, true,
                        new Dictionary<int, string>()
                        {
                            { 1,"Vous tentez de redemarrer le taxi"},
                            { 2,"A pied"}
                        }
                    )
                },

                
                //#11  
                {"Escalier", new Noeud("Vous traversez le terrain vague sans être répérer. Vous apercevez un escalier en très mauvaise" +
                                       "état qui mène au haut de la colline", null, perso7, true,
                        new Dictionary<int, string>()
                        {
                            { 1,"Vers La Cathédrale"},
                            { 2,"En plein milieu de l'escalier, sur un vousblablblblblblblblblblbllb"}
                        }
                    )
                },
                
                
                //#12
                {"La Marjolaine", new Noeud("Vous sautez à bord du bateau, et après quelques recherches, vous rendez compte\n" +
                                            "que c'était le vent qui a fait rouler une bouteile sur le pont. Vous retournez\n" +
                                            "vers la sortie.", ennemi6, null, true,
                        new Dictionary<int, string>()
                        {
                            { 1,"Derive"},
                            { 2,"Vers La Cathedrale"}
                        }
                    )
                },

                //#13
                {"Derive", new Noeud("Le bateau n'était pas amarré et pendant la bagarre, vous avez dérivé.\n" +
                                     "Après quelques minutes de dérive, coup de chance, le bateau s'échoue sur le pilier\n" +
                                     "dBu pont. Vous réussissez à grimper et vous marchez en direction de la ville où\n" +
                                     "vous vous trouviez il y a à peine quelques minutes. ", null, null, false,
                        new Dictionary<int, string>()
                        {
                            { 1,"Pont"},
                        }
                    )
                },

                
                //#14
                {"Vers La Cathedrale", new Noeud("Sur le chemin de la Cathédrale, vous atteingnez enfin le haut de la colline,\n" +
                                            "et vous vous retrouvez sur le coin d'un immeuble sur la rue Racine. Sur la gauche à 200 mètres" +
                                            " se trouve La Cathédrale. POur y accéder, vous devez traverser en diagonale la rue." +
                                            "La rue semble déserte, mais c'est très à découvert. En avant de vous, de l'autre côté de la rue, " +
                                            "vous avez l'Hotel du Sorcier où vient d'entrer 2 Guerriers. Quel choix ferez-vous ? ", null, null, false,
                        new Dictionary<int, string>()
                        {
                            { 1,"Hotel"},
                            { 2,"Traversez la rue"}
                        }
                    )
                },

                
                //#15   
                {"Vous tentez de redemarrer le taxi", new Noeud("Vous tentez de redémarrer le taxi par vous même. Lorsque vous apercevez le chauffeur" +
                                              "s'éloigner à pleine jambe du taxi, vous comprenez ce qui se passe. Une déflagration" +
                                              "se fait attendre et s'en fait du taxi et de tout ce qui s'y trouve. ", null, null, false,
                        new Dictionary<int, string>()
                        {
                            { 1,"MORT"},
                        }
                    )
                },

                
                //#16  
                {"A pied", new Noeud("N'ayant pas de temps à perdre vous continuez votre route en direction de votre objectif sur la rue" +
                                     "racine", null, perso3, true,
                        new Dictionary<int, string>()
                        {
                            { 1,"Vers La Cathedrale"},

                            { 2,"Malheureusement, pour vous, on vous attendait et une flèche lancer derrière vous , vous transperce le coeur" +
                                "sans que vous aillez le temps de faire quoi que ce soit."}
                        }
                    )
                },

                //#17   
                {"Hotel", new Noeud("Vous entrez dans l'hotel et vous arrivez dans le vestibule de l'hotel.  Les 2 barbares ont disparus." +
                                    "Devant vous, vous voyez la porte qui donne vers l'arrière de l'hôtel. Cependant, vous devez traverser" +
                                    "un couloir qui semble très dangereux avec ses nombreuses portes. Vous courrez tout de même le risque" +
                                    "et vous tente de rejoindre la porte arrière ou vous tentez de passer à l'étage par l'escalier " +
                                    "afin d'avoir une meilleure vision. Avant même d'avoir pris votre décision, vous sortez du vestibule" +
                                    "en faisant quelques pas.  ", ennemi3, null, true,
                        new Dictionary<int, string>()
                        {
                            { 1,"Etage"},
                            { 2,"Porte de derrière"}
                        }
                    )
                },

                //#18
                {"Etage", new Noeud("Vous montez à l'étage par l'escalier. Malheureusement pour vous, on vous y attendait" +
                                    "Les deux guerriers que vous aviez vu entrer et le reste de la bande vous saute dessus, et vous" +
                                    "acheve et vous éclate la tronche !!!!", null, null, false,
                        new Dictionary<int, string>()
                        {
                            { 1,"MORT"},
                        }
                    )
                },

                //#19
                {"Porte de derrière", new Noeud("Après avoir traversé le halle de l'hotel, vous arrivez au couloir. ", null,perso4, true,
                        new Dictionary<int, string>()
                        {
                            { 1,"Cour de l'hotel"},
                            { 2,"Rendus au milieu de couloir, vous vous rendez compte dans quel pétrin vous êtes," +
                                "les 6 portes s'ouvrent d'un coup et on vous tombe dessus sans que vous ayez le temps" +
                                "de faire quoi que ce soit."
                            }
                        }
                    )
                },

                //#20  
                {"Cour de l'hotel", new Noeud("Vous ouvrez la porte de l'hotel et vous voilà tout prêt de votre objectif. Vous vous rendez tout" +
                                              "près de la clôture en bordure de la rue, ", ennemi5, null, true,
                        new Dictionary<int, string>()
                        {
                            { 1,"Traversez la rue"},

                            { 2,"La vue de votre objectif à quelques mètres, vous a fait perdre votre vigilence et vous 'avez pas remarquer les" +
                                "$$$$$$$$$ qui vous attendaient à l'étage. Leur $$$$$$$ vous réduisent à bouillis. "}
                        }
                    )
                },


                //#21  
                {"Traversez la rue", new Noeud("Vous attendez que la rue soit déserte, et vous vous lancez en direction de la " +
                                                 "Cathédrale.", null, null, false,
                    new Dictionary<int, string>()
                    {
                        { 1,"Entrez dans la Cathedrale"},

                        { 2,"Lorsque vous arrivez au milieu, vous entendez un léger déclic et vous sentez une grande chaleur" +
                            "vous envahir. Une rue minée vous attendait et vous n'aviez aucune chance de la traverser.  "}
                        }
                    )
                },

                //#22
                {"Entrez dans la Cathedrale", new Noeud("Vous arrivez devant la Cathédrale et vous entrer par la seule issue encore" +
                                                        "disponible, les 2 grandes portes centrales. Une fois à l'intérieur, vous devez" +
                                                        "faire vite et atteindre l'objectif, qui se trouve sous le plancher derrière" +
                                                        "l'hotel de l'église. Vous avancez vers l'hotel prudemment."
                                                        ,null, perso5, true, //valider si true/false
                        new Dictionary<int, string>()
                        {
                            { 1,"FIN"}
                        }
                    )
                },

            };
            return dicnoeud;

        }

     

       

    }
}
