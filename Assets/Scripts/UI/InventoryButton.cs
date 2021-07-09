using Inventory;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class InventoryButton : MonoBehaviour
    {
        [Header("Item Display")]
        [SerializeField] private Image itemDisplayImage;
        [SerializeField] private TextMeshProUGUI itemTitle;
        [SerializeField] private TextMeshProUGUI itemDescription;
        
        [SerializeField] private ItemScriptable item;
        
        private Button btn;

        private void Awake()
        {
            btn = GetComponent<Button>();
            btn.interactable = false;
        }

        public void ActivateButton(ItemScriptable itemScriptable)
        {
            item = itemScriptable;
            btn.interactable = true;
            btn.onClick.AddListener(delegate { UpdateItemDisplay(item); });
        }

        private void UpdateItemDisplay(ItemScriptable itemScriptable)
        {
            itemDisplayImage.color = Color.white;
            itemDisplayImage.sprite = itemScriptable.display;
            itemTitle.text = itemScriptable.title;
            itemDescription.text = itemScriptable.description;
        }
    }
}