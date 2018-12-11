using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer
{
    class WallPool
    {
        List<Wall> Walls;

        public WallPool()
        {
            Walls = new List<Wall>();
        }

        public Wall GetObject()
        {
            foreach (Wall Wall in Walls)
            {
                if(Wall.Used == false)
                {
                    return Wall;
                }
            }

            return AddObject();
        }

        public void ReturnObject(ref Wall _wall)
        {
            _wall.Used = false;
        }

        private Wall AddObject()
        {
            Walls.Add(new Wall(new Vector2(0,0)));
            return Walls[Walls.Count - 1];
        }
    }
}
