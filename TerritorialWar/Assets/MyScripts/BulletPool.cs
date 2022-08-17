using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool
{
    private static BulletPool _instance;
    public static BulletPool Instance
    {
        get
        {
            if (_instance == null)
                _instance = new BulletPool();
            return _instance;
        }
    }
    Queue<Bullet> ballQueue = new Queue<Bullet>();
    public void InPool(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
        ballQueue.Enqueue(bullet);
    }
    public Bullet OutPool()
    {
        if (ballQueue.Count > 0)
            return ballQueue.Dequeue();
        else
            return null;
    }
}
