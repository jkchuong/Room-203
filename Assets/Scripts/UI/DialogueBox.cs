using System.Collections;
using Inventory;
using TMPro;
using UnityEngine;

namespace UI
{
    public class DialogueBox : MonoBehaviour
    {
        [SerializeField] private Color32 textColor;
        private TextMeshProUGUI textMeshPro;

        private void Awake()
        {
            textMeshPro = GetComponent<TextMeshProUGUI>();
        }

        private void Start()
        {
            ChangeTextAlpha(0);
        }

        private void ChangeTextAlpha(byte alpha)
        {
            textColor.a = alpha;
            textMeshPro.faceColor = textColor;
        }

        public IEnumerator ShowPickupText(ItemScriptable itemScriptable)
        {
            textMeshPro.text = "Obtained " + itemScriptable.title;

            ChangeTextAlpha(255);

            yield return new WaitForSeconds(3f);

            ChangeTextAlpha(0);
        }
    }
}