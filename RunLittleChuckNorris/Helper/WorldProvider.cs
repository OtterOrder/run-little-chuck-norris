using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RunLittleChuckNorris.Helper
{
    public interface IWorldProvider
    {
        #region Properties

        List<GameObject.Obstacle> Obstacles { get; }
        List<GameObject.Plateforme> Plateformes { get; }

        #endregion
    }
}
