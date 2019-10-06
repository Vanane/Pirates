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

using Pirates.Factories;
using Pirates.Entities.Animations;
using Pirates.Custom;


namespace Pirates.Entities
{
	public partial class Boat
	{
        /// <summary>
        /// Initialization logic which is execute only one time for this Entity (unless the Entity is pooled).
        /// This method is called when the Entity is added to managers. Entities which are instantiated but not
        /// added to managers will not have this method called.
        /// </summary>

        public bool mAnchored { get { return Anchored; } }    

        public enum Sides { Left = -1, Right = 1};

        private void CustomInitialize()
		{
            this.Z = Custom.GameSettings.GroundLevelSpritesDepth;

            Anchored = false;
            AnchorSpriteInstance.RelativeX = this.BoatSpriteInstance.Width / 2;
            AnchorSpriteInstance.RelativeY = this.BoatSpriteInstance.Height / 2;
        }

        private void CustomActivity()
		{
            if (Anchored)
                Anchor();
        }
      

		private void CustomDestroy()
		{


		}

        private static void CustomLoadStaticContent(string contentManagerName)
        {


        }

        public void Anchor()
        {
            //Stops the boat and allows to prevent from moving
            Anchored = true;
            SpeedScale = 0;
            Velocity = new Microsoft.Xna.Framework.Vector3(0, 0, 0);
            RotationZVelocity = 0;
            AnchorSpriteInstance.Visible = true;
        }

        public void UnAnchor()
        {
            Anchored = false;
            AnchorSpriteInstance.Visible = false;
        }


        public void SwitchSide()
        {
            SideToShootFrom *= -1;
        }

        public void FireCannonball()
        {
            if(TimeBetweenShoot < FlatRedBall.Screens.ScreenManager.CurrentScreen.PauseAdjustedSecondsSince(LastTimeShot))
            {
                var ball = CannonballFactory.CreateNew(X, Y);
                ball.RotationZ = this.RotationZ;
                ball.SetTrajectory(this.X, this.Y, this.RotationMatrix.Left * SideToShootFrom);
                ball.Damage = 10;

                LastTimeShot = (float)FlatRedBall.Screens.ScreenManager.CurrentScreen.PauseAdjustedCurrentTime;

                FlatRedBall.Audio.AudioManager.Play(fire, GameSettings.GetSettings.VolumeLevel);
            }
        }


        public void TakeDamage(float Damage)
        {
            this.CurrentHealth -= Damage;
            if (CurrentHealth <= 0 && !IsDead)
                PerformDeath();
        }

        private void PerformDeath()
        {
            IsDead = true;

            int NumberOfExplosions = 6, i;

            float Delay = 0.1f, ExplosionLength = 0;
            float TimeBeforeDestroy = 0;
            

            for (i = 0; i < NumberOfExplosions; i++)
            {
                if (i == 0)
                    ExplosionLength = PlayExplosion().ExposedCurrentChain.TotalLength;
                else
                    this.Call(() => PlayExplosion()).After(i * Delay);
            }

            TimeBeforeDestroy = i * Delay;

            this.Call(Destroy).After(TimeBeforeDestroy);
        }

        private Explosion PlayExplosion()
        {
            float ExplosionDistanceX = this.BoatSpriteInstance.Width / 2;
            float ExplosionDistanceY = this.BoatSpriteInstance.Height / 2;
            float SpriteX, SpriteY;

            SpriteX = FlatRedBallServices.Random.Between(X - ExplosionDistanceX, X + ExplosionDistanceX);
            SpriteY = FlatRedBallServices.Random.Between(Y - ExplosionDistanceY, Y + ExplosionDistanceY);

            return ExplosionFactory.CreateNew(SpriteX, SpriteY);
        }


    }
}
