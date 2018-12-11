using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer
{
    class Map
    {
        List<Wall> m_MapWalls;
        WallPool m_WallPool;

        public Map()
        {
            m_MapWalls = new List<Wall>();
            m_WallPool = new WallPool();
        }

        public LoadMap()
        {

        }

    }
}
