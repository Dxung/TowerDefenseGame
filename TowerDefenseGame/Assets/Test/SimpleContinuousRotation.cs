using UnityEngine;
using System.Collections;

public class SimpleContinuousRotation : MonoBehaviour
{

    public float _rotationAmount = 2f;
    public int _tickForSecond = 60;
    public bool _pause = false;


    void Start()
    {
        StartCoroutine(Rotate());
    }

    private IEnumerator Rotate()
    {
        WaitForSeconds Wait = new WaitForSeconds(1f / _tickForSecond);

        while (true)
        {
            if (!_pause)
            {
                transform.Rotate(Vector3.up * _rotationAmount);
            }

            yield return Wait;
        }
    }
}
