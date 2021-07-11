using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class DoorBack : MonoBehaviour
    {
        private Button btn;

        private void Awake()
        {
            btn = GetComponent<Button>();
        }

        private void Start()
        {
            btn.onClick.AddListener(ExitDoorCanvas);
        }

        private static void ExitDoorCanvas()
        {
            DoorUI.Instance.SetUI();
        }
    }
}