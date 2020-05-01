using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour {

  // Only allow one instance of the Drone script at a time
  // Only allows other classes to get instance of the Drone script
  // Does not allow other classes to delete an instance of the Drone script
  public static Drone Instance {get; private set;}

  [SerializeField]
  private Transform firePoint; // spawn point for Bullet.prefab to shoot forward along the z-axis

  [SerializeField]
  private GameObject bulletPrefab;

  public int maxAmmo = 20;
  public float reloadTime = 2f;
  private int currentAmmo;
  private bool isReloading = false;

  // Awake is always called before Start and only gets called once per instance
  private void Awake() {
    // Sets singleton property to this instance of Drone class when running for first time
    if(Instance ==  null) {
      Instance = this;
      DontDestroyOnLoad(gameObject); // FAILS FOR MULTI-THREAD
    } else {
      Destroy(gameObject);
    }
  }

  // Start is called before the first frame update
  private void Start() {
    currentAmmo = maxAmmo;
  }

  // Update is called once per frame
  private void Update() {
    // Keeps returning (threads) until reload() is finished
    if(isReloading) {
      return;
    }

    if(currentAmmo <= 0) {
      StartCoroutine(reload()); // Coroutines can be paused at any point using yield statements
      return;
    }

    if(Input.GetButtonDown("Fire1")) {
      shoot(); // Press 'right click' or 'x' in order to call
    }
  }

  // Method that simulates reloading ammo
  private IEnumerator reload() {
    isReloading = true;
    Debug.Log("Reloading...");
    yield return new WaitForSeconds(reloadTime); // IEnumerator allows us to pause the process to simulate reloading
    currentAmmo = maxAmmo;
    isReloading = false;
  }

  // Method that shoots a bullet from the Drone's current location in the direction where the Player was facing
  private void shoot() {
    Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    currentAmmo--;
  }
}
