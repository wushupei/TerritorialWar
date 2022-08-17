using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSystem : MonoBehaviour
{
    [SerializeField] Color ballColor;
    Ball ball;
    List<Ball> balls = new List<Ball>();
    Transform ori;
    Gun gun;

    Text territoryTex, multipleTex, surplusTex, DeathTimer;
    int territory, multiple, surplus;
    void Start()
    {
        Init();
    }
    void Init()
    {
        ball = Resources.Load<Ball>("MyPrefabs/Ball/Ball");
        ori = transform.Find("BG").Find("Ori");
        gun = GetComponentInChildren<Gun>();
        territoryTex = transform.Find("HUD").Find("Territory").GetComponent<Text>();
        multipleTex = transform.Find("HUD").Find("Multiple").GetComponent<Text>();
        surplusTex = transform.Find("HUD").Find("Surplus").GetComponent<Text>();
        DeathTimer = transform.Find("HUD").Find("DeathTime").GetComponent<Text>();
        SetTerritory(224);
        SetMultiple(false);
        SetSurplus(0);

        Invoke("CreateBall", 1);
    }
    public void CreateBall()
    {
        balls.Add(Instantiate(ball, ori.position, ori.rotation, transform).Init(this, ballColor));
    }
    public void Fire()
    {
        SetSurplus(multiple);
        gun.AddFunQueue(multiple);
    }
    public void SetTerritory(int num)
    {
        territory += num;
        territoryTex.text = "Territory:" + territory.ToString();
        if (territory == 0)
        {
            SystemDeath();
            enabled = false;
        }
    }
    public void SetMultiple(bool _double)
    {
        if (_double)
            multiple *= 2;
        else
            multiple = 1;
        multipleTex.text = "Multiple:" + multiple.ToString();
    }
    public void SetSurplus(int num)
    {
        surplus += num;
        surplusTex.text = "Surplus:" + surplus.ToString();
    }
    public Color SystemWin()
    {
        foreach (var item in balls)
        {
            Destroy(item.GetComponent<Ball>());
        }
        return ballColor;
    }
    public void SystemDeath()
    {
        foreach (var item in balls)
        {
            Destroy(item.gameObject);
        }
        DeathTimer.text = MainGame.Instance.GetDeathTimer();
        gun.Death();
    }
}
