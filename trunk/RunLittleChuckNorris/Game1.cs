using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;
using RunLittleChuckNorris.Helper;
using RunLittleChuckNorris.GameObject;
using RunLittleChuckNorris.GameComponents;

namespace RunLittleChuckNorris
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game, Helper.IGameOver
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        LevelManager _levelManager;

        public const int _mBackBufferWidth = 1280;
        public const int _mBackBufferHeight = 720;

        private HUD      _mHUD;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = _mBackBufferWidth;
            graphics.PreferredBackBufferHeight = _mBackBufferHeight;
            Content.RootDirectory = "Content";

            _levelManager = new GameComponents.LevelManager(this);
            Components.Add(_levelManager);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // set the spritebatch to the sprite
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Sprite.SprBatch = spriteBatch;
            Text.SprBatch = spriteBatch;

            Services.AddService(typeof(IGameOver), this);

            base.Initialize();

            _mHUD = new HUD(this, LevelManager.GetCurrentCam());
            _mHUD.Position = new Vector2(-graphics.PreferredBackBufferWidth / 2.0f + 250.0f, -graphics.PreferredBackBufferHeight / 2.0f);
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            Sprite.SprBatch = null;
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
 

            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            LevelManager.GetCurrentCam().SetCamera(graphics);

            spriteBatch.Begin(SpriteBlendMode.AlphaBlend, SpriteSortMode.Immediate, SaveStateMode.None, LevelManager.GetCurrentCam().mTransform);

            base.Draw(gameTime);

            spriteBatch.End();
        }

        #region IGameOver
        public void GameOver()
        {
            
        }
        #endregion
    }
}
