using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAction : MonoBehaviour
{
    Vector2 Rot = Vector2.zero;
    Vector2 Bias = new Vector2(5.0f, 5.0f); //単位秒あたりの回転角
    public float maxPitch = 50.0f; //仰角の制限
    public float minPitch = -50.0f; //俯角の制限
    void Update()
    {
        Rot.x = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * Bias.x;
        Rot.y += Input.GetAxis("Mouse Y") * Bias.y;
        Rot.y = Mathf.Clamp(Rot.y, minPitch, maxPitch);
        transform.localEulerAngles = new Vector3(-Rot.y, Rot.x, 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
}
