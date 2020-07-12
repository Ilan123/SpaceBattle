using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject PauseMenu;
    [SerializeField] GameObject LoseMenu;
    [SerializeField] GameObject scoreGameObj;
    [SerializeField] GameObject deBugMenu;
    private Text scoreTxt;
    public static UIManager instance;


    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        scoreTxt = scoreGameObj.GetComponent<Text>();
    }
    public void TryAgian()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
    public void Resume()
    {
        GameManager.instance.Unpause();
        PauseMenu.SetActive(false);
    }
    public void ShowLoseMenu()
    {
        LoseMenu.SetActive(true);
    }
    public void ShowPauseMenu()
    {
        GameManager.instance.Pause();
        PauseMenu.SetActive(true);
    }

    public void SetScore(int score)
    {
        scoreTxt.text = scoreTxt.text = "Score: " + score;
    }

    public void SetPlayerSpeed(string speed)
    {
        Movement.instance.startSpeed = float.Parse(speed);
        Debug.Log("IN: " + speed);
        Debug.Log(Movement.instance.startSpeed);
    }

    public void SetGameSpeed(string speed)
    {
        GameManager.instance.setGameSpeed(float.Parse(speed));
    }

    public void LockCameraY(bool lockcam)
    {
        Camera.main.GetComponent<ObjectFollowRelativly>().followY = lockcam;
    }

    public void LockCameraX(bool lockcam)
    {
        Camera.main.GetComponent<ObjectFollowRelativly>().followX = lockcam;
    }

    public void showDebugMenu()
    {
        PauseMenu.SetActive(false);
        deBugMenu.SetActive(true);
    }

    public void quitDeBugMenu()
    {
        PauseMenu.SetActive(true);
        deBugMenu.SetActive(false);
    }

}
