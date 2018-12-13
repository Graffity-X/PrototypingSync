using Systems;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Battles.Players {
    public class AttackButton : MonoBehaviour {

        public AttackByPath AttackByPath { get; set; }
        private EventTrigger eventTrigger;

        [SerializeField]private bool trigger;
        
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

            this.ObserveEveryValueChanged(n => n.trigger)
                .Subscribe(n => {
                    if (AttackByPath != null) AttackByPath.Attack(trigger);
                });
        }
        
        


        private void Down() {
            trigger = true;
        }


        private void Up() {
            trigger = false;
        }
    }
}