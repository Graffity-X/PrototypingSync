using UnityEngine;

namespace Battles {
    public class PlayerObjectCreator : MonoBehaviour {
        [SerializeField] private GameObject playerBody;
        
        public GameObject Create(GameObject root) {
            var temp = PhotonNetwork.Instantiate(playerBody.name,root.transform.position,root.transform.rotation,0);
            temp.GetComponent<PlayerChaser>().SetUp(root);
            return temp;
        }
    }
}