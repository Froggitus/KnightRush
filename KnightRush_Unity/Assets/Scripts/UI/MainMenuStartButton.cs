using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuStartButton : MonoBehaviour
{
    public Button startButton;

    void Start()
    {
        Button btn = startButton.GetComponent<Button>();
        btn.onClick.AddListener(startGameOnClick);
    }

    void startGameOnClick()
    {
        Debug.Log("start");
        SceneManager.LoadScene("LevelMVP", LoadSceneMode.Single);
        Debug.Log("loaded");
    }
}
