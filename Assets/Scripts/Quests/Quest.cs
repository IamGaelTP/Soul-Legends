using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public bool isActive;

    public string title;
    public string description;
    public int objectsTaken;
    public int objectsRequired;

    public bool isReached()
    {
        return (objectsTaken >= objectsRequired);
    }

    public void LloronaChildTaken()
    {
        objectsTaken++;
    }

    public void QuestComplete()
    {
        isActive = false;
        Debug.Log(title + " was completed!");
    }
}
