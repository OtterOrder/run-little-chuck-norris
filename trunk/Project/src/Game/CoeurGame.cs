using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

namespace Coeur
{
    public class CoeurGame : Microsoft.Xna.Framework.Game
    {
        #region constant

        public static int NbMachines = 4; 

        public const int mBackBufferWidth = 1280;
        public const int mBackBufferHeight = 720;

        #endregion

        #region Private Members

        private GraphicsDeviceManager   _mGraphics;
        private SpriteBatch             _mSpriteBatch;
        private ContentManager          _mContent;
        
        //temp
        private Level _testLevel;

        #endregion

        #region Constructor

        public CoeurGame()
        {
            _mGraphics = new GraphicsDeviceManager(this);
            _mGraphics.PreferredBackBufferWidth = mBackBufferWidth;
            _mGraphics.PreferredBackBufferHeight = mBackBufferHeight;

            Content.RootDirectory = "Resources";
        }

        #endregion

        #region Game Override

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _mSpriteBatch = new SpriteBatch(GraphicsDevice);
            _mContent = new ContentManager(Services, "Resources");

            _testLevel = new LevelTest(this, _mContent);
            _testLevel.Init();

        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            float Dt = (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            _testLevel.Update(Dt);

            SceneManager.Singleton.Update(Dt);
        }

        protected override void Draw(GameTime gameTime)
        {
            _mSpriteBatch.GraphicsDevice.Clear(Color.DeepPink);

            _testLevel.Draw(_mSpriteBatch, _mGraphics);

            base.Draw(gameTime);
        }
        
        #endregion
    }
}

