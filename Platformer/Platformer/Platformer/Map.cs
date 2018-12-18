using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer
{
    class Map
    {
        List<Wall> m_ListWalls;
        WallPool m_WallPool;

        public Map()
        {
            m_ListWalls = new List<Wall>();
            m_WallPool = new WallPool();
        }

        public List<Wall> GetWalls()
        {
            return m_ListWalls;
        }

        public void LoadMap()
        {
            using (StreamReader reader = new StreamReader("Content/Map/Map1.csv"))
            {
                int lineCounter = 0;

                while (!reader.EndOfStream)
                {
                    string[] elements = reader.ReadLine().Split(',');
                    for (int i = 0; i < elements.Length; i++)
                    {
                        switch (elements[i])
                        {
                            case "0":
                                Wall wall = m_WallPool.GetObject();
                                wall.SetPosition(new Vector2(i * 32, lineCounter * 32));

                                m_ListWalls.Add(wall);
                                break;
                        }
                    }
                    lineCounter++;
                }
            }
        }

        public void DrawMap(SpriteBatch sb, Camera camera)
        {
            foreach(Wall wall in m_ListWalls)
            {
                wall.Draw(sb, camera);
            }
        }
        
    }
}
