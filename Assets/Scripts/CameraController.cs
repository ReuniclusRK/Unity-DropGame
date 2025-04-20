using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //private Player _player;
    // Start is called before the first frame update
    //float speed;

    private GameObject SD_unitychan_humanoid;

    private const float RotateSpeed = 720f;

    //private int x = 0;
    //矢印キーなどが押されているか判定用の変数

    private int y = 0;
    //同上
    
    private @_3Dunitychan _3Dunitychan;
    
    void Start()
    {
        //SD_unitychan_humanoid
        //_player = GameObject.Find("SD_unitychan_humanoid").GetComponent<Player>();
        _3Dunitychan = new @_3Dunitychan();
        _3Dunitychan.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = InputToDirection();
        float magnitude = direction.magnitude;

        if (Mathf.Approximately(magnitude, 0f) == false)
        {
            UpdateRotation(direction);
        }
    }

    private Vector3 InputToDirection() {
        Vector3 direction = new Vector3(0f, 180f, 0f);

        /*if(_3Dunitychan.Camera.Left.IsPressed())
        {
            //移動先に向けて回転
            //transform.Rotate(Vector3.left);
            direction.x -= 0.0001f;
            Debug.Log("Camera Left");
            if(direction.x < -180)
            {
                direction.x += 360; 
            }
            x++;
        }else if(_3Dunitychan.Camera.Right.IsPressed())
        {
            //移動先に向けて回転
            //transform.LookAt(Vector3.right);
            direction.x += 0.0001f;
            Debug.Log("Camera Right");

            if(direction.x > 180)
            {
                direction.x -= 360; 
            }
            x++;
        }else 
        */
        if(_3Dunitychan.Camera.Up.IsPressed())
        {
            //移動先に向けて回転
            //transform.LookAt(Vector3.up);
            direction.y += 0.0001f;
            Debug.Log("Camera Up");

            if(direction.y > 180)
            {
                direction.y -= 360; 
            }
            y++;
        }else if(_3Dunitychan.Camera.Down.IsPressed())
        {
            //移動先に向けて回転
            //transform.LookAt(Vector3.down);
            direction.y -= 0.0001f;
            Debug.Log("Camera Down");

            if(direction.y < -180)
            {
                direction.y += 360; 
            }
            y++;
        }
        /*else if((_3Dunitychan.Camera.Up.IsPressed() && _3Dunitychan.Camera.Down.IsPressed())||(_3Dunitychan.Camera.Right.IsPressed() && _3Dunitychan.Camera.Left.IsPressed()))
        {
            if(x != 2 || y != 2)
            {
            //移動先に向けて回転
            transform.LookAt(SD_unitychan_humanoid.transform);
            //direction = new Vector3(x,0f,0f);
            //this.transform.Rotate(direction_2,Space.World);
            Debug.Log("正面");
            }
        }
        */
            //x = 0;
            y = 0;
            return direction.normalized;
    }

    private void UpdateRotation(Vector3 direction)
    {
        Quaternion from = transform.rotation;
        Quaternion to = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.RotateTowards(from, to, RotateSpeed * Time.deltaTime);
    }
}
