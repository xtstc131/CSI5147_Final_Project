using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinishFinal : MonoBehaviour
{

    public Button buttonQuit;
    void Start()
    {

        var leave = buttonQuit.GetComponent<Button>();
        leave.onClick.AddListener(endGame);

    }

    void endGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
}
