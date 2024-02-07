using UnityEngine;
using UnityEngine.SceneManagement;

namespace MVC.UI
{
    public class RestartButton : MonoBehaviour
    {
        public void RestartLevel()
        {
            SceneManager.LoadScene("Demo");
        }
    }
}