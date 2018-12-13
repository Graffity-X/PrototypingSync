using UnityEngine;

namespace Battles {
    public class EnemyCreater : MonoBehaviour {
        public GameObject Enemy;


        private void Start() {
            Launch();
        }

        public void Launch() {
            var info = this.GetComponent<PlayersInfo>();
            var p1 = info.Players[0].transform.position;
            var p2 = info.Players[1].transform.position;
            var pos=new Vector3((p1.x+p2.x)/2,(p1.y+p2.y)/2,(p1.z+p2.z)/2);
            var temp=PhotonNetwork.Instantiate(Enemy.name, pos, Quaternion.identity,0);
            temp.transform.SetParent(transform);
        }
    }
}