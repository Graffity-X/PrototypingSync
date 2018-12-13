using UnityEngine;
using UnityEngine.XR.iOS;

namespace DefaultNamespace {
    public class Test : MonoBehaviour {
        public void Launch() {
            var temp=new GameObject();
            temp.transform.position = UnityARMatrixOps.GetPosition(transform.position);
            temp.transform.rotation = UnityARMatrixOps.GetRotation(transform.worldToLocalMatrix);
            
            UnityARSessionNativeInterface.GetARSessionNativeInterface().SetWorldOrigin (temp.transform);
            
            Destroy(temp);
        }
    }
}