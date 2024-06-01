using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsLibrary {
    public interface PhysicsEntity {

        public Body Body { get; protected set; }

        public abstract void OnCollisionEnter2D();

        public abstract void OnCollisionExit2D();

        public abstract void OnCollisionStay2D();

        public abstract void OnTriggerEnter2D();

        public abstract void OnTriggerExit2D();

        public abstract void OnTriggerStay2D();

    }
}
