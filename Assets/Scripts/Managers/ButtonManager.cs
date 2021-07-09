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
    }
}