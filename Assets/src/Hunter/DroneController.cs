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
        Drone.Instance.reloadTime = reloadTime;
        Drone.Instance.drone = gameObject;
        Drone.Instance.maxAmmo = maxAmmo;
    }
}

public class Drone : Singleton<Drone>
{
    private bool isReloading;
    private float bulletDistance;
    private float bulletRotation;
    private GameObject bullet;
    private GameObject[] bulletPrefabs;
    private int currentAmmo;
    private int currentBullet;
    private Vector3 droneTarget;
    private Vector3 bulletDifference;

    [HideInInspector] public float reloadTime;
    [HideInInspector] public GameObject drone;
    [HideInInspector] public int maxAmmo;
    [HideInInspector] public Vector3 bulletDirection;



    private void Update()
    {
        if(GameManager.Instance.inGame)
        {
            if (!isReloading)
            {
                if (currentAmmo <= 0)
                {
                    reload();
                    return;
                }

                if (Input.GetButtonDown("Fire1"))
                    shoot();

                if (Input.GetButtonDown("Fire2"))
                    changeAmmo();
            }
        }
    }
    public void Start()
    {
        isReloading = false;
        bulletPrefabs = PrefabLoader.LoadAllPrefabsAt(@"Assets/Prefabs/Jenner/PlayerBullets").ToArray();
        bullet = bulletPrefabs[0];
        currentAmmo = maxAmmo;
        currentBullet = 0;
    }

    private IEnumerator reload_Coroutine()
    {
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        isReloading = false;
    }

    private void changeAmmo()
    {
        if (currentBullet < bulletPrefabs.Length - 1)
            currentBullet++;
        else
            currentBullet = 0;

        bullet = bulletPrefabs[currentBullet];
    }



    public void reload()
    {
        StartCoroutine(reload_Coroutine());
    }

    public void shoot()
    {
        droneTarget = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.x));
        droneTarget = new Vector3(GameManager.Instance.player.transform.position.x, droneTarget.y, droneTarget.z);
        bulletDifference = droneTarget - drone.transform.position;
        bulletRotation = Mathf.Atan2(bulletDifference.y, bulletDifference.z) * -Mathf.Rad2Deg;
        bulletDistance = bulletDifference.magnitude;
        bulletDirection = bulletDifference / bulletDistance;
        GameManager.Instance.spawnEntity(bullet, drone.transform.position, Quaternion.Euler(bulletRotation, 0f, 0f), 0);
        currentAmmo--;
    }
}