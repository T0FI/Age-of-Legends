using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class selectorScript : MonoBehaviour
{

    public GameObject sHero1;
    public GameObject sHero2;
    public GameObject sHero3;
    public GameObject sHero4;
    public GameObject sHero5;
    public GameObject sHero2Pos;
    public GameObject sHero3Pos;
    public GameObject sHero4Pos;
    public GameObject sHero5Pos;

    public GameObject Hero1Stats;
    public GameObject Hero2Stats;
    public GameObject Hero3Stats;
    public GameObject Hero4Stats;
    public GameObject Hero5Stats;

    private Vector3 CharacterPosition;
    private Vector3 CharacterPosition2;
    private Vector3 CharacterPosition3;
    private Vector3 CharacterPosition4;
    private Vector3 CharacterPosition5;
    private Vector3 OffScreen;
    public int CharacterInt = 1;
    private SpriteRenderer sHero1Render, sHero2Render, sHero3Render, sHero4Render, sHero5Render;

    GameObject mainMenuMusic;

    private readonly string selectedHero = "SelectedHero";

    private void Awake()
    {
        mainMenuMusic = GameObject.Find("Main Menu Music");

        CharacterPosition = sHero1.transform.position;
        CharacterPosition2 = sHero2Pos.transform.position;
        CharacterPosition3 = sHero3Pos.transform.position;
        CharacterPosition4 = sHero4Pos.transform.position;
        CharacterPosition5 = sHero5Pos.transform.position;


        OffScreen = sHero5.transform.position;


        sHero1Render = sHero1.GetComponent<SpriteRenderer>();
        sHero2Render = sHero1.GetComponent<SpriteRenderer>();
        sHero3Render = sHero1.GetComponent<SpriteRenderer>();
        sHero4Render = sHero1.GetComponent<SpriteRenderer>();
        sHero5Render = sHero1.GetComponent<SpriteRenderer>();


        Hero1Stats = GameObject.Find("Hero1 Stats");
        Hero2Stats = GameObject.Find("Hero2 Stats");
        Hero3Stats = GameObject.Find("Hero3 Stats");
        Hero4Stats = GameObject.Find("Hero4 Stats");
        Hero5Stats = GameObject.Find("Hero5 Stats");

        Hero1Stats.active = true;
        Hero2Stats.active = false;
        Hero3Stats.active = false;
        Hero4Stats.active = false;
        Hero5Stats.active = false;

    }

    public void NextCharacter()
    {
        switch (CharacterInt)
        {
            case 1:
                PlayerPrefs.SetInt(selectedHero, 1);

                Hero1Stats.active = false;
                sHero1Render.enabled = false;
                sHero1.transform.position = OffScreen;

                sHero2.transform.position = CharacterPosition2;
                sHero2Render.enabled = true;
                Hero2Stats.active = true;
                CharacterInt++;
                break;
            case 2:
                PlayerPrefs.SetInt(selectedHero, 2);

                Hero2Stats.active = false;
                sHero2Render.enabled = false;
                sHero2.transform.position = OffScreen;

                sHero3.transform.position = CharacterPosition3;
                sHero3Render.enabled = true;
                Hero3Stats.active = true;
                CharacterInt++;
                break;
            case 3:
                PlayerPrefs.SetInt(selectedHero, 3);

                Hero3Stats.active = false;
                sHero3Render.enabled = false;
                sHero3.transform.position = OffScreen;

                sHero4.transform.position = CharacterPosition4;
                sHero4Render.enabled = true;
                Hero4Stats.active = true;
                CharacterInt++;
                break;
            case 4:
                PlayerPrefs.SetInt(selectedHero, 4);

                Hero4Stats.active = false;
                sHero4Render.enabled = false;
                sHero4.transform.position = OffScreen;

                sHero5.transform.position = CharacterPosition5;
                sHero5Render.enabled = true;
                Hero5Stats.active = true;
                CharacterInt++;
                break;
            case 5:
                PlayerPrefs.SetInt(selectedHero, 5);

                Hero5Stats.active = false;
                sHero5Render.enabled = false;
                sHero5.transform.position = OffScreen;

                sHero1.transform.position = CharacterPosition;
                sHero1Render.enabled = true;
                Hero1Stats.active = true;
                CharacterInt++;
                ResetInt();
                break;
            default:
                ResetInt();
                break;
        }
    }

    public void PrevCharacter()
    {
        switch (CharacterInt)
        {
            case 1:
                PlayerPrefs.SetInt(selectedHero, 4);

                Hero1Stats.active = false;
                sHero1Render.enabled = false;
                sHero1.transform.position = OffScreen;

                sHero5.transform.position = CharacterPosition5;
                sHero5Render.enabled = true;
                Hero5Stats.active = true;

                CharacterInt--;
                ResetInt();
                break;
            case 2:
                PlayerPrefs.SetInt(selectedHero, 5);

                Hero2Stats.active = false;
                sHero2Render.enabled = false;
                sHero2.transform.position = OffScreen;

                sHero1.transform.position = CharacterPosition;
                sHero1Render.enabled = true;
                Hero1Stats.active = true;

                CharacterInt--;
                break;
            case 3:
                PlayerPrefs.SetInt(selectedHero, 1);

                Hero3Stats.active = false;
                sHero3Render.enabled = false;
                sHero3.transform.position = OffScreen;

                sHero2.transform.position = CharacterPosition2;
                sHero2Render.enabled = true;
                Hero2Stats.active = true;

                CharacterInt--;
                break;
            case 4:
                PlayerPrefs.SetInt(selectedHero, 2);

                Hero4Stats.active = false;
                sHero4Render.enabled = false;
                sHero4.transform.position = OffScreen;

                sHero3.transform.position = CharacterPosition3;
                sHero3Render.enabled = true;
                Hero3Stats.active = true;

                CharacterInt--;
                break;
            case 5:
                PlayerPrefs.SetInt(selectedHero, 3);

                Hero5Stats.active = false;
                sHero5Render.enabled = false;
                sHero5.transform.position = OffScreen;

                sHero4.transform.position = CharacterPosition4;
                sHero4Render.enabled = true;
                Hero4Stats.active = true;

                CharacterInt--;
                break;
            default:
                ResetInt();
                break;
        }
    }

    private void ResetInt()
    {
        if (CharacterInt >= 5)
        {
            CharacterInt = 1;
        }
        else
        {
            CharacterInt = 5;
        }
    }

    public void ChangeScene()
    {
        Destroy(mainMenuMusic);
        FindObjectOfType<audioManager>().Play("Button Press");
        SceneManager.LoadScene(2);
    }
}
