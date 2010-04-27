using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using RunLittleChuckNorris.GameObject;


namespace RunLittleChuckNorris.Helper
{
    class CollisionManager
    {
        private List<Obstacle> _mObstacleList = new List<Obstacle>();
        private List<Obstacle> _mPlatformList = new List<Obstacle>();

        private IWorldProvider _wordlProvider;

        public CollisionManager(Game game)
        {
            _wordlProvider = (IWorldProvider)game.Services.GetService(typeof(IWorldProvider));

            _mObstacleList = _wordlProvider.Obstacles;
            _mPlatformList = _wordlProvider.Obstacles;
        }

        public void UpdateListObstacle()
        {
            _mObstacleList = _wordlProvider.Obstacles;
            _mPlatformList = _wordlProvider.Obstacles;
        }

        GameObject.GameObject Collide(GameObject.GameObject obj)
        {
            // Rectangle du l'objet dont on veut savoir la collision
            Rectangle personRectangle = new Rectangle((int)obj.X, (int)obj.Y, obj.Sprite.Width, obj.Sprite.Width);

            foreach (Obstacle obs in _mPlatformList)
            {
                Rectangle blockRectangle = new Rectangle((int)obs.X, (int)obs.Y, obs.Sprite.Width, obs.Sprite.Height);

                 // Verifie la collision
                if (personRectangle.Intersects(blockRectangle))
                {
                    GameObject.GameObject collisionObj = (GameObject.GameObject)obs;
                    return collisionObj;
                }
            }

            return null;
        }
    }
}



