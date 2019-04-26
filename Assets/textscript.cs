using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textscript : MonoBehaviour {

    public Text uitext;
    public Canvas infoTextCanvas;
    // Use this for initialization
    void Start () {
		Debug.Log("Game started.");
		uitext = GameObject.Find("uitext").GetComponent<Text>();
		StartCoroutine(ChangeTextOnInterval());
	}
	
	// Update is called once per frame
	void Update () {}

	IEnumerator ChangeTextOnInterval()
    {
        uitext.text = "Welcome to the game. Move around with WASD, run faster with shift and jump with space. ESC to quit.";
        Debug.Log(string.Format("Text changed at time {0}.", Time.time));
		yield return new WaitForSeconds(10);
        infoTextCanvas = GameObject.Find("InfoTextCanvas").GetComponent<Canvas>();
        infoTextCanvas.enabled = false;
        Debug.Log(string.Format("Text hidden at time {0}.", Time.time));
    }
}
