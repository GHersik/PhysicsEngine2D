
namespace PhysicsLibrary {
    public partial struct Vector2 {

        public static readonly Vector2 One = new(1, 1);
        public static readonly Vector2 Zero = new(0, 0);
        public static readonly Vector2 Left = new(-1, 0);
        public static readonly Vector2 Right = new(1, 0);
        public static readonly Vector2 Up = new(0, 1);
        public static readonly Vector2 Down = new(0, -1);

        public static double Dot(Vector2 a, Vector2 b) => (a.x * b.x) + (a.y * b.y);
        public static Vector2 Cross(Vector2 a, Vector2 b) => new(a.x * b.x, a.y * b.y);
        public static double Distance(Vector2 a, Vector2 b) {
            double deltaX = a.x - b.x;
            double deltaY = a.y - b.y;
            return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
        }

        public static Vector2 operator +(Vector2 a, Vector2 b) => new(a.x + b.x, a.y + b.y);
        public static Vector2 operator +(Vector2 a, double scalar) => new(a.x + scalar, a.y + scalar);
        public static Vector2 operator -(Vector2 a, Vector2 b) => new(a.x - b.x, a.y - b.y);
        public static Vector2 operator -(Vector2 a, double scalar) => new(a.x - scalar, a.y - scalar);
        public static Vector2 operator *(Vector2 vectorToMultiply, double scalar) => new(vectorToMultiply.x * scalar, vectorToMultiply.y * scalar);
        public static Vector2 operator *(double scalar, Vector2 vectorToMultiply) => new(vectorToMultiply.x * scalar, vectorToMultiply.y * scalar);
        public static Vector2 operator /(Vector2 vectorToDivide, double scalar) => new(vectorToDivide.x / scalar, vectorToDivide.y / scalar);
        public static bool operator ==(Vector2 a, Vector2 b) => a.x == b.x && a.y == b.y;
        public static bool operator !=(Vector2 a, Vector2 b) => a.x != b.x || a.y != b.y;
    }
}