using UnityEngine;
using UnityEngine.UI;

namespace Inventory
{
    [CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/ItemScriptable")]
    public class ItemScriptable : ScriptableObject
    {
        public Sprite display;
        public string title;
        
        [TextArea(5, 15)]
        public string description;
    }
}
