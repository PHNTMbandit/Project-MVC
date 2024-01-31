using Sirenix.OdinInspector;
using UnityEngine;

namespace MVC.UI
{
    public class UIFollowWorld : MonoBehaviour
    {
        public Transform FollowTarget { get; private set; }

        private Camera _mainCamera;
        private Canvas _HUDCanvas;
        private Vector2 _offset;
        private RectTransform _rectTransform;

        private void Awake()
        {
            _mainCamera = Camera.main;

            _rectTransform = GetComponent<RectTransform>();
            _HUDCanvas = GameObject.FindGameObjectWithTag("HUD").GetComponent<Canvas>();
        }

        private void Update()
        {
            var viewportPoint = _mainCamera.WorldToViewportPoint(FollowTarget.position + (Vector3)_offset);
            var screenPoint = _HUDCanvas.worldCamera.ViewportToScreenPoint(viewportPoint);
            RectTransformUtility.ScreenPointToWorldPointInRectangle(_rectTransform, screenPoint, _HUDCanvas.worldCamera, out Vector3 worldPoint);

            if (viewportPoint.z > 0)
            {
                _rectTransform.position = worldPoint;
            }
        }

        public void SetFollowTarget(Transform followTarget, Vector2 offset)
        {
            FollowTarget = followTarget;
            _offset = offset;
        }
    }
}