using Systems;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Battles.Players {
    public class AttackButton : MonoBehaviour {

        public AttackControll AttackControll { get; set; }
        private EventTrigger eventTrigger;

        private bool trigger;
        
        private void Start() {
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
            if (trigger) {
                if (AttackControll == null) return;
                AttackControll.Attack();
            }
        }

        private void Down() {
            trigger = true;
        }

        private void Up() {
            trigger = false;
        }
    }
}