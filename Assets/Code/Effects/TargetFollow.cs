using UnityEngine;

namespace Assets.Code.Effects
{
    public class TargetFollow : MonoBehaviour
    {
        public float MoveSpeed;
        public float YOffset;

        private Transform target;

        public void StartFollowing(Transform targ)
        {
            target = targ;
            this.enabled = true;
        }

        void Update()
        {
            if (target != null)
            {
                var targetPos = Vector3.Lerp(transform.position, target.position, MoveSpeed);
                targetPos.y = YOffset;
                transform.position = targetPos;
            }
        }
    }
}
