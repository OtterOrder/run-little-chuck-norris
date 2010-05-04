using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Coeur
{
    public class SpriteComparer : IComparer<Sprite>
    {
        public int Compare(Sprite _Spr1, Sprite _Spr2)
        {
            if (_Spr1.Depth > _Spr2.Depth)
                return -1;
            else
                if (_Spr1.Depth < _Spr2.Depth)
                    return 1;

            return 0;
        }
    }
}
