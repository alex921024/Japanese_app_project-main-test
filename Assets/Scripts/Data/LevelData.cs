using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelData
{
    public int chapterIndex { get; private set; }
    public string pinyin;
    public bool isKatakana;
    public Sprite image { get; private set; }
    public AudioClip audioClip { get; private set; }
    public List<string> answer { get; private set; }
    public List<Sprite> answerImg { get; private set; }
    public LevelData(int chapterIndex, string pinyin, bool isKatakana)
    {
        this.chapterIndex = chapterIndex;
        this.pinyin = pinyin;
        this.isKatakana = isKatakana;
        this.image = SetIamge();
        this.audioClip = SetAudio();
        this.answer = new List<string>();
        this.answerImg = new List<Sprite>();
        SetAnswer();
        SetAnswerImage();
    }
    private Sprite SetIamge()
    {
        string folderPath = $"Chapter{chapterIndex}/Pictures";
        Sprite[] sprites = Resources.LoadAll<Sprite>(folderPath);
        foreach (Sprite sprite in sprites)
        {
            if (sprite.name == pinyin.ToLower())
            {
                return sprite;
            } 
        }
        Debug.Log("Image not found");
        return null;
    }
    private AudioClip SetAudio()
    {
        string folderPath = $"Chapter{chapterIndex}/Sounds";
        AudioClip[] audios = Resources.LoadAll<AudioClip>(folderPath);
        foreach (AudioClip audio in audios)
        {
            if (audio.name == pinyin.ToLower())
            {
                return audio;
            } 
        }
        Debug.Log("Audio not found");
        return null;
    }
    private void SetAnswer()
    {
        string standardString = pinyin.ToLower();
        //建立放小字串的空字串
        string currentSubString = string.Empty;
        //建立N的特例
        bool encounterN = false;
        //建立抝音的特例
        string[] searchStrings = {"cha", "chu", "cho", "sha", "shu", "sho", "ja", "ju", "jo"};


        foreach (char character in standardString)
        {
            if (character == '-')
            {
                answer.Add("-");
            }
            //遇到N:先標記，如果接下來是子音，就結束片段
            else if (character == 'n')
            {
                //nn特例:Ginniro
                if (encounterN)
                {
                    encounterN = false;
                    answer.Add(currentSubString);
                    currentSubString = string.Empty;
                }
                else
                {
                    currentSubString += character.ToString();
                    encounterN = true;
                }
            }
            //遇到母音:結束片段
            else if (character == 'a' || character == 'e' || character == 'i' || character == 'o' || character == 'u')
            {
                encounterN = false;
                currentSubString += character.ToString();
                //抝音
                if ((currentSubString.Length > 2 && currentSubString != "shi" && currentSubString != "chi" && currentSubString != "tsu") || 
                    (currentSubString == "ja" || currentSubString == "ju" || currentSubString == "jo"))
                {
                    string firstWord;
                    string secondWord;
                    //加i加y
                    //e.g.cha
                    if (searchStrings.Any(s => currentSubString.Contains(s)))
                    {
                        //ch i
                        firstWord = currentSubString.Substring(0, currentSubString.Length - 1) + "i";
                        //y a
                        secondWord = "y" + currentSubString[currentSubString.Length - 1];
                    }
                    //加i
                    //e.g.nya
                    else
                    {
                        //n i
                        firstWord = currentSubString.Substring(0, currentSubString.Length - 2) + "i";
                        //ya
                        secondWord = currentSubString.Substring(currentSubString.Length - 2);
                    }
                    answer.Add(firstWord);
                    answer.Add(secondWord);
                }
                //其他特例：fe=>fue
                else if (currentSubString == "fe")
                {
                    answer.Add("fu");
                    answer.Add("e");
                }
                else
                {
                    answer.Add(currentSubString);
                }
                currentSubString = string.Empty;
            }
            //遇到n以外的子音:加入片段
            else
            {
                //輸出n，同時避免n類抝音被擋
                if (encounterN && character != 'y')
                {
                    encounterN = false;
                    answer.Add(currentSubString);
                    currentSubString = string.Empty;
                }
                currentSubString += character.ToString();
            }
        }
        //輸出句尾的N
        answer.Add(currentSubString);
    }
    private void SetAnswerImage()
    {
        bool isFound;
        string folderPath = isKatakana ? "JPChars/Katakana" : "JPChars/Hiragana";
        Sprite[] sprites = Resources.LoadAll<Sprite>(folderPath);
        foreach (string word in answer)
        {
            isFound = false;
            foreach (Sprite sprite in sprites)
            {
                if (sprite.name == word)
                {
                    answerImg.Add(sprite);
                    isFound = true;
                }
            }
            if (!isFound)
            {
                Debug.Log(word + " not found");
            }
        }
        
    }
}
