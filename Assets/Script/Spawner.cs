using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public GameObject Enemy;
    public float Delay;
    public float Spawn_Rate;

	// Use this for initialization
	void Start () {
        InvokeRepeating("Spawn", Delay, Spawn_Rate);

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void Spawn () {
        GameObject e = Instantiate(Enemy);
        Enemy component = e.GetComponent<Enemy>();
        component.transform.position = transform.position;
    }
}
