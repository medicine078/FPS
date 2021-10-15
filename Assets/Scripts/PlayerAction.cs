using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public float moveSpeed = 3.0f; //単位秒あたりの移動距離
    public float rotSpeed = 180.0f; //単位秒あたりの回転角
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float v = Input.GetAxis("Vertical"); //上下キー操作（-1～0～1）
        float h = Input.GetAxis("Horizontal"); //左右キー操作（-1～0～1）
        transform.Rotate(0, h * rotSpeed * Time.fixedDeltaTime, 0); //回転操作
        Vector3 Dir = new Vector3(0, 0, v);
        Dir = transform.TransformDirection(Dir); //特定する物体で言い換えた向きにする。
        transform.position += Dir * Time.fixedDeltaTime * moveSpeed;


    }
}
