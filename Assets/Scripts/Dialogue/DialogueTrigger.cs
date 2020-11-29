using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject King;


    void OnTriggerEnter2D(Collider2D other)
        {

            if (other.gameObject.tag == "Player")
            {

            FindObjectOfType<dialogueManager>().StartDialogue(dialogue);
            FindObjectOfType<audioManager>().Play("KingTrigger");
            King.GetComponent<BoxCollider2D>().enabled = false;

        }
        }


}
