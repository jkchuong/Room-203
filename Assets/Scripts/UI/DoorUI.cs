using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UI
{
    public class DoorUI : MonoBehaviour
    {
        private bool isShown;
        private CanvasGroup canvasGroup;
        private List<DoorPanel> doorPanels = new List<DoorPanel>();

        public static DoorUI Instance;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            } 
            else 
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }

            canvasGroup = GetComponent<CanvasGroup>();
            doorPanels = FindObjectsOfType<DoorPanel>().ToList();
        }

        private void Start()
        {
            RefreshDoorPanels();
        }

        public void ShowUI(bool show)
        {
            if (show)
            {
                canvasGroup.alpha = 1;
                canvasGroup.interactable = true;
                canvasGroup.blocksRaycasts = true;
            }
            else
            {
                canvasGroup.alpha = 0;
                canvasGroup.interactable = false;
                canvasGroup.blocksRaycasts = false;
            }
        }
        
        public void RefreshDoorPanels()
        {
            foreach (var panel in doorPanels.Where(panel => InventoryUI.Instance.ContainsPlate(panel.timeEra)))
            {
                panel.ActivateButton();
            }
        }

        public void SetUI()
        {
            ShowUI(!isShown);
            isShown = !isShown;
        }
    }
}
