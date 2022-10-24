using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenScene : MonoBehaviour
{
    public string sceneName;
    
    public void Open()
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);

    }

}
