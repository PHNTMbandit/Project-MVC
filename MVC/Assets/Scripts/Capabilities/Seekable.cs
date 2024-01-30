using UnityEngine;

namespace MVC.Capabilities
{
    [AddComponentMenu("Capabilities/Seekable")]
    public class Seekable : MonoBehaviour
    {
        [Range(0, 10), SerializeField]
        private float _speed;

        private Transform _target;
        private bool _isFollowing = false;

        private void OnDisable()
        {
            _isFollowing = false;
            _target = null;
        }

        private void Update()
        {
            if (_isFollowing)
            {
                transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
            }
        }

        public void SetTarget(Transform target)
        {
            _target = target;
            _isFollowing = true;
        }
    }
}