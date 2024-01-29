using MVC.Controllers;
using UnityEngine;

namespace MVC.Factories
{
    public class ProjectileFactory
    {
        public GameObject GetProjectile(GameObject projectilePrefab, Transform origin, float velocity)
        {
            Rigidbody rigidbody = ObjectPoolController.Instance.GetPooledObject(projectilePrefab.name, origin.position, Quaternion.identity, null).GetComponent<Rigidbody>();
            rigidbody.AddForce(origin.forward * velocity, ForceMode.Impulse);

            return rigidbody.gameObject;
        }
    }
}