using MVC.Controllers;
using UnityEngine;

namespace MVC.Factories
{
    public class WorldUIFactory
    {
        public T GetUI<T>(T prefab, Vector3 position, Transform parent) where T : MonoBehaviour
        {
            return ObjectPoolController.Instance.GetPooledObject(prefab.name, position, Quaternion.identity, parent, true).GetComponent<T>();
        }
    }
}