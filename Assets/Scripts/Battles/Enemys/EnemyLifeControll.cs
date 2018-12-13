using UnityEngine;
using UnityEngine.UI;


namespace Battles.Enemys {
    public class EnemyLifeControll : MonoBehaviour {
        [SerializeField] private Image lifeGauge;
        [SerializeField] private float life;
        [SerializeField] private float damage;

        public Text clear;
        
        private float defoultLife;

        private PhotonView photonView;

        private void Start() {
            photonView = this.GetComponent<PhotonView>();
            defoultLife = life;
        }

        public void Damage() {
            photonView.RPC("DamageRPC",PhotonTargets.AllBuffered);
        }

        [PunRPC]
        public void DamageRPC() {
            life -= damage;
            lifeGauge.fillAmount = life / defoultLife;
            if (life <= 0) {
                clear.enabled = true;
            }
        }

    }
}