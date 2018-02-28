using System;
using System.Security.Cryptography.X509Certificates;
using Game.Library.Enums;
using Game.Library.TypePersonnage;

namespace Game.Library.Methodes
{
    public class MethodeCombat
    {
        public static double Dommage(ElementType elementattaque, ElementType elementdefense)
        {
            switch (elementattaque)
            {
                case ElementType.Physique:
                    if (elementdefense == ElementType.Etheral)
                    {
                        return 0.5;
                    }
                    else
                    {
                        return 1;
                    }

                case ElementType.Etheral:

                    return 1;

                case ElementType.Air:

                    if (elementdefense == ElementType.Eau)
                    {
                        return 1.5;
                    }
                    else if (elementdefense == ElementType.Terre)
                    {
                        return 0.5;
                    }
                    else
                    {
                        return 1;
                    }

                case ElementType.Feu:
                    if (elementdefense == ElementType.Terre)
                    {
                        return 1.5;
                    }
                    else if (elementdefense == ElementType.Eau)
                    {
                        return 0.5;
                    }
                    else
                    {
                        return 1;
                    }
                case ElementType.Eau:
                    if (elementdefense == ElementType.Feu)
                    {
                        return 1.5;
                    }
                    else if (elementdefense == ElementType.Air)
                    {
                        return 0.5;
                    }
                    else
                    {
                        return 1;
                    }
                 case ElementType.Terre:
                    if (elementdefense == ElementType.Feu)
                    {
                        return 0.5;
                    }
                    else if (elementdefense == ElementType.Air)
                    {
                        return 1.5;
                    }
                    else
                    {
                        return 1;
                    }   
                    
            }

            return 1;
        }

        


    }
}
