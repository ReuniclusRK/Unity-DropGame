using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_SE : MonoBehaviour
{
    public AudioClip item_get;
    public AudioClip win_SE;
    public AudioClip GameOver_SE;

    public AudioClip gamestart;

    AudioSource audioSource0;
    AudioSource audioSource1;
    AudioSource audioSource2;

    AudioSource audioSource3;
    private int count =0;

    private GameController _gamecontroller;
    void Start () 
    {
    //Componentを取得
    audioSource0 = GetComponent<AudioSource>();
    audioSource1 = GetComponent<AudioSource>();
    audioSource2 = GetComponent<AudioSource>();
    audioSource3 = GetComponent<AudioSource>();

    _gamecontroller = GameObject.Find("Prefab").GetComponent<GameController>();
    audioSource0.PlayOneShot(gamestart);
    }

    void Update () 
    {
        if(count == 0)
        {
            if(_gamecontroller.score >= 10)
            {
                audioSource2.PlayOneShot(win_SE);
                count++;
            }

            if(_gamecontroller.DropScore >= 50)
            {
                audioSource3.PlayOneShot(GameOver_SE);
                count++;
            }
            
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(_gamecontroller.score < 10 && _gamecontroller.DropScore < 50)
        {
            audioSource1.PlayOneShot(item_get);
        }
    }
}
