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

namespace Pirates.Entities
{
	public partial class Skeleton
	{
        /// <summary>
        /// Initialization logic which is execute only one time for this Entity (unless the Entity is pooled).
        /// This method is called when the Entity is added to managers. Entities which are instantiated but not
        /// added to managers will not have this method called.
        /// </summary>
		private void CustomInitialize()
		{
            Hitbox.Width = SpriteInstance.Width;
            Hitbox.Height = SpriteInstance.Height;

            this.Z = Pirates.Custom.GameSettings.GroundLevelSpritesDepth;

        }

        private void CustomActivity()
		{


		}

		private void CustomDestroy()
		{


		}

        private static void CustomLoadStaticContent(string contentManagerName)
        {


        }

        public void ReceiveDamage(float damage)
        {
            this.Health -= damage;

            Console.WriteLine("Touché : " + Health);
            if (this.Health < 0)
            {
                Destroy();
            }
        }
	}
}
