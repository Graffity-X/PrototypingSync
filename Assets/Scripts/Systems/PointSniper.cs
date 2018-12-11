using UnityEngine;

namespace Systems {
    public class PointSniper : MonoBehaviour {
        public static Vector2 Snipe2D(Vector2 point,Vector2 start,Vector2 end) {
            return new Vector2(Random.Range(start.x, end.x), Random.Range(start.y, end.y));
        }
    }
}