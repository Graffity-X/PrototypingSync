using SPU;
using UnityEngine;

namespace Battles.Players {
    public class PlayerInit : MonoBehaviour,IRecieveSPUNotification {
        [SerializeField] private Camera camera;
        [SerializeField] private PlayerObjectCreator playerObjectCreator;
        
        
        
        public void OnOpenCanvas() {
            var temp=playerObjectCreator.Create(camera);
            camera.gameObject.GetComponent<BodyControll>().body = temp;
            this.GetComponent<AttackButton>().AttackByPath = temp.GetComponent<AttackByPath>();
        }

        public void OnCloseCanvas() {
            //Empty
        }
    }
}