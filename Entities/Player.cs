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
	public partial class Player
	{
        /// <summary>
        /// Initialization logic which is execute only one time for this Entity (unless the Entity is pooled).
        /// This method is called when the Entity is added to managers. Entities which are instantiated but not
        /// added to managers will not have this method called.
        /// </summary>
		private void CustomInitialize()
		{
            SpriteInstance.CurrentChainName = "Idle";
            Hitbox.Width = SpriteInstance.Width;
            Hitbox.Height = SpriteInstance.Height;
        }

        private void CustomActivity()
		{
            if (Velocity != new Microsoft.Xna.Framework.Vector3(0, 0, 0))
                SpriteInstance.CurrentChainName = "Walking";
            else
                SpriteInstance.CurrentChainName = "Idle";
		}

		private void CustomDestroy()
		{


		}

        private static void CustomLoadStaticContent(string contentManagerName)
        {


        }
	}
}
