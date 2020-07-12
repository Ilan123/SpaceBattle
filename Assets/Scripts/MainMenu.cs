using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
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
