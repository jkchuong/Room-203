using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;

public class Loader : MonoBehaviour
{
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(8f);
        
        SceneLoader.Instance.FadeSceneLoad("Menu");
    }
    
    
}
