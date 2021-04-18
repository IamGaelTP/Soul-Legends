using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    QuestGiver questGiver;
    public GameObject dialogueCanvas;
    public GameObject lloronaDialogue;

    private void Awake()
    {
        questGiver = FindObjectOfType<QuestGiver>();
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Hijo Llorona"))
        { 
            questGiver.quest.LloronaChildTaken();
            questGiver.UpdateQuestWindow();
            Destroy(col.gameObject);
        }
    }

    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.CompareTag("Rama Plat"))
        {
            if (this.gameObject.transform.position.y < col.gameObject.transform.position.y)
            {
                col.gameObject.GetComponent<BoxCollider>().isTrigger = true;
            }
        }
    }

    private void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.CompareTag("Llorona"))
        {
            dialogueCanvas.SetActive(true);

            //On Quest Completed
            if (questGiver.quest.isReached())
            {
                questGiver.quest.QuestComplete();
                lloronaDialogue.GetComponent<DialogueManager>().stopIndex = lloronaDialogue.GetComponent<DialogueManager>().sentences.Length;
            }
        }
    }

    private void OnTriggerStay(Collider trigger)
    {
        if (trigger.gameObject.CompareTag("Llorona"))
        {
            if (lloronaDialogue.GetComponent<DialogueManager>().index == 5)
            {
                questGiver.OpenQuestWindow();
                Debug.Log("GIVING QUEST");
            }
        }
    }

    private void OnTriggerExit(Collider trigger)
    {
        if (trigger.gameObject.CompareTag("Rama Plat"))
        {
            if (this.gameObject.transform.position.y > trigger.transform.position.y)
            {
                trigger.GetComponent<BoxCollider>().isTrigger = false;
            }
        }
    }


}
