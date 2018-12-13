using System;
using Systems;
using UniRx;
using UnityEngine;

namespace Battles.Players {
    public class AttackByPath : MonoBehaviour {
        private Subject<bool> attackStream=new Subject<bool>();
        public IObservable<bool> AttackStream => attackStream;

        private PhotonView photonView;

        private void Awake() {
            photonView = this.GetComponent<PhotonView>();
        }

        public void Attack(bool t) {
            photonView.RPC("AttackRPC",PhotonTargets.AllBuffered,t);
        }

        [PunRPC]
        private void AttackRPC(bool t) {
            attackStream.OnNext(t);
        }
    }
}