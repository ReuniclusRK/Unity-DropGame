using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropObject2 : MonoBehaviour
{

    //public int Drop = 0;
    //落とした数を入れる変数
    public int acquisition;
    //獲得した数を入れる変数
    private GameController _gamecontroller;

    private float time = 1.0f;
    //
    private float isTime = 1.0f;
    //基準となるtime

    // Start is called before the first frame update
    void Start()
    {
        _gamecontroller = GameObject.Find("Prefab").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        time += 0.01f;

        // transformを取得
        Transform myTransform = this.transform;

        // ローカル座標基準で、現在の回転量へ加算する
        myTransform.Rotate (new Vector3(100.0f, 100.0f, 100.0f)*Time.deltaTime);

        //GameObject.Find("score").GetComponent<gameController>().addscore1();
    }


    private void OnCollisionEnter(Collision collision)
    //衝突判定
    {
        Destroy(this.gameObject,0.1f);
        if(collision.gameObject.CompareTag("Player")) 
        //床とplayerごとに衝突判定を分ける
        {
            _gamecontroller.addscore2();
        }
        else 
        {
            //Drop += 2;
            _gamecontroller.addDropScore2();
        }
        
        
        
        //数値を2増やす
        _gamecontroller.SetCountText();
        Debug.Log("Hit"); // ログを表示する 

        if(time >= isTime)
        //Destroyを0.1f遅らせているため、過度にクローンを作らせないための措置
        {
            Instantiate(this, new Vector3(Random.Range(-3.0f, 3.0f), Random.Range(30.0f,60.0f), Random.Range(-3.0f, 3.0f)), Quaternion.identity);
            //this.transform.Translate(0.1f*0.01f,0.1f*0.01f,0.1f*0.01f);
            //objectの再生成
            time = 0.0f;
        }
        
        
    }

}

