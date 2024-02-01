using MVC.UI;
using UnityEngine;

namespace MVC.Capabilities
{
    [RequireComponent(typeof(Renderer))]
    [RequireComponent(typeof(AutoTargetUI))]
    [AddComponentMenu("Capabilities/Targetable")]
    public class Targetable : MonoBehaviour
    {
        private AutoTargetUI _autoTargetUI;
        private Camera _camera;
        private Renderer _renderer;

        private void Awake()
        {
            _camera = Camera.main;
            _autoTargetUI = GetComponent<AutoTargetUI>();
            _renderer = GetComponent<Renderer>();
        }

        public bool IsVisible()
        {
            Plane[] planes = GeometryUtility.CalculateFrustumPlanes(_camera);

            if (GeometryUtility.TestPlanesAABB(planes, _renderer.bounds))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SetCurrentTarget(bool enable)
        {
            _autoTargetUI.SetAutoTargetIconEnabled(enable);
        }
    }
}