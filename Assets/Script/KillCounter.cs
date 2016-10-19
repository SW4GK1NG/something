using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KillCounter : MonoBehaviour {

    public Text txt;
    public int CurrentKill;

    // Use this for initialization
    void Start()
    {
        txt = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentKill <= 1)
        {
            txt.text = "Kill: " + CurrentKill;
        }
        else
        {
            txt.text = "Kills: " + CurrentKill;
        }
    }
}
