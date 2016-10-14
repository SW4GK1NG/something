using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Counter : MonoBehaviour {

    public int kill;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void addkill()
    {
        kill++;

        if (kill == 20)
        {
            SceneManager.LoadScene("Lv2");
        }
    }
}
