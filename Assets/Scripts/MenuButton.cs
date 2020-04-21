using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuButton : MonoBehaviour
{
    public Button buttonStart;
    public Button buttonQuit;
    void Start()
{
        var play = buttonStart.GetComponent<Button>();
        play.onClick.AddListener(startGame);
        var leave = buttonQuit.GetComponent<Button>();
        leave.onClick.AddListener(endGame);

    }
void startGame()
{
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void endGame()
    {
        Debug.Log("Quit Game~");
        Application.Quit();
    }
}
