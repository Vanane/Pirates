using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using FlatRedBall;
using FlatRedBall.Input;
using FlatRedBall.Instructions;
using FlatRedBall.AI.Pathfinding;
using FlatRedBall.Graphics.Animation;
using FlatRedBall.Graphics.Particle;
using FlatRedBall.Math.Geometry;
using FlatRedBall.Localization;



namespace Pirates.Screens
{
	public partial class IslandScreen
	{

		void CustomInitialize()
		{
            float bgRatio = SpriteInstance.Height / SpriteInstance.Width;
            SpriteInstance.Width = FlatRedBallServices.ClientWidth;
            SpriteInstance.Height = FlatRedBallServices.ClientWidth * bgRatio;
            SpriteInstance.X = Camera.Main.X;
            SpriteInstance.Y = Camera.Main.Y;            
        }

        void CustomActivity(bool firstTimeCalled)
		{


		}

		void CustomDestroy()
		{


		}

        static void CustomLoadStaticContent(string contentManagerName)
        {


        }

	}
}
