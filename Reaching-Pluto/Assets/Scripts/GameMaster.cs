using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;
using System.Collections.Generic;

public class GameMaster : MonoBehaviour
{
    public static GameMaster gm;

    [SerializeField]
    private int maxLevel = 100;
    public static int _curLevel;
    public static int CurrentLevel
    {
        get { return _curLevel; }
    }

    [SerializeField]
    private int maxExp = 100;
    public static int _curExp;
    public static int CurrentExperience
    {
        get { return _curExp; }
    }

    public string LevelUp = "LevelUp";

    [SerializeField]
    private int maxLives = 3;
    private static int _remainingLives;
    public static int RemainingLives
    {
        get { return _remainingLives; }
    }

    [SerializeField]
    private int startingMoney;
    public static int Money;

    void Awake()
    {
        if (gm == null)
        {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        }
    }

    public List<Transform> loot = new List<Transform>();

    public Transform playerPrefab;
    public Transform spawnPoint;
    public float spawnDelay = 2;
    public Transform spawnPrefab;
    public string respawnCountdownSoundName = "RespawnCountdown";
    public string spawnSoundName = "Spawn";

    public string gameOverSoundName = "GameOver";

    public CameraShake cameraShake;

    [SerializeField]
    private GameObject gameOverUI;

    [SerializeField]
    private GameObject upgradeMenu;

    [SerializeField]
    private GameObject escapeMenu;

    [SerializeField]
    private WaveSpawner waveSpawner;

    public delegate void UpgradeMenuCallback(bool active);
    public UpgradeMenuCallback onToggleUpgradeMenu;

    public delegate void EscapeMenuCallback(bool active);
    public EscapeMenuCallback onToggleEscapeMenu;

    //cache
    private AudioManager audioManager;

    void Start()
    {
        if (cameraShake == null)
        {
            Debug.LogError("No camera shake referenced in GameMaster");
        }

        _remainingLives = maxLives;

        Money = startingMoney;

        //caching
        audioManager = AudioManager.instance;
        if (audioManager == null)
        {
            Debug.LogError("FREAK OUT! No AudioManager found in the scene.");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            ToggleUpgradeMenu();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleEscapeMenu();
        }
        if (_curLevel < maxLevel)
        {
            if (_curExp >= maxExp)
            {
                _curExp = 1;
                _curLevel++;
                audioManager.PlaySound(LevelUp);
            }
        }
    }

    private void ToggleEscapeMenu()
    {
        escapeMenu.SetActive(!escapeMenu.activeSelf);
        waveSpawner.enabled = !escapeMenu.activeSelf;
        onToggleEscapeMenu.Invoke(escapeMenu.activeSelf);
    }

    private void ToggleUpgradeMenu()
    {
        upgradeMenu.SetActive(!upgradeMenu.activeSelf);
        waveSpawner.enabled = !upgradeMenu.activeSelf;
        onToggleUpgradeMenu.Invoke(upgradeMenu.activeSelf);
    }

    public void EndGame()
    {
        audioManager.PlaySound(gameOverSoundName);
        Debug.Log("GAME OVER");
        gameOverUI.SetActive(true);
    }

    public IEnumerator _RespawnPlayer()
    {
        audioManager.PlaySound(respawnCountdownSoundName);
        yield return new WaitForSeconds(spawnDelay);
        audioManager.PlaySound(spawnSoundName);
        Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
        GameObject clone = Instantiate(spawnPrefab, spawnPoint.position, spawnPoint.rotation) as GameObject;
        Destroy(clone, 3f);
    }

    public static void KillPlayer(Player player)
    {
        Destroy(player.gameObject);
        _remainingLives -= 1;
        if (_remainingLives <= 0)
        {
            gm.EndGame();
        }
        else
        {
            gm.StartCoroutine(gm._RespawnPlayer());
        }
    }

    public static void KillEnemy(Enemy enemy)
    {
        gm._KillEnemy(enemy);
    }
    public void _KillEnemy(Enemy _enemy)
    {

        // Spawn reward with a given percent chance
        int lootPercentChance = 40;

        if (Random.Range(1, 100) <= lootPercentChance)
        {
            Instantiate(loot[Random.Range(0, loot.Count - 1)], _enemy.transform.position, Quaternion.identity);
        }
        // Let's play some sound
        audioManager.PlaySound(_enemy.deathSoundName);

        //Add experience and money
        _curExp += 20;
        Money += _enemy.moneyDrop;
        // Add particles
        GameObject _clone = Instantiate(_enemy.deathParticles, _enemy.transform.position, Quaternion.identity) as GameObject;
        Destroy(_clone, 5f);

        // Go camerashake
        cameraShake.Shake(_enemy.shakeAmt, _enemy.shakeLength);
        Destroy(_enemy.gameObject);
    }


public static void KillFinalBoss(FinalBoss FinalBoss)
    {
        gm._KillFinalBoss(FinalBoss);
    }
    public void _KillFinalBoss(FinalBoss _FinalBoss)
    {

        // Spawn reward
        Instantiate(_FinalBoss.reward, _FinalBoss.transform.position, Quaternion.identity);

        // Let's play some sound
        audioManager.PlaySound(_FinalBoss.deathSoundName);

        //Add experience and money
        _curExp += 40;
        Money += _FinalBoss.moneyDrop;

        // Add particles
        GameObject _clone = Instantiate(_FinalBoss.deathParticles, _FinalBoss.transform.position, Quaternion.identity) as GameObject;
        Destroy(_clone, 5f);

        // Go camerashake
        cameraShake.Shake(_FinalBoss.shakeAmt, _FinalBoss.shakeLength);
        Destroy(_FinalBoss.gameObject);
    }

}
