using UnityEngine;
using UnityEngine.SceneManagement;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class MenuManager : MonoBehaviour
{

    public static MenuManager instance;

    [SerializeField]
    string hoverOverSound = "ButtonHover";

    [SerializeField]
    string pressButtonSound = "ButtonPress";

    AudioManager audioManager;

    public GameObject audioListener;
    private bool muted = false;

    public GameObject credits;
    private bool showCredits = false;

    public GameObject optionsMenu;
    private bool showOptions = false;

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
            audioListener.SetActive(false);
            muted = false;
        }
        else
        {
            audioListener.SetActive(true);
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
        Application.OpenURL("market://details?id=com.CortexArts.OtterSpace");
    }

    public void ToggleHighScore()
    {
        Social.ShowLeaderboardUI();
    }

    public void ToggleOptions() {
        if (showOptions)
        {
            optionsMenu.SetActive(false);
            showOptions = false;
        }
        else
        {
            optionsMenu.SetActive(true);
            showOptions = true;
        }
    }

    public void Authenticate()
    {
        Social.localUser.Authenticate((bool success) => {
            if (success)
            {
                Debug.Log("LOGGED IN!");
            }
            else
            {
                Debug.Log("NOT LOGGED IN!");
            }
        });
    }
}
