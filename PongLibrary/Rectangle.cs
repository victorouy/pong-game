using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongLibrary
{
    public struct Rectangle
    {
        public int width { get; set; }
        public int height { get; set; }
        public int y { get; set; }
        public int x { get; set; }

        public Rectangle(int width, int height, int y, int x)
        {
            this.width = width;
            this.height = height;
            this.y = y;
            this.x = x;
        }
    }
}
