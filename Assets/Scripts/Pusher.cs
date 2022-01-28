using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pusher : MonoBehaviour
{
    Vector3 startPosition;

    public float ampulitube;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.localPosition;
        //transformがいきなりでてきたらscriptがアタッチされてるゲームオブジェクトを指す
        //localPositionはオフセット量(親要素との差)
    }

    // Update is called once per frame
    void Update()
    {
        float z = ampulitube * Mathf.Sin(Time.time * speed);//Mathfは数学系のクラス

        transform.localPosition = startPosition + new Vector3(0, 0, z);
    }
}
