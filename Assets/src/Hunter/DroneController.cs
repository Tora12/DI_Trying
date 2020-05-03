using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DroneController : MonoBehaviour
{
    public float reloadTime;
    public int maxAmmo;

    private void Start()
    {
        Dron.Instance.reloadTime = reloadTime;
        Dron.Instance.maxAmmo = maxAmmo;
    }
}

public class Dron : Singleton<Dron>
{
    private bool isReloading;
    private GameObject bullet;
    private int currentAmmo;
    private Vector3 droneTarget;

    [HideInInspector] public float reloadTime;
    [HideInInspector] public int maxAmmo;



    private void FixedUpdate()
    {
        droneTarget = Input.mousePosition;

        if(!isReloading)
        {
            if(currentAmmo <= 0)
            {
                StartCoroutine(reload());
                return;
            }

            if (Input.GetButtonDown("Fire1"))
                shoot();
        }
    }
    public void Start()
    {
        isReloading = false;
        bullet = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Jenner/Bullet.prefab", typeof(GameObject));
        currentAmmo = maxAmmo;
    }

    private IEnumerator reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        isReloading = false;
    }

    private void shoot()
    {
        GameManager.Instance.spawnEntity(bullet, droneTarget, Quaternion.identity, 0);
        currentAmmo--;
    }
}