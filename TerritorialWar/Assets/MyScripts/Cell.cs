using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    Image img;
    PlayerSystem playerSystem;
    public void SwitchColor(LayerMask layer, PlayerSystem _playerSystem)
    {
        if (img == null)
            img = GetComponent<Image>();
        if (playerSystem == null)
            playerSystem = GetComponentInParent<PlayerSystem>();
        playerSystem.SetTerritory(-1);
        gameObject.layer = layer;
        switch (LayerMask.LayerToName(layer))
        {
            case "Green":
                img.color = Color.green; break;
            case "Red":
                img.color = Color.red; break;
            case "Yellow":
                img.color = Color.yellow; break;
            case "Blue":
                img.color = Color.blue; break;
        }
        playerSystem = _playerSystem;
        playerSystem.SetTerritory(1);
    }
}
