using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    Image img;
    Rigidbody2D r2d;
    PlayerSystem playerSystem;
    public void Init(Transform targetTf, LayerMask _layer, Color _col, PlayerSystem _playerSystem)
    {
        if (img == null)
            img = GetComponent<Image>();
        if (r2d == null)
            r2d = GetComponent<Rigidbody2D>();

        transform.SetPositionAndRotation(targetTf.position, targetTf.rotation);
        gameObject.layer = _layer;
        img.color = _col;
        playerSystem = _playerSystem;
        gameObject.SetActive(true);
        r2d.Sleep();
        r2d.AddForce(-transform.up * 500, ForceMode2D.Impulse);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject obj = collision.gameObject;
        if (obj.CompareTag("Cell"))
        {
            obj.GetComponent<Cell>().SwitchColor(gameObject.layer, playerSystem);
            BulletPool.Instance.InPool(this);
        }
    }
}
