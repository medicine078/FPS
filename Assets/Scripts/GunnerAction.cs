using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunnerAction : MonoBehaviour
{
    float yRot = 0;
    public float rotSpeed = 5.0f; //回転速度

    public float maxPitch = 50.0f; //仰角の制限
    public float minPitch = -50.0f; //俯角の制限

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //現在のカメラの仰角俯角にマウスの前後移動量を（速度を考慮して）加える
        yRot += Input.GetAxis("Mouse Y") * rotSpeed * Time.deltaTime;
        //制限角度以内に収める(Clamp)
        yRot = Mathf.Clamp(yRot, minPitch, maxPitch);
        //上記で求めたyRotをカメラの角度に与える
        transform.localEulerAngles = new Vector3(-yRot, 0, 0);
    }
}
