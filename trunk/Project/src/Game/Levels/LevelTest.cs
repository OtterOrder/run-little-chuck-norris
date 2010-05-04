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
    class LevelTest : Level
    {
        #region Private Members

        private Background _mBg;

        private UInt32     _mSceneTest;
        private Camera     _mDefaultCam;

        #endregion

        #region Constructor

        public LevelTest(CoeurGame _Game, ContentManager _Content) : base(_Game, _Content)
        {
            _mSceneTest = SceneManager.Singleton.CreateScene();
            _mGame = _Game;
        }

        #endregion

        #region Level override

        #region Public Methods

        public override void Init()
        {
            _mDefaultCam = SceneManager.Singleton.GetNewCamera(_mSceneTest);
            _mDefaultCam.SetViewportParam(0, 0, 1.0f, 1.0f);
            _mDefaultCam.Position = new Vector2(0.0f, 0.0f);

            _mBg = SceneManager.Singleton.GetNewBackground("Graphics/Backgrounds/Test_bg", _mContent, _mSceneTest);
            _mBg.Depth = 0.9f;
            _mBg.Speed = new Vector2(1.0f, 0.5f);
            _mBg.Speed.X = 1.0f;

        }

        public override void Update(float _Dt)
        {

        }

        public override void Draw(SpriteBatch _SprBatch, GraphicsDeviceManager _GraphicsManager)
        {
            SceneManager.Singleton.DrawScene(_SprBatch, _GraphicsManager, _mSceneTest);
        }

        #endregion

        #endregion
    }
}
