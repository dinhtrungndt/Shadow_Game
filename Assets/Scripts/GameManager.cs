using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public float TimeBee0, CountBee0;
    public GameObject Bee0;
    public float NumberBee0;

    public GameObject Player;

    /* public float TimeClock, CountClock;
     public Sprite Clock0, Clock1, Clock2, Clock3, Clock4, Clock5, Clock6, Clock7, Clock8, Clock9, Clock10, Clock11;
     public int NumberClock;
     public GameObject ClockImage;*/

    // Start is called before the first frame update
    void Start()
    {
        TimeBee0 = 1f;
        CountBee0 = TimeBee0;
        NumberBee0 = 0;

       /* // đồng hồ
        TimeClock = 1f;
        CountClock = TimeClock;
        NumberClock = 0;*/
    }

    // Update is called once per frame
    void Update()
    {
        if(NumberBee0 < 3) RandomBee();
        /*UpdateClockImage();*/
    }

   // tạo random quạ sau 1s 1 lần, vtri ngẫu nhiên
   void RandomBee()
    {
        CountBee0 -= Time.deltaTime;
        if(CountBee0 <= 0)
        {
            NumberBee0++;
            CountBee0 = TimeBee0;
            GameObject go1 = Instantiate(Bee0);
            go1.GetComponent<Bee0>().InstantiatePlaye(Player);
            go1.transform.position = new Vector3(
                       Random.Range(150, 55),1f,0);
            /* Destroy(go1, 5f);*/
        }
    }

    /*void UpdateClockImage()
    {
        CountClock -= Time.deltaTime;
        if(CountClock <= 0)
        {
            CountClock = TimeClock;
            Sprite[] sprites = new Sprite[] { Clock0, Clock1, Clock2, Clock3, Clock4, Clock5,
        Clock6, Clock7, Clock8, Clock9, Clock10, Clock11};
            ClockImage.GetComponent<Image>().sprite = sprites[NumberClock];
           NumberClock++;
            if (NumberClock > 11) NumberClock = 0;
        }
    }*/

  
}
