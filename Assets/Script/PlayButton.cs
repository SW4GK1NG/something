using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour {

    public bool gamestart = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Go(string Scenename)
    {
        SceneManager.LoadScene(Scenename);
    }

    public void ok()
    {
        gamestart = true;
    }
}
