using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class LevelCount : MonoBehaviour
{

    private Text levelText;

    void Awake()
    {
        levelText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        levelText.text = "LEVEL: " + GameMaster.CurrentLevel.ToString();
    }
}
