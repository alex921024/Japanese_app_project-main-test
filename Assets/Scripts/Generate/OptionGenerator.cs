using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionGenerator : MonoBehaviour
{
    private int optionsNumber;
    private List<Sprite> optionImg = new List<Sprite>();
    private List<Sprite> JPCharsImg = new List<Sprite>();
    private void Awake() {
        SetAllJPChars();
        optionsNumber = GameObject.Find("Template").GetComponent<UIController>().options.Length;
    }
    public List<Sprite> GenerateOptions(List<Sprite> answerImg)
    {
        int answerNumber = answerImg.Count;
        //新增答案照片列表
        optionImg = answerImg;
        //新增選項照片列表
        for (int i = answerNumber ;i < optionsNumber; i++)
        {
            Sprite img = null;
            do{
                //生成亂數並檢查重複
                int randomIndex = Random.Range(0, JPCharsImg.Count);
                img = JPCharsImg[randomIndex];
            } while(Repeat(img, optionImg, i));
            optionImg.Add(img);
        }
        //打亂陣列
        Shuffle();
        return optionImg;
    }
    //設定所有50音資料
    private void SetAllJPChars()
    {
        string folderPath = "JPChars";  //指定五十音資料夾路徑
        Sprite[] sprites = Resources.LoadAll<Sprite>(folderPath);
        JPCharsImg.AddRange(sprites);
    }
    private bool Repeat(Sprite img , List<Sprite> imgs, int currentIndex)
    {
        bool isRepeat = false;
        for (int i = 0; i < currentIndex; i++)
        {
            if (img == imgs[i])
            {
                isRepeat = true;
            }
        }
        return isRepeat;
    }
    private void Shuffle()
    {
        for (int i = 0; i < optionsNumber; i++)
        {
            int randomIndex = Random.Range(i, optionsNumber);
            //交換
            Sprite temp = optionImg[i];
            optionImg[i] = optionImg[randomIndex];
            optionImg[randomIndex] = temp;
        }
    }
}
