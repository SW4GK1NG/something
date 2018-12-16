using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour {

    //For Debug
    public bool grounded;
    PlayButton componentlol;
    public float timewalk = 0;
    public float timeshoot = 0;
    public HPCounterBoss HPcounterboss;
    public alert warn;
    public string warntext;
    public int maxhp;
    public bool isAngry = false;
    public bool canwalk = true;
    public bool canshoot = true;
    public bool dead = false;

    //For Cofig
    public float speed;
    public float Jspeed;
    public float bullet_speed;
    public int hp;
    public float shoottype;
    public float jumpOrNot;
    public Transform gun_point;
    public GameObject Bullet;
    public GameObject explode;
    public AudioClip jump_sound;
    public AudioClip shoot_sound;
    public AudioClip die_sound;
    public AudioClip get_hit;
    public AudioClip angrysound;

    // Use this for initialization
    void Start() {
        gun_point = transform.Find("Gun_point");
        componentlol = GameObject.FindObjectOfType<PlayButton>();
        InvokeRepeating("normalshoot", 1, 3);
        InvokeRepeating("shoot", 10, 10);
        InvokeRepeating("alert", 6, 10);
        InvokeRepeating("jump", 3, 7);
        maxhp = hp;
    }

    // Update is called once per frame
    void Update() {
        HPcounterboss = GameObject.FindObjectOfType<HPCounterBoss>();
        HPcounterboss.CurrentHP = hp;
        if (componentlol.gamestart == true)
        {
            if (canwalk == true)
            {
                walk();
            }
        }
        if (hp == maxhp / 2)
        {
            angry();
        }

        if (canshoot == false)
        {
            CancelInvoke("shoot");
            CancelInvoke("alert");
            CancelInvoke("normalshoot");
        }
    }

    void angry ()
    {  
        if (isAngry == false)
        {
            for (int i = 0; i <= 5; i++)
            {
                AudioSource.PlayClipAtPoint(angrysound, transform.position);
            }
            CancelInvoke("normalshoot");
            CancelInvoke("shoot");
            CancelInvoke("alert");
            InvokeRepeating("normalshoot", 1, 1);
            InvokeRepeating("shoot", 7, 7);
            InvokeRepeating("alert2", 5, 7);
            isAngry = true;
        }
    }

    void alert()
    {
        StartCoroutine(rip());
    }

    void alert2()
    {      
        StartCoroutine(rip2());
    }

    IEnumerator rip ()
    {
        warn = GameObject.FindObjectOfType<alert>();
        warntext = "The Boss is about to use a special attack!!";
        warn.gettxt = warntext;
        yield return new WaitForSeconds(1f);
        warntext = "";
        warn.gettxt = warntext;
        yield return new WaitForSeconds(1f);
        warntext = "The Boss is about to use a special attack!!";
        warn.gettxt = warntext;
        yield return new WaitForSeconds(1f);
        warntext = "";
        warn.gettxt = warntext;
        yield return new WaitForSeconds(1f);
    }

    IEnumerator rip2()
    {
        warn = GameObject.FindObjectOfType<alert>();
        warntext = "The Boss is about to use a special attack!!";
        warn.gettxt = warntext;
        yield return new WaitForSeconds(2f);
        warntext = "";
        warn.gettxt = warntext;
    }

    void normalshoot()
    {
        if (componentlol.gamestart == true)
        {
            GameObject bullet = Instantiate(Bullet);
            BossBullet component = bullet.GetComponent<BossBullet>();
            component.speedbullet = bullet_speed * -1;
            component.yspeed = 0;
            component.location = gun_point.position;
            AudioSource.PlayClipAtPoint(shoot_sound, transform.position);

            GameObject bullet2 = Instantiate(Bullet);
            BossBullet component2 = bullet2.GetComponent<BossBullet>();
            component2.speedbullet = bullet_speed * -1;
            component2.yspeed = 0;
            Vector3 component2location = gun_point.position;
            component2location.y -= 3;
            component2.location = component2location;
            AudioSource.PlayClipAtPoint(shoot_sound, transform.position);

            GameObject bullet3 = Instantiate(Bullet);
            BossBullet component3 = bullet3.GetComponent<BossBullet>();
            component3.speedbullet = bullet_speed * -1;
            component3.yspeed = 0;
            Vector3 component3location = gun_point.position;
            component3location.y += 3;
            component3.location = component3location;
            AudioSource.PlayClipAtPoint(shoot_sound, transform.position);

            GameObject bullet4 = Instantiate(Bullet);
            BossBullet component4 = bullet4.GetComponent<BossBullet>();
            component4.speedbullet = bullet_speed * -1;
            component4.yspeed = bullet_speed / 3;
            component4.location = gun_point.position;
            AudioSource.PlayClipAtPoint(shoot_sound, transform.position);

            GameObject bullet5 = Instantiate(Bullet);
            BossBullet component5 = bullet5.GetComponent<BossBullet>();
            component5.speedbullet = bullet_speed * -1;
            component5.yspeed = bullet_speed / -3;
            component5.location = gun_point.position;
            AudioSource.PlayClipAtPoint(shoot_sound, transform.position);
        }
    }

    void shoot ()
    {
        if (componentlol.gamestart == true)
        {
            shoottype = UnityEngine.Random.Range(1, 4);
            if (shoottype == 1)
            {
                StartCoroutine(shootcone());
            }
            if (shoottype == 2)
            {
                StartCoroutine(shootstraigh());
            }
            if (shoottype == 3)
            {
                StartCoroutine(shootwave());
            }
        }
    }

    void jump ()
    {
        if (componentlol.gamestart == true)
        {
            jumpOrNot = UnityEngine.Random.Range(1, 101);
            if (jumpOrNot >= 80)
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, Jspeed));
            }
        }
    }

    IEnumerator shootcone ()
    {
        CancelInvoke("normalshoot");
        for (int i = 0; i <= 6; i++)
        {

            if (canshoot == false)
            {
                break;
            }
            GameObject bullet1 = Instantiate(Bullet);
            BossBullet component1 = bullet1.GetComponent<BossBullet>();
            component1.speedbullet = bullet_speed * -1;
            component1.yspeed = 0;
            component1.location = gun_point.position;
            AudioSource.PlayClipAtPoint(shoot_sound, transform.position);

            GameObject bullet2 = Instantiate(Bullet);
            BossBullet component2 = bullet2.GetComponent<BossBullet>();
            component2.speedbullet = bullet_speed * -1;
            component2.yspeed = bullet_speed / 3;
            component2.location = gun_point.position;
            AudioSource.PlayClipAtPoint(shoot_sound, transform.position);

            GameObject bullet3 = Instantiate(Bullet);
            BossBullet component3 = bullet3.GetComponent<BossBullet>();
            component3.speedbullet = bullet_speed * -1;
            component3.yspeed = bullet_speed / -3;
            component3.location = gun_point.position;
            AudioSource.PlayClipAtPoint(shoot_sound, transform.position);

            GameObject bullet4 = Instantiate(Bullet);
            BossBullet component4 = bullet4.GetComponent<BossBullet>();
            component4.speedbullet = bullet_speed * -1;
            component4.yspeed = bullet_speed / 4;
            component4.location = gun_point.position;
            AudioSource.PlayClipAtPoint(shoot_sound, transform.position);

            GameObject bullet5 = Instantiate(Bullet);
            BossBullet component5 = bullet5.GetComponent<BossBullet>();
            component5.speedbullet = bullet_speed * -1;
            component5.yspeed = bullet_speed / -4;
            component5.location = gun_point.position;
            AudioSource.PlayClipAtPoint(shoot_sound, transform.position);

            GameObject bullet6 = Instantiate(Bullet);
            BossBullet component6 = bullet6.GetComponent<BossBullet>();
            component6.speedbullet = bullet_speed * -1;
            component6.yspeed = bullet_speed / 8;
            component6.location = gun_point.position;
            AudioSource.PlayClipAtPoint(shoot_sound, transform.position);

            GameObject bullet7 = Instantiate(Bullet);
            BossBullet component7 = bullet7.GetComponent<BossBullet>();
            component7.speedbullet = bullet_speed * -1;
            component7.yspeed = bullet_speed / -8;
            component7.location = gun_point.position;
            AudioSource.PlayClipAtPoint(shoot_sound, transform.position);
            yield return new WaitForSeconds(0.075f);
        }
        if (hp <= maxhp / 2)
        {
            InvokeRepeating("normalshoot", 1, 1);
        }
        if (hp > maxhp / 2)
        {
            InvokeRepeating("normalshoot", 1, 3);
        }
    }

    IEnumerator shootstraigh ()
    {
        CancelInvoke("normalshoot");
        for (int i = 0; i <= 20; i++)
        {
            if (canshoot == false)
            {
                break;
            }
            GameObject bullet = Instantiate(Bullet);
            BossBullet component = bullet.GetComponent<BossBullet>();
            component.speedbullet = bullet_speed * -1;
            component.yspeed = 0;
            component.location = gun_point.position;
            AudioSource.PlayClipAtPoint(shoot_sound, transform.position);

            GameObject bullet2 = Instantiate(Bullet);
            BossBullet component2 = bullet2.GetComponent<BossBullet>();
            component2.speedbullet = bullet_speed * -1;
            component2.yspeed = 0;
            Vector3 component2location = gun_point.position;
            component2location.y -= 3;
            component2.location = component2location;
            AudioSource.PlayClipAtPoint(shoot_sound, transform.position);

            GameObject bullet3 = Instantiate(Bullet);
            BossBullet component3 = bullet3.GetComponent<BossBullet>();
            component3.speedbullet = bullet_speed * -1;
            component3.yspeed = 0;
            Vector3 component3location = gun_point.position;
            component3location.y += 3;
            component3.location = component3location;
            AudioSource.PlayClipAtPoint(shoot_sound, transform.position);
            yield return new WaitForSeconds(0.075f);
        }
        if (hp <= maxhp / 2)
        {
            InvokeRepeating("normalshoot", 1, 1);
        }
        if (hp > maxhp / 2)
        {
            InvokeRepeating("normalshoot", 1, 3);
        }
    }

    IEnumerator shootwave ()
    {
        CancelInvoke("normalshoot");
        for (int i = 1; i <= 29; i++)
        {

            if (canshoot == false)
            {
                break;
            }
            if (i <= 5)
            {
                GameObject bullet = Instantiate(Bullet);
                BossBullet component = bullet.GetComponent<BossBullet>();
                component.speedbullet = bullet_speed * -1;
                component.yspeed = 0;
                Vector3 offset = gun_point.position;
                offset.y += 2;
                offset.y -= i;
                component.location = offset;
                AudioSource.PlayClipAtPoint(shoot_sound, transform.position);
                yield return new WaitForSeconds(0.050f);
            }

            if (i >= 6 && i < 10)
            {
                GameObject bullet = Instantiate(Bullet);
                BossBullet component = bullet.GetComponent<BossBullet>();
                component.speedbullet = bullet_speed * -1;
                component.yspeed = 0;
                Vector3 offset = gun_point.position;
                offset.y -= 1;
                offset.y += (i - 6);
                component.location = offset;
                AudioSource.PlayClipAtPoint(shoot_sound, transform.position);
                yield return new WaitForSeconds(0.050f);
            }

            if (i >= 10 && i < 14)
            {
                GameObject bullet = Instantiate(Bullet);
                BossBullet component = bullet.GetComponent<BossBullet>();
                component.speedbullet = bullet_speed * -1;
                component.yspeed = 0;
                Vector3 offset = gun_point.position;
                offset.y += 1;
                offset.y -= (i - 10);
                component.location = offset;
                AudioSource.PlayClipAtPoint(shoot_sound, transform.position);
                yield return new WaitForSeconds(0.050f);
            }

            if (i >= 14 && i < 18)
            {
                GameObject bullet = Instantiate(Bullet);
                BossBullet component = bullet.GetComponent<BossBullet>();
                component.speedbullet = bullet_speed * -1;
                component.yspeed = 0;
                Vector3 offset = gun_point.position;
                offset.y -= 1;
                offset.y += (i - 14);
                component.location = offset;
                AudioSource.PlayClipAtPoint(shoot_sound, transform.position);
                yield return new WaitForSeconds(0.050f);
            }

            if (i >= 18 && i < 22)
            {
                GameObject bullet = Instantiate(Bullet);
                BossBullet component = bullet.GetComponent<BossBullet>();
                component.speedbullet = bullet_speed * -1;
                component.yspeed = 0;
                Vector3 offset = gun_point.position;
                offset.y += 1;
                offset.y -= (i - 18);
                component.location = offset;
                AudioSource.PlayClipAtPoint(shoot_sound, transform.position);
                yield return new WaitForSeconds(0.050f);
            }

            if (i >= 22 && i < 26)
            {
                GameObject bullet = Instantiate(Bullet);
                BossBullet component = bullet.GetComponent<BossBullet>();
                component.speedbullet = bullet_speed * -1;
                component.yspeed = 0;
                Vector3 offset = gun_point.position;
                offset.y -= 1;
                offset.y += (i - 22);
                component.location = offset;
                AudioSource.PlayClipAtPoint(shoot_sound, transform.position);
                yield return new WaitForSeconds(0.050f);
            }

            if (i >= 26)
            {
                GameObject bullet = Instantiate(Bullet);
                BossBullet component = bullet.GetComponent<BossBullet>();
                component.speedbullet = bullet_speed * -1;
                component.yspeed = 0;
                Vector3 offset = gun_point.position;
                offset.y += 1;
                offset.y -= (i - 26);
                component.location = offset;
                AudioSource.PlayClipAtPoint(shoot_sound, transform.position);
                yield return new WaitForSeconds(0.050f);
            }
        }
        if (hp <= maxhp / 2)
        {
            InvokeRepeating("normalshoot", 1, 1);
        }
        if (hp > maxhp / 2)
        {
            InvokeRepeating("normalshoot", 1, 3);
        }
    }

    void walk ()
    {
        if (timewalk <= 2f)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            timewalk = timewalk + Time.deltaTime;
        }

        if (timewalk <= 4f && timewalk >= 2f)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            timewalk = timewalk + Time.deltaTime;
        }

        if (timewalk >= 4f)
        {
            jump();
            timewalk = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D coli)
    {
        if (coli.gameObject.tag == "Bullet_go")
        {
            AudioSource.PlayClipAtPoint(get_hit, transform.position);
            hp--;
            if (hp <= 0)
            {
                if (dead == false)
                {
                    StartCoroutine(die());
                }
            }
        }
    }

    IEnumerator die()
    {
        dead = true;
        canwalk = false;
        canshoot = false;
        yield return new WaitForSeconds(1);
        GameObject boom = Instantiate(explode);
        Explosion component = explode.GetComponent<Explosion>();
        component.location = transform.position;
        for (int i = 0; i <= 5; i++)
        {
            AudioSource.PlayClipAtPoint(die_sound, transform.position);
        }
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("End");
    }
}
