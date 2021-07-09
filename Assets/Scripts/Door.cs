using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] private CanvasGroup doorCanvas;
    
    private const string CORRIDOR_SCENE = "Corridor";

    public void Interact()
    {
        if (doorCanvas)
        {
            doorCanvas.alpha = 1;
            doorCanvas.blocksRaycasts = true;
            doorCanvas.interactable = true;
        }
        else
        {
            SceneLoader.Instance.FadeSceneLoad(CORRIDOR_SCENE);
        }
    }
}
