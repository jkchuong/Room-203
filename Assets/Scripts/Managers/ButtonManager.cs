using UI;
using UnityEngine;

namespace Managers
{
    public class ButtonManager : MonoBehaviour
    {
        public void OpenInventory()
        {
            InventoryUI.Instance.SetUI();
        }

        public void StartButton()
        {
            SceneLoader.Instance.FadeSceneLoad("Corridor");
        }

        public void ControlsButton()
        {
            Debug.LogError("Controls not set up");
        }

        public void CreditsButton()
        {
            Debug.LogError("Credits not set up");
        }
    }
}