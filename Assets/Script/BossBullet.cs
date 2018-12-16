using UnityEngine;
using System.Collections;

public class BossBullet : MonoBehaviour {

    public Vector3 location;
    public float speedbullet;
    public float yspeed;
    public AudioClip hit;

    // Use this for initialization
    void Start()
    {
        transform.position = location;
        GetComponent<Rigidbody2D>().AddForce(new Vector2(speedbullet, yspeed));
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D coli)
    {
        if (coli.gameObject.tag == ("Player"))
        {
            AudioSource.PlayClipAtPoint(hit, transform.position);
            Destroy(gameObject);
        }

        if (coli.gameObject.tag == ("remove"))
        {
            Destroy(gameObject);
        }
    }
}
