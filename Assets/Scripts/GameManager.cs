using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private float score = 0;
    public Text scoreValueText;
    public Text finalScoreText;
    public GameObject energyBar;
    public Slider timer;

    public Slider rechargeBar;

    private float velocityModifier = 1f;
    private bool paused = false;

    public GameObject player;
    public Text stageText;

    [Header("Main Menu Panels")]
    public GameObject mainmenuPanel;
    public GameObject configsPanel;
    public GameObject controlsPanel;
    public GameObject creditsPanel;

    [Header("Prefabs")]
    public GameObject powerupPrefab;
    public GameObject bossPrefab;
    public GameObject bossHealthBar;

    [Header("UI Panels")]
    public GameObject winPanel;
    public GameObject losePanel;
    public GameObject pausePanel;


    private void Start()
    {
        Time.timeScale = 1f;
        if (energyBar != null)
        {
            timer = energyBar.GetComponent<Slider>();
        }

        float savedScore = PlayerPrefs.GetFloat("Score", 0);
        score = savedScore;
        
        if (scoreValueText != null)
        {
            scoreValueText.text = score.ToString(); // Updates score text
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (VelocityController.instance != null)
        {
            velocityModifier = VelocityController.instance.velocityModifier;
        }

        // If player ran out of time, trigger game over
        if (timer != null && timer.value <= 0)
        {
            Lose();
        }

        // Open or close pause screen
        if (pausePanel != null && Input.GetKeyDown(KeyCode.Escape))
        {
            if (!paused)
            {
                PauseGame();
            }
            else
            {
                UnpauseGame();
            }
        }

        // Check input to recharge ship's energy
        if (Input.GetKeyDown(KeyCode.K))
        {
            RechargeEnergyBar();
        }

        // Game cheat to change levels easily
        if (Input.GetKeyDown(KeyCode.F1))
        {
            StartLevel1(); // Loads Level 1
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            StartLevel2(); // Loads Level 2
        }
    }

    public void SpawnPowerUp(Vector3 position)
    {
        Instantiate(powerupPrefab, position, Quaternion.identity);
    }
    
    public void Score(float points)
    {
        score += points * velocityModifier;
        scoreValueText.text = score.ToString();
    }

    public void FillRechargeBar(float energy)
    {
        rechargeBar.value += energy * velocityModifier;
    }

    public void RechargeEnergyBar()
    {
        timer.value += rechargeBar.value;
        rechargeBar.value = 0f;
    }

    public void Win()
    {
        bossHealthBar.SetActive(false);
        winPanel.SetActive(true);
        if (finalScoreText != null)
        {
            finalScoreText.text = score.ToString();
        }
        PlayerPrefs.SetFloat("Score", 0); // Resets player score for next playthrough
        Time.timeScale = 0f;
    }

    public void Lose()
    {
        Destroy(GameObject.Find("Player")); // Destroy player's ship
        //AudioController.instance.PlaySFX(3);

        losePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void StartBossBattle()
    {
        ClearBullets();
        AudioController.instance.PlayBGMusic(3);

        // Replenish player's energy and deactivates loss of energy through time
        timer.value = timer.maxValue;
        energyBar.GetComponent<Timer>().enabled = false;

        bossHealthBar.SetActive(true);

        Invoke("SpawnBoss", 10f);
    }

    void SpawnBoss()
    {
        Instantiate(bossPrefab);
    }

    public void OpenMainMenu()
    {
        SceneManager.LoadScene(0);
        AudioController.instance.PlayBGMusic(0);
    }

    public void ActivateMainMenuPanel()
    {
        configsPanel.SetActive(false);
        controlsPanel.SetActive(false);
        creditsPanel.SetActive(false);
        mainmenuPanel.SetActive(true);
    }


    public void OpenConfigMenu()
    {
        mainmenuPanel.SetActive(false);
        configsPanel.SetActive(true);
    }

    public void OpenControlsMenu()
    {
        mainmenuPanel.SetActive(false);
        controlsPanel.SetActive(true);
    }

    public void OpenCreditsMenu()
    {
        mainmenuPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }

    public void StartLevel1()
    {
        PlayerPrefs.SetFloat("Score", 0); // Resets player score
        SceneManager.LoadScene(1);
        AudioController.instance.PlayBGMusic(1);
    }

    public void StartLevel2()
    {
        PlayerPrefs.SetFloat("Score", score); // Updates player score
        SceneManager.LoadScene(2);
        AudioController.instance.PlayBGMusic(2);
    }

    public void TransitionToLevel2()
    {
        ClearBullets();
        
        // Show Stage Cleared message
        stageText.text = "Stage Cleared";
        stageText.enabled = true;

        energyBar.GetComponent<Timer>().enabled = false; // Deactivates loss of health over time

        Invoke("AnimatePlayerExitStage", 2f);
        Invoke("StartLevel2", 4f);
    }

    public void ClearBullets()
    {
        // Destroy all enemy bullets on screen
        GameObject[] bulletsOnScreen = GameObject.FindGameObjectsWithTag("EnemyBullet");
        for (int i = 0; i < bulletsOnScreen.Length; i++)
        {
            Destroy(bulletsOnScreen[i]);
        }
    }

    void AnimatePlayerExitStage()
    {
        player.GetComponent<PlayerControl>().enabled = false; // Disables player input
        player.GetComponent<ExitStage>().enabled = true;
    }

    public void PauseGame()
    {
        paused = true;
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void UnpauseGame()
    {
        paused = false;
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }



    public void QuitGame()
    {

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Quit in Unity Editor
#endif

        Application.Quit(); // Quit in build
    }
}
