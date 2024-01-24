using Sirenix.OdinInspector;
using UnityEngine;

namespace MVC.Player
{
    [AddComponentMenu("Player/Player Shoot")]
    public class PlayerShoot : MonoBehaviour
    {
        [BoxGroup("References"), SerializeField]
        private GameObject _bulletPrefab;

        public void Shoot()
        {
            print("shooting");
        }
    }
}