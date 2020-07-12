using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject player;

    [SerializeField] AudioSource themeMusic;
    [SerializeField] float playerBoostRate = 1.5f;
    [SerializeField] float timeToActiveThePlayerBoost = 100f;
    [SerializeField] float timeBoostRate = 1.5f;
    [SerializeField] float timeToActiveThetimeBoost = 100f;
    private float timeScale;
    private bool hasPlayerBeenBoosted = false;
    private bool hasTimeBeenBoosted = false;
    public static GameManager instance;
    private float playerScore;
    private float playerPrevScore;
    private void Awake()
    {
        timeScale = 1f;
        hasPlayerBeenBoosted = false;
        hasTimeBeenBoosted = false;

        if (timeToActiveThePlayerBoost < 0)
            hasPlayerBeenBoosted = true;

        if (timeToActiveThetimeBoost < 0)
            hasTimeBeenBoosted = true;
    }

    public bool HasBeenBoosted()
    {
        return hasPlayerBeenBoosted || hasTimeBeenBoosted;
    }

    // Start is called before the first frame update
    void Start()
    {
        timeScale = 1f;
        Time.timeScale = timeScale;
        GameManager.instance = this;
    }
    private void Reset()
    {
        timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasPlayerBeenBoosted && Time.time > timeToActiveThePlayerBoost)
        {
            Debug.Log("The Player Has Been Boosted!");
            Debug.Log(Time.time);
            player.GetComponent<Movement>().ScaleUp(playerBoostRate);
            hasPlayerBeenBoosted = true;
        }
        if(!hasTimeBeenBoosted && Time.time > timeToActiveThetimeBoost)
        {
            Debug.Log("The Time Has Been Boosted!");
            Debug.Log(Time.time);
            timeScale *= timeBoostRate;
            Time.timeScale = timeScale;
            hasTimeBeenBoosted = true;
        }

        playerScore += Time.deltaTime;

        if ((int)playerScore - (int)playerPrevScore >= 1)
            UIManager.instance.SetScore((int)playerScore);
    }

    public void Lose()
    {
        Debug.Log("You Lost");
        Time.timeScale = 0;
        themeMusic.Stop();
        UIManager.instance.ShowLoseMenu();
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void Unpause()
    {
        Time.timeScale = timeScale;
    }

    public void setGameSpeed(float speed)
    {
        timeScale = speed;
    }
}
