using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour {

    //ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;

    //ゲームオーバを表示するテキスト
    private GameObject gameoverText;

    //得点を表示させるtext
    private GameObject pointText;

    //得点
    private int point;

    // Use this for initialization
    void Start()
    {
        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");
        this.pointText = GameObject.Find("PointText");
        this.point = 0;

        //ポイントの初期表示
        PointViewChanged();
    }

    // Update is called once per frame
    void Update()
    {
        //ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameoverTextにゲームオーバを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }
    }

    //ポイントの表示が変わるべき時にポイントを表示する
    private void PointViewChanged()
    {
        //ポイントの表示
        pointText.GetComponent<Text>().text = "point: " + this.point;
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "SmallStarTag":
                this.point += 1;
                break;
            case "LargeStarTag":
                this.point += 5;
                break;
            case "SmallCloudTag":
                this.point += 10;
                break;
            case "LargeCloudTag":
                this.point += 50;
                break;
            default:
                break;
        }

        //ポイントの表示を更新
        PointViewChanged();

    }
}
