using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class generalForTower : MonoBehaviour
{
    private Vector3 _rayOrigin;
    private Vector3 _rayDirection;
    float rayLength = 10f;
    

    RaycastHit hitInfo;

    [SerializeField] private GameObject _startWhenClickedObj;
    [SerializeField] private GameObject _towerHead;
    [SerializeField] private GameObject _target;
    private Vector3 _direction;
    private Quaternion _lookRotation;
    [SerializeField] float _rotationSpeed;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _startWhenClickedObj.SetActive(false);
        GetRay();
    }

    // Update is called once per frame
    void Update()
    {
        TurnHeadToTarget();
    }



    void TurnHeadToTarget()
    {
        if (_target)
        {
            _direction = (_target.transform.position - _towerHead.transform.position).normalized;
            _lookRotation = Quaternion.LookRotation(_direction);
            _towerHead.transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * _rotationSpeed);

        }
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



    /*--- Func for turn on when clicked in and off when clicked out ---*/
    public void SwitchState()
    {
        _startWhenClickedObj.SetActive(!_startWhenClickedObj.activeSelf);
    }

}
