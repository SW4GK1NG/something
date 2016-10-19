using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {

    //For Debug
    public bool grounded;
    PlayButton componentlol;

    //For Cofig
    public float Jspeed;
    public float bullet_speed;
    public int hp;
    public int shoottype;
    public Transform gun_point;
    public GameObject Bullet;
    public AudioClip jump_sound;
    public AudioClip shoot_sound;
    public AudioClip die_sound;
    public AudioClip get_hit;

    // Use this for initialization
    void Start () {
        gun_point = transform.Find("Gun_point");
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    void jump ()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, Jspeed));
    }
}
