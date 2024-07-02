using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using PhysicsLibrary;

namespace PhysicsEngine2D {

    public class Scenes {

        readonly Random rnd = new Random();

        public SceneData Ambient() {
            SceneData scene = new SceneData();
            for (int i = 1; i < 10; i++)
                for (int j = 1; j < 10; j++) {
                    //SolidColorBrush randomColor = new SolidColorBrush(Color.FromRgb((byte)rnd.Next(80, 255), (byte)rnd.Next(80, 255), (byte)rnd.Next(80, 255)));
                    Vector2 position = new Vector2(i * 50 + rnd.Next(-18, 18), j * 50 + rnd.Next(-18, 18));
                    int massAndForceMultiplier = rnd.Next(4, 8);
                    Circle2DEntity circle = new Circle2DEntity(position, massAndForceMultiplier, ColorSettings.WhiteBrush);
                    circle.body.Mass = massAndForceMultiplier;
                    circle.body.AddForce(new Vector2(rnd.Next(-4000, 4000), rnd.Next(-1000, 1000)));
                    circle.body.Damping = 1;
                    scene.AddEntity(circle);
                }

            AddWalls(scene);
            PhysicsSettings.SetNewGravity(PhysicsSettings.NoGravity);
            return scene;
        }

        public SceneData BrownianMotion() {
            SceneData scene = new SceneData();
            for (int i = 1; i < 18; i++)
                for (int j = 1; j < 8; j++) {
                    Vector2 position = new Vector2(i * 28, j * 28);
                    Circle2DEntity circle = new Circle2DEntity(position, 4, ColorSettings.YellowBrush);
                    circle.body.Mass = 4;
                    circle.body.AddForce(new Vector2(rnd.Next(-4000, 4000), rnd.Next(-1000, 1000)));
                    circle.body.Damping = 1;
                    scene.AddEntity(circle);
                }

            Circle2DEntity bigCircle = new Circle2DEntity(new Vector2(250, 400), 20, ColorSettings.YellowBrush);
            bigCircle.body.Mass = 20;
            scene.AddEntity(bigCircle);

            AddWalls(scene);
            PhysicsSettings.SetNewGravity(Vector2.Zero);
            return scene;
        }

        public SceneData CircleVsBox() {
            SceneData scene = new SceneData();

            Circle2DEntity bigCircle = new Circle2DEntity(new Vector2(250, 100), 20, ColorSettings.YellowBrush);
            bigCircle.body.Mass = 20;
            //bigCircle.body.Damping = 1;
            bigCircle.body.Restitution = .7;
            scene.AddEntity(bigCircle);

            Box2DEntity boxEntity = new(new Vector2(250, 400), 100, 40, ColorSettings.WhiteBrush);
            boxEntity.body.SetKinematic(true);
            scene.AddEntity(boxEntity);


            PhysicsSettings.SetNewGravity(new Vector2(0,200));
            return scene;
        }

        void AddWalls(SceneData sceneData) {
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
    }
}
