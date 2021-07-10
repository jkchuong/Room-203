using System;
using UI;
using UnityEngine;

namespace Interactions
{
    public class ShowUI : MonoBehaviour, IInteractable
    {
        private Player player;

        private void Start()
        {
            player = FindObjectOfType<Player>();
        }

        public void Interact()
        {
            DoorUI.Instance.SetUI();
        }
    }
}
