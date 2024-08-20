using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControllerForStartScene : MonoBehaviour
{
    public GameObject startBtn;
    public GameObject information;
    public GameObject character;
    public void ShowInformation()
    {
        startBtn.SetActive(false);
        information.SetActive(true);
        character.SetActive(false);
    }
    public void HideInformation()
    {
        startBtn.SetActive(true);
        information.SetActive(false);
        character.SetActive(true);
    }
}
