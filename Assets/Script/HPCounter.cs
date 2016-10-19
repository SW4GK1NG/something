using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HPCounter : MonoBehaviour {

    public Text txt;
    public int CurrentHP;

	// Use this for initialization
	void Start () {
        txt = gameObject.GetComponent<Text>();
        txt.text = "HP: 20";
    }
	
	// Update is called once per frame
	void Update () {
        txt.text = "HP: " + CurrentHP;
    }
}
