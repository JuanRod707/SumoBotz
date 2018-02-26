using UnityEngine;

namespace Assets.Code.Effects
{
    public class EndCameraZoom : MonoBehaviour
    {
        public TargetFollow Target;
        public float MinFov;
        public float FovChange;

        private Camera cam;

        public void ZoomTo(Transform target)
        {
            Target.StartFollowing(target);
            cam = GetComponent<Camera>();
            this.enabled = true;
        }

        void Update()
        {
            transform.LookAt(Target.transform);
            var dir = transform.eulerAngles;
            dir.z = 0f;

            transform.eulerAngles = dir;

            if (cam.fieldOfView > MinFov)
            {
                cam.fieldOfView -= FovChange;
            }
        }
    }
}
