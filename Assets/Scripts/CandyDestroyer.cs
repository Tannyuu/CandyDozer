using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyDestroyer : MonoBehaviour
{
    public CandyManager candyManager;
    public int reward;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Candy")//いきなりGameObjectだとこのスクリプトがアタッチされてるゲームオブジェクト
        {
            candyManager.AddCandy(reward);//自分のrewardの数字の分だけcandyを増やす

            Destroy(other.gameObject);
        }
    }
}
