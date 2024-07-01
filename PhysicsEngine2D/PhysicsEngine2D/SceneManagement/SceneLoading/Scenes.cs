using PhysicsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using static SimulationWindow.SceneManagement.SceneLoader;

namespace PhysicsEngine2D {

    public class Scenes {

        private readonly Random rnd = new Random();

        public SceneData Ambient() {
            SceneData scene = new SceneData();
            for (int i = 1; i < 4; i++)
                for (int j = 1; j < 4; j++)
                    scene.AddEntity(InstantiateCircleEntity(new Vector2(i * 28, j * 28), 1, ColorSettings.YellowBrush));

            AddWalls(scene);
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


            AddWalls(scene);
            PhysicsSettings.SetNewGravity(Vector2.Zero);
            return scene;
        }

        private void AddWalls(SceneData sceneData) {
            Box2DEntity right = new(new Vector2(520, 250), 40, 580, ColorSettings.TransparentBrush);
            right.body.SetKinematic(true);
            Box2DEntity left = new(new Vector2(-20, 250), 40, 580, ColorSettings.TransparentBrush);
            left.body.SetKinematic(true);
            Box2DEntity top = new(new Vector2(250, -20), 580, 40, ColorSettings.TransparentBrush);
            top.body.SetKinematic(true);
            Box2DEntity bottom = new(new Vector2(250, 520), 580, 40, ColorSettings.TransparentBrush);
            bottom.body.SetKinematic(true);

            sceneData.AddEntity(right);
            sceneData.AddEntity(left);
            sceneData.AddEntity(top);
            sceneData.AddEntity(bottom);
        }

        private Entity InstantiateCircleEntity(Vector2 initPosition, double radius, SolidColorBrush color) {
            int massAndForceMultiplier = rnd.Next(4, 8);
            Entity circleEntity = new Circle2DEntity(initPosition, radius * massAndForceMultiplier, color);
            circleEntity.body.SetMass(massAndForceMultiplier);
            circleEntity.body.AddForce(new Vector2(rnd.Next(1000, 4000), rnd.Next(100, 1000)));
            return circleEntity;
        }

        public SceneData CircleVsBox() {
            SceneData scene = new SceneData();

            Circle2DEntity bigCircle = new Circle2DEntity(new Vector2(250, 100), 20, ColorSettings.YellowBrush);
            bigCircle.body.SetMass(20);
            //bigCircle.body.AddForce(new Vector2(0, 10000));
            scene.AddEntity(bigCircle);

            Box2DEntity boxEntity = new(new Vector2(250, 400),100,40, ColorSettings.GreenBrush);
            boxEntity.body.SetKinematic(true); 
            scene.AddEntity(boxEntity);


            PhysicsSettings.SetNewGravity(PhysicsSettings.EarthGravity);
            return scene;
        }
    }
}
