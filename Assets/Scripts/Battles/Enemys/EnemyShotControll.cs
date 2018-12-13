using Systems;
using Battles.Systems;
using UniRx;
using UnityEngine;

namespace Battles.Enemys {
    public class EnemyShotControll : MonoBehaviour {
        [SerializeField] private GameObject bullet;
        [SerializeField] private float attackInterval;
        [SerializeField] private float errorRange=1;
        
        private void Start() {
            foreach (var item in transform.GetComponentInParent<PlayersInfo>().Players) {
                SetUp(item);
            }
        }

        private void SetUp(GameObject target) {
            new RandomrWithInterval(-1f, 1f, errorRange, 1.5f).PublishStream
                .Subscribe(n => {
                    var tp = target.transform.position;
                    var hori = PointSniper.Snipe2D(new Vector2(n, n), new Vector2(tp.x - errorRange, tp.y - errorRange),
                        new Vector2(tp.x + errorRange, tp.y + errorRange));
                    Shot(new Vector3(hori.x,hori.y,tp.z));
                });
        }

        private void Shot(Vector3 point) {
            var temp = PhotonNetwork.Instantiate(bullet.name, transform.position, Quaternion.identity,0);
            temp.GetComponent<EnemyBullet>().LaunchLookAt(point);
        }
    }
}