using PhysicsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PhysicsEngine2D {

    public class Scenes {

        private readonly Random rnd = new Random();

        private Entity[] allPossibleEntities = { new Entity(new Circle2D()) };

        public SceneData CirclesScene() {
            SceneData scene = new SceneData();
            Entity circleEntity = new(new Circle2D());
            circleEntity.Body.position = new Vector2(20, 20);
            circleEntity.Body.AddForce(new Vector2(3000, -1000));
            scene.AddEntity(circleEntity);

            return scene;
        }
    }
}
