using UnityEngine;
using System.Collections;

public class SpawnerHeal : MonoBehaviour {

    public GameObject Heal;
    public float Delay;
    public float Spawn_Rate;
    public bool gamego;
    public float yes;
    public float willspawn;
    PlayButton componentlol;

    // Use this for initialization
    void Start () {
        componentlol = GameObject.FindObjectOfType<PlayButton>(); 
        InvokeRepeating("Spawn", Delay, Spawn_Rate);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void Spawn () {
        if (componentlol.gamestart == true)
        {
            yes = UnityEngine.Random.Range(1, 11);
            if (yes >= 10 / willspawn)
            {
                GameObject e = Instantiate(Heal);
                Heal component = e.GetComponent<Heal>();
                component.transform.position = transform.position;
                //Invoke("cancle",0.01f);
                //Debug.Log(Spawn_Rate);
            }
        }
    }

    void cancle() {
        CancelInvoke("Spawn");
        //Spawn_Rate = Spawn_Rate - 0.1f;
        InvokeRepeating("Spawn", 0, Spawn_Rate);
    }
}
