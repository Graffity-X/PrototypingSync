using Systems;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Battles.Players {
    public class AttackButton : MonoBehaviour {

        public AttackByPath AttackByPath { get; set; }
        private EventTrigger eventTrigger;

        private bool trigger;
        private PhotonView photonView;
        
        private void Start() {
            photonView = this.GetComponent<PhotonView>();
            eventTrigger = this.GetComponent<EventTrigger>();
            
            var down=new EventTrigger.Entry();
            down.eventID = EventTriggerType.PointerDown;
            down.callback.AddListener((n)=>Down());
            eventTrigger.triggers.Add(down);
            
            var up=new EventTrigger.Entry();
            up.eventID = EventTriggerType.PointerUp;
            up.callback.AddListener((n)=>Up());
            eventTrigger.triggers.Add(up);

        }

        private void Update() {
            if (AttackByPath == null) return;
            AttackByPath.Attack(trigger);
        }

        private void Down() {
            photonView.RPC("DownRPC", PhotonTargets.AllBuffered);
        }
        
        [PunRPC]
        private void DownRPC() {
            trigger = true;
        }


        private void Up() {
            photonView.RPC("UpRPC",PhotonTargets.AllBuffered);
        }
        
        [PunRPC]
        private void UpRPC() {
            trigger = false;
        }
    }
}