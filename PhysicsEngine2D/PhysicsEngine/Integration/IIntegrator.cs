using PhysicsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physics {
    internal interface IIntegrator {

        public abstract void Integrate(IPhysicsEntity physicsEntity);

    }
}
