﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ieStartLevelPrefs : MonoBehaviour {

    public int PlaceTotalBuilding;
    private LevelValueHolder LevelValueHolderScript;
    private ieLevelValueHolder ieLevelValueHolderScript;
    public Text NumberOfPeopleText;
    void Start() 
    {
        /*if (!PlayerPrefs.HasKey("UnlockLevels")) PlayerPrefs.SetInt("UnlockLevels",1);
        if(!PlayerPrefs.HasKey("RescuePoints")) PlayerPrefs.SetInt("RescuePoints",75);
        if (!PlayerPrefs.HasKey("TotalRescuePoints")) PlayerPrefs.SetInt("TotalRescuePoints", 0);
        if (!PlayerPrefs.HasKey("CurrentZoom")) PlayerPrefs.SetInt("CurrentZoom", 0);
        if (!PlayerPrefs.HasKey("CompleteLevelCounter")) PlayerPrefs.SetInt("CompleteLevelCounter", 0);

     
        for (int num = 1; num < PlaceTotalBuilding; num++)
        {
            if (!PlayerPrefs.HasKey("Building_L" + num.ToString())) PlayerPrefs.SetInt("Building_L" + num.ToString(), 0);
            LevelValueHolderScript = GameObject.Find("Building_L" + num.ToString()).GetComponent<LevelValueHolder>();
            LevelValueHolderScript.RescueHolderPlayerPref = PlayerPrefs.GetInt("Building_L" + num.ToString());
        }*/

        for (int num = 76; num < 101; num++)
        {
            if (!PlayerPrefs.HasKey("ieBuilding_L" + num.ToString())) PlayerPrefs.SetInt("ieBuilding_L" + num.ToString(), 0);
            ieLevelValueHolderScript = GameObject.Find("ieBuilding_L" + num.ToString()).GetComponent<ieLevelValueHolder>();
            ieLevelValueHolderScript.RescueHolderPlayerPref = PlayerPrefs.GetInt("ieBuilding_L" + num.ToString());
        }
        
    }
}
