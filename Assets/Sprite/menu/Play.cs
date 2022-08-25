using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    
 public void playbutton()
    {
        SceneManager.LoadScene(0);
    } 
    public void quit()
    {
        Debug.Log("quit");
        Application.Quit();
    }
}
