using System.Collections;
using Inventory;
using TMPro;
using UnityEngine;

namespace UI
{
    public class DialogueBox : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI dialogueBox;
        [SerializeField] private Color32 textColor;
        private TextMeshProUGUI textMeshPro;

        private void Awake()
        {
            textMeshPro = GetComponent<TextMeshProUGUI>();
        }

        private void Start()
        {
            ChangeTextAlpha(0, dialogueBox);
            ChangeTextAlpha(0, textMeshPro);
        }

        private void ChangeTextAlpha(byte alpha, TextMeshProUGUI box)
        {
            textColor.a = alpha;
            box.faceColor = textColor;
        }

        public IEnumerator ShowPickupText(ItemScriptable itemScriptable)
        {
            textMeshPro.text = "Obtained " + itemScriptable.title;

            ChangeTextAlpha(255, textMeshPro);

            yield return new WaitForSeconds(3f);

            ChangeTextAlpha(0, textMeshPro);
        }

        public IEnumerator ShowDialogue(string dialogue)
        {
            dialogueBox.text = dialogue;

            ChangeTextAlpha(255, dialogueBox);

            yield return new WaitForSeconds(5f);

            ChangeTextAlpha(0, dialogueBox);
        }
    }
}