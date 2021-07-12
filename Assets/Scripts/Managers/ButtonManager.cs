using System;
using UI;
using UnityEngine;

namespace Managers
{
    public class ButtonManager : MonoBehaviour
    {
        [SerializeField] private CanvasGroup mainCanvas;
        [SerializeField] private CanvasGroup controlsCanvas;
        [SerializeField] private CanvasGroup creditsCanvas;
        
        public void OpenInventory()
        {
            InventoryUI.Instance.SetUI();
        }

        public void StartButton()
        {
            GameManager.Instance.Reset();
            SceneLoader.Instance.FadeSceneLoad("Room Early");
        }

        public void ControlsButton()
        {
            ActivateCanvas(controlsCanvas);
            DeactivateCanvas(mainCanvas);
            DeactivateCanvas(creditsCanvas);        
        }

        public void CreditsButton()
        {
            ActivateCanvas(creditsCanvas);
            DeactivateCanvas(mainCanvas);
            DeactivateCanvas(controlsCanvas);
            
        }

        public void BackButton()
        {
            ActivateCanvas(mainCanvas);
            DeactivateCanvas(creditsCanvas);
            DeactivateCanvas(controlsCanvas);
        }

        private static void ActivateCanvas(CanvasGroup canvas)
        {
            canvas.alpha = 1;
            canvas.interactable = true;
            canvas.blocksRaycasts = true;
        }

        private static void DeactivateCanvas(CanvasGroup canvas)
        {
            canvas.alpha = 0;
            canvas.interactable = false;
            canvas.blocksRaycasts = false;
        }
    }
}