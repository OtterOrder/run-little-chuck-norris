using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace RunLittleChuckNorris.Helper
{
    public class Text
    {
        public static SpriteBatch SprBatch = null;

        public enum TextMode
        {
            AlignedLeft,
            Center,
            AlignedRight
        }

        public Vector2 Position = new Vector2();
        public Vector2 Scale = new Vector2(1.0f, 1.0f);
        public string TextString = "";
        public Color Color = Color.White;

        private SpriteFont _mFont = null;

        private Vector2 _mOrigin = new Vector2();
        public TextMode mMode = TextMode.AlignedLeft;

        //------------------------------------------------------------------
        public Text(string _FileName, ContentManager _ContentManager)
        {
            _mFont = _ContentManager.Load<SpriteFont>(_FileName);
        }

        //------------------------------------------------------------------
        public int Length
        {
            get { return TextString.Length; }
        }

        //------------------------------------------------------------------
        public void Update()
        {
            switch (mMode)
            {
                case TextMode.AlignedLeft:
                    _mOrigin = new Vector2(0.0f, 0.0f);
                    break;

                case TextMode.AlignedRight:
                    _mOrigin.X = _mFont.MeasureString(TextString).X;
                    break;

                case TextMode.Center:
                    _mOrigin.X = _mFont.MeasureString(TextString).X / 2.0f;
                    break;
            }
        }

        //------------------------------------------------------------------
        public void Draw()
        {
            SprBatch.DrawString(_mFont, TextString, Position, Color, 0, _mOrigin, Scale, SpriteEffects.None, 0.5f);
        }
    }
}