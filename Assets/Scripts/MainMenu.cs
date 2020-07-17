using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Text scoreTxt;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        scoreTxt.text = "Best Score: " + PlayerPrefs.GetInt("BestScore", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touches.Length > 0 || Input.GetMouseButton(0))
        {
            SceneManager.LoadScene("Game", LoadSceneMode.Single);
        }

    }
}
