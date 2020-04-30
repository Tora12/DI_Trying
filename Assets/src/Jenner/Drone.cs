using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour {

  [SerializeField]
  private Transform firePoint;

  [SerializeField]
  private GameObject bulletPrefab;

  private Vector3 shootDirection;

  public int maxAmmo = 50;
  private int currentAmmo;
  public float reloadTime = 2f;
  private bool isReloading = false;

  // Start is called before the first frame update
  void Start() {
    currentAmmo = maxAmmo;
  }

  // Update is called once per frame
  void Update() {

    if(isReloading) {
      return;
    }

    if(currentAmmo <= 0) {
      StartCoroutine(reload());
      return;
    }

    // attempt to be able to shoot towards mouse position
    // shootDirection = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));

    if(Input.GetButtonDown("Fire1")) {
      shoot();
    }

  }

  IEnumerator reload() {
    isReloading = true;
    Debug.Log("Reloading...");
    yield return new WaitForSeconds(reloadTime);
    currentAmmo = maxAmmo;
    isReloading = false;
  }

  void shoot() {
    Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    currentAmmo--;
  }
}
