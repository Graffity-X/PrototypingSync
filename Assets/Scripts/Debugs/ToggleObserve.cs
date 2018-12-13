using Battles.Players;
using UnityEngine;
using UnityEngine.UI;

namespace Debugs {
    public class ToggleObserve : MonoBehaviour {
        private Toggle toggle;

        private AttackByPath attackByPath;

        private void Awake() {
            toggle = this.GetComponent<Toggle>();

        }

        public void SetUp(AttackByPath attack_by_path) {
            attackByPath = attack_by_path;
        }

        private void Update() {
            if (attackByPath == null) return;
            attackByPath.Attack(toggle.isOn);
        }
    }
}