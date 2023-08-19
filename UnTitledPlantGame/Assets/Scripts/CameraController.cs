using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _player;
    // Update is called once per frame
    void Update()
    {
        Camera.main.transform.position = new Vector3(_player.position.x,_player.position.y, Camera.main.transform.position.z);
    }
}
