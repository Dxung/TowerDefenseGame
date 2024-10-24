using UnityEngine;
using System.Collections;

public class LookAtTarget : MonoBehaviour
{

    public Transform _target;
    public float _speed = 1f;

    private Coroutine _lookCoroutine;

    void Start()
    {
        StartRotating();
    }


    void StartRotating()
    {
        if (_lookCoroutine != null)
        {
            StopCoroutine(_lookCoroutine );
        }
        _lookCoroutine = StartCoroutine(LookAt());

    }

    private IEnumerator LookAt()
    {
        Debug.Log("check");

        Quaternion  lookRotation = Quaternion.LookRotation( _target.position-transform.position);

        float time = 0;
        while (time < 1)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, time);

            time += Time.deltaTime * _speed;
            
        }
        yield return null;
    }

}
