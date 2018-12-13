using Systems;
using UnityEngine;
using UnityEngine.Serialization;

namespace Battles {
    public class PlayerChaser : MonoBehaviour {
        [SerializeField] private GameObject target;

        public void SetUp(GameObject root) {
            if (target != null) {
                ScrollLogger.Log("I already have target!");
                return;
            }

            target = root;
        }

        private void Update() {
            transform.position = target.transform.position;
            transform.rotation = target.transform.rotation;
        }
    }
}