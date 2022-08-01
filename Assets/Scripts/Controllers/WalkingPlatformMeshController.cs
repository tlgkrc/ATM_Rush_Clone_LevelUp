using UnityEngine;

namespace Controllers
{
    public class WalkingPlatformMeshController : MonoBehaviour
    {
        #region Self Variables

        #region Serialize Variables
        [SerializeField] private float scrollSpeed = 0.05f;
        [SerializeField] private Renderer renderer;
        #endregion

        #endregion

        private void Awake()
        {
            renderer = GetComponent<Renderer>();
        }

        private void Update()
        {
            float offset = Time.time * scrollSpeed;
            renderer.material.SetTextureOffset("_BaseMap", new Vector2(0, -offset));
        }
    }
}