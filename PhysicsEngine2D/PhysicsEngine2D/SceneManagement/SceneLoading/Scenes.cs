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

        public SceneData Ambient() {
            SceneData scene = new SceneData();
            for (int i = 1; i < 4; i++)
                for (int j = 1; j < 4; j++)
                    scene.AddEntity(InstantiateCircleEntity(new Vector2(i * 28, j * 28), 1, ColorSettings.YellowBrush));
            PhysicsSettings.SetNewGravity(PhysicsSettings.EarthGravity);
            return scene;
        }

        public SceneData BrownianMotion() {
            SceneData scene = new SceneData();
            for (int i = 1; i < 18; i++)
                for (int j = 1; j < 8; j++)
                    scene.AddEntity(InstantiateCircleEntity(new Vector2(i * 28, j * 28), 1, ColorSettings.YellowBrush));

            Circle2DEntity bigCircle = new Circle2DEntity(new Vector2(250, 400), 20, ColorSettings.BlueBrush);
            bigCircle.body.SetMass(20);
            scene.AddEntity(bigCircle);
            PhysicsSettings.SetNewGravity(Vector2.Zero);
            return scene;
        }

        private Entity InstantiateCircleEntity(Vector2 initPosition, double radius, SolidColorBrush color) {
            int massAndForceMultiplier = rnd.Next(4, 8);
            Entity circleEntity = new Circle2DEntity(initPosition, radius * massAndForceMultiplier, color);
            circleEntity.body.SetMass(massAndForceMultiplier);
            circleEntity.body.AddForce(new Vector2(rnd.Next(100, 1000), rnd.Next(100, 1000)));
            return circleEntity;
        }
    }
}
