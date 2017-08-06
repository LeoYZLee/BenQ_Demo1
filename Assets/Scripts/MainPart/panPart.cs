using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class panPart : MonoBehaviour {
    [SerializeField]
    private Transform panPartMark;
    [SerializeField]
    private GameObject movePart;

    [SerializeField]
    private List<Transform> points;

    public float yAngel = 0;
    //public float old_yAngel = 0;
    public int old_level = 0;

    [SerializeField]
    float minAngel = 0.0f;
    [SerializeField]
    float maxAngel = 90.0f;
    [SerializeField]
    int devideNum = 6;


    [SerializeField]
    Animation ani;

    private int level = 0;


    // Use this for initialization
    void Start() {
        ani.wrapMode = WrapMode.ClampForever;

    }

    // Update is called once per frame
    void Update() {

        float checkValue = Mathf.RoundToInt(panPartMark.localEulerAngles.y);
        int angel_unit = (int)(maxAngel - minAngel) / devideNum;
         level = Mathf.FloorToInt( checkValue / angel_unit);

        yAngel = level * angel_unit;

        Debug.Log("localEulerAngles:" + panPartMark.localEulerAngles.y.ToString() + " y = " + yAngel.ToString());

        //if (old_level != level)
        //{
        //float dis = Vector3.Distance(points[old_level].position, points[level].position) / (float)devideNum;
        //Transform point = p1.transform;
        //point.transform.localPosition =  p1.forward * dis * level;

        movePart.transform.position = points[level].position;//Vector3.Lerp(points[old_level].position, points[level].position, Time.deltaTime);



            transform.eulerAngles = new Vector3(0, yAngel, 0);
            old_level = level;

        //}

    }
}
