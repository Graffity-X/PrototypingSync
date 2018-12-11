using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Battles {
    public class LifeControll : MonoBehaviour {
        [SerializeField]private int life;
        [SerializeField]private Image[] icons;

        public void Damage(int dm=1) {
            life -= dm;
            foreach (var i in Enumerable.Range(0,icons.Length)) {
                icons[i].enabled = i <= life;
            }
        }
    }
}