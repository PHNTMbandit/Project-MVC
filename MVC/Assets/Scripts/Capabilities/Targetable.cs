using MVC.UI;
using UnityEngine;

namespace MVC.Capabilities
{
    [RequireComponent(typeof(AutoTargetUI))]
    [AddComponentMenu("Capabilities/Targetable")]
    public class Targetable : MonoBehaviour
    {
        [field: SerializeField]
        public Renderer Target { get; private set; }

        private AutoTargetUI _autoTargetUI;
        private Camera _camera;

        private void Awake()
        {
            _camera = Camera.main;
            _autoTargetUI = GetComponent<AutoTargetUI>();
        }

        private void Start()
        {
            _autoTargetUI.Initialise(Target);
        }

        public bool IsVisible()
        {
            Plane[] planes = GeometryUtility.CalculateFrustumPlanes(_camera);

            if (GeometryUtility.TestPlanesAABB(planes, Target.bounds))
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