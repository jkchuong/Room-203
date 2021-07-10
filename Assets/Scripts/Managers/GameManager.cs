using System;
using System.Collections.Generic;
using Inventory;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        public List<QuestProgression> QuestProgressions = new List<QuestProgression>();
        
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

        private void Start()
        {
            QuestProgressions.Add(QuestProgression.Default);
        }
    }
}
