using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAction : MonoBehaviour
{
    public GameObject HitEffect; //エフェクトプレハブ

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5.0f); //5秒で自身を撤去
    }

    void OnCollisionEnter(Collision other)
    {
        //何かに当たったらエフェクトプレハブを設置
        Instantiate(HitEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
