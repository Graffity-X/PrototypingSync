using UnityEngine;

namespace Battles {
    public class MyBodyChaser : MonoBehaviour {
        [SerializeField] private Camera mine;

        private void Update() {
            transform.position = mine.transform.position;
            transform.rotation = mine.transform.rotation;
        }
    }
}