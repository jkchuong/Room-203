using System;
using System.Collections;
using System.Collections.Generic;
using Inventory;
using Managers;
using UnityEngine;

public class Hole : MonoBehaviour
{
    private void Start()
    {
        if (GameManager.Instance.QuestProgressions.Contains(QuestProgression.MovedLamp))
        {
            Destroy(gameObject);
        }
    }
}
