using UnityEngine;



public class OnClick : MonoBehaviour
{

    [Header("Can Choose Multiple Layers")]
    [SerializeField] LayerMask _layerMask;


    private RaycastHit _hit;

    [SerializeField] private GameObject _currentClickedObj;

    [Header("choose which kind of obj to switch state when click out")]
    [SerializeField] private string _switchStateObjTag;



    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ActionWhenRaycast(CreateRaycast());
        }
    }



    /*--- Create raycast from main camera to where the mouse pointing ---*/
    Ray CreateRaycast()
    {
        return Camera.main.ScreenPointToRay(Input.mousePosition); 
    }


    /*--- Check if the raycast collider something ---*/
    void ActionWhenRaycast(Ray createdRay)

    {
        if (Physics.Raycast(createdRay,out _hit, Mathf.Infinity, _layerMask))
        {
            CheckIfClickOtherObj(_hit.collider.gameObject, _switchStateObjTag);
        }
        else
        {
            RayCastNotHit();
        }
    }


    /*--- check if click other obj ---*/
    void CheckIfClickOtherObj(GameObject obj, string objTag)
    {
        if(_currentClickedObj == null)                                              //in case first time click in that obj
        {
            _currentClickedObj = obj;
            SwitchStateforTower(_currentClickedObj);
        }
        else
        {
            if (!System.Object.ReferenceEquals(_currentClickedObj, obj))            //if press other obj
            {
                SwitchStateforTower(obj);
                SwitchStateforTower(_currentClickedObj);
                _currentClickedObj = obj;
            }
        }
    }  


    /*--- Incase raycast not hit anything (click out)*/
    void RayCastNotHit()
    {
        if(_currentClickedObj != null)
        {
            SwitchStateforTower(_currentClickedObj);
            _currentClickedObj = null;
        }
        
    }



    /*--- Switch State for Choosen Tower ---*/
    void SwitchStateforTower(GameObject theTower) 
    {
        if (theTower.CompareTag(_switchStateObjTag))
        {
            theTower.GetComponent<generalForTower>().SwitchState();
        }
        
    }
}
