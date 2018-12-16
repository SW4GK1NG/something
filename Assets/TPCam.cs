using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPCam : MonoBehaviour {

    public Camera TPP;
    public Camera FPP;

    // Use this for initialization
    void Start () {
        TPP.enabled = true;
        FPP.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space))
        {
            if (TPP.enabled)
            {
                FPP.enabled = true;
                TPP.enabled = false;
            }
            else
            {
                TPP.enabled = true;
                FPP.enabled = false;
            }
        }
    }
}
