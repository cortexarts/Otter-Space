using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ExpCount : MonoBehaviour
{

    private Text expText;

    void Awake()
    {
        expText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        expText.text = "EXP: " + GameMaster.CurrentExperience.ToString();
    }
}
