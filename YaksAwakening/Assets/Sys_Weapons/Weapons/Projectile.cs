using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]

public abstract class Projectile : MonoBehaviour
{

    //Projectile Stats
    [Header("Stats")]
    [SerializeField] private float projectileSpeed;

    //Additional Components
    [Header("Components")]
    [SerializeField] private Rigidbody2D rigidBody;

    #region TriggerHit
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hit " + collision.name);
        StartCoroutine(ParentHitCoroutine(collision));

    }

    //OwnerWrapper
    private IEnumerator ParentHitCoroutine(Collider2D collision)
    {
        //Perform custom on hit Coroutine if defined
        yield return ColliderHitCoroutine(collision);

        Debug.Log("The Cake is a lie!");
        //Finally Destory the projectile
        Destroy(this.gameObject);

    }

    //Perform a specific action per projectile type
    protected virtual IEnumerator ColliderHitCoroutine(Collider2D collision)
    {
        yield return null;
    }

    #endregion

    #region Initalization Steps

    public void StartProjectile(Vector2 direction)
    {
        //Recieve Direction
        rigidBody.velocity = direction*projectileSpeed;
        


    }


    #endregion


}
