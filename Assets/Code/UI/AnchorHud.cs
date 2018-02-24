using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.UI
{
    public class AnchorHud : MonoBehaviour
    {
        public Vector3 Offset;

        private Transform anchor;

        public void SetAnchor(Transform anchor)
        {
            this.anchor = anchor;
        }

        void Update()
        {
            if (anchor != null)
            {
                transform.position = anchor.position + Offset;
            }
        }
    }
}
