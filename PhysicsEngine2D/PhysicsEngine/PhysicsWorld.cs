using System.Collections;
using System.Collections.ObjectModel;
using PhysicsLibrary;

namespace Physics {
    public class PhysicsWorld : IEnumerable<IPhysicsEntity> {

        private HashSet<IPhysicsEntity> physicsEntities = new();

        public PhysicsWorld() {
            physicsEntities.Clear();
        }

        public PhysicsWorld(Collection<IPhysicsEntity> physicsObjects) {
            ReplaceRegistry(physicsObjects);
        }

        public void ReplaceRegistry(Collection<IPhysicsEntity> physicsObjects) {
            physicsEntities.Clear();
            physicsEntities = physicsObjects.ToHashSet();
        }

        public bool AddBody(IPhysicsEntity physicsEntity) {
            if (physicsEntities.Contains(physicsEntity))
                return false;

            physicsEntities.Add(physicsEntity);
            return true;
        }

        public bool RemoveBody(IPhysicsEntity physicsEntity) {
            if (!physicsEntities.Contains(physicsEntity))
                return false;

            physicsEntities.Remove(physicsEntity);
            return true;
        }

        public bool Contains(IPhysicsEntity physicsEntity) => physicsEntities.Contains(physicsEntity);

        public void Clear() => physicsEntities.Clear();

        public IEnumerator<IPhysicsEntity> GetEnumerator() {
            foreach (var physicsEntity in physicsEntities)
                yield return physicsEntity;
        }

        public IPhysicsEntity[] GetPhysicsEntityArray() { return physicsEntities.ToArray(); }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
