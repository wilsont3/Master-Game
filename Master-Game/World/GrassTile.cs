﻿using System;

namespace MasterGame.World
{
    public class GrassTile : BaseTile
    {
        public GrassTile(int length, int height) 
            : base(TileType.Grass, true, length, height)
        {
        }
    }
}
