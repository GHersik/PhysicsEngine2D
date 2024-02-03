using System;

namespace PhysicsLibrary {
    public partial struct Vector2 {

        public double x;
        public double y;

        public readonly double Magnitude => Math.Sqrt((x * x) + (y * y));
        public readonly Vector2 Normalized {
            get {
                Vector2 normalized = new Vector2(x, y);
                normalized.Normalize();
                return normalized;
            }
        }

        public Vector2(double x = 0, double y = 0) {
            this.x = x;
            this.y = y;
        }

        public void Normalize() {
            double magnitude = Magnitude;
            if (magnitude == 0) {
                this = Zero;
                return;
            }

            x /= magnitude;
            y /= magnitude;
        }

        public override string ToString() => $"({x},{y})";
    }
}