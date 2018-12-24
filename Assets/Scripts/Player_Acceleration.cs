using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Acceleration : MonoBehaviour {

    private Vector3 dir;
    private int Shakecount=0;
    public float count_down;
    //制限時間
    public float Shaketime;
    public float Slidespeed;
    private int takasa=0;
    public Text count;
    public Text count_downtxt;
    public Text shake_timetxt;
    public Text takasatxt;
    public AudioSource nobi;
    public GameObject haikei;
    public GameObject bamboo;
    public GameObject titlebutton;
    private float goalpoint;
    private bool play=false;

    void Start()
    {
        takasatxt.text = takasa.ToString() + "m";
        titlebutton.SetActive(false);
    }

    void FixedUpdate () {
        count_down -= Time.deltaTime;
        if (count_down<1)
        {
            count_downtxt.text = "";
            Shaketime -= Time.deltaTime;
            if (Shaketime > 0)
            {
                shake_timetxt.text = "振れ！\n" + ((int)Shaketime).ToString();
                Shake();
            }
            else
            {
                if (!play)
                {
                    nobi.Play();
                    play = !play;
                }
                goalpoint = (float)-(72.5 / 250)*Shakecount;
                shake_timetxt.text = "";
                if (haikei.transform.position.y > goalpoint)
                {
                    haikei.transform.position = new Vector2(haikei.transform.position.x, haikei.transform.position.y - Time.deltaTime * Slidespeed);
                    if (bamboo.transform.position.y > -9.5)
                    {
                        bamboo.transform.position = new Vector2(bamboo.transform.position.x, bamboo.transform.position.y - Time.deltaTime * Slidespeed);
                    }
                    takasa = takasa + 2500;
                    takasatxt.text = takasa.ToString()+"m";
                }
                else
                {
                    nobi.Stop();
                    titlebutton.SetActive(true);
                }
            }
        }
        else
        {
            count.text = "";
            shake_timetxt.text = "";
            count_downtxt.text = ((int)count_down).ToString();
        }
	}

    void Shake()
    {
        dir = Vector3.zero;

        dir.y = Input.acceleration.y;
        if (dir.y > 3 || dir.y < -3)
        {
            Shakecount++;
            if (Shakecount >= 250)
            {
                Shakecount = 250;
            }
        }
        if (Shakecount < 250)
        {
            count.text = "神パワー: " + Shakecount.ToString();
        }
        else
        {
            count.text = "神パワー: MAX!";
        }
    }
}
