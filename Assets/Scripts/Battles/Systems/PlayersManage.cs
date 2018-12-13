using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Systems;
using Battles.Players;
using UnityEngine;

namespace Battles.Systems {
    public class PlayersManage : MonoBehaviour {
        [SerializeField]private List<GameObject> players;
        public ReadOnlyCollection<GameObject> Players=>new ReadOnlyCollection<GameObject>(players);

        private PhotonView photonView;

        private void Start() {
            photonView = this.GetComponent<PhotonView>();
        }

        private void AddPlayer(GameObject p) {
            if (players.Contains(p)) {
                return;
            }
            this.GetComponent<AttackControll>().SetUp(p.GetComponent<AttackByPath>());
            this.GetComponent<LifeControll>().SetUp(p.GetComponent<AttackReciever>());
            players.Add(p);
        }
        public int AmountPlayer {
            get { return players.Count(n => n != null); }
        }

        public void UpdatePlayer() {
            photonView.RPC("SearchPlayer",PhotonTargets.AllBuffered);
        }

        [PunRPC]
        private void SearchPlayer() {
            foreach (var item in UnityEngine.Object.FindObjectsOfType<GameObject>()
                .Where(n=>n.CompareTag("Player"))) {
                AddPlayer(item);
            }
        }
        
    }
}