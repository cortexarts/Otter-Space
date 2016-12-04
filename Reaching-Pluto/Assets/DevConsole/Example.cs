using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DevConsole;   

public class Example:MonoBehaviour {

    float deltaTime = 0.0f;
    bool displayToggled = false;

    void Start(){
		Console.AddCommand(new Command<string>("TIME_TIMESCALE", TimeScale));
		Console.AddCommand(new Command<string>("TIME_SHOWTIME", ShowTime));
		Console.AddCommand(new Command<string>("PHYSICS_GRAVITY_X", XGravity));
		Console.AddCommand(new Command<string>("PHYSICS_GRAVITY_Y", YGravity));
		Console.AddCommand(new Command<string>("PHYSICS_GRAVITY_Z", ZGravity));
		Console.AddCommand(new Command<string>("HELP",DisplayHelp, CommandHelp));
        Console.AddCommand(new Command<string>("SHOW_FPS", DisplayFPS));
    }

    void Update()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
    }

    static void DisplayHelp(string args){
		Console.Log("Type DisplayHelp? to use this command");
	}
	static void CommandHelp(){
        
        string unColoredText = "Command info will be added later";
		while (unColoredText != string.Empty){
			string coloredText = string.Empty;
			int i = 0;
			for (i = 0; i < unColoredText.Length; i++){
				if (unColoredText[i] == ' ')
					break;
				coloredText+=unColoredText[i];
			}
			Color color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
			Console.Log(coloredText, color);
			unColoredText = unColoredText.Substring(Mathf.Min(unColoredText.Length,i+1));
		};
	}
	static void TimeScale(string sValue){
		float fValue;
		if (float.TryParse(sValue, out fValue)){
			Time.timeScale = fValue;
			Console.Log("Change successful", Color.green);
		}
		else
			Console.LogError("The entered value is not a valid float value");
	}

    void DisplayFPS(string sValue)
    {
        displayToggled = true;
        Console.LogError("displayToggled is true");
    }

    void OnGUI()
    {
        if (displayToggled)
        {
            
            int w = Screen.width, h = Screen.height;

            GUIStyle style = new GUIStyle();

        //Rect rect = new Rect(0, 0, w, h * 2 / 100);
        Rect rect = new Rect(w - 100, 10, 100, 100);
            style.alignment = TextAnchor.UpperRight;
            style.fontSize = h * 3 / 100;
            style.normal.textColor = new Color(1.0f, 1.0f, 0.5f, 1.0f);
            float fps = 1.0f / deltaTime;
            string text = string.Format("{0:0} FPS", fps);
            GUI.Label(rect, text, style);
        }
    }

    static void ShowTime(string args){
		Console.Log(Time.time.ToString());
	}

	static void XGravity(string sValue){
		float fValue;
		if (float.TryParse(sValue, out fValue)){
			Physics.gravity = new Vector3(fValue,Physics.gravity.y,  Physics.gravity.z);
			Console.Log("Change successful", Color.green);
		}
		else
			Console.LogError("The entered value is not a valid float value");
	}
	static void YGravity(string sValue){
		float fValue;
		if (float.TryParse(sValue, out fValue)){
			Physics.gravity = new Vector3(Physics.gravity.x, fValue, Physics.gravity.z);
			Console.Log("Change successful", Color.green);
		}
		else
			Console.LogError("The entered value is not a valid float value");
	}
	static void ZGravity(string sValue){
		float fValue;
		if (float.TryParse(sValue, out fValue)){
			Physics.gravity = new Vector3(Physics.gravity.x, Physics.gravity.y, fValue);
			Console.Log("Change successful", Color.green);
		}
		else
			Console.LogError("The entered value is not a valid float value");
	}
}