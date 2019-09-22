using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogBehavior : MonoBehaviour
{

    private int _phase; // 0 - pre-fight, 1 - fight w/ beakers, 2 - minions, 3 - ded
    [SerializeField] private GameObject _beaker;
    [SerializeField] private GameObject _bork;
    [SerializeField] private GameObject _player;
    // Start is called before the first frame update
    void Start()
    {
        _phase = 2;

        StartCoroutine(BeakerBurst(.5f));
        StartCoroutine(Bork());

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
        while (_phase == 1 || _phase == 2)
        {
                if (_beaker != null && _player != null)
                {
                    Vector3 targetDirection1 = _player.transform.position - transform.position;
                    Instantiate(_beaker, transform.position, Quaternion.FromToRotation(Vector3.right, targetDirection1));
                }
            if (_phase == 1)
                yield return new WaitForSeconds(cooldown);
            else
                yield return new WaitForSeconds(cooldown * 2 / 3);

        }
    }

    IEnumerator Bork()
    {
        while (_phase == 2)
        {
            Vector3 targetDirection1 = _player.transform.position - transform.position;
            Instantiate(_bork, transform.position, Quaternion.FromToRotation(Vector3.right, targetDirection1));
            yield return new WaitForSeconds(Random.Range(4, 7));
        }
    }
}
