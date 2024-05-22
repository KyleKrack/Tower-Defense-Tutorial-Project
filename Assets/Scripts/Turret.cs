using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    
    private Transform target;
    private Enemy targetEnemy; 
    
    [Header("General")]
    public float range = 15f;
    
    [Header("Use Bullets (default)")]
    public float fireRate = 1f;
    private float fireCountDown = 0f;
    public GameObject bulletPrefab;

    
    [Header("Use Laser")] 
    public bool useLaser = false;
    public LineRenderer lineRenderer;
    public ParticleSystem impactEffect;
    public int damageOverTime = 30;
    public float slowPercent = .5f; 
    
    
    [Header("Unity Setup")]
    
    public string enemyTag = "Enemy";
    public float turnSpeed = 10f; 
    public Transform partToRotate;
    
    public Transform firePoint; 
    
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f); 
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            if (useLaser)
            {
                if (lineRenderer.enabled)
                {
                    impactEffect.Stop();
                    lineRenderer.enabled = false; 
                }
            }
            return;
        }
           
        
        //target lockon
        lockOnTarget();

        if (useLaser)
        {
            Laser();
        }
        else
        {
            if (fireCountDown <= 0f)
            {
                Shoot();
                fireCountDown = 1f / fireRate;
            }

            fireCountDown -= Time.deltaTime; 
        }
        

    }

    void Laser()
    {
        
        targetEnemy.GetComponent<Enemy>().takeDamage(damageOverTime * Time.deltaTime);

        targetEnemy.Slow(slowPercent); 
        
        
        if (!lineRenderer.enabled)
        {
            impactEffect.Play(); 
            lineRenderer.enabled = true; 
        }
        lineRenderer.SetPosition(0,firePoint.position);
        lineRenderer.SetPosition(1, target.position);

        Vector3 dir = firePoint.position - target.position;
        
        impactEffect.transform.position = target.position + dir.normalized; 
        
        impactEffect.transform.rotation = Quaternion.LookRotation(dir);

        
    }

    void lockOnTarget()
    {
        Vector3 direction = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void Shoot()
    {
        Debug.Log("Shoot");
        GameObject bulletGO = (GameObject) Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }

    void UpdateTarget()
    {

        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null; 
        
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy; 
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Enemy>(); 
        }
        else
        {
            target = null; 
        }
        
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range); 
    }
}
