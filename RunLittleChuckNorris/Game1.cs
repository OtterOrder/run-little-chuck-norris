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
    public class Game1 : Microsoft.Xna.Framework.Game, Helper.IGameOver, Helper.IWorldProvider
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        LevelManager _levelManager;

        public const int _mBackBufferWidth = 1280;
        public const int _mBackBufferHeight = 720;

        private HUD      _mHUD;

        private List<GameObject.Plateforme> _mPlateformes;
        private List<GameObject.Obstacle> _mObstacles;

        private bool _mIsGamePaused;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = _mBackBufferWidth;
            graphics.PreferredBackBufferHeight = _mBackBufferHeight;
            Content.RootDirectory = "Content";

            _mPlateformes = new List<GameObject.Plateforme>();
            _mObstacles = new List<GameObject.Obstacle>();

            _levelManager = new GameComponents.LevelManager(this);
            Components.Add(_levelManager);

            _mIsGamePaused = true;
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
            Services.AddService(typeof(IWorldProvider), this);

            // HUD
            HUDStateParams[] ParamsArray = new HUDStateParams[HUD.NbStates];
            for (int i = 0; i < HUD.NbStates; i++)
            {
                ParamsArray[i] = new HUDStateParams();
            }

            TextParams TxtParams;

                // Game Start
            TxtParams = new TextParams();
            TxtParams.FontName = "Fonts/HUDFontGameOver";
            TxtParams.TextValue = "Press X to play";
            TxtParams.Color = Color.Red;
            TxtParams.Mode = Text.TextMode.Center;
            TxtParams.Position = new Vector2(0.0f, 20.0f);
            ParamsArray[(int)HUD.HUDState.GameStart].ParamsList.Add(TxtParams);

                // Score
            TxtParams = new TextParams();
            TxtParams.FontName = "Fonts/HUDFont";
            TxtParams.TextValue = "Score : /Score";
            TxtParams.Color = Color.Green;
            TxtParams.Mode = Text.TextMode.AlignedLeft;
            TxtParams.Position = new Vector2(-graphics.PreferredBackBufferWidth / 2.0f + 250.0f, -graphics.PreferredBackBufferHeight / 2.0f);
            ParamsArray[(int)HUD.HUDState.Playing].ParamsList.Add(TxtParams);

                // Game Over
            TxtParams = new TextParams();
            TxtParams.FontName = "Fonts/HUDFontGameOver";
            TxtParams.TextValue = "Game Over";
            TxtParams.Color = Color.Red;
            TxtParams.Mode = Text.TextMode.Center;
            TxtParams.Position = new Vector2(0.0f, 20.0f);
            ParamsArray[(int)HUD.HUDState.GameOver].ParamsList.Add(TxtParams);

            TxtParams = new TextParams();
            TxtParams.FontName = "Fonts/HUDFontGameOver";
            TxtParams.TextValue = "Score : /Score";
            TxtParams.Color = Color.Red;
            TxtParams.Mode = Text.TextMode.Center;
            TxtParams.Position = new Vector2(0.0f, 80.0f);
            ParamsArray[(int)HUD.HUDState.GameOver].ParamsList.Add(TxtParams);

            TxtParams = new TextParams();
            TxtParams.FontName = "Fonts/HUDFontGameOver";
            TxtParams.TextValue = "Your Highest Score : /HighScore";
            TxtParams.Color = Color.Red;
            TxtParams.Mode = Text.TextMode.Center;
            TxtParams.Position = new Vector2(0.0f, 100.0f);
            ParamsArray[(int)HUD.HUDState.GameOver].ParamsList.Add(TxtParams);

            TxtParams = new TextParams();
            TxtParams.FontName = "Fonts/HUDFontGameOver";
            TxtParams.TextValue = "Press X to replay";
            TxtParams.Color = Color.Red;
            TxtParams.Mode = Text.TextMode.Center;
            TxtParams.Position = new Vector2(0.0f, 300.0f);
            ParamsArray[(int)HUD.HUDState.GameOver].ParamsList.Add(TxtParams);

            _mHUD = new HUD(this, ParamsArray);

            base.Initialize();

            // need to be done only when the hud is initialized
            _mHUD.State = HUD.HUDState.GameStart;
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

            // when we are in pause (the game just started or after game over
            if (_mIsGamePaused && Keyboard.GetState().IsKeyDown(Keys.X))
            {
                _mIsGamePaused = false;
                _mHUD.State = HUD.HUDState.Playing;
            }


            base.Update(gameTime);

            // update the HUD score
            _mHUD.Score = _levelManager.Player.DistanceParcourue;
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
            _levelManager.CreateInitLevel();
            _mIsGamePaused = true;

            // compare the current score to the previous best one and keep the best...
            _levelManager.Player.BestDistance = Math.Max(_levelManager.Player.BestDistance, _levelManager.Player.DistanceParcourue);

            _mHUD.HighScore = _levelManager.Player.BestDistance;

            // display the HUD
            _mHUD.State = HUD.HUDState.GameOver;

        }

        #endregion

        #region IWorldProvider

        public List<GameObject.Obstacle> Obstacles
        {
            get { return _mObstacles; }
        }

        public List<GameObject.Plateforme> Plateformes
        {
            get { return _mPlateformes; }
        }

        public bool IsFreezed
        {
            get { return _mIsGamePaused; }
        }

        #endregion
    }
}
