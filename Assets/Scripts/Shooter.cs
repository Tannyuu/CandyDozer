using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject[] candyPrefabs;
    public Transform candyParentTransform;//親子関係を結んで動きを連動させたりする GameObject型だとcandy.transform.parent = candyParent.transformになる GetComponentが必要になる
    public float shotForce;
    public float shotTorque;
    public float baseWidth;
    public CandyManager candyManager;//candyManagerをinspectorから登録できる shooterからcandymanagerを使いたい

    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) Shot();  //Downを消すとボタン押しっぱなしで連射できる
    }

    GameObject SampleCandy() //GameObjectの戻り値を返す型
    {
        int index = Random.Range(0, candyPrefabs.Length);//0～3まで
        return candyPrefabs[index];
    }

    Vector3 GetInstantiatePosition()
    {
        float x = baseWidth * (Input.mousePosition.x/*クリックしたxの座標*/ / Screen.width) - (baseWidth / 2);//ベースの横幅の〇%の場所にシューターを向ける
        return transform.position + new Vector3(x, 0, 0);
    }

    public void Shot()
    {
        //Debug.Log(Hoge.num); staticフィールドだとクラス名.で誰でもアクセスできる scriptのassetsにあるだけで使える しかし、誰でも使える分弊害もある 個人開発だとアリ
        //Hoge.num++;
        if(candyManager.GetCandyAmount() <= 0)
        {
            return;
        }

        GameObject candy = (GameObject)Instantiate(
            SampleCandy(),
            GetInstantiatePosition(),
            Quaternion.identity//.Euler(0,0,0)でもいい　三次元空間の中の回転　position(0,0,0)でオブジェクトを作りたいときの表記
                               //Euler(0,0,0);
             );

        candy.transform.parent = candyParentTransform;//親になるオブジェクトを設定する際には親になるGameObjectのtransformを代入する

        Rigidbody candyRigidBody = candy.GetComponent<Rigidbody>();
        candyRigidBody.AddForce(transform.forward * shotForce);//加える力
        candyRigidBody.AddTorque(new Vector3(0, shotTorque, 0));//回転力

        candyManager.ConsumeCandy();
    }
}
