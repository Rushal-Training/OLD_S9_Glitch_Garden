using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    public GameObject projectile, gun;

    private GameObject projectileParent;
    private Animator animator;
    private Spawner myLaneSpawner;

    private void Start()
    {
        animator = GetComponent<Animator>();
        projectileParent = GameObject.Find("Projectiles");

        if(!projectileParent)
        {
            projectileParent = new GameObject("Projectiles");
        }

        SetMyLaneSpawner();
    }

    private void Update()
    {
        if(IsAttackerAheadInLane())
        {
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
    }

    void SetMyLaneSpawner ()
    {
        GameObject parent = GameObject.Find("Spawners");
        foreach(Transform child in parent.transform)
        {
            if(child.transform.position.y == transform.position.y)
            {
                myLaneSpawner = child.gameObject.GetComponent<Spawner>();
                return;
            }
        }

        Debug.LogError(name + " can't find any spawners.");
    }

    bool IsAttackerAheadInLane()
    {
        if(myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }

        foreach(Transform attacker in myLaneSpawner.transform)
        {
            if(attacker.transform.position.x > transform.position.x)
            {
                return true;
            }
        }

        // Attackers in lane but behind
        return false;
    }

    private void Fire()
    {
        GameObject newProjectile = Instantiate(projectile);
        newProjectile.transform.parent = projectileParent.transform;
        newProjectile.transform.position = gun.transform.position;
    }

    /*private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }*/
}
