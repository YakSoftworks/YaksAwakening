using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerToolBase : ScriptableObject
{
    /*
        Controls are made assuming we are only supporting controller

        Should be adaptable for Key/Mouse

     */

    //Bumper Actions
    //Assume to be secondary

    public abstract void RBActionPerformed();
    public abstract void LBActionPerformed();

    //Trigger Actions
    //Assume to be primary

    public abstract void RTActionPerformed();
    public abstract void LTActionPerformed();






}
