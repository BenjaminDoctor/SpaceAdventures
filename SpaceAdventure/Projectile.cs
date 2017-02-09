using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceAdventure
{
    class Projectile
    {
        public string ImageFile {get;set;}
        public int XPosition { get; set; }
        public int YPosition {get;set;}
        public int XVelosity { get; set; }
        public int YVelosity {get;set;}

        public Projectile(string imageFile, int xPosition, int yPosition, int xVelosity, int yVelosity)
        {
            ImageFile = imageFile;
            XPosition = xPosition;
            YPosition = yPosition;
            XVelosity = xVelosity;
            YVelosity = yVelosity;
        }
    }
}
