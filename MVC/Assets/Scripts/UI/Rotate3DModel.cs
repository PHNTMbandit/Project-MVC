using MVC.Input;
using UnityEngine;

namespace MVC.UI
{
    public class Rotate3DModel : MonoBehaviour
    {
        [SerializeField, Range(0, 10)]
        private float _rotationSpeed;

        [SerializeField]
        private InputReader _inputReader;

        private void Update()
        {
            if (_inputReader.ShootInput)
            {
                transform.Rotate(new Vector3(0, -_inputReader.LookInput.x, 0f) * _rotationSpeed);
            }
        }
    }
}