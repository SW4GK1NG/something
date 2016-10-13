using UnityEngine;
using System.Collections;

public class SPIN_ME_BABY : MonoBehaviour {

	public Vector3 spin;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (spin);
	}
}
