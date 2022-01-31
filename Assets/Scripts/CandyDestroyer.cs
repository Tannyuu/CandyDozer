using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyDestroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Candy")//いきなりGameObjectだとこのスクリプトがアタッチされてるゲームオブジェクト
        {
            Destroy(other.gameObject);
        }
    }
}
