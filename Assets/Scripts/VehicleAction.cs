using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleAction : MonoBehaviour
{
    float h; //水平軸
    float v; //垂直軸
    Vector3 Dir; //移動方向
    public float foreSpeed = 5.0f; //前進速度
    public float backSpeed = 2.0f; //後退速度
    public float rotSpeed = 25.0f; //単位秒あたりの回転角

    //public GameObject Manager;
    //BallAction[] BallAction = new BallAction[9];
    void FixedUpdate()
    {

        h = Input.GetAxis("Horizontal"); //入力デバイスの水平軸
        v = Input.GetAxis("Vertical"); //入力デバイスの垂直軸
        Dir = new Vector3(0, 0, v);
        Dir = transform.TransformDirection(Dir);
        Dir *= (v > 0.1f) ? foreSpeed : backSpeed;
        transform.localPosition += Dir * Time.fixedDeltaTime; //本体を移動
        transform.Rotate(0, h * rotSpeed * Time.fixedDeltaTime * 2, 0); //本体を回転
    }

    // Start is called before the first frame update
    void Start()
    {
        //for (int i = 0; i < 9; i++)
        //{
        //    BallAction[i]=Manager.transform.GetChild(i).gameObject.GetComponent<BallAction>();
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
