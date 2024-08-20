using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    //物件
    public GameObject panel;
    public Sprite dayBackGround;
    public Sprite nightBackGround;
    public GameObject slider;
    public GameObject image;
    public GameObject pinyin;
    public GameObject soundBtn;
    public GameObject correct;
    public GameObject wrong;
    public GameObject goodEnd;
    public GameObject badEnd;
    public GameObject pausePanel;
    public GameObject[] options;
    public void SetUpLearnModeUI()
    {
        slider.SetActive(false);
        panel.GetComponent<Image>().sprite = dayBackGround;

    }
    public void SetUpChallengeModeUI(){
        slider.SetActive(true);
        panel.GetComponent<Image>().sprite = nightBackGround;

    }
    public void SetUpBasicTopicUI(){
        image.SetActive(false);
        pinyin.GetComponent<RectTransform>().sizeDelta = new Vector2(800, 200);
        pinyin.GetComponent<RectTransform>().anchoredPosition = new Vector2(-400, 500);
        pinyin.GetComponent<TextMeshProUGUI>().alignment = TextAlignmentOptions.Center;
        pinyin.GetComponent<TextMeshProUGUI>().fontSize = 150;
        soundBtn.SetActive(false);
    }
    public void SetUpAdvancedTopicUI(){
        pinyin.SetActive(false);
        soundBtn.SetActive(false);
    }
    public void SetUp(LevelData levelData, List<Sprite> optionImg)
    {
        //LevelData
        image.GetComponent<Image>().sprite = levelData.image;
        pinyin.GetComponent<TextMeshProUGUI>().text = levelData.pinyin;
        soundBtn.GetComponent<AudioSource>().clip = levelData.audioClip;
        soundBtn.GetComponent<AudioSource>().Play();
        //OptionData
        for (int i = 0; i < optionImg.Count; i++)
        {
            options[i].GetComponent<Option>().ChangeToOptionArea();
            options[i].GetComponent<Image>().sprite = optionImg[i];
        }
    }
    
    public void ShowCorrect()
    {
        correct.SetActive(true);
    }
    public void ShowWrong()
    {
        wrong.SetActive(true);
    }
    public void ShowGoodEnd()
    {
        goodEnd.SetActive(true);
    }
    public void ShowBadEnd()
    {
        badEnd.SetActive(true);
    }
    public void ShowPause()
    {
        pausePanel.SetActive(true);
    }
    public void HideFeedBack()
    {
        correct.SetActive(false);
        wrong.SetActive(false);
        goodEnd.SetActive(false);
        badEnd.SetActive(false);
        pausePanel.SetActive(false);
    }
}
