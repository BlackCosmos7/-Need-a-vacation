using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalChoise : MonoBehaviour

{
    public GameObject firstPanel;
    public GameObject secondPanel;

    public void FirstPanel()
    {
        if (firstPanel != null)
        {
            firstPanel.SetActive(true);
        }
    }

    public void SecondPanel()
    {
        if (secondPanel != null)
        {
            secondPanel.SetActive(true);
        }
    }
}