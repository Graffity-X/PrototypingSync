using System;
using UniRx;
using UnityEngine;

namespace Battles {
    public class AttackReciever : MonoBehaviour {
        private Subject<Unit> hitStream=new Subject<Unit>();
        public IObservable<Unit> HitStream => hitStream;

        private void OnTriggerEnter(Collider other) {
            if (other.gameObject.CompareTag("EnemyBullet")) {
                hitStream.OnNext(Unit.Default);
            }
        }
    }
}