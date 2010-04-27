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

    public class TextParams
    {
        public string FontName = "";
        public string TextValue = "";
        public Color Color = Color.White;
        public Text.TextMode Mode = Text.TextMode.AlignedLeft;
        public Vector2 Position = new Vector2();
    }

    public class HUDStateParams
    {
        public List<TextParams> ParamsList = new List<TextParams> ();
    }

    public class HUDStateVars
    {
        public List<string> TextValues = new List<string>();
        public List<Vector2> Positions = new List<Vector2>();
        public List<Text> Texts = new List<Text> ();

        public HUDStateVars(HUDStateParams _Params, ContentManager _ContentManager)
        {
            foreach (TextParams Params in _Params.ParamsList)
            {
                TextValues.Add(Params.TextValue);
                Positions.Add(Params.Position);

                Text lText = new Text(Params.FontName, _ContentManager);
                lText.TextValue = Params.TextValue;
                lText.Color = Params.Color;
                lText.Mode = Params.Mode;
                Texts.Add(lText);
            }
        }
    }

    public class HUD : Microsoft.Xna.Framework.DrawableGameComponent
    {
        public static int NbStates = 3;
        public enum HUDState
        {
            Playing = 0,
            GameOver = 1,
            GameStart = 2
        }

        private HUDStateVars[] _mHUDStateVars = new HUDStateVars [NbStates];
        private HUDStateVars _mCurrentHUDState = null;

        private Camera _mCamera = null;
        private float _mScore = 0.0f;
        private float _mHighScore = 0.0f;

        private HUDState _mState = HUDState.Playing;

        public HUD(Game game, HUDStateParams[] _ParamsArray)
            : base(game)
        {
            for (int i = 0; i < NbStates; i++)
                _mHUDStateVars[i] = new HUDStateVars(_ParamsArray[i], game.Content);

            game.Components.Add(this);
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            _mCamera = LevelManager.GetCurrentCam();

            _mScore = 0.0f;
            _mState = HUDState.GameOver;
            ChangeState(HUDState.Playing);
            base.Initialize();
        }

        public float Score
        {
            get { return _mScore; }
            set { _mScore = Math.Max(value, 0.0f); }
        }

        public float HighScore
        {
            get { return _mHighScore; }
            set { _mHighScore = Math.Max(value, _mHighScore); }
        }

        public HUDState State
        {
            get { return _mState; }
            set { ChangeState(value); }
        }

        private void ChangeState(HUDState _State)
        {
            if (_State == _mState)
                return;

            _mState = _State;
            _mCurrentHUDState = _mHUDStateVars[(int)_mState];
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            for (int i = 0; i < _mCurrentHUDState.Texts.Count; i++)
            {
                _mCurrentHUDState.Texts[i].Position = _mCamera.Position + _mHUDStateVars[(int)_mState].Positions[i];
                _mCurrentHUDState.Texts[i].TextValue = _mHUDStateVars[(int)_mState].TextValues[i].Replace("/Score", _mScore.ToString());
                _mCurrentHUDState.Texts[i].TextValue = _mCurrentHUDState.Texts[i].TextValue.Replace("/HighScore", _mHighScore.ToString());
                _mCurrentHUDState.Texts[i].Update();
            }
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            for (int i = 0; i < _mHUDStateVars[(int)_mState].Texts.Count; i++)
            {
                _mCurrentHUDState.Texts[i].Draw();
            }
        }
    }
}