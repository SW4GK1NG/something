using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Counter : MonoBehaviour {

    public int kill;
    public string nextlevel;
    public int killcount;
    public KillCounter Killcounter;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Killcounter = GameObject.FindObjectOfType<KillCounter>();
        Killcounter.CurrentKill = kill;
    }

    public void addkill()
    {
        kill++;
        Debug.Log(kill +" Kill");
        if (kill == killcount)
        {
            SceneManager.LoadScene(nextlevel);
        }
    }
}
