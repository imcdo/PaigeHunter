using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
public class RulerAttack : MonoBehaviour
{
    private Animator _Ruler;
    private Collider2D m_Collider;
    // Start is called before the first frame update
    private void Awake()
    {
        _Ruler = GetComponent<Animator>();
        m_Collider = GetComponent<Collider2D>();
        gameObject.GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
        if (Input.GetKeyDown("k"))
        {
            Debug.Log("hello");
            gameObject.GetComponent<Renderer>().enabled = true;
            m_Collider.enabled = true;

            _Ruler.SetTrigger("Attack");
            StopAllCoroutines();
            StartCoroutine(DelayVisibility(.5f));

        }

        IEnumerator DelayVisibility(float wait)
        {
            yield return new WaitForSeconds(wait);
            gameObject.GetComponent<Renderer>().enabled = false;
            //m_Collider.enabled = false;

        }



    }
}
