using System;
using System.Collections.Generic;
using System.Text;
using FlatRedBall;
using FlatRedBall.Input;
using FlatRedBall.Instructions;
using FlatRedBall.AI.Pathfinding;
using FlatRedBall.Graphics.Animation;
using FlatRedBall.Graphics.Particle;
using FlatRedBall.Math.Geometry;
using Microsoft.Xna.Framework;

namespace Pirates.Entities
{
	public partial class Cannonball
	{
        /// <summary>
        /// Initialization logic which is execute only one time for this Entity (unless the Entity is pooled).
        /// This method is called when the Entity is added to managers. Entities which are instantiated but not
        /// added to managers will not have this method called.
        /// </summary>

        Vector3 OriginalPosition;


		private void CustomInitialize()
		{
            OriginalPosition = Position;
            SpriteInstance.Z = this.Z;
		}

		private void CustomActivity()
		{
            if (Vector3.Distance(OriginalPosition, Position) >= this.Range)
                this.Destroy();

		}

		private void CustomDestroy()
		{


		}

        private static void CustomLoadStaticContent(string contentManagerName)
        {


        }

        public void SetTrajectory(float StartingX, float StartingY, Vector3 Direction)
        {
            this.X = StartingX;
            this.Y = StartingY;
            OriginalPosition = this.Position;
            this.Velocity = Direction * FlyingSpeed;
        }
	}
}
