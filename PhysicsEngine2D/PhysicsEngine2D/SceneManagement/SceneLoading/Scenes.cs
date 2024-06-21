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

        public SceneData GravityAndMass() {
            SceneData scene = new SceneData();
            for (int i = 1; i < 18; i++)
                for (int j = 1; j < 18; j++)
                    scene.AddEntity(InstantiateCircle(new Vector2(i * 28, j * 28), 1, ColorSettings.YellowBrush));

            scene.AddEntity(InstantiateCircle(new Vector2(250, 250), 3, ColorSettings.BlueBrush));
            return scene;
        }

        private Entity InstantiateCircle(Vector2 initPosition, double radius, SolidColorBrush color) {
            int massAndForceMultiplier = rnd.Next(4, 8);
            Entity circleEntity = new(new Circle2D(radius * massAndForceMultiplier, color), new CircleCollider(radius * massAndForceMultiplier), new PhysicsLibrary.Transform(initPosition));
            circleEntity.Body.SetMass(massAndForceMultiplier);
            circleEntity.Body.AddForce(new Vector2(rnd.Next(100, 1000), rnd.Next(100, 1000)));
            return circleEntity;
        }
    }
}
