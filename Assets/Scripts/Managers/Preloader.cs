using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class Preloader : MonoBehaviour
    {
        private void Start()
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
