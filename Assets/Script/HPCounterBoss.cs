using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HPCounterBoss : MonoBehaviour {

    public Text txt;
    public int CurrentHP;

	// Use this for initialization
	void Start () {
        txt = gameObject.GetComponent<Text>();
        txt.text = "Boss HP: 50";
    }
	
	// Update is called once per frame
	void Update () {
        txt.text = "Boss HP: " + CurrentHP;
    }
}
