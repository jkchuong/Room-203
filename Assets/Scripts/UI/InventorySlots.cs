using System.Collections.Generic;
using Inventory;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class InventorySlots : MonoBehaviour
    {
        private List<InventoryButton> buttonList = new List<InventoryButton>();
        private List<Image> imageList = new List<Image>();

        private void Start()
        {
            foreach (Transform child in transform)
            {
                Transform itemButton = child.GetChild(0);
                Transform itemImage = itemButton.GetChild(0);
                
                buttonList.Add(itemButton.GetComponent<InventoryButton>());
                imageList.Add(itemImage.GetComponent<Image>());
            }
        }

        public void ActivateButton(int index, ItemScriptable itemScriptable)
        {
            buttonList[index].ActivateButton(itemScriptable);
            imageList[index].sprite = itemScriptable.display;
        }
    }
}
