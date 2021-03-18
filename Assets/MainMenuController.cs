using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class MainMenuController : MonoBehaviour
{
    public void multiplayer() {
        SceneManager.LoadScene(5);
    }
 
    public void campaign() {
        SceneManager.LoadScene(5);
    }
 
    public void exitGame() {
        Application.Quit();
    }
}