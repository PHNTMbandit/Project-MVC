using MVC.Controllers;
using MVC.UI;
using UnityEngine;

namespace MVC.Factories
{
    public class WorldUIFactory
    {
        public T GetUI<T>(T prefab, Transform target, Transform parent, Vector2 offset) where T : MonoBehaviour
        {
            T UI = ObjectPoolController.Instance.GetPooledObject(prefab.name, target.position, Quaternion.identity, parent, true).GetComponent<T>();
            UI.GetComponent<UIFollowWorld>().SetFollowTarget(target, offset);

            return UI;
        }
    }
}