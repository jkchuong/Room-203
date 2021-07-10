using System;
using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class DoorPlateSlots : MonoBehaviour
    {
        public TimeEra timeEra;
        
        [SerializeField] private Sprite plateSilhouette;
        [SerializeField] private Sprite plateShown;

        private Image plateImage;

        private void Awake()
        {
            plateImage = GetComponent<Image>();
            plateImage.sprite = plateSilhouette;
        }

        public void ShowPlate()
        {
            plateImage.sprite = plateShown;
        }
    }
}