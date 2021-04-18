using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public int itemsCounter;
    public int charmsCounter;
    public GameObject winCanvas;

    // Update is called once per frame
    void Update()
    {
        if(itemsCounter >= 3 && charmsCounter >= 1)
        {
            winCanvas.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
