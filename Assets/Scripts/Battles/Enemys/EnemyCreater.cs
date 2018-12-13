using Battles.Systems;
using UnityEngine;

namespace Battles.Enemys {
    public class EnemyCreater : MonoBehaviour {
        public GameObject Enemy;


        private void Start() {
            
        }

        public void Launch() {
            var info = this.GetComponent<PlayersManage>();
            var po=new Vector3();
            foreach (var item in info.Players) {
                var tp = item.transform.position;
                po.x += tp.x;
                po.y += tp.y;
                po.z = tp.z;
            }

            var l = info.AmountPlayer;
            var pos=new Vector3(po.x/l,po.y/l,po.z/l);
            var temp=PhotonNetwork.Instantiate(Enemy.name, pos, Quaternion.identity,0);
            temp.transform.SetParent(transform);
        }
    }
}