using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float width = 900;
    private void Awake() {
        this.GetComponent<Camera>().orthographicSize = width / 2 / (Screen.width / Screen.height);
    }
}
