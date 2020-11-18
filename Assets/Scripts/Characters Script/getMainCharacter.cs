using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getMainCharacter : MonoBehaviour
{
    //https://www.youtube.com/watch?v=NcaFOMv-_XQ&ab_channel=GregEads

    //public Sprite spriteHero1, spriteHero2, spriteHero3, spriteHero4, spriteHero5;
    public GameObject Hero1, Hero2, Hero3, Hero4, Hero5;
    private SpriteRenderer mySprite;
    private readonly string selectedHero = "SelectedHero";


    void Awake()
    {
        mySprite = this.GetComponent<SpriteRenderer>();

        Hero1 = GameObject.Find("Hero1");
        Hero2 = GameObject.Find("Hero2");
        Hero3 = GameObject.Find("Hero3");
        Hero4 = GameObject.Find("Hero4");
        Hero5 = GameObject.Find("Hero5");
    }
    // Start is called before the first frame update
    void Start()
    {
        int getCharcter;
        getCharcter = PlayerPrefs.GetInt(selectedHero);
        
        switch (getCharcter)
        {
            case 1:

                

                Hero1.active = false;
                Hero3.active = false;
                Hero4.active = false;
                Hero5.active = false;

                break;
            case 2:

                Hero1.active = false;
                Hero2.active = false;
                Hero4.active = false;
                Hero5.active = false;
                break;
            case 3:

                Hero1.active = false;
                Hero2.active = false;
                Hero3.active = false;
                Hero5.active = false;
                break;
            case 4:

                Hero1.active = false;
                Hero2.active = false;
                Hero3.active = false;
                Hero4.active = false;
                break;
            case 5:

                Hero2.active = false;
                Hero3.active = false;
                Hero4.active = false;
                Hero5.active = false;
                break;
            default:

                Hero2.active = false;
                Hero3.active = false;
                Hero4.active = false;
                Hero5.active = false;
                break;
        }
    }


}
