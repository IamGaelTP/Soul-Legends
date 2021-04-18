using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    QuestGiver questGiver;
    CameraChange cameraChange;
    PlayerHealth playerHealth;
    WinCondition winScript;
    public GameObject dialogueCanvas;
    public GameObject lloronaDialogue;
    public GameObject charm;

    public Vector3 tp;


    private void Awake()
    {
        questGiver = FindObjectOfType<QuestGiver>();
        cameraChange = FindObjectOfType<CameraChange>();
        playerHealth = FindObjectOfType<PlayerHealth>();
        winScript = FindObjectOfType<WinCondition>();
    }


    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Hijo Llorona"))
        { 
            questGiver.quest.LloronaChildTaken();
            questGiver.UpdateQuestWindow();
            Destroy(col.gameObject);

            this.gameObject.transform.position = tp;
        }

        if (col.gameObject.CompareTag("Llorona Wall"))
        {
            if (lloronaDialogue.GetComponent<DialogueManager>().index == 5)
            {
                col.gameObject.SetActive(false);
            }
        }

        if (col.gameObject.CompareTag("Enemy"))
        {
            playerHealth.TakeDamage(20);

            //Play Audio
            AudioManager.instance.Play("Take Damage");


            playerHealth.isAlive();

            if(!playerHealth.isAlive())
            {
                playerHealth.Death();
            }
        }

        if (col.gameObject.CompareTag("Picos"))
        {
            playerHealth.TakeDamage(100);

            //Play Audio
            AudioManager.instance.Play("Take Damage");


            playerHealth.isAlive();

            if (!playerHealth.isAlive())
            {
                playerHealth.Death();
            }
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

            cameraChange.cam.orthographic = true;
            cameraChange.cam.nearClipPlane = -15f;
            cameraChange.gameProjection = eGameProjection.orto;
            cameraChange.persObjects.SetActive(false);
            CameraChange.canChange = false;

            //Play Audio
            if (lloronaDialogue.GetComponent<DialogueManager>().index <= 5)
            {
                AudioManager.instance.Play("Llorona Crying");
            }
            else
            {
                AudioManager.instance.Stop("Llorona Crying");
            }
         
        }

        if (trigger.gameObject.CompareTag("GetLoc"))
        {
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, -3.82f);
        }

        if (trigger.gameObject.CompareTag("Item"))
        {
            winScript.itemsCounter++;
            Destroy(trigger.gameObject);

            //Play Sound
            AudioManager.instance.Play("Take Object");
        }

        if (trigger.gameObject.CompareTag("Charm"))
        {
            winScript.charmsCounter++;
            Destroy(trigger.gameObject);

            //Play Sound
            AudioManager.instance.Play("Take Charm");
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

                //Play Sound
                AudioManager.instance.Play("");
            }
            else if (lloronaDialogue.GetComponent<DialogueManager>().index > 5)
            {
                trigger.GetComponent<Animator>().SetBool("isIdle", true);
            }
            else if((lloronaDialogue.GetComponent<DialogueManager>().index >= 8))
            {
                charm.SetActive(true);
            }
        }

        if (trigger.gameObject.CompareTag("2DZone"))
        {
            CameraChange.canChange = false;
        }

        if (trigger.gameObject.CompareTag("3DZone"))
        {
            CameraChange.canChange = false;
        }
    }

    private void OnTriggerExit(Collider trigger)
    {
        if (trigger.gameObject.CompareTag("Llorona"))
        {
            CameraChange.canChange = true;
            dialogueCanvas.SetActive(false);

            AudioManager.instance.Stop("Llorona Crying");
        }

        if (trigger.gameObject.CompareTag("Rama Plat"))
        {
            if (this.gameObject.transform.position.y > trigger.transform.position.y)
            {
                trigger.GetComponent<BoxCollider>().isTrigger = false;
            }
        }

        if (trigger.gameObject.CompareTag("2DZone"))
        {
            CameraChange.canChange = true;
            AudioManager.instance.Play("2D Theme");
        }

        if (trigger.gameObject.CompareTag("3DFullZone"))
        {
            AudioManager.instance.Play("3D Theme");
        }
    }


}
