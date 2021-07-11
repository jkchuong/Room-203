using Managers;
using UnityEngine;

namespace Interactions
{
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
}
