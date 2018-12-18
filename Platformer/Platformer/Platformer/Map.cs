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
        List<Spike> m_ListSpikes;
        Goal m_Goal;
        WallPool m_WallPool;

        public Map()
        {
            m_ListWalls = new List<Wall>();
            m_ListSpikes = new List<Spike>();
            m_WallPool = new WallPool();
        }

        public Goal getGoal()
        {
            return m_Goal;
        }

        public List<Wall> GetWalls()
        {
            return m_ListWalls;
        }

        public List<Spike> GetSpikes()
        {
            return m_ListSpikes;
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
                            case "2":
                                m_ListSpikes.Add(new Spike(new Vector2(i * 32, lineCounter * 32)));
                                break;
                            case "3":
                                m_Goal = new Goal(new Vector2(i * 32, lineCounter * 32));
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
            foreach(Spike spik in m_ListSpikes)
            {
                spik.Draw(sb, camera);
            }
            m_Goal.Draw(sb, camera);
        }
        
    }
}
