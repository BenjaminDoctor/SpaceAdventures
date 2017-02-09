using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SpaceAdventure
{
    public class GameEngine
    {
        public const int MAP_WIDTH = 20;
        public const int MAP_HEIGHT = 12;
        public const int CELL_WIDTH = 24;
        public const int CELL_HEIGHT = 24;
        public string StatusMessage;
        static string ImageDirectory = @"..\..\Images\";

        public int ScreenWidth { get; set; }
        public object PlayerAction { get; set; }

        Stopwatch timer = new Stopwatch();
        DateTime startTime;
        long interval = 1000;

        TileMap map;
        Actor hero;
        List<Actor> actors = new List<Actor>();
        List<NPC> npc = new List<NPC>();
        List<Projectile> Projectiles;
        IList<Explosion> Explosions;

#region Obsolete
        //static Dictionary<TileNames, Tile> Tiles;
        //Tuple<Image, int, int, int, int> Projectile;
        #endregion

        public GameEngine()
        {
            Init();
            CreateMap();
        }

        public void Init()
        {
            StatusMessage = "Nothing to say";
            
            hero = new Actor(new Dictionary<int, string> { {0, "Hero_Bazooka_1.gif" }, { 1, "Hero_Bazooka_2.gif" } });
            NPC badguy = new NPC(new Dictionary<int, string> { { 0, "oryx_16bit_scifi_creatures_67.gif" }, { 1, "oryx_16bit_scifi_creatures_68.gif" } });
            Projectiles = new List<Projectile>();
            Explosions = new List<Explosion>();

            hero.X = 1;
            hero.Y = 1;
            hero.FacingLeft = true;
            hero.Inventory.Add(ItemNames.Bazooka);
            hero.EquipItem(ItemNames.Bazooka);
            actors.Add(hero);

            badguy.X = 10;
            badguy.Y = 8;
            badguy.FacingLeft = false;
            badguy.Inventory.Add(ItemNames.Rifle );
            badguy.EquipItem(ItemNames.Rifle);
            badguy.Goal = new Point(hero.X, hero.Y);
            npc.Add(badguy);
            
        }

        private void CreateMap()
        {
            map = new TileMap(MAP_WIDTH,MAP_HEIGHT );
#region Obsolete
            //map = new int[MAP_HEIGHT][] {
            //new int[MAP_WIDTH]{ 3, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 4},
            //new int[MAP_WIDTH]{ 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2},
            //new int[MAP_WIDTH]{ 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2},
            //new int[MAP_WIDTH]{ 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2},
            //new int[MAP_WIDTH]{ 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2},
            //new int[MAP_WIDTH]{ 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2},
            //new int[MAP_WIDTH]{ 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2},
            //new int[MAP_WIDTH]{ 5, 1, 1, 1, 1, 1, 1, 1, 1, 8, 1, 1, 1, 1, 1, 1, 1, 1, 1, 6},
            //new int[MAP_WIDTH]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            //new int[MAP_WIDTH]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            //new int[MAP_WIDTH]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            //new int[MAP_WIDTH]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}}; 
            #endregion
        }

        public void GameLoop(ref Graphics graphic)
        {
            timer.Start();

            while (timer.ElapsedMilliseconds < interval / 30)
            {
                if (CheckInputs())
                {

                    Update();
                }

                Render(graphic);
            }

            timer.Restart();
            
        }

        private bool CheckInputs()
        {
            bool value = false;

            if (PlayerAction != null)
            {
                MoveActor(PlayerAction);
                PlayerAction = null;
                value = true;
            }

            return value;
        }
        
        private void Update()
        {
            foreach (NPC n in npc)
            {
                if (map.DistanceBetweenPoints(n.X, n.Y, hero.X, hero.Y) > 3)
                {
                    List<Point> path = map.PathFind(new Point(n.X, n.Y), new Point(hero.X, hero.Y));

                    if (path.Count > 1)
                    {
                        Point p = path.First(t => t.X != n.X || t.Y != n.Y);
                        if (p.X < n.X) n.FacingLeft = true;
                        if (p.X > n.X) n.FacingLeft = false;
                        n.SetPosition(p.X, p.Y);                        
                    }
                    else
                    {
                        n.SetPosition(n.X, n.Y);
                    }
                }
            }
        }

        private void Render(Graphics graphic)
        {
            DrawMap(ref graphic);
            DrawCharacters(ref graphic);
            if (Projectiles.Count() > 0)
            {
                DrawProjectiles(ref graphic);
            }

            if (Explosions.Count > 0)
            {
                DrawExplosion(ref graphic);
            }
        }

        private void DrawProjectiles(ref Graphics graphic)
        {
            int counter = Projectiles.Count();
            int i = 0;
            while (i < Projectiles.Count())
            {
                Projectile p = Projectiles[i];
                int newX = p.XPosition  + p.XVelosity;
                int newY = p.YPosition + p.YVelosity;

                if (npc.Any(x => x.X == newX && x.Y == newY))
                {
                    StatusMessage = "Blowup";
                    Projectiles.Remove(p);
                    Explosions.Add(new Explosion(new Dictionary<int, string> { { 0, "oryx_16bit_scifi_FX_lg_83.png" }, { 1, "oryx_16bit_scifi_FX_lg_84.png" } },
                        newX, newY));
                }
                else if (newX > 0 && newX < MAP_WIDTH - 1 && newY > 0 && newY < MAP_HEIGHT - 1
                    && map.Rows[newY].Columns[newX].IsPassable)
                {
                    p.XPosition = newX;
                    p.YPosition = newY;
                    DrawGraphic(ref graphic, p.ImageFile, p.YPosition, p.XPosition);
                }
                else
                {
                    Projectiles.Remove(p);
                }
                i++;
            }             
        }

        private void DrawExplosion(ref Graphics graphic)
        {
            IList<Explosion> removals = new List<Explosion>();

            foreach (var e in Explosions)
            {
                Image image = Image.FromFile(string.Concat(ImageDirectory, e.ExplosionImage));
                int offset = (ScreenWidth - (MAP_WIDTH * CELL_WIDTH)) / 2;
                graphic.DrawImage(image, new Point(XUnit(e.XPosition) + offset, YUnit(e.YPosition)));

                if (e.Counter == 0) removals.Add(e);
            }

            foreach (var r in removals)
            {
                Explosions.Remove(r);
            }
        }

        private void DrawMap(ref Graphics graphic)
        {
            for (int r = 0; r < MAP_HEIGHT && r < map.Rows.Count(); r++)
            {
                for (int c = 0; c < MAP_WIDTH && c < map.Rows[r].Columns.Count(); c++)
                {
                    MapCell mc = map.Rows[r].Columns[c];

                    foreach (TileNames tile in mc.Tiles.Values )
                    {
                        Tile t = TileList.Tiles[tile];
                        DrawGraphic(ref graphic, t.TileImage, r, c);
                        #region Obsolete
                        //string fileName = string.Concat(ImageDirectory, t.TileImage);
                        //Image image = Image.FromFile(fileName);

                        //int offset = (ScreenWidth - (MAP_WIDTH * CELL_WIDTH)) / 2;
                        //Point ulCorner = new Point(c * CELL_WIDTH + offset, r * CELL_HEIGHT);

                        //int xPosition = c * CELL_WIDTH;
                        //int yPosition = r * CELL_HEIGHT;

                        //graphic.DrawImage(image, ulCorner);
                        #endregion
                    }

                    if (mc.Inventory != ItemNames.Empty  )
                    {
                        Item item = ItemList.Items[mc.Inventory];
                        DrawGraphic(ref graphic, ItemList.Items[mc.Inventory].ItemImage,r, c);
                    }
                }
            }
        }

        private void DrawCharacters(ref Graphics graphic)
        {
            foreach (Actor a in actors)
            {
                Image image = Image.FromFile(string.Concat(ImageDirectory, a.ActorImage));
                if (!a.FacingLeft)
                {
                    image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                }

                int offset = (ScreenWidth - (MAP_WIDTH * CELL_WIDTH)) / 2;
                graphic.DrawImage(image, new Point(XUnit(a.X) + offset, YUnit(a.Y)));
            }

            foreach (NPC n in npc)
            {
                Image image = Image.FromFile(string.Concat(ImageDirectory, n.ActorImage));
                if (!n.FacingLeft)
                {
                    image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                }

                int offset = (ScreenWidth - (MAP_WIDTH * CELL_WIDTH)) / 2;
                graphic.DrawImage(image, new Point(XUnit(n.X) + offset, YUnit(n.Y)));
            }
        }

        private void DrawPlayer(int xDelta, int yDelta)
        {
            int newX = hero.X + xDelta;
            int newY = hero.Y + yDelta;

            if (map.ValidPoint(newX,newY))
            {
#region Obsolete
                //bool passable = true;

                //foreach (TileNames t in map.Rows[newY].Columns[newX].Tiles)
                //{
                //    if (!TileList.Tiles[t].IsPassable)
                //    {
                //        passable = false;
                //        break;
                //    }
                //}
                #endregion
                if ( map.Rows[newY].Columns[newX].IsPassable)
                {
                    hero.X = newX;
                    hero.Y = newY;
                }
            }
        }

        private void DrawGraphic(ref Graphics graphic, string imageFile, int y, int x)
        {
            int offset = (ScreenWidth - (MAP_WIDTH * CELL_WIDTH)) / 2;
            Point ulCorner = new Point(x * CELL_WIDTH + offset, y * CELL_HEIGHT);
            if (imageFile != null)
            {
                graphic.DrawImage(Image.FromFile(string.Concat(ImageDirectory, imageFile)), ulCorner);
            }
        }

        public void ActorFire()
        {
            Projectiles.Add(new Projectile("oryx_16bit_scifi_FX_sm_151.png",hero.X, hero.Y, 1, 0));
        }

        public void MoveActor(object direction)
        {
            switch (direction.ToString())
            {
                case "UpArrow":
                    {
                        DrawPlayer(0, -1);
                        break;
                    }
                case "DownArrow":
                    {
                        DrawPlayer(0, 1);
                        break;
                    }
                case "LeftArrow":
                    {
                        hero.FacingLeft = true;
                        DrawPlayer(-1, 0);
                        break;
                    }
                case "RightArrow":
                    {
                        hero.FacingLeft = false;
                        DrawPlayer(1, 0);
                        break;
                    }
                case "O":
                    {
                        OpenDoor();
                        break;
                    }
                case "C":
                    {
                        CloseDoor();
                        break;
                    }
                case "P":
                    {
                        PickupItem();
                        break;
                    }
                case "Escape":
                    {
                        Environment.Exit(0);
                        break;
                    }
                case "F":
                    {
                        ActorFire();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        private void PickupItem()
        {
            if (map.Rows[hero.Y].Columns[hero.X].Inventory != ItemNames.Empty)
            {
                hero.Inventory.Add(map.Rows[hero.Y].Columns[hero.X].Inventory);
                map.Rows[hero.Y].Columns[hero.X].Inventory = ItemNames.Empty;
            }
        }

        private void CloseDoor()
        {
            List<Point> pointsWithOpenDoors = CheckForDoors(TileNames.OpenDoor);
            //if only one door open it
            if (pointsWithOpenDoors.Count == 1)
            {
                //Close door
                //int index = map.Rows[pointsWithOpenDoors.First().Y].Columns[pointsWithOpenDoors.First().X].Tiles["Item"].IndexOf("Item",TileNames.OpenDoor);
                map.Rows[pointsWithOpenDoors.First().Y].Columns[pointsWithOpenDoors.First().X].Tiles["Item"] = TileNames.ClosedDoor;
            }
            else if (pointsWithOpenDoors.Count > 1)
            {
                //Ask which door to close
                StatusMessage = "Which door?";
            }
            else
            {
                StatusMessage = "No door to open?";
            }
        }

        private void OpenDoor()
        {
            List<Point> pointsWithClosedDoors = CheckForDoors(TileNames.ClosedDoor);
            //if only one door open it
            if (pointsWithClosedDoors.Count == 1)
            {
                //Open door
                //int index = map.Rows[pointsWithClosedDoors.First().Y].Columns[pointsWithClosedDoors.First().X].Tiles.IndexOf(TileNames.ClosedDoor);
                map.Rows[pointsWithClosedDoors.First().Y].Columns[pointsWithClosedDoors.First().X].Tiles["Item"] = TileNames.OpenDoor;
            }
            else if (pointsWithClosedDoors.Count > 1)
            {
                //Ask which door to close
                StatusMessage = "Which door?";
            }
            else
            {
                StatusMessage = "No door to open?";
            }
        }
        private List<Point> CheckForDoors(TileNames tileToLookFor)
        {
            List<Point> pointsWithDoors = new List<Point>();
            //get current position
            int heroX = hero.X;
            int heroY = hero.Y;
            //check for doors

            Point[] pointsToCheck = new Point[]{
            new Point(0,1),
            new Point(1,0),
            new Point(0,-1),
            new Point(-1,0)
            };

            foreach (Point p in pointsToCheck)
            {
                if (map.Rows[heroY + p.Y].Columns[heroX + p.X].Tiles.Values.Contains(tileToLookFor))
                {
                    pointsWithDoors.Add(new Point(heroX + p.X, heroY + p.Y));
                }
            }
            return pointsWithDoors;
        }

        public Object[] GetInventory()
        {
            Object[] value = new Object[]{};

            value = hero.Inventory.Cast<object>().ToArray();
            
            return value;
        }

        private int XUnit(int x)
        {
            return x * CELL_WIDTH;
        }

        private int YUnit(int y)
        {
            return y * CELL_HEIGHT;
        }
    }
}
