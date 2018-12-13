using System;
using Systems;
using UniRx;
using UnityEngine;

namespace Battles.Players {
    public class AttackReciever : MonoBehaviour {
        private Subject<int> hitStream=new Subject<int>();
        public IObservable<int> HitStream => hitStream;

        private void OnTriggerEnter(Collider other) {
            if (other.gameObject.CompareTag("EnemyBullet")) {
                hitStream.OnNext(1);
            }
        }
    }
}