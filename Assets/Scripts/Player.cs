using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    public float speed = 8; // Inspectorビューで変更可能
    Animator animator;

    private @_3Dunitychan _3Dunitychan;
    private GameController _gamecontroller;
    //InputSystem

    private const float RotateSpeed = 720f;
    bool running; // フィールド
    bool Runing { // プロパティ
        get { return running; }
        set { // 値が異なるセット時のみanimator.SetBoolを呼ぶようにします
            if (value != running)
            {
                running = value;
                animator.SetBool("Running", running);
            }
        }
    }
    private void Start()
    {
        animator = GetComponent<Animator>();
        //animation
        _3Dunitychan = new @_3Dunitychan();
        _3Dunitychan.Enable();
        //InputSystem

        _gamecontroller = GameObject.Find("Prefab").GetComponent<GameController>();
    }
    void Update()
    {

        //Transform myTransform = this.transform;

        /*
        // 水平方向キー
        float x = Input.GetAxis("Horizontal");
        // 垂直方向キー
        float z = Input.GetAxis("Vertical");
        // 方向
        var velocity = new Vector3(x, 0, z);
        */
        // 移動用キーが押されていれば
        //if (direction.magnitude > 0)
        /*
            // 向きを変える
            //transform.rotation = Quaternion.LookRotation(direction); 

            //ベクトルの向きを取得
            Vector3 direction = velocity.normalized;
             //移動距離を計算
            float distance = speed * Time.deltaTime;
            //移動先を計算
            Vector3 destination = transform.position + direction * distance;

            //移動先に向けて回転
            transform.Rotate(Vector3.left);
        
            // 前に移動する
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            Runing = true; // プロパティによるセット
        } else
        {
            Runing = false; // プロパティによるセット
        }*/

        Vector3 direction = InputToDirection();
        float magnitude = direction.magnitude;

        if (Mathf.Approximately(magnitude, 0f) == false)
        {
            UpdateRotation(direction);
            // 前に移動する
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            Runing = true; // プロパティによるセット

            if(transform.position.x >=4) {
                transform.position = new Vector3(3.9f,0,transform.position.z);
            }
            if(transform.position.x <=-4) {
                transform.position = new Vector3(-3.9f,0,transform.position.z);
            }
            if(transform.position.z >=4) {
                transform.position = new Vector3(transform.position.x,0,3.9f);
            }
            if(transform.position.z <= -4) {
                transform.position = new Vector3(transform.position.x,0,-3.9f);
            }

        }else{
            Runing = false; // プロパティによるセット
        }
        
    }

    private Vector3 InputToDirection() {
        Vector3 direction = new Vector3(0f, 0f, 0f);

        if(_3Dunitychan.Move.Left.IsPressed())
        {
            if((_gamecontroller.score <= 48)||(_gamecontroller.DropScore <= 20))
            {//移動先に向けて回転
            //transform.Rotate(Vector3.left);
            direction.x += 1f;
            //Debug.Log("左に動く");
            }
            
        }else if(_3Dunitychan.Move.Right.IsPressed())
        {
            if((_gamecontroller.score <= 48)||(_gamecontroller.DropScore <= 20))
            {//移動先に向けて回転
            //transform.LookAt(Vector3.right);
            direction.x -= 1f;
            //Debug.Log("右に動く");
            }
            
        
        }else if(_3Dunitychan.Move.Up.IsPressed())
        {
            if((_gamecontroller.score <= 48)||(_gamecontroller.DropScore <= 20))
            {//移動先に向けて回転
            //transform.LookAt(Vector3.up);
            direction.z -= 1f;
            //Debug.Log("上に動く");]
            }
            
        
        }else if(_3Dunitychan.Move.Down.IsPressed())
        {
            if((_gamecontroller.score <= 48)||(_gamecontroller.DropScore <= 20))
            { //移動先に向けて回転
            //transform.LookAt(Vector3.down);
            direction.z += 1f;
            // Debug.Log("下に動く");
            }
        }

        return direction.normalized;
    }
    

    private void UpdateRotation(Vector3 direction)
    {
        Quaternion from = transform.rotation;
        Quaternion to = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.RotateTowards(from, to, RotateSpeed * Time.deltaTime);
    }
}