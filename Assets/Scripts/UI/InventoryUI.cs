using System.Collections.Generic;
using Inventory;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class InventoryUI : MonoBehaviour
    {
        [SerializeField] private CanvasGroup canvasGroup;

        [Header("Inventory Slots")]
        [SerializeField] private InventorySlots inventorySlots;
        
        private List<ItemScriptable> itemList = new List<ItemScriptable>();
        private bool isShown;

        public static InventoryUI Instance;
        
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
        }
        
        private void Start()
        {
            ShowUI(false);
        }

        private void ShowUI(bool show)
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
        
        private void RefreshInventory()
        {
            for (int i = 0; i < itemList.Count; i++)
            {
                inventorySlots.ActivateButton(i, itemList[i]);    
            }
        }

        public void AddItem(ItemScriptable itemScriptable)
        {
            itemList.Add(itemScriptable);
            RefreshInventory();
        }

        public void SetUI()
        {
            ShowUI(!isShown);
            isShown = !isShown;
        }
    }
}
