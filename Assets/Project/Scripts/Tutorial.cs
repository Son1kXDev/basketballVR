using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public List<GameObject> panels;
    public int curPanelNum;

    public static bool isTutorial = false;

    private void Start()
    {
        isTutorial = false;
        curPanelNum = 0;
        panels[curPanelNum].SetActive(true);
        print(panels.Count);
    }

    private void NextPanel()
    {
        panels[curPanelNum].SetActive(false);
        curPanelNum++;
        panels[curPanelNum].SetActive(true);
    }

    public void TakeABall()
    {
        if (!isTutorial)
        {
            NextPanel();
            StartCoroutine(Timer());
            isTutorial = true;
        }
    }

    private IEnumerator Timer()
    {
        while (curPanelNum < panels.Count)
        {
            print("next panel");
            yield return new WaitForSeconds(7);
            NextPanel();
        }
    }
}