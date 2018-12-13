using SPU;
using UnityEngine;

namespace Battles.Players {
    public class PlayerInit : MonoBehaviour,IRecieveSPUNotification {
        [SerializeField] private Camera camera;
        [SerializeField] private PlayerObjectCreator playerObjectCreator;
        
        
        
        public void OnOpenCanvas() {
            var temp=playerObjectCreator.Create(camera);
            this.GetComponent<AttackButton>().AttackControll = temp.GetComponent<AttackControll>();
        }

        public void OnCloseCanvas() {
            //Empty
        }
    }
}