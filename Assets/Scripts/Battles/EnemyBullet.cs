using UnityEngine;

namespace Battles {
    public class EnemyBullet : MonoBehaviour {
        [SerializeField] private float speed;
        [SerializeField] private float deleteTime;

        public void LaunchLookAt(Vector3 point) {
            this.transform.LookAt(point);
            this.GetComponent<Rigidbody>().AddForce(transform.forward*speed,ForceMode.VelocityChange);
            Destroy(gameObject,deleteTime);
        }
    }
}