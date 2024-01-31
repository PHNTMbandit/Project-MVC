using Sirenix.OdinInspector;
using UnityEngine;

namespace MVC.UI
{
    public class UIFollowWorld : MonoBehaviour
    {
        public Transform FollowTarget { get; private set; }

        private Camera _camera;
        private Vector2 _offset;

        private void Awake()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            Vector3 worldPosition = _camera.WorldToScreenPoint(FollowTarget.position + (Vector3)_offset);
            if (worldPosition.z > 0)
            {
                transform.position = worldPosition;
            }
        }

        public void SetFollowTarget(Transform followTarget, Vector2 offset)
        {
            FollowTarget = followTarget;
            _offset = offset;
        }
    }
}