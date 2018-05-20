using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

    public enum Weapons { BLASTER, MINIGUN, LASER, SCATTER, TRIPLER, }
public class PlayerShip : MonoBehaviour
{

    float health = 100.0f;
    float maxHealth = 100.0f;
    int lives = 3;
    public GameObject[] weapons;
    float speed;
    int points;
    int nukes;
    int maxNukes;
    SpriteRenderer sr;
    Sprite[] splode, ship;
    public bool asplode = false;
    int splodeCt = 0;
    int shipCt = 0;
    int animCt = 0;
    GameObject currWeapon;
    public bool respawning = false;
    float respawnTransparency = 1.0f;
    float respawnTimer = 20.0f;
    bool respawnFlip = false;

    public float Health
    {
        get
        {
            return health;
        }

        set
        {
            health = value;
        }
    }

    public float MaxHealth
    {
        get
        {
            return maxHealth;
        }

        set
        {
            maxHealth = value;
        }
    }

    // Use this for initialization
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        splode = Resources.LoadAll<Sprite>("splode");
        ship = Resources.LoadAll<Sprite>("PlayerShip");
        switchWeapons(Weapons.BLASTER);
    }

    private void Update()
    {

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (health <= 0 && !respawning)
            asplode = true;

        animateShip();

        if (Input.GetKey(KeyCode.W) && !asplode)
        {
            transform.position += new Vector3(0, 1, 0) * Time.deltaTime * 10;
        }
        if (Input.GetKey(KeyCode.A) && !asplode)
        {
            transform.position -= new Vector3(1, 0, 0) * Time.deltaTime * 10;
        }
        if (Input.GetKey(KeyCode.S) && !asplode)
        {
            transform.position -= new Vector3(0, 1, 0) * Time.deltaTime * 10;
        }
        if (Input.GetKey(KeyCode.D) && !asplode)
        {
            transform.position += new Vector3(1, 0, 0) * Time.deltaTime * 10;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            switchWeapons(Weapons.BLASTER);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            switchWeapons(Weapons.MINIGUN);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            switchWeapons(Weapons.LASER);
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            switchWeapons(Weapons.SCATTER);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            switchWeapons(Weapons.TRIPLER);
        }
    }

    public void awardPoints(int _p)
    {
        points += _p;
    }

    public int readPoints()
    {
        return points;
    }

    public void takeDamage(float _hp)
    {
        Debug.Log("Taking damage!");
        health -= _hp;
    }

    private void animateShip()
    {
        if (asplode)
            esplode();
        else if (respawning)
            respawnAnimation();
        else
        {
            animCt++;
            if (animCt % 5 == 0)
            {
                animCt = 0;
                sr.sprite = ship[shipCt];
                shipCt++;
                if (shipCt == ship.Length)
                    shipCt = 0;
            }
        }
    }

    private void respawnAnimation()
    {
        if (respawnFlip)
        {
            respawnTransparency -= 0.1f;
            if (respawnTransparency <= 0.0f)
            {
                respawnFlip = false;
                respawnTransparency = 0.0f;
            }
        }
        else
        {
            respawnTransparency += 0.1f;
            if (respawnTransparency >= 1.0f)
            {
                respawnFlip = true;
                respawnTransparency = 1.0f;
            }
        }
        sr.color = new Color(1, 1, 1, respawnTransparency);
        respawnTimer -= 0.1f;
        if (respawnTimer <= 0.0f)
        {
            sr.color = new Color(1, 1, 1, 1);
            respawnTimer = 20.0f;
            respawning = false;
            GetComponent<Collider2D>().enabled = true;
        }
    }

    private void esplode()
    {
        GetComponent<Collider2D>().enabled = false;
        sr.sprite = splode[splodeCt];
        splodeCt++;
        if (splodeCt == splode.Length)
        {
            asplode = false;
            respawn();
        }
    }

    public void switchWeapons(Weapons weapon)
    {

        if (currWeapon != null)
        {
            Destroy(currWeapon);
        }
        currWeapon = Instantiate(weapons[(int)weapon], transform.position + new Vector3(0, 0.26f, 0), Quaternion.identity);
        currWeapon.transform.parent = this.transform;
        //currWeapon.transform.position = transform.parent.position;
    }

    public void respawn()
    {
        asplode = false;
        splodeCt = 0;
        if (lives > 0)
        {
            lives--;
            health = maxHealth;
            transform.position = new Vector3(0, 0, -10);
            respawning = true;
            sr.sprite = ship[0];
            GetComponent<Collider2D>().enabled = false;
        }
        else
        {
            SceneManager.LoadScene("gameOver");
        }
    }

    public void oneUp()
    {
        lives++;
    }

    public int getLives()
    {
        return lives;
    }
}
