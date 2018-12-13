using System.Linq;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Battles.Players {
    public class LifeControll : MonoBehaviour {
        [SerializeField]private int life;
        [SerializeField]private Image[] icons;

        private Subject<int> damageStream=new Subject<int>();

        private void Start() {
            damageStream.Subscribe(Damage);
        }

        private void Damage(int dm=1) {
            life -= dm;
            foreach (var i in Enumerable.Range(0,icons.Length)) {
                icons[i].enabled = i <= life;
            }
        }

        public void SetUp(AttackReciever attack_reciever) {
            damageStream.Merge(attack_reciever.HitStream);
        }
    }
}