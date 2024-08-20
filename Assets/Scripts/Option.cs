using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Option : MonoBehaviour
{
    public float scaleFactor = 0.8f;
    private string parent;
    void Start()
    {
        parent = this.transform.parent.name;
    }
    public void ChangeParent(){
        if (this.transform.parent == GameObject.Find(parent).transform)
        {
            ChangeToAnswerArea();
        }
        else
        {
            ChangeToOptionArea();
        }
    }
    public void ChangeToAnswerArea(){
        this.transform.SetParent(GameObject.Find("AnswerArea").transform);  
        this.transform.localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);
    }
    public void ChangeToOptionArea(){
        if (parent != null){
            this.transform.SetParent(GameObject.Find(parent).transform);
            this.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
