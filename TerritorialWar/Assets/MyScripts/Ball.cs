using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    PlayerSystem playerSystem;
    Image img;
    public Ball Init(PlayerSystem _playerSystem, Color col)
    {
        if (img == null)
            img = GetComponent<Image>();
        playerSystem = _playerSystem;
        img.color = col;
        return this;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "X2collider")
        {
            playerSystem.SetMultiple(true);
        }
        else if (collision.gameObject.name == "Firecollider")
        {
            playerSystem.Fire();
            playerSystem.SetMultiple(false);
        }
    }
}
