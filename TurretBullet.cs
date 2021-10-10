﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBullet : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f, _force = 10f;
    [SerializeField]
    private float _destroyPosX = 0f;
    [SerializeField]
    private GameObject _explosionPrefab;
    [SerializeField]
    private Vector3 _offsetParticle = new Vector3(0, 0, 10);

    // Update is called once per frame
    void FixedUpdate()
    {
        BulletMovement();
    }


    void BulletMovement()
    {
        transform.Translate(Vector3.left * _speed * Time.deltaTime);
        if(transform.position.x < _destroyPosX )
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Player player = other.gameObject.GetComponent<Player>();
            player.Damage();
            Destroy(this.gameObject);
            GameObject explosionPrefab = Instantiate(_explosionPrefab, other.transform.position + _offsetParticle, Quaternion.identity);
            Destroy(explosionPrefab, 1f);
        }
    }
}
