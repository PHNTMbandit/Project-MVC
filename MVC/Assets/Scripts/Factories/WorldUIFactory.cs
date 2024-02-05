using MVC.Controllers;
using MVC.UI;
using UnityEngine;

namespace MVC.Factories
{
    public class WorldUIFactory
    {
        public T GetUI<T>(T prefab, Vector3 position, Transform parent, Vector2 offset) where T : MonoBehaviour
        {
            T UI = ObjectPoolController.Instance.GetPooledObject(prefab.name, position, Quaternion.identity, parent, true).GetComponent<T>();
            UI.GetComponent<UIFollowWorld>().SetFollowTarget(position, offset);

            return UI;
        }
    }
}