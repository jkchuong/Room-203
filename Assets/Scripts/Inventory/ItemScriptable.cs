using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory
{
    [CreateAssetMenu(fileName = "New Item", menuName = "ScriptableObjects/ItemScriptable")]
    public class ItemScriptable : ScriptableObject
    {
        public ItemType type;
        public TimeEra timeEra;
        
        public Sprite display;
        public string title;
        
        [TextArea(5, 15)]
        public string description;
    }
}
