using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAction : MonoBehaviour
{
    public bool Activate = false;
    GameManager gm;
    GameObject Manager;
    GameObject ballParent;
    bool startFlg;

    // Start is called before the first frame update
    void Start()
    {
        startFlg = false;
        Manager = GameObject.Find("Manager");
        ballParent = GameObject.Find("BallPrefab");
        gm = Manager.gameObject.GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (startFlg == true)
        {
            if (other.gameObject.tag == "Bullet" && gameObject.name.Substring(5, 1) == gm.nextTarget.ToString())
            {
                if (gm.nextTarget == 9)
                {
                    gm.gameFinish = true;
                }
                gm.nextTarget++;
                gm.Time_flg = true;
                Debug.Log("当たった");
                Destroy(gameObject);
                Debug.Log("デストロイ");
            }
        }
    }

    void BallDestroy(string strNum)
    {
        int Num = int.Parse(strNum) + 1;
        if (Num + "" == gameObject.name.Substring(5, 1))
        {
            Activate = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        startFlg = gm.gameStart;
        //Debug.Log(startFlg);
    }
}
