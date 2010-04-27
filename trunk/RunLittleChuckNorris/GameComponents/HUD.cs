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


namespace RunLittleChuckNorris.GameComponents
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class HUD : Microsoft.Xna.Framework.DrawableGameComponent
    {
        public Vector2 Position = new Vector2(0.0f, 0.0f);
        private Camera _mCamera = null;
        private float _mScore = 0.0f;
        private Text _mText = null;

        public HUD(Game game, Camera _Camera)
            : base(game)
        {
            _mCamera = _Camera;
            _mText = new Text("Fonts/HUDFont", game.Content);

            game.Components.Add(this);
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            _mScore = 0.0f;
            base.Initialize();
        }

        public float Score
        {
            get { return _mScore; }
            set { _mScore = Math.Max(value, 0.0f); }
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            _mText.Position = _mCamera.Position + Position;
            _mText.TextString = "Score = " + _mScore.ToString();
            _mText.Update();
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            _mText.Draw(); 
        }
    }
}