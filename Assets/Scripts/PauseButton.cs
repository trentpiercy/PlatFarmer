using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PauseButton : MonoBehaviour
{
    public Text buttonText;
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(TogglePause);
    }
    public void TogglePause()
    {
        
        Time.timeScale = Mathf.Approximately(Time.timeScale, 0.0f) ? 1.0f : 0.0f;
        Debug.Log(Time.timeScale);
        if (Time.timeScale==0.0f)
        {
            Debug.Log("Paused");
            buttonText.text = "Resume";
            GetComponent<Button>().GetComponent<Image>().color = Color.green;
        } else
        {
            Debug.Log("Resumed");
            buttonText.text = "Pause";
            GetComponent<Button>().GetComponent<Image>().color = Color.gray;

        }
    }

}