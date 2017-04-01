using System;
using System.Collections.Generic;
using System.Linq;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using GooglePlayGames.BasicApi.Multiplayer;
using GooglePlayGames.BasicApi.Quests;
using GooglePlayGames.BasicApi.SavedGame;
using GooglePlayGames.OurUtils;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;

    [SerializeField]
    string hoverOverSound = "ButtonHover";

    [SerializeField]
    string pressButtonSound = "ButtonPress";

    AudioManager audioManager;

    private bool muted = false;

    public GameObject credits;
    private bool showCredits = false;

    public GameObject pauseMenu;
    private bool showPause = false;

	public GameObject pauseButton;

    public GameObject mutedBtn;
    public GameObject UnmutedBtn;

    public GameObject UpgradeUI;
    bool upgradeEnabled = false;

    void Start()
    {
        audioManager = AudioManager.instance;
        if (audioManager == null)
        {
            Debug.LogError("No audiomanager found!");
        }
    }

    public void StartGame()
    {
        audioManager.PlaySound(pressButtonSound);

        if (!PlayerPrefs.HasKey("SavedLevel") || PlayerPrefs.GetInt("SavedLevel") != 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("SavedLevel", 1);
            PlayerPrefs.Save();
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
            PlayerPrefs.SetInt("SavedLevel", 2);
            PlayerPrefs.Save();
        }
    }

    public void QuitGame()
    {
        audioManager.PlaySound(pressButtonSound);

        Debug.Log("WE QUIT THE GAME!");
        Application.Quit();
    }

    public void OnMouseOver()
    {
        audioManager.PlaySound(hoverOverSound);
    }

    public void ToggleMute() {
        if (muted)
        {
            AudioListener.volume = 0.0f;
            UnmutedBtn.SetActive(true);
            mutedBtn.SetActive(false);
            muted = false;
        }
        else
        {
            AudioListener.volume = 1.0f;
            mutedBtn.SetActive(true);
            UnmutedBtn.SetActive(false);
            muted = true;
        }
    }

    public void ToggleCredits() {
        if (showCredits)
        {
            credits.SetActive(false);
            showCredits = false;
        }
        else
        {
            credits.SetActive(true);
            showCredits = true;
        }
    }

    public void ShowRate()
    {
        Debug.Log("Showing app page!");
        Application.OpenURL("market://details?id=com.CortexArts.OtterSpace");
    }

    public void ToggleHighScore()
    {
        Debug.Log("Showing highscore!");
        PlayGamesPlatform.Instance.ShowLeaderboardUI("CgkIofG9zvYSEAIQBg");
    }

    public void TogglePause() {
        if (showPause)
        {
            if (muted)
            {
                AudioListener.volume = 1.0f;
            }
            else
            {
                AudioListener.volume = 0.0f;
            }
            pauseMenu.SetActive(false);
			pauseButton.SetActive(true);
			Time.timeScale = 1;
            showPause = false;
        }
        else
        {
            if (muted)
            {
                AudioListener.volume = 1.0f;
            }
            else
            {
                AudioListener.volume = 0.0f;
            }
            pauseMenu.SetActive(true);
			pauseButton.SetActive(false);
			Time.timeScale = 0;
            showPause = true;
        }
    }

    public void Authenticate()
    {
        PlayGamesPlatform.Activate();
        PlayGamesPlatform.Instance.Authenticate((bool success) =>
        {
            if (success)
            {
                Debug.Log("Login succesful!");
            }
            else
            {
                Debug.Log("Login failed!");
            }
        });
    }

    public void SkipScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ToggleUpgradeUI()
    {
        if (upgradeEnabled)
        {
            UpgradeUI.SetActive(true);
            upgradeEnabled = false;
        }
        else
        {
            UpgradeUI.SetActive(false);
            upgradeEnabled = true;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().name == "MainMenu")
            {
                Debug.Log("Quit game!");
                ((PlayGamesPlatform)Social.Active).SignOut();
                Application.Quit();
            }
            else
            {
                TogglePause();
            }
        }
    }
}
