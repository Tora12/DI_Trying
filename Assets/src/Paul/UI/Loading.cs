using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    public GameObject dataStoreObject = null;
    private DataStore dataStore = null;
    public GameObject ui = null;
    void Start()
    {
        dataStoreObject = GameObject.Find("DataStore");
        
        if (dataStoreObject != null)
        {
            dataStore = dataStoreObject.GetComponent<DataStore>();
            ui = GameObject.Find("Canvas");
            if (dataStore.ui)
            {
                ui.SetActive(true);
            }
            else if (!dataStore.ui)
            {
                ui.SetActive(false);
            }
			if(dataStore.bcmode){
				GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthandDamage>().health=float.MaxValue;
			}
        }
        else
            Debug.LogWarning("Main Menu Scene not Loaded.\nYou can Safely ignore this message, added for better debug.");
    } 
}
