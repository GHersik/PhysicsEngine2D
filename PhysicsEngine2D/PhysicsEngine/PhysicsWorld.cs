using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhysicsLibrary;

namespace Physics {
    internal class PhysicsWorld : IEnumerable<Body> {

        private HashSet<Body> bodies = new HashSet<Body>();

        public PhysicsWorld() {
            bodies.Clear();
        }

        public PhysicsWorld(Collection<Body> physicsObjects) {
            ReplaceRegistry(physicsObjects);
        }

        public void ReplaceRegistry(Collection<Body> physicsObjects) {
            bodies.Clear();
            bodies = physicsObjects.ToHashSet();
        }

        public bool AddBody(Body bodyToAdd) {
            if (bodies.Contains(bodyToAdd))
                return false;

            bodies.Add(bodyToAdd);
            return true;
        }

        public bool RemoveBody(Body bodyToRemove) {
            if (!bodies.Contains(bodyToRemove))
                return false;

            bodies.Remove(bodyToRemove);
            return true;
        }

        public bool Contains(Body body) => bodies.Contains(body);

        public void Clear() => bodies.Clear();

        public IEnumerator<Body> GetEnumerator() {
            foreach (var body in bodies)
                yield return body;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
