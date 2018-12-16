using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class alert : MonoBehaviour {

    public Text txt;
    public int CurrentHP;
    public string gettxt;

    // Use this for initialization
    void Start()
    {
        txt = gameObject.GetComponent<Text>();
        txt.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = gettxt;
    }
}