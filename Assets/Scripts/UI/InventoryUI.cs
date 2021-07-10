using System;
using System.Collections.Generic;
using System.Linq;
using Inventory;
using Managers;
using UnityEngine;

namespace UI
{
    public class InventoryUI : MonoBehaviour
    {
        [SerializeField] private CanvasGroup canvasGroup;

        [Header("Inventory Slots")]
        [SerializeField] private InventorySlots inventorySlots;

        [Header("Door Plate Slots")] [SerializeField]
        private List<DoorPlateSlots> doorPlateSlots = new List<DoorPlateSlots>();
        
        private readonly List<TimeEra> doorPlates = new List<TimeEra>();
        private readonly List<ItemScriptable> itemList = new List<ItemScriptable>();
        
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
            AddDoorPlate(TimeEra.Early);
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
            switch (itemScriptable.type)
            {
                case ItemType.Item:
                    itemList.Add(itemScriptable);
                    RefreshInventory();
                    break;
                
                case ItemType.DoorPlate:
                    AddDoorPlate(itemScriptable.timeEra);
                    break;
                
                default:
                    return;
            }
        }

        public void SetUI()
        {
            ShowUI(!isShown);
            isShown = !isShown;
        }

        public void AddDoorPlate(TimeEra plate)
        {
            if (doorPlates.Contains(plate)) return;
            
            doorPlates.Add(plate);
            DoorPlateSlots slot = doorPlateSlots.FirstOrDefault(x => x.timeEra == plate);
            slot.ShowPlate();
        }

        public bool ContainsPlate(TimeEra plate)
        {
            return doorPlates.Contains(plate);
        }
    }
}