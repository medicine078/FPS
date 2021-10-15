using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RummerAction : MonoBehaviour
{
    public float moveSpeed = 3.0f; //単位秒あたりの移動距離
    public float rotSpeed = 360.0f; //単位秒あたりの回転角

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float v = Input.GetAxis("Vertical"); //上下キー操作（-1～0～1）
        float h = Input.GetAxis("Horizontal"); //左右キー操作（-1～0～1）
        bool x = Input.GetButton("Fire2");

        if(x == true && v > 0)
        {
            v *= 2;
        }
        //【命題２】の位置
        Vector3 Dir = new Vector3(h/2, 0, v);

        //マウスのX方向の移動量を取得する。
        float Pan = Input.GetAxis("Mouse X");
        //回転量を求める
        Pan = Pan * rotSpeed * Time.fixedDeltaTime;
        //現在の状況に回転量を加える。
        transform.Rotate(0, Pan, 0);

        Dir = transform.TransformDirection(Dir); //特定する物体で言い換えた向きにする。
        transform.position += Dir * Time.fixedDeltaTime * moveSpeed;
    }
}
