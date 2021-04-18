using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    public GameObject bookCanvas;
    public GameObject[] book;

    private bool isAlreadyOpen = false;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M) && !isAlreadyOpen)
        {
            Time.timeScale = 0f;
            bookCanvas.SetActive(true);
            book[0].SetActive(true);
            book[1].SetActive(false);
            isAlreadyOpen = true;
        }
        else if (Input.GetKeyDown(KeyCode.M) && isAlreadyOpen)
        {
            bookCanvas.SetActive(false);
            book[0].SetActive(false);
            book[1].SetActive(false);
            isAlreadyOpen = false;
            Time.timeScale = 1f;
        }
    }

    public void NextPage(int nextPage)
    {
        book[nextPage].SetActive(true);
    }
}
