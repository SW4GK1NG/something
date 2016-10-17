using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerControll : MonoBehaviour {

	//For Debug
	public bool jump = false;
    public bool grounded = false;
    public bool faceleft = true;
    public bool shoot = true;
    PlayButton componentlol;

    //For Cofig
    public float speed;
    public float Jspeed;
    public LayerMask Ground;
    public float bullet_speed;
    public int hp;
    public Transform gun_point;
    public GameObject Bullet;
    public Transform GroundCheck;
    public AudioClip jump_sound;
    public AudioClip shoot_sound;
    public AudioClip die_sound;
    public AudioClip get_hit;

    // Use this for initialization
    void Start () {
		GroundCheck = transform.Find ("GroundCheck");
        gun_point = transform.Find ("GunPoint");
        componentlol = GameObject.FindObjectOfType<PlayButton>();
    }
	
	// Update is called once per frame
	void Update () {
        if (componentlol.gamestart == true)
        {
            if (Input.GetKeyDown(KeyCode.Z) && faceleft == true)
            {
                GameObject x = Instantiate(Bullet);
                Bullet component = x.GetComponent<Bullet>();
                component.speedbullet = bullet_speed * -1;
                component.location = gun_point.position;
                component.shoot_by_player = shoot;
                AudioSource.PlayClipAtPoint(shoot_sound, transform.position);
            }

            if (Input.GetKeyDown(KeyCode.Z) && faceleft == false)
            {
                GameObject x = Instantiate(Bullet);
                Bullet component = x.GetComponent<Bullet>();
                component.speedbullet = bullet_speed;
                component.location = gun_point.position;
                component.shoot_by_player = shoot;
                AudioSource.PlayClipAtPoint(shoot_sound, transform.position);
            }

            grounded = Physics2D.OverlapCircle(GroundCheck.position, 0.15f, Ground);

            if (Input.GetKeyDown(KeyCode.UpArrow) && grounded)
            {
                jump = true;
                AudioSource.PlayClipAtPoint(jump_sound, transform.position);
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }

            if (jump)
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, Jspeed));
                jump = false;
            }

            if (Input.GetKey(KeyCode.LeftArrow) && faceleft == false)
            {
                Flip();
            }

            if (Input.GetKey(KeyCode.RightArrow) && faceleft == true)
            {
                Flip();
            }
        }
    }

    void Flip () {
        faceleft = !faceleft;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    void OnTriggerEnter2D(Collider2D coli)
    {
        if (coli.gameObject.tag == "Bullet_enemy")
        {
            AudioSource.PlayClipAtPoint(get_hit, transform.position);
            hp--;
            if (hp <= 0)
            {
                AudioSource.PlayClipAtPoint(die_sound, transform.position);
                Destroy(gameObject);
                SceneManager.LoadScene("die");
            }
        }
    }
}
