using Battles.Players;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

namespace Debugs {
    public class CreateTemplement : MonoBehaviour {
        [SerializeField] private Vector3 pos;
        [SerializeField] private PlayerObjectCreator playerObjectCreator;

        public ToggleObserve toggleObserve;
        
        public void Launch() {
            var a=new GameObject();
            a.transform.position = pos;
            var temp=playerObjectCreator.Create(a.AddComponent<Camera>());
            a.gameObject.SetActive(false);
            toggleObserve.SetUp(temp.GetComponent<AttackByPath>());
        }

    }
}