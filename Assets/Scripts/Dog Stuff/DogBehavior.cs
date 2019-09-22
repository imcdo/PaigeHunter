﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogBehavior : MonoBehaviour
{

    private int _phase; // 0 - pre-fight, 1 - fight w/ beakers, 2 - minions, 3 - ded
    [SerializeField] private GameObject _beaker;
    [SerializeField] private GameObject _player;
    // Start is called before the first frame update
    void Start()
    {
        _phase = 1;
        BeakerBurst(2f);
        StartCoroutine(BeakerBurst(.5f));
    }

    // Update is called once per frame
    void Update()
    {
        if (_phase == 1)
        {
        } else if (_phase == 2)
        {

        }

    }

    IEnumerator BeakerBurst(float cooldown)
    {
        Debug.Log("In method???");
        while (_phase == 1)
        {
            Debug.Log("In while loop");
                if (_beaker != null && _player != null)
                {
                Debug.Log("In if statement");

                Vector3 modifiedPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                    Vector3 targetDirection1 = _player.transform.position - transform.position;
                    Vector3 targetDirection2 = _player.transform.position - modifiedPos;
                    Vector3 targetDirection3 = _player.transform.position + modifiedPos;
                    Instantiate(_beaker, transform.position, Quaternion.FromToRotation(Vector3.right, targetDirection1));
                    Instantiate(_beaker, transform.position, Quaternion.FromToRotation(Vector3.right, targetDirection2));
                    Instantiate(_beaker, transform.position, Quaternion.FromToRotation(Vector3.right, targetDirection3));


            }
            yield return new WaitForSeconds(cooldown);
            Debug.Log("after waitforseconds");

        }
    }
}
