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
using Microsoft.Xna.Framework.Graphics;

namespace Pirates.Entities
{
	public partial class WeaponEntity
	{
        /// <summary>
        /// Initialization logic which is execute only one time for this Entity (unless the Entity is pooled).
        /// This method is called when the Entity is added to managers. Entities which are instantiated but not
        /// added to managers will not have this method called.
        /// </summary>
		private void CustomInitialize()
		{
            this.Z = Custom.GameSettings.GroundLevelSpritesDepth;

            RefreshLineHitboxSize();
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

        public void SetTexture(Texture2D t)
        {
            SpriteInstance.Texture = t;
            RefreshLineHitboxSize();
        }

        public void RefreshLineHitboxSize()
        {
            MeleeHitbox.RelativePoint1 = new Point3D(0, 0, 0);
            MeleeHitbox.RelativePoint2 = new Point3D(new Vector3(SpriteInstance.Width, 0, 0));
            MeleeHitbox.Color = Color.Red;
        }

    }
}
