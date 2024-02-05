using Sirenix.OdinInspector;
using UnityEngine;

namespace MVC.UI
{
    public class UIFollowWorld : MonoBehaviour
    {
        public Vector3 FollowAnchor { get; private set; }

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
            var viewportPoint = _mainCamera.WorldToViewportPoint(FollowAnchor + (Vector3)_offset);
            var screenPoint = _HUDCanvas.worldCamera.ViewportToScreenPoint(viewportPoint);
            RectTransformUtility.ScreenPointToWorldPointInRectangle(_rectTransform, screenPoint, _HUDCanvas.worldCamera, out Vector3 worldPoint);

            if (viewportPoint.z > 0)
            {
                _rectTransform.position = worldPoint;
            }
        }

        public void SetFollowTarget(Vector3 followTarget, Vector2 offset)
        {
            FollowAnchor = followTarget;
            _offset = offset;
        }
    }
}