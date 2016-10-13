using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    //For Config
    public Spawner m_spawn;
    public int hp;
    public float flip_delay;
    public float flip_speed;
    public LayerMask RayMask;
    public GameObject Bullet;
    public float bullet_speed;
    public float shoot_speed;
    public float shoot_delay;
    public Transform gun_point;
    public float RayDistance;
    public float walk_speed;
    
    //For Debug
    public bool shooting;
    public bool flipping;
    public bool face_right;
    public int time_flip;
    public bool flip_fin;
    public bool walking;

    // Use this for initialization
    void Start () {
        gun_point = transform.Find("SANSDANCE");
        face_right = true;
    }
	
	// Update is called once per frame
	void Update () {
        Vector2 Origin = new Vector2(transform.position.x, transform.position.y);
        Vector2 Direction = new Vector2(transform.localScale.x, 0);
        RaycastHit2D Ray = Physics2D.Raycast(Origin, Direction, RayDistance, RayMask);
        Debug.DrawRay(Origin, Direction);
        if (Ray)
        {
            if (shooting == false)
            {
                shooting = true;
                InvokeRepeating("shoot", shoot_delay, shoot_speed);

            }
            walking = false;
            flip_fin = false;
        }
        else
        {
            shooting = false;
            CancelInvoke("shoot");
        }

        if (!Ray && flip_fin == false)
        {
            if (flipping == false)
            {
                flip_fin = false;
                flipping = true;
                InvokeRepeating("Flip", flip_delay, flip_speed);
            }    
        }
        else
        {
            flipping = false;
            CancelInvoke("Flip");
        }

        if (flip_fin == true)
        {
            time_flip = 0;
            walk();
        }



    }

    void OnTriggerEnter2D (Collider2D coli)
    {
        if (coli.gameObject.tag == "Bullet_go")
        {
            hp--;
            if (hp <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    void shoot ()
    {
        if (face_right == false)
        {
            GameObject x = Instantiate(Bullet);
            Bullet component = x.GetComponent<Bullet>();
            component.speedbullet = bullet_speed * -1;
            component.location = gun_point.position;
            Rigidbody2D rig = x.GetComponent<Rigidbody2D>();
        }
        else
        {
            GameObject x = Instantiate(Bullet);
            Bullet component = x.GetComponent<Bullet>();
            component.speedbullet = bullet_speed;
            component.location = gun_point.position;
            Rigidbody2D rig = x.GetComponent<Rigidbody2D>();
        }
    }

    void Flip()
    {
        face_right = !face_right;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
        time_flip++;
        if (time_flip >=5)
        {
            CancelInvoke("Flip");
            flip_fin = true;
        }
    }

    void walk()
    {
        if (face_right == false)
        {
            transform.position += Vector3.left * walk_speed * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.right * walk_speed * Time.deltaTime;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "wall")
        {
            walkflip();
        }
    }

    void walkflip()
    {
        face_right = !face_right;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

}
