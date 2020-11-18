using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class defeatAnimation : MonoBehaviour
{
    public GameObject Hero1D, Hero2D, Hero3D, Hero4D, Hero5D;
    private SpriteRenderer mySprite;
    private readonly string selectedHero = "SelectedHero";

    void Awake()
    {
        mySprite = this.GetComponent<SpriteRenderer>();

        Hero1D = GameObject.Find("Hero1Death");
        Hero2D = GameObject.Find("Hero2Death");
        Hero3D = GameObject.Find("Hero3Death");
        Hero4D = GameObject.Find("Hero4Death");
        Hero5D = GameObject.Find("Hero5Death");
    }
    // Start is called before the first frame update
    void Start()
    {
        int getCharcter;
        getCharcter = PlayerPrefs.GetInt(selectedHero);

        switch (getCharcter)
        {
            case 1:

                Hero1D.active = false;
                Hero3D.active = false;
                Hero4D.active = false;
                Hero5D.active = false;

                break;
            case 2:

                Hero1D.active = false;
                Hero2D.active = false;
                Hero4D.active = false;
                Hero5D.active = false;
                break;
            case 3:

                Hero1D.active = false;
                Hero2D.active = false;
                Hero3D.active = false;
                Hero5D.active = false;
                break;
            case 4:

                Hero1D.active = false;
                Hero2D.active = false;
                Hero3D.active = false;
                Hero4D.active = false;
                break;
            case 5:

                Hero2D.active = false;
                Hero3D.active = false;
                Hero4D.active = false;
                Hero5D.active = false;
                break;
            default:

                Hero2D.active = false;
                Hero3D.active = false;
                Hero4D.active = false;
                Hero5D.active = false;
                break;
        }
    }


}
