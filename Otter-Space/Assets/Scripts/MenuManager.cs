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

	public GameObject MobileSingleStickControl;
	private bool showControl = true;

	public GameObject pauseButton;
	private bool showPause = true;

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

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
            Application.OpenURL("market://details?id=com.cortexarts.otterspace");
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
			MobileSingleStickControl.SetActive (true);
			showControl = true;
			pauseButton.SetActive (true);
			showPause = true;
        }
        else
        {
            optionsMenu.SetActive(true);
            showOptions = true;
			MobileSingleStickControl.SetActive (false);
			showControl = false;
			pauseButton.SetActive (false);
			showPause = false;
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
