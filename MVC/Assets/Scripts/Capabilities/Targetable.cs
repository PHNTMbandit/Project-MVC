using MVC.UI;
using Sirenix.OdinInspector;
using UnityEngine;

namespace MVC.Capabilities
{
    [RequireComponent(typeof(AutoTargetUI))]
    [AddComponentMenu("Capabilities/Targetable")]
    public class Targetable : MonoBehaviour
    {
        public AutoTargetUI AutoTargetUI { get; private set; }

        [BoxGroup("References"), SerializeField]
        private Renderer _target;

        private Camera _camera;

        private void Awake()
        {
            _camera = Camera.main;
            AutoTargetUI = GetComponent<AutoTargetUI>();
        }

        private void Start()
        {
            AutoTargetUI.Initialise(transform);
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
    }
}