using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heroDamage : MonoBehaviour
{

    public static int heroADamage;
    public static int attackDValue;


    private SpriteRenderer mySprite;
    private readonly string selectedHero = "SelectedHero";

    private void Awake()
    {

        mySprite = this.GetComponent<SpriteRenderer>();

    }
    // Start is called before the first frame update
    void Start()
    {
        int getCharcter;
        getCharcter = PlayerPrefs.GetInt(selectedHero);

        switch (getCharcter)
        {
            case 1:
                //Hero2 Damage
                heroADamage = 120;
                break;
            case 2:
                //Hero3 Damage
                heroADamage = 100;
                break;
            case 3:
                //Hero4 Damage
                heroADamage = 100;
                break;
            case 4:
                //Hero5 Damage
                heroADamage = 60;
                break;
            case 5:
                //Hero1 Damage
                heroADamage = 80;
                break;
            default:

                break;
        }
    }

    public static int setHeroDamage
    {
        get
        {
            return heroADamage;
        }
        set
        {
            heroADamage = attackDValue;
        }
    }
}
