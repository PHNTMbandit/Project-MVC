using MVC.UI;
using Sirenix.OdinInspector;
using UnityEngine;

namespace MVC.Capabilities
{
    [RequireComponent(typeof(AutoTargetUI))]
    [AddComponentMenu("Capabilities/Targetable")]
    public class Targetable : MonoBehaviour
    {
        [BoxGroup("References"), SerializeField]
        private Renderer _target;

        private Camera _camera;
        private AutoTargetUI _autoTargetUI;

        private void Awake()
        {
            _camera = Camera.main;
            _autoTargetUI = GetComponent<AutoTargetUI>();
        }

        private void Start()
        {
            _autoTargetUI.Initialise(transform);
        }

        public bool IsVisible()
        {
            Plane[] planes = GeometryUtility.CalculateFrustumPlanes(_camera);

            if (GeometryUtility.TestPlanesAABB(planes, _target.bounds))
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