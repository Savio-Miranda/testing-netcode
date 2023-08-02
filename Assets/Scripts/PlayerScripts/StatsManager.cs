using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class StatsManager
{
    private GameObject _player;
    private Rigidbody _rb;
    [SerializeField] private float life;
    [SerializeField] private float speed;
    [SerializeField] private float strength;
    [SerializeField] private float jumpForce;


    public StatsManager(GameObject player)
    {
        _player = player;
        _rb = _player.GetComponent<Rigidbody>();
    }
    float GetSpeed() => speed;
}
