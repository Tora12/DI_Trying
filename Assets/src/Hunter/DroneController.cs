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
        Dron.Instance.drone = gameObject;
        Dron.Instance.maxAmmo = maxAmmo;
    }
}

public class Dron : Singleton<Dron>
{
    private bool isReloading;
    private GameObject bullet;
    private int currentAmmo;

    [HideInInspector] public float reloadTime;
    [HideInInspector] public GameObject drone;
    [HideInInspector] public int maxAmmo;
    public Vector3 droneTarget;
    Vector3 difference;
    float rotationX;
    float rotationY;
    float rotationZ;
    float distance;
    public Vector3 direction;


    private void Update()
    {
        if (!isReloading)
        {
            if(currentAmmo <= 0)
            {
                //StartCoroutine(reload());
                //return;
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
        droneTarget = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.x));
        droneTarget = new Vector3(GameManager.Instance.player.transform.position.x, droneTarget.y, droneTarget.z);
        difference = droneTarget - drone.transform.position;
        rotationX = Mathf.Atan(difference.x) * Mathf.Rad2Deg;
        distance = difference.magnitude;
        direction = difference / distance;
        GameManager.Instance.spawnEntity(bullet, drone.transform.position, Quaternion.Euler(rotationX, 0f, 0f), 0);
        currentAmmo--;
    }
}