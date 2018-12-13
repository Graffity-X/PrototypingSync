using System;
using System.Linq;
using Systems;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Battles.Players {
    public class LifeControll : MonoBehaviour {
        [SerializeField]private int life;
        [SerializeField]private Image[] icons;

        public Text gameOverMes;

        private IObservable<int> damageStream=new Subject<int>();

        private AttackControll attackControll;

        private PhotonView photonView;
        
        private void Start() {
            photonView = this.GetComponent<PhotonView>();
            attackControll = this.GetComponent<AttackControll>();
        }

        private void Damage(int dm=1) {
            if (!attackControll.IsActive) return;
            photonView.RPC("DamageRPC",PhotonTargets.AllBuffered,dm);
        }
        
        [PunRPC]
        private void DamageRPC(int dm) {
            ScrollLogger.Log("damage");
            life -= dm;
            foreach (var i in Enumerable.Range(0,icons.Length)) {
                icons[i].enabled = i < life;
            }

            if (life <= 0) {
                gameOverMes.enabled = true;
            }
        }

        public void SetUp(AttackReciever attack_reciever) {
            damageStream=damageStream.Merge(attack_reciever.HitStream);
            damageStream.Subscribe(n=>Damage());
        }
    }
}