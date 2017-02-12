﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Media;

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
            
            hero = new Actor(new CharacterSprite(10, 1),new Point(1,1));
            NPC badguy = new NPC(new CharacterSprite(2, 0),new Point(10,8));
            Projectiles = new List<Projectile>();
            Explosions = new List<Explosion>();

            hero.FacingLeft = true;
            hero.Inventory.Add(ItemNames.Bazooka);
            hero.EquipItem(ItemNames.Bazooka);
            actors.Add(hero);

            //badguy.X = 10;
            //badguy.Y = 8;
            badguy.FacingLeft = false;
            badguy.Inventory.Add(ItemNames.Rifle );
            badguy.EquipItem(ItemNames.Rifle);
            badguy.Goal = hero.Position;
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
                if (map.DistanceBetweenPoints(n.Position.X, n.Position.Y, hero.Position.X, hero.Position.Y) > 3)
                {
                    List<Point> path = map.PathFind(new Point(n.Position.X, n.Position.Y), new Point(hero.Position.X, hero.Position.Y));

                    if (path.Count > 1)
                    {
                        Point p = path.First(t => t.X != n.Position.X || t.Y != n.Position.Y);

                        if (p.X < n.Position.X)
                        {
                            n.FacingLeft = true;
                        }
                        else
                        {
                            n.FacingLeft = false;
                        }

                        n.SetPosition(p.X, p.Y);                        
                    }
                    else
                    {
                        n.SetPosition(n.Position.X, n.Position.Y);
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

                if (npc.Any(x => x.Position.X == newX && x.Position.Y == newY))
                {
                    StatusMessage = "Blowup";
                    Projectiles.Remove(p);
                    Explosions.Add(new Explosion(new Dictionary<int, string> { { 0, "oryx_16bit_scifi_FX_lg_83.png" }, { 1, "oryx_16bit_scifi_FX_lg_84.png" } },
                        newX, newY));
                    SoundPlayer sound = new SoundPlayer(SpaceAdventure.Properties.Resources._317748__jalastram__sfx_explosion_03);
                    sound.Play();
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
                Image image = a.ActorImage;                

                int offset = (ScreenWidth - (MAP_WIDTH * CELL_WIDTH)) / 2;
                graphic.DrawImage(image, new Point(XUnit(a.Position.X) + offset, YUnit(a.Position.Y)));
            }

            foreach (NPC n in npc)
            {
                Image image = n.ActorImage;

                int offset = (ScreenWidth - (MAP_WIDTH * CELL_WIDTH)) / 2;
                graphic.DrawImage(image, new Point(XUnit(n.Position.X) + offset, YUnit(n.Position.Y)));
            }
        }

        private void DrawPlayer(int xDelta, int yDelta)
        {
            int newX = hero.Position.X + xDelta;
            int newY = hero.Position.Y + yDelta;

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
                    hero.Position = new Point(newX,newY);
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
            Projectiles.Add(new Projectile("oryx_16bit_scifi_FX_sm_151.png",hero.Position.X, hero.Position.Y, 1, 0));
            SoundPlayer sound = new SoundPlayer(SpaceAdventure.Properties.Resources._175267__jonccox__gun_plasma);
            sound.Play();
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
            if (map.Rows[hero.Position.Y].Columns[hero.Position.X].Inventory != ItemNames.Empty)
            {
                hero.Inventory.Add(map.Rows[hero.Position.Y].Columns[hero.Position.X].Inventory);
                map.Rows[hero.Position.Y].Columns[hero.Position.X].Inventory = ItemNames.Empty;
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
            int heroX = hero.Position.X;
            int heroY = hero.Position.Y;
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
