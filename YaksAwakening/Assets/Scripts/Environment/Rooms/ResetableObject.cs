using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetableObject : MonoBehaviour
{

    [Header("Object Specification")]
    [SerializeField] GameObject spawnObject; //Variable for the prefab of the object to create

    [SerializeField] bool disableOnStart; //Boolean on whether or not to disable on start


    //[Header("Gizmos")]
    //[SerializeField] Sprite gizmoSprite;

    private GameObject spawnedObject; //Reference to the object created

    #region Unity Functions

    protected virtual void Start()
    {

        //Create a copy of the object
        CreateObject();

    }

    #endregion

    #region Custom Functions

    #region Creation/Destruction
    public virtual void CreateObject()
    {
        //If an object already exists, destory it
        if (spawnedObject != null)
        {
            Destroy(spawnedObject);
        }
        //Create new instance of the object
        Debug.Log("Creating New Object");
        spawnedObject = Instantiate(spawnObject, transform);


        //If object specified to wait until activated, disable it
        if (disableOnStart)
        {
            DisableObject();
            Debug.Log("Object Disabled On Start");
        }

    }

    public virtual void DestoryObject()
    {
        //Destory Object
        Destroy(spawnedObject);
    }

    #endregion


    #region Enable/Disable

    //Returns true if properly enables
    public virtual bool EnableObject()
    {
        //Check to see if we are already enabled
        if (spawnedObject.activeSelf)
        {
            //If we are, Log it and return false
            Debug.Log("Object already Enabled");
            return false;
        }
        else
        {
            //Otherwise, enable and return true
            spawnedObject.SetActive(true);
            return true;
        }
    }

    //Returns true if properly disables
    public virtual bool DisableObject()
    {
        //Check to see if already disabled
        if (!spawnedObject.activeSelf)
        {
            //If we are, Log it and return false
            Debug.Log("Object already Disabled");
            return false;
        }
        else
        {
            //Otherwise, disable and return true
            spawnedObject.SetActive(false);
            return true;
        }
    }
    #endregion

    #endregion

    #region Gizmos

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 drawLocation = transform.position;
        drawLocation.y += .5f;
        Gizmos.DrawWireCube(drawLocation, new Vector3(1f, 1f, 1f));
    }


    #endregion






}
