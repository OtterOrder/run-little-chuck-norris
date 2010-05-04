using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;

namespace Coeur
{
    public abstract class Level
    {
        #region Protected Members

        protected ContentManager _mContent;
        protected CoeurGame _mGame;

        #endregion

        #region Constructor

        public Level(CoeurGame _Game, ContentManager _Content)
        {
            _mContent = _Content;
            _mGame = _Game;
        }

        #endregion

        #region Public abstract methods

        public abstract void Init();
        public abstract void Update(float _Dt);
        public abstract void Draw(SpriteBatch _SprBatch, GraphicsDeviceManager _GraphicsManager);

        #endregion
    }
}
