using UnityEngine;
using UnityEngine.Events;

namespace MVC.Utilities
{
    public class AnimationEvent : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent _onAnimationEvent;

        public void CallAnimationEvent()
        {
            _onAnimationEvent.Invoke();
        }
    }
}