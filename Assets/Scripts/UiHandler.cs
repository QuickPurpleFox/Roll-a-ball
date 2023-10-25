using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiHandler : MonoBehaviour
{
    public void StartGameButton()
    {
        SceneManager.LoadScene("FirstScene");
    }

    public void QuitGameButton()
    {
        Application.Quit();
    }
}
