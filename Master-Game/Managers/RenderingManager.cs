﻿using System;
using System.Drawing;
using MasterGame.World;
using MasterGame.Entities;

namespace MasterGame.Manager
{
    public class RenderingManager
    {
        readonly EntityManager MasterEntityManager;
        readonly WorldManager MasterWorldManager;

        public RenderingManager(ref EntityManager entityManager, ref WorldManager worldManager)
        {
            MasterEntityManager = entityManager;
            MasterWorldManager = worldManager;
        }

        public void ProcessGraphics()
        {
            ClearFrame();
            PlayerEntity player = MasterEntityManager.GetPlayer() as PlayerEntity;
            if (player != null)
            {
                RenderMap(ref player);
                RenderHud(ref player);
            }
        }

        protected void ClearFrame()
        {
            Console.Clear();
        }

        protected void RenderMap(ref PlayerEntity player)
        {
            //Todo: need a better way to do this later
            Point currentPosition = new Point(0, 0);
            Point playerPosition = new Point(player.Position.X, player.Position.Y);

            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    currentPosition.X = x;
                    currentPosition.Y = y;
                    if(currentPosition == playerPosition)
                    {
                        Console.Write(" X ");
                        continue;
                    }
                    BaseTile tile = MasterWorldManager.TileAt(currentPosition);
                    if(tile != null)
                    {
                        if(tile.Type == TileType.Grass)
                        {
                            Console.Write(" ^ ");
                        }
                        else if (tile.Type == TileType.Lava)
                        {
                            Console.Write(" ~ ");
                        }
                    }
                }
                Console.WriteLine("");
            }
            Console.WriteLine("");
        }

        protected void RenderHud(ref PlayerEntity player)
        {
            if (player.isAlive())
            {
                Console.WriteLine("HP: " + player.HealthPoints);
                Console.WriteLine("Where to next?");
            }
            else
            {
                Console.WriteLine("You died!");
                Console.Write("Type X to exit, Y to restart.");
            }
        }
    }
}
