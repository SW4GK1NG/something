using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public bool goleft;
    public PlayerControll m_controll;
    public Vector3 location;
    public float speedbullet;

	// Use this for initialization
	void Start () {
        transform.position = location;
        GetComponent<Rigidbody2D>().AddForce(new Vector2(speedbullet, 0f));
    }
	
	// Update is called once per frame
	void Update () {
       
    }

    void OnTriggerEnter2D (Collider2D coli) {
        Destroy(gameObject);
    }
}
