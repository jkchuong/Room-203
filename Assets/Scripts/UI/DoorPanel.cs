using Managers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class DoorPanel : MonoBehaviour
    {
        public TimeEra timeEra;
    
        private Button panelButton;

        private void Awake()
        {
            panelButton = GetComponent<Button>();
        }

        private void Start()
        {
            panelButton.onClick.AddListener(delegate { LoadScene(timeEra.ToString()); });
        }

        public void ActivateButton()
        {
            panelButton.interactable = true;
        }

        private void LoadScene(string scene)
        {
            if (SceneManager.GetActiveScene().name == "Room " + scene)
            {
                DoorUI.Instance.SetUI(); // Close the door UI since you're in the same scene
            }
            else
            {
                SceneLoader.Instance.FadeSceneLoad("Room " + scene);
            
                // Mute audio if player hasn't played record player yet
                if (!GameManager.Instance.QuestProgressions.Contains(QuestProgression.PlayedRecord) && scene == "Late")
                {
                    StartCoroutine(AudioManager.Instance.MuteAudio());
                }
                else
                {
                    StartCoroutine(AudioManager.Instance.PlayAudio());
                }
            }

            FindObjectOfType<Player>().isPaused = false;
        }
    }
}