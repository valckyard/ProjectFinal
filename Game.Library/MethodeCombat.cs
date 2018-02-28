using Game.Library.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Game.Library
{
    public class MethodeCombat
    {
        public static double Dommage(Elements elementattaque, Elements elementdefense)
        {
            switch (elementattaque)
            {
                case Elements.Physique:
                    if (elementdefense == Elements.Etheral)
                    {
                        return 0.5;
                    }
                    else
                    {
                        return 1;
                    }

                case Elements.Etheral:

                    return 1;

                case Elements.Air:

                    if (elementdefense == Elements.Eau)
                    {
                        return 1.5;
                    }
                    else if (elementdefense == Elements.Terre)
                    {
                        return 0.5;
                    }
                    else
                    {
                        return 1;
                    }

                case Elements.Feu:
                    if (elementdefense == Elements.Terre)
                    {
                        return 1.5;
                    }
                    else if (elementdefense == Elements.Eau)
                    {
                        return 0.5;
                    }
                    else
                    {
                        return 1;
                    }
                case Elements.Eau:
                    if (elementdefense == Elements.Feu)
                    {
                        return 1.5;
                    }
                    else if (elementdefense == Elements.Air)
                    {
                        return 0.5;
                    }
                    else
                    {
                        return 1;
                    }
                 case Elements.Terre:
                    if (elementdefense == Elements.Feu)
                    {
                        return 0.5;
                    }
                    else if (elementdefense == Elements.Air)
                    {
                        return 1.5;
                    }
                    else
                    {
                        return 1;
                    }   
                    
                 default:
                    break;
            }

            return 1;
        }
        


    }
}
