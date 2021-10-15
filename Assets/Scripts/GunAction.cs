using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAction : MonoBehaviour
{
    public float Vel = 30.0f; //弾の初速度
    public float interval = 0.1f; //弾の射出間隔
    public GameObject Bullet; //弾のプレハブ
    GameObject B;
    bool isTrigger = false; //トリガーを引いているか？

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Shot");
    }

    IEnumerator Shot()
    {
        while (true)
        { //永遠に繰り返す
            if (isTrigger)
            { //トリガーを引いていたら発砲処理（２行）を実行
                B = Instantiate(Bullet, transform.position, Quaternion.identity);
                B.GetComponent<Rigidbody>().velocity = transform.forward * Vel;
            }
            yield return new WaitForSeconds(interval); //射出間隔だけ待つ
        }
    }

    // Update is called once per frame
    void Update()
    {
        isTrigger = Input.GetButton("Fire1");
    }
}
