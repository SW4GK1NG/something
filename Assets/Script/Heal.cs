using UnityEngine;
using System.Collections;

public class Heal : MonoBehaviour {

    public PlayerControll playerhp;
    public AudioClip heal;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnCollisionEnter2D (Collision2D coli)
    {
        if (coli.gameObject.tag == ("Player"))
        {
            playerhp = GameObject.FindObjectOfType<PlayerControll>();
            playerhp.hp = 20;
            for (int i = 0; i <= 5; i++)
            {
                AudioSource.PlayClipAtPoint(heal, transform.position);
            }
            Destroy(gameObject);
        }
    }
}
