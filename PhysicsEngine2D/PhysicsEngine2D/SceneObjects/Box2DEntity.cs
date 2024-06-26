using PhysicsEngine2D;
using PhysicsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PhysicsEngine2D {
    public class Box2DEntity : Entity {

        //Random random = new Random();

        public Box2DEntity(Vector2 position, double width, double height, SolidColorBrush color) {
            transform = new PhysicsLibrary.Transform(position);
            renderer = new Box2D(width, height, color);
            collider = new BoxCollider2D(new Vector2(-width / 2, -height / 2), new Vector2(width / 2, height / 2));
            body = new Body();
        }

        public Box2DEntity(Vector2 position, double width, double height) : this(position, width, height, ColorSettings.BlueBrush) { }

        public Box2DEntity(Vector2 position, double width) : this(position, width, 10, ColorSettings.BlueBrush) { }

        public Box2DEntity(Vector2 position) : this(position, 10, 10, ColorSettings.BlueBrush) { }

        public Box2DEntity() : this(new Vector2(250, 250), 10, 10, ColorSettings.BlueBrush) { }

        public override void Update() {
            //SolidColorBrush randomColor = new SolidColorBrush(Color.FromArgb(255, (byte)random.Next(0,255), (byte)random.Next(0, 255), (byte)random.Next(0, 255)));
            //renderer.SetColor(randomColor);
        }
    }
}
