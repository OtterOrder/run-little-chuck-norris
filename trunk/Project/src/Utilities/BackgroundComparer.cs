using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Coeur
{
    //-------------------------------------------------------------------------
    public class BackgroundComparer : IComparer<Background>
    {
        public int Compare(Background _Bg1, Background _Bg2)
        {
            if (_Bg1.Depth > _Bg2.Depth)
                return -1;
            else
                if (_Bg1.Depth < _Bg2.Depth)
                    return 1;

            return 0;
        }
    }
}
