using UnityEngine;
using System.Collections;

[RequireComponent(typeof(EnemyAI))]
public class FinalBoss : MonoBehaviour
{

    [System.Serializable]
    public class FinalBossStats
    {
        public int maxHealth = 100;

        private int _curHealth;
        public int curHealth
        {
            get { return _curHealth; }
            set { _curHealth = Mathf.Clamp(value, 0, maxHealth); }
        }

        public int damage = 40;

        public void Init()
        {
            curHealth = maxHealth;
        }
    }

    public FinalBossStats stats = new FinalBossStats();

    public Transform deathParticles;
    public Transform reward;

    public int moneyDrop = 20;

    public float shakeAmt = 0.1f;
    public float shakeLength = 0.1f;

    public string deathSoundName = "Explosion";

    [Header("Optional: ")]
    [SerializeField]
    private StatusIndicator statusIndicator;

    void Start()
    {
        stats.Init();

        if (statusIndicator != null)
        {
            statusIndicator.SetHealth(stats.curHealth, stats.maxHealth);
        }

        GameMaster.gm.onToggleUpgradeMenu += OnUpgradeMenuToggle;
        GameMaster.gm.onToggleEscapeMenu += OnEscapeMenuToggle;

        if (deathParticles == null)
        {
            Debug.LogError("No death particles referenced on Enemy");
        }
    }

    public void DamageEnemy(int damage)
    {
        stats.curHealth -= damage;
        if (stats.curHealth <= 0)
        {
            GameMaster.KillFinalBoss(this);
        }

        if (statusIndicator != null)
        {
            statusIndicator.SetHealth(stats.curHealth, stats.maxHealth);
        }
    }

    void OnUpgradeMenuToggle(bool active)
    {
        GetComponent<EnemyAI>().enabled = !active;
    }
    void OnEscapeMenuToggle(bool active)
    {
        GetComponent<EnemyAI>().enabled = !active;
    }

    void OnCollisionEnter2D(Collision2D _colInfo)
    {
        Player _player = _colInfo.collider.GetComponent<Player>();
        if (_player != null)
        {
            Debug.Log("Enemy health: " + stats.curHealth);
            _player.DamagePlayer(stats.damage);
            DamageEnemy(9999999);
        }
    }
    void OnDestroy()
    {
        GameMaster.gm.onToggleUpgradeMenu -= OnUpgradeMenuToggle;
        GameMaster.gm.onToggleEscapeMenu -= OnEscapeMenuToggle;
    }
}
