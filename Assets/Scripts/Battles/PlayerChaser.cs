using Systems;
using UnityEngine;

namespace Battles {
    public class CameraChaser : MonoBehaviour {
        [SerializeField] private Camera mine;

        public void SetUp(Camera camera) {
            if (mine != null) {
                ScrollLogger.Log("I already have camera!");
                return;
            }

            mine = camera;
        }

        private void Update() {
            transform.position = mine.transform.position;
            transform.rotation = mine.transform.rotation;
        }
    }
}