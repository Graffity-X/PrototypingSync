using System;
using UniRx;
using UnityEngine;

namespace Battles.Enemys {
    public class EnemyBullet : MonoBehaviour {
        [SerializeField] private float speed;
        [SerializeField] private float deleteTime;

        public void LaunchLookAt(Vector3 point) {
            this.transform.LookAt(point);
            this.GetComponent<Rigidbody>().AddForce(transform.forward*speed,ForceMode.VelocityChange);
            Observable.Timer(TimeSpan.FromSeconds(deleteTime)).Subscribe(n => PhotonNetwork.Destroy(gameObject));
        }
    }
}