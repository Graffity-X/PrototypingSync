using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Systems;
using UnityEngine;

namespace Battles {
    public class PlayersInfo : MonoBehaviour {
        [SerializeField]private List<GameObject> players;
        public ReadOnlyCollection<GameObject> Players=>new ReadOnlyCollection<GameObject>(players);

        public void AddPlayer(GameObject p) {
            if (players.Contains(p)) {
                ScrollLogger.Log(p.name+"is contain my info");
                return;
            }
            players.Add(p);
        }
        public int AmountPlayer {
            get { return players.Count(n => n != null); }
        }
    }
}