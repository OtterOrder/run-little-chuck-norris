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


namespace RunLittleChuckNorris.GameObject
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class Bullet : Obstacle
    {
        private float _mFireSpeed;
        private Helper.IWorldProvider _mWorldProvider;

        public Bullet(Game game)
            : base(game)
        {
            Sprite = new Helper.Sprite("Graphics/Sprites/Bullet", Game.Content);
            Sprite.Loop = false;
            Sprite.Origin = new Vector2(Sprite.Width / 2, Sprite.Height);

            _mFireSpeed = -0.4f;

            _mWorldProvider = (Helper.IWorldProvider)game.Services.GetService(typeof(Helper.IWorldProvider));

        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here

            base.Initialize();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (_mWorldProvider.IsFreezed)
                return;

            X += _mFireSpeed * gameTime.ElapsedGameTime.Milliseconds;

        }
    }
}