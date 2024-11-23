using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper : MonoBehaviour
{
    [SerializeField] Room startingRoom;

    private void Start()
    {
        GameManager.Instance.SetCurrentRoom(startingRoom);
    }

}
