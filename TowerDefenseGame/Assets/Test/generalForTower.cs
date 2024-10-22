using UnityEngine;
using UnityEngine.UIElements;

public class generalForTower : MonoBehaviour
{
    private Vector3 _rayOrigin;
    private Vector3 _rayDirection;
    float rayLength = 10f;
    

    RaycastHit hitInfo;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetRay();
    }

    // Update is called once per frame
    void Update()
    {
        CheckHit();
        GetRay();
    }


    void CheckHit()
    {
        bool hasHit = Physics.Raycast(_rayOrigin, _rayDirection, out hitInfo, rayLength);

        Debug.DrawRay(_rayOrigin, _rayDirection * rayLength, Color.red);
        if (hasHit)
        {
            Debug.Log("Hit: " + hitInfo.collider.name);
        }
    }

    void GetRay()
    {
        _rayOrigin = this.gameObject.transform.position;
        _rayDirection = this.gameObject.transform.forward;
    }
}
