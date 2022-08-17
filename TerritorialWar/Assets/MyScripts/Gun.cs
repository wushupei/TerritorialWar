using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    Bullet bullet;
    Transform muzzle;
    Transform curBullets;
    Color col;
    Collider2D c2d;
    [HideInInspector] public PlayerSystem playerSystem;
    Queue<IEnumerator> funQueue = new Queue<IEnumerator>();
    bool inFire;
    bool isDie;
    [SerializeField] bool sho;
    private void Start()
    {
        bullet = Resources.Load<Bullet>("MyPrefabs/Bullet/Bullet");
        muzzle = transform.GetChild(0).GetChild(0);
        curBullets = GameObject.Find("CurBullets").transform;
        col = GetComponentInChildren<Image>().color;
        c2d = GetComponent<Collider2D>();
        playerSystem = GetComponentInParent<PlayerSystem>();
    }
    public void AddFunQueue(int _multiple)
    {
        funQueue.Enqueue(Fire(_multiple));
        if (inFire == false)
            StartCoroutine(funQueue.Dequeue());
    }
    IEnumerator Fire(int _multiple)
    {
        inFire = true;
        for (int i = 0; i < _multiple; i++)
        {
            if (isDie || MainGame.Instance.over) break;
            Bullet obj = BulletPool.Instance.OutPool();
            if (obj != null)
                obj.Init(muzzle, gameObject.layer, col, playerSystem);
            else
                Instantiate(bullet, curBullets).Init(muzzle, gameObject.layer, col, playerSystem);
            playerSystem.SetSurplus(-1);
            yield return new WaitForSeconds(0.1f);
        }
        inFire = false;
        if (funQueue.Count > 0)
            StartCoroutine(funQueue.Dequeue());
    }
    public void Death()
    {
        Image[] imgs = GetComponentsInChildren<Image>();
        foreach (var item in imgs)
        {
            item.color = Color.black;
        }
        isDie = true;
        MainGame.Instance.PlayerOut(this);
    }
}
