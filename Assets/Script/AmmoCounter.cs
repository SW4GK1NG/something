using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AmmoCounter : MonoBehaviour {

    public Text txt;
    public int CurrentAmmo;

    // Use this for initialization
    void Start()
    {
        txt = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentAmmo == 0)
        {
            txt.text = "Ammo: Reloading...";
        }
        else
        {
            txt.text = "Ammo: " + CurrentAmmo;
        }
    }
}
