using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour {

    public float hook_Speed;

    public int scoreValue;

    public string itemTag;

    void OnDisable() {  
        GameplayManager.instance.DisplayScore(scoreValue);
    }

}
