using System;
using Managers;
using UI;
using UnityEngine;
using UnityEngine.UI;

public class DoorPanel : MonoBehaviour
{
    [SerializeField] private TimeEra timeEra;
    
    private Button panelButton;

    private void Awake()
    {
        panelButton = GetComponent<Button>();
    }

    private void Start()
    {
        panelButton.onClick.AddListener(delegate { LoadScene(timeEra.ToString()); });
        panelButton.interactable = InventoryUI.Instance.ContainsPlate(timeEra);
    }

    private static void LoadScene(string scene)
    {
        SceneLoader.Instance.FadeSceneLoad("Room " + scene);
    }
}