using UnityEngine;
using UnityEngine.XR.iOS;

namespace Presets {
    public static class WorldOriginSetter{
        public static void Set(Transform transform) {
            var temp=new GameObject();
            temp.transform.position = UnityARMatrixOps.GetPosition(transform.position);
            temp.transform.rotation = UnityARMatrixOps.GetRotation(transform.worldToLocalMatrix);
            
            UnityARSessionNativeInterface.GetARSessionNativeInterface().SetWorldOrigin (temp.transform);
            
            
        }
    }
}