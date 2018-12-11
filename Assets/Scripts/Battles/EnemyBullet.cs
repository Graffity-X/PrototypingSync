using UnityEngine;

namespace Battles {
    public class EnemyBullet : MonoBehaviour {
        [SerializeField] private float speed;
        [SerializeField] private float deleteTime;

        public void Launch() {
            this.GetComponent<Rigidbody>().AddForce(transform.forward*speed,ForceMode.VelocityChange);
            Destroy(gameObject,deleteTime);
        }
    }
}