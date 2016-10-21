using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

    public Vector3 location;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update () {
	    transform.position = location;
	}
}
