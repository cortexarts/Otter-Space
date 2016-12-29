using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    [SerializeField]
    string hoverOverSound = "ButtonHover";

    [SerializeField]
    string pressButtonSound = "ButtonPress";

    AudioManager audioManager;

    public GameObject audioListener;
    private bool muted = false;

    public GameObject credits;
    private bool showCredits;

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
            Application.OpenURL("market://details?id=com.nianticlabs.pokemongo");
    }

    public void ToggleHighScore()
    {
        Application.OpenURL("market://details?id=com.nianticlabs.pokemongo");
    }
}
