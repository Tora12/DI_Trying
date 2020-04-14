using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    public GameObject dataStoreObject = null;
    private DataStore dataStore = null;
    public GameObject ui;
    void Start()
    {
        dataStoreObject = GameObject.Find("DataStore");
        dataStore = dataStoreObject.GetComponent<DataStore>();

        ui = GameObject.Find("Canvas");

        if (dataStore.ui)
        {
            ui.SetActive(true);
        }
        
        else if(!dataStore.ui) 
        {
            ui.SetActive(false);
        }
    } 
}
