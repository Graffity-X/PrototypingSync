using Battles.Systems;
using UnityEngine;

namespace Battles.Players {
    public class PlayerObjectCreator : MonoBehaviour {
        [SerializeField] private GameObject playerBody;
        
        public GameObject Create(Camera camera) {
            var temp = PhotonNetwork.Instantiate(playerBody.name,camera.transform.position,camera.transform.rotation,0);
            //temp.GetComponent<PlayerChaser>().SetUp(camera.gameObject);

            this.GetComponent<PlayersManage>().UpdatePlayer();
            return temp;
        }
    }
}