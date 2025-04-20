using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM_Changer : MonoBehaviour
{
    public AudioSource[] _audios;
    [Range(0,1)]
    private GameController _gamecontroller;

    // Start is called before the first frame update
    void Start()
    {
        _gamecontroller = GameObject.Find("Prefab").GetComponent<GameController>();
        _audios[0].Play();
    }
    

    // Update is called once per frame
    void Update()
    {
        if(_gamecontroller.score >= 10)
        {
            _audios[1].Play();
        }
    }
}
