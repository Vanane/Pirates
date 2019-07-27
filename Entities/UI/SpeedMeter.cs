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

namespace Pirates.Entities.UI
{
    public partial class SpeedMeter
    {
        /// <summary>
        /// Initialization logic which is execute only one time for this Entity (unless the Entity is pooled).
        /// This method is called when the Entity is added to managers. Entities which are instantiated but not
        /// added to managers will not have this method called.
        /// </summary>        

        public Sprite mSpriteInstance { get { return SpeedMeterSpriteInstance; } }

        Dictionary<int, int> CasesCoordinates;



		private void CustomInitialize()
		{
            StateSpriteInstance.Z = 35;
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

        public void SetCaseScale(int NumberOfCases, int Min, int Max, int DefaultCase)
        {
            CasesCoordinates = new Dictionary<int, int>();            
            for (int i = Min; i <= Max; i++)
            {
                CasesCoordinates.Add(i, SpeedMeterStateSprite.Height * (i - 1));
            }
            SetState(DefaultCase);
        }

        public void SetState(int NewState)
        {
            StateSpriteInstance.RelativePosition = new Vector3(StateSpriteInstance.RelativeX, CasesCoordinates[NewState], StateSpriteInstance.RelativeZ);
        }
	}
}
