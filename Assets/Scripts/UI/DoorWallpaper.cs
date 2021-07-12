using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class DoorWallpaper : MonoBehaviour
    {
        [SerializeField] private Sprite wallpaper1;
        [SerializeField] private Sprite wallpaper2;
        [SerializeField] private Sprite wallpaper3;
        [SerializeField] private Sprite wallpaper4;
        [SerializeField] private Sprite wallpaper5;

        private Sprite currentWallpaper;
        private Image doorWallpaper;

        private void Awake()
        {
            doorWallpaper = GetComponent<Image>();
        }

        public void ChangeWallpaper(string scene)
        {
            doorWallpaper.sprite = ChooseWallpaper(scene);
        }

        private Sprite ChooseWallpaper(string scene)
        {
            switch (scene)
            {
                case "Room Early":
                    return wallpaper1;
                
                case "Room MidEarly":
                    return wallpaper2;
                
                case "Room Mid":
                    return wallpaper2;
                
                case "Room MidLate":
                    return wallpaper2;
                
                case "Room Late":
                    return wallpaper2;
                
                default:
                    return null;
            }
        }
    }
}
