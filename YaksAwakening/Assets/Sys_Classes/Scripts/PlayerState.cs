using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{


    #region Singleton

    private static PlayerState _instance;

    public static PlayerState Instance {  get { return _instance; } }


    #endregion

    #region Classes

    [SerializeField] private List<PlayerClass> classes = new List<PlayerClass>(3);

    private int currentClass = 0;

    #endregion

    #region Unity Functions
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else { Destroy(gameObject);}



    }

    #endregion

    #region ClassFunctions

    public void ChangeClass(int direction)
    {
        Debug.Log("Old Class: " + classes[currentClass].name);
        currentClass  = ((currentClass + direction) + classes.Count) % classes.Count;
        Debug.Log("New Class: " + classes[currentClass].name);
    }

    public void UseAbility(int abilityNum)
    {
        classes[currentClass].UseAbility(abilityNum);
    }

    #endregion



}
