using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceAdventure
{
    class Projectile
    {
        public string ImageFile {get;set;}
        public Bitmap Image { get; set; }
        public Point Position { get; set; }
        public Size Velosity { get; set; }
                
        public int XVelosity { get; set; }
        public int YVelosity {get;set;}

        public Projectile(string imageFile, Point position, Size velosity)
        {
            ImageFile = imageFile;
            Position = position;
            Velosity = velosity;
        }

        public Projectile(Bitmap image, Point position, Size velosity)
        {
            Image = image;
            Position = position;
            Velosity = velosity;
        }
    }
}
