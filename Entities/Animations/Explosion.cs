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

namespace Pirates.Entities.Animations
{
	public partial class Explosion
	{
        /// <summary>
        /// Initialization logic which is execute only one time for this Entity (unless the Entity is pooled).
        /// This method is called when the Entity is added to managers. Entities which are instantiated but not
        /// added to managers will not have this method called.
        /// </summary>

        
        public AnimationChain ExposedCurrentChain { get { return SpriteInstance.CurrentChain; } }

		private void CustomInitialize()
		{
            this.RotationZ = FlatRedBallServices.Random.Next(-180,180);

            this.Call(this.Destroy).After(SpriteInstance.AnimationChains.Find(a => a.Name == "Explosion").TotalLength - TimeManager.SecondDifference);            
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
	}
}
