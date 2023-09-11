using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform target;
    [SerializeField] private float shootInterval = 1;
    
    void Start()
    {
        StartCoroutine(Shoot());
    }

    void Update()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Enemy");
        if (targets.Length == 0) 
        {
            return;
        }
        target = targets[0].transform;
        LookAtTarget(target);
    }

    void LookAtTarget(Transform target)
    {
        Vector2 direction = target.position - transform.position;
        transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);
    }

    IEnumerator Shoot() {
        while(true) 
        {
            GameObject projectileGameObject = Instantiate(projectilePrefab);
            Projectile projectile = projectileGameObject.GetComponent<Projectile>();
            projectile.target = target;
            yield return new WaitForSeconds(shootInterval);
        }
    }
}
