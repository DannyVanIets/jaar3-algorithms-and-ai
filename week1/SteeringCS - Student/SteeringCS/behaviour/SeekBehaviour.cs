using SteeringCS.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteeringCS.behaviour
{
    class SeekBehaviour : SteeringBehaviour
    {
        public SeekBehaviour(MovingEntity me) : base(me)
        {
            
        }

        public override Vector2D Calculate()
        {
            Vector2D desiredVelocity = ME.MyWorld.Target.Pos.Clone().Sub(ME.Pos); // (TargetPos - m_pVehicle->Pos())
            desiredVelocity.Normalize(); // Vec2DNormalize(TargetPos - Vehicle)
            desiredVelocity.Multiply(ME.MaxSpeed); //Vector2D desiredVelocity = Vec2DNormalize(TargetPos - Vehicle) * m_pVehicle->MaxSpeed();
            return desiredVelocity.Sub(ME.Velocity); // (DesiredVelocity - m_pVehicle->Velocity());
        }
    }
}
