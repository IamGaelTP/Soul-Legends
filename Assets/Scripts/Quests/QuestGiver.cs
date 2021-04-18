using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{
    public Quest quest;
    public PlayerQuest player;
    public GameObject questWindow;
    public Text titleText;
    public Text descriptionText;
    public Text objectsTakenText;
    public Text objectsRequiredText;

    public void OpenQuestWindow()
    {
        questWindow.SetActive(true);

        titleText.text = quest.title;
        descriptionText.text = quest.description.ToString();
        objectsTakenText.text = quest.objectsTaken.ToString();
        objectsRequiredText.text = quest.objectsRequired.ToString();

        ActiveQuest();
    }

    public void UpdateQuestWindow()
    {
        objectsTakenText.text = quest.objectsTaken.ToString();
        objectsRequiredText.text = quest.objectsRequired.ToString();
    }


    public void ActiveQuest()
    {
        quest.isActive = true;
        player.quest = quest;
    }
}
