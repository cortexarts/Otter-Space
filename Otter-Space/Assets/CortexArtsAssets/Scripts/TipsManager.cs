using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipsManager : MonoBehaviour
{
    public Text tooltip;
    public GameObject tooltipCont;

    public enum State
    {
        ONE,
        TWO,
        THREE,
    }

    public State state;

    public void NexState()
    {
        if (state == State.ONE)
        {
            state = State.TWO;
        }
    }

    // Update is called once per frame
    void Update () {
        if (state == State.ONE)
        {
            tooltip.text = "Click on the Back button or Escape to open the pause menu. Click on this box to remove it.";
        }
        else if (state == State.TWO)
        {
            tooltip.gameObject.SetActive(false);
            tooltipCont.SetActive(false);
        }
    }
}
