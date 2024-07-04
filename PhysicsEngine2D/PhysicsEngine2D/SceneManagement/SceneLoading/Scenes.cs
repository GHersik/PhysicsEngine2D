using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using PhysicsLibrary;

namespace SimulationWindow {

    public static class Scenes {

        //SolidColorBrush randomColor = new SolidColorBrush(Color.FromRgb((byte)rnd.Next(80, 255), (byte)rnd.Next(80, 255), (byte)rnd.Next(80, 255)));
        static readonly Random rnd = new();

        public static SceneData Ambient() {
            SceneData scene = new();

            for (int i = 1; i < 10; i++)
                for (int j = 1; j < 10; j++) {
                    Vector2 position = new(i * 50 + rnd.Next(-18, 18), j * 50 + rnd.Next(-18, 18));
                    int massAndRadius = rnd.Next(4, 8);
                    Circle2DEntity circle = new(position, massAndRadius, ColorSettings.WhiteBrush);
                    circle.Body.Mass = massAndRadius;
                    circle.Body.Damping = 1;
                    circle.Body.AddForce(new Vector2(rnd.Next(-200, 200), rnd.Next(-200, 200)), ForceMode.Impulse);
                    scene.AddEntity(circle);
                }

            AddWalls(scene);
            PhysicsSettings.SetGravity(PhysicsSettings.NoGravity);
            PhysicsSettings.SetFixedTimeStep(.03);
            return scene;
        }

        public static SceneData BrownianMotion() {
            SceneData scene = new();

            for (int i = 1; i < 18; i++)
                for (int j = 1; j < 8; j++) {
                    Vector2 position = new(i * 28, j * 28);
                    Circle2DEntity circle = new(position, 4, ColorSettings.YellowBrush);
                    circle.Body.Mass = 4;
                    circle.Body.Damping = 1;
                    circle.Body.AddForce(new Vector2(rnd.Next(-300, 300), rnd.Next(-300, 300)), ForceMode.Impulse);
                    scene.AddEntity(circle);
                }

            Circle2DEntity bigCircle = new(new Vector2(250, 400), 20, ColorSettings.YellowBrush);
            bigCircle.Body.Mass = 20;
            scene.AddEntity(bigCircle);

            AddWalls(scene);
            PhysicsSettings.SetGravity(Vector2.Zero);
            PhysicsSettings.SetFixedTimeStep(.02);
            return scene;
        }

        public static SceneData RestingContact() {
            SceneData scene = new();

            Circle2DEntity bigCircle = new(new(250, 100), 20, ColorSettings.TransparentBrush);
            bigCircle.Body.Mass = 20;
            bigCircle.Body.Damping = .9;
            bigCircle.Body.Restitution = .7;
            bigCircle.Renderer.SetBounds(ColorSettings.YellowBrush, 1.5);
            scene.AddEntity(bigCircle);

            Box2DEntity boxEntity = new(new(250, 400), 100, 40, ColorSettings.TransparentBrush);
            boxEntity.Body.SetKinematic(true);
            boxEntity.Renderer.SetBounds(ColorSettings.YellowBrush, 3);
            scene.AddEntity(boxEntity);

            AddWalls(scene);
            PhysicsSettings.SetGravity(new Vector2(0, 200));
            PhysicsSettings.SetFixedTimeStep(.06);
            return scene;
        }

        public static SceneData BilliardSample() {
            SceneData scene = new();

            double x = 190;
            for (int i = 0; i < 5; i++) {
                double y = 100 + i * 21;
                for (int j = 0; j < 5 - i; j++) {
                    Vector2 position = new(x + j * 24 + i * 12, y);
                    Circle2DEntity circle = new(position, 12, ColorSettings.WhiteBrush);
                    circle.Body.Damping = .7;
                    scene.AddEntity(circle);
                }
            }

            Circle2DEntity whiteBall = new(new Vector2(250, 400), 12, ColorSettings.WhiteBrush);
            whiteBall.Body.Damping = .7;
            whiteBall.Body.AddForce(new(rnd.Next(-40, 40), -rnd.Next(200, 500)), ForceMode.Impulse);
            scene.AddEntity(whiteBall);

            AddWalls(scene);
            PhysicsSettings.SetGravity(PhysicsSettings.NoGravity);
            PhysicsSettings.SetFixedTimeStep(.01);
            return scene;
        }

        public static SceneData Tunneling() {
            SceneData scene = new();

            Circle2DEntity bigCircle = new(new(100, 250), 20, ColorSettings.TransparentBrush);
            bigCircle.Body.Mass = 20;
            bigCircle.Body.Damping = 1;
            bigCircle.Body.Restitution = .7;
            bigCircle.Body.AddForce(new(10000, 0), ForceMode.Impulse);
            bigCircle.Renderer.SetBounds(ColorSettings.YellowBrush, 1.5);
            scene.AddEntity(bigCircle);

            Box2DEntity boxEntity = new(new(360, 250), 40, 100, ColorSettings.TransparentBrush);
            boxEntity.Body.SetKinematic(true);
            boxEntity.Renderer.SetBounds(ColorSettings.YellowBrush, 3);
            scene.AddEntity(boxEntity);

            AddWalls(scene);
            PhysicsSettings.SetGravity(PhysicsSettings.NoGravity);
            PhysicsSettings.SetFixedTimeStep(.07);
            return scene;
        }

        public static SceneData MarginalBounds() {
            SceneData scene = new();

            Circle2DEntity bigCircle = new(new Vector2(100, 250), 20, ColorSettings.TransparentBrush);
            bigCircle.Body.Mass = 20;
            bigCircle.Body.Damping = 1;
            bigCircle.Body.Restitution = .7;
            bigCircle.Body.AddForce(new(11000, 0), ForceMode.Impulse);
            bigCircle.Renderer.SetBounds(ColorSettings.YellowBrush, 1.5);
            scene.AddEntity(bigCircle);

            Box2DEntity boxEntity = new(new(360, 280), 100, 40, ColorSettings.TransparentBrush);
            boxEntity.Body.SetKinematic(true);
            boxEntity.Renderer.SetBounds(ColorSettings.YellowBrush, 3);
            scene.AddEntity(boxEntity);

            AddWalls(scene);
            PhysicsSettings.SetGravity(PhysicsSettings.NoGravity);
            PhysicsSettings.SetFixedTimeStep(.07);
            return scene;
        }

        public static SceneData ImpossibleScenarios() {
            SceneData scene = new();

            Circle2DEntity bigCircle = new(new(100, 250), 20, ColorSettings.TransparentBrush);
            bigCircle.Body.Mass = 20;
            bigCircle.Body.Damping = 1;
            bigCircle.Body.Restitution = .7;
            bigCircle.Body.AddForce(new(10000, 0), ForceMode.Impulse);
            bigCircle.Renderer.SetBounds(ColorSettings.YellowBrush, 1.5);
            scene.AddEntity(bigCircle);

            Box2DEntity boxEntity = new(new(360, 250), 40, 100, ColorSettings.TransparentBrush);
            boxEntity.Body.SetKinematic(true);
            boxEntity.Renderer.SetBounds(ColorSettings.YellowBrush, 3);
            scene.AddEntity(boxEntity);

            AddWalls(scene);
            PhysicsSettings.SetGravity(PhysicsSettings.NoGravity);
            PhysicsSettings.SetFixedTimeStep(.07);
            return scene;
        }

        public static SceneData LargeSet() {
            SceneData scene = new();

            for (int i = 1; i < 20; i++)
                for (int j = 1; j < 20; j++) {
                    Vector2 position = new(i * 25 + rnd.Next(-1, 1), j * 25 + rnd.Next(-1, 1));
                    Circle2DEntity circle = new(position, 4, ColorSettings.WhiteBrush);
                    circle.Body.AddForce(new(rnd.Next(-1000, 1000), rnd.Next(-1000, 1000)));
                    circle.Body.Damping = .9;
                    scene.AddEntity(circle);
                }

            AddWalls(scene);
            PhysicsSettings.SetGravity(PhysicsSettings.EarthGravity);
            PhysicsSettings.SetFixedTimeStep(.02);
            return scene;
        }

        static void AddWalls(SceneData sceneData) {
            Box2DEntity right = new(new(520, 250), 40, 580, ColorSettings.TransparentBrush);
            right.Body.SetKinematic(true);
            Box2DEntity left = new(new(-20, 250), 40, 580, ColorSettings.TransparentBrush);
            left.Body.SetKinematic(true);
            Box2DEntity top = new(new(250, -20), 580, 40, ColorSettings.TransparentBrush);
            top.Body.SetKinematic(true);
            Box2DEntity bottom = new(new(250, 520), 580, 40, ColorSettings.TransparentBrush);
            bottom.Body.SetKinematic(true);

            sceneData.AddEntity(right);
            sceneData.AddEntity(left);
            sceneData.AddEntity(top);
            sceneData.AddEntity(bottom);
        }
    }
}
