using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteeringCS.entity
{

    abstract class MovingEntity : BaseGameEntity
    {
        public Vector2D Velocity { get; set; }
        public float Mass { get; set; }
        public float MaxSpeed { get; set; }

        public SteeringBehaviour SB { get; set; }

        public MovingEntity(Vector2D pos, World w) : base(pos, w)
        {
            Mass = 30;
            MaxSpeed = 150;
            Velocity = new Vector2D();
        }

        public override void Update(float timeElapsed)
        {
            // Calculate the combined force from each steering behavior in the vehicle's list.
            Vector2D steeringForce = SB.Calculate();

            Vector2D acceleration = steeringForce.divide(Mass);

            Velocity.Add(acceleration.Multiply(timeElapsed));

            Velocity.truncate(MaxSpeed);

            Pos.Add(Velocity.Multiply(timeElapsed)); // Is .Clone() necessary here?

            if(Velocity.LengthSquared() > 0.00000001)
            {
                //TODO: add heading and perhaps side.

            }

            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            return String.Format("{0}", Velocity);
        }
    }
}
