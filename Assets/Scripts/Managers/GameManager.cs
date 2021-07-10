﻿using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            } 
            else 
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }
    }
}
