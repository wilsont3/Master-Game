﻿using System.Drawing;

namespace MasterGame.Entities
{
    public class BaseEntity
    {
        public EntityType Type { get; }
        public string Name { get; }
        public float HealthPoints { get; set; }
        public bool CanCollide { get; }
        public bool CanMove { get; }
        public bool CanTakeDamage { get; }
        public bool PlayerControlled { get; }
        public Point Position;

        public BaseEntity(EntityType type, string name, float healthPoints, 
                          bool canCollide, bool canMove, bool canTakeDamage, bool isPlayerControlled)
        {
            Type = type;
            Name = name;
            HealthPoints = healthPoints;
            CanCollide = canCollide;
            CanMove = canMove;
            CanTakeDamage = canTakeDamage;
            PlayerControlled = isPlayerControlled;
            Position.X = 0;
            Position.Y = 0;
        }

        public bool isAlive()
        {
            return HealthPoints > 0.0f;
        }
    }
}
