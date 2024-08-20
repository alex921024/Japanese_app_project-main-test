using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    //丟level資料
    public LevelData[] chapter1;
    public LevelData[] chapter2;
    public LevelData[] chapter3;
    public LevelData[] chapter4;
    public LevelData[] chapter5;
    public LevelData[] chapter6;
    public LevelData[] chapter7;
    public LevelData[] chapter8;
    public LevelData[] chapter9;
    public LevelData[] chapter10;
    public LevelData[] chapter11;
    private List<LevelData[]> chapters = new List<LevelData[]>();
    private LevelData[] currentChapter;

    void Awake()
    {
        chapters.Add(chapter1);
        chapters.Add(chapter2);
        chapters.Add(chapter3);
        chapters.Add(chapter4);
        chapters.Add(chapter5);
        chapters.Add(chapter6);
        chapters.Add(chapter7);
        chapters.Add(chapter8);
        chapters.Add(chapter9);
        chapters.Add(chapter10);
        chapters.Add(chapter11);
    }
    public LevelData GenerateLevel(int levelIndex)
    {
        int chapterIndex = GlobalData.chapter;
        currentChapter = chapters[chapterIndex - 1];
        if (levelIndex >= 0 && levelIndex < currentChapter.Length)
        {
            LevelData levelData = new LevelData(chapterIndex, currentChapter[levelIndex].pinyin, 
            currentChapter[levelIndex].isKatakana);
            return levelData;
        }
        return null;
    }
    public int GetChapterLength()
    {
        currentChapter = chapters[GlobalData.chapter - 1];
        return currentChapter.Length;
    }
}
