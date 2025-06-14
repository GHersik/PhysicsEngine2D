﻿using PhysicsLibrary;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SimulationWindow {
    public class SceneData : IEnumerable<Entity> {

        public int SceneEntitiesAmount => sceneEntities.Count;

        HashSet<Entity> sceneEntities = new();

        public SceneData() {
            sceneEntities.Clear();
        }

        public SceneData(Collection<Entity> initialEntities) {
            sceneEntities.Clear();
            sceneEntities = initialEntities.ToHashSet();
        }

        public void NewSceneData(Collection<Entity> entities) {
            sceneEntities.Clear();
            sceneEntities = entities.ToHashSet();
        }

        public bool AddEntity(Entity entityToAdd) {
            if (sceneEntities.Contains(entityToAdd))
                return false;

            sceneEntities.Add(entityToAdd);
            return true;
        }

        public bool RemoveEntity(Entity entityToRemove) {
            if (sceneEntities.Contains(entityToRemove))
                return true;

            return true;
        }

        public bool Contains(Entity entity) => sceneEntities.Contains(entity);

        public void Clear() => sceneEntities.Clear();

        public Collection<IPhysicsEntity> RetrievePhysicsEntities() {
            Collection<IPhysicsEntity> bodies = new();
            foreach (var entity in sceneEntities)
                bodies.Add(entity);

            return bodies;
        }

        public IEnumerator<Entity> GetEnumerator() {
            foreach (var entity in sceneEntities)
                yield return entity;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
