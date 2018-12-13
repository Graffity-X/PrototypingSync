using Systems;
using UnityEngine;
using UniRx;

namespace Battles.Enemys {
    public class EnemyMoveControll : MonoBehaviour {
        [SerializeField] private float speed;
        [SerializeField] private float interval;

        private Rigidbody rigidbody;
        
        private void Awake() {
            rigidbody = this.GetComponent<Rigidbody>();
            new RandomInterval(interval, 0.5f)
                .PublishStream.Subscribe(n => {
                    rigidbody.velocity=Vector3.zero;
                    var rd = Random.Range(0,5);
                    
                    switch (rd) {
                        case 0:
                            rigidbody.velocity = Vector3.up * speed;
                            break;
                        case 1:
                            rigidbody.velocity = Vector3.down * speed;
                            break;
                        case 2:
                            rigidbody.velocity = Vector3.right * speed;
                            break;
                        case 3:
                            rigidbody.velocity = Vector3.left * speed;
                            break;
                    }
                });
        }
        
    }
}