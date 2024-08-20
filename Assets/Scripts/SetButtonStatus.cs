using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetButtonStatus : MonoBehaviour
{
    public Button[] onlockBtn;
    public GameObject[] completionIndicator;
    public GameObject[] lockIndicator;
    private int completeNumber;
    // Start is called before the first frame update
    void Start()
    {
        for (int chapterIndex = 1; chapterIndex < 12; chapterIndex++)
        {
            bool isComplete = PlayerPrefs.GetInt($"Chapter{chapterIndex}Completed", 0) == 1;
            if (isComplete)
            {
                completionIndicator[chapterIndex - 1].SetActive(true);
                completeNumber++;
            }
        }
        if (completeNumber >= 8)
        {
            lockIndicator[0].SetActive(false);
            onlockBtn[0].interactable = true;
        }
        if (completeNumber >= 9)
        {
            lockIndicator[1].SetActive(false);
            onlockBtn[1].interactable = true;
        }
        if (completeNumber >= 10)
        {
            lockIndicator[2].SetActive(false);
            onlockBtn[2].interactable = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
