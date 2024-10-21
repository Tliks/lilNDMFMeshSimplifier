using UnityEngine;

namespace jp.lilxyzw.ndmfmeshsimplifier.runtime
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Renderer))]
    internal class NDMFMeshSimplifier : MonoBehaviour
    #if LIL_VRCSDK3
    , VRC.SDKBase.IEditorOnly
    #endif
    {
        [HideInInspector]
        public (int, int) Triangles = (0, 0);

        [Range(0,1)] public float quality = 0.5f;
        public SimplificationOptions options = SimplificationOptions.Default;
    }
}
