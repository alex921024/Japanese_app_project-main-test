using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetParameter : MonoBehaviour
{
    //設定模式
    public void SetMode(bool _mode){
        GlobalData.mode = _mode;
    }
    //設定章節
    public void SetChapter(int _chapter){
        GlobalData.chapter = _chapter;
    }
    //設定下一幕
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    //清除玩家資料
    public void ClearPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
    }
}
