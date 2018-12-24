using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_Button : MonoBehaviour {

    
    public void StartButton()
    {
        this.GetComponent<AudioSource>().Play();
        SceneManager.LoadScene("Main");
    }

    public void title()
    {
        this.GetComponent<AudioSource>().Play();
        SceneManager.LoadScene("Start");
    }
}
