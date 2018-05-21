using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyShip : MonoBehaviour
{
    public enum Weapons { BLASTER, MINIGUN, LASER, SCATTER, TRIPLER, }

    float health = 20.0f;
    float maxHealth = 20.0f;
    public GameObject[] weapons;
    float speed;
    SpriteRenderer sr;
    Sprite[] splode, ship;
    public bool asplode = false;
    int splodeCt = 0;
    int shipCt = 0;
    int animCt = 0;
    [SerializeField]
    GameObject currWeapon;
    float weaponTimer = 0.0f;
    bool timingWeapon = false;
    int colorIndex = 0;
    int nextColor = 1;
    float colerp = 0.0f;

    Color[] colArr = {  new Color(1.0f,0.5f,0.5f),
        Color.white,
                        new Color(1.0f, 0.8f, 0.5f),
                        Color.white,
                        new Color(1.0f, 1.0f, 0.5f),
                        Color.white,
                        new Color(0.5f, 1.0f, 0.5f),
                        Color.white,
                        new Color(0.5f, 0.5f, 1.0f),
                        Color.white,
                        new Color(0.8f, 0.5f, 1.0f),
                        Color.white };
    // Use this for initialization
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        splode = Resources.LoadAll<Sprite>("splode");
        ship = Resources.LoadAll<Sprite>("PlayerShip");
        switch (Random.Range(0, 5))
        {
            case 0:
                switchWeapons(Weapons.BLASTER);
                break;
            case 1:
                switchWeapons(Weapons.LASER);
                break;
            case 2:
                switchWeapons(Weapons.MINIGUN);
                break;
            case 3:
                switchWeapons(Weapons.SCATTER);
                break;
            case 4:
                switchWeapons(Weapons.TRIPLER);
                break;
            default:
                switchWeapons(Weapons.BLASTER);
                break;
        }
        switch (Random.Range(0, 7))
        {
            case 0:
                sr.color = colArr[0];
                colorIndex = 0;
                break;

            case 1:
                sr.color = colArr[1];
                colorIndex = 1;
                break;

            case 2:
                sr.color = colArr[2];
                colorIndex = 2;
                break;

            case 3:
                sr.color = colArr[3];
                colorIndex = 3;
                break;

            case 4:
                sr.color = colArr[4];
                colorIndex = 4;
                break;

            case 5:
                sr.color = colArr[5];
                colorIndex = 5;
                break;

            case 6:
                sr.color = colArr[6];
                colorIndex = 6;
                break;

            default:
                sr.color = colArr[0];
                colorIndex = 0;
                break;
        }
        Destroy(gameObject, 8);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += new Vector3(0, .3f, 0) * Time.deltaTime * 10;
        nextColor = colorIndex + 1;
        if (nextColor == colArr.Length)
            nextColor = 0;
        if(sr.color != colArr[nextColor])
        {
            sr.color = Color.Lerp(colArr[colorIndex], colArr[nextColor], colerp);
            colerp += 0.1f;
        }
        else
        {
            colerp = 0.0f;
            colorIndex = Random.Range(0, colArr.Length);
            if (colorIndex == colArr.Length)
                colorIndex = 0;
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

        switch (weapon)
        {
            case Weapons.BLASTER:
            {
                currWeapon.GetComponent<Weapon>().ai = true;
                timingWeapon = false;
                weaponTimer = 1.0f;
                break;
            }

            case Weapons.LASER:
            {
                currWeapon.GetComponent<Minigun>().ai = true;

                timingWeapon = true;
                weaponTimer = 30.0f;
                break;
            }

            case Weapons.MINIGUN:
            {
                currWeapon.GetComponent<Laser>().ai = true;

                timingWeapon = true;
                weaponTimer = 100.0f;
                break;
            }
            case Weapons.TRIPLER:
            {
                currWeapon.GetComponent<Tripler>().ai = true;

                timingWeapon = true;
                weaponTimer = 60.0f;
                break;
            }
            case Weapons.SCATTER:
            {
                currWeapon.GetComponent<Scattergun>().ai = true;
                timingWeapon = true;
                weaponTimer = 50.0f;
                break;
            }
        }


    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
