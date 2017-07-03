using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour
{

    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20;
    //弾いたときの傾き
    private float flickAngle = -20;

    // Use this for initialization
    void Start()
    {
        this.myHingeJoint = GetComponent<HingeJoint>();
        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);
    }

    // Update is called once per frame
    void Update()
    {
        //左矢印キーを押した時左フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.flickAngle);
        }
        //右矢印キーを押した時右フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }
        
        //矢印キー離された時フリッパーを元に戻す
        if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.defaultAngle);
        }




        for (int i = 0; i < Input.touchCount; ++i)
        {
            Touch touch = Input.GetTouch(i);

            //タッチしたところが左の方ならば
            if (touch.position.x < Screen.width / 2 && touch.phase == TouchPhase.Began && tag == "LeftFripperTag")
            {
                SetAngle(this.flickAngle);
            }

            if (Screen.width / 2 < touch.position.x && touch.phase == TouchPhase.Began && tag == "RightFripperTag")
            {
                SetAngle(this.flickAngle);
            }

            if (touch.position.x < Screen.width / 2 && touch.phase == TouchPhase.Ended && tag == "LeftFripperTag")
            {
                SetAngle(this.defaultAngle);
            }

            if (Screen.width / 2 < touch.position.x && touch.phase == TouchPhase.Ended && tag == "RightFripperTag")
            {
                SetAngle(this.defaultAngle);
            }

        }





        
    }

    //フリッパーの傾きを設定
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}
