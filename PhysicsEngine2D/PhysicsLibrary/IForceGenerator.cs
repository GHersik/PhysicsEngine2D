using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsLibrary {
    public interface IForceGenerator {

        public abstract void UpdateForce(Body body, double duration = 0);
    }
}
