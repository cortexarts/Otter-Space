using UnityEngine;
using UnityEngine.UI;

public class UpgradeMenu : MonoBehaviour {

	[SerializeField]
	private Text healthText;

	[SerializeField]
	private Text speedText;

	[SerializeField]
	private int healthIncremention = 50;

	[SerializeField]
	private int movementSpeedIncremention = 20;

    [SerializeField]
    private int upgradeCost = 50;

	private PlayerStats stats;

	void OnEnable ()
	{
		stats = PlayerStats.instance;
		UpdateValues();
    }

	void UpdateValues ()
	{
		healthText.text = "HEALTH: " + stats.maxHealth.ToString();
		speedText.text = "SPEED: " + stats.movementSpeed.ToString();
    }

	public void UpgradeHealth ()
	{
        if (GameMaster.Money < upgradeCost)
        {
            AudioManager.instance.PlaySound("NoMoney");
            return;
        }
		stats.maxHealth = (int)(stats.maxHealth + healthIncremention);
        GameMaster.Money -= upgradeCost;
        AudioManager.instance.PlaySound("EnoughMoney");
        UpdateValues();
	}

	public void UpgradeSpeed()
	{
        if (GameMaster.Money < upgradeCost)
        {
            AudioManager.instance.PlaySound("NoMoney");
            return;
        }
        stats.movementSpeed = (int)(stats.movementSpeed + movementSpeedIncremention);
        GameMaster.Money -= upgradeCost;
        AudioManager.instance.PlaySound("EnoughMoney");
        UpdateValues();
	}

}
