//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Interactable : MonoBehaviour
//{


//    private void Update()
//    {
//        if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject()) ;
//        getInteraction();
//    }

//    private void getInteraction()
//    {
//        Ray interactionRay = Camera.main.ScreenPointToRay(Input.mousePosition);
//        RaycastHit interactioninfo;
//        if(Physics.Raycast(interactionRay,out interactioninfo,Mathf.Infinity))
//        {
//            GameObject interactedObject = interactioninfo.collider.gameObject;
//            if(interactedObject.tag=="interactable Object")
//            {
//                Debug.Log("interactable interacted");
//            }
//            else
//            {
                
//            }
//        }
//    }
   


//}
