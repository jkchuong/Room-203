using Managers;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    private static void LoadScene(string scene)
    {
        if (SceneManager.GetActiveScene().name == "Room " + scene)
        {
            DoorUI.Instance.SetUI(); // Close the door UI since you're in the same scene
        }
        else
        {
            SceneLoader.Instance.FadeSceneLoad("Room " + scene);
        }

        FindObjectOfType<Player>().isPaused = false;
    }
}