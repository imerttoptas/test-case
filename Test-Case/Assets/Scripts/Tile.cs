using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] GameObject x;
    private GameMechanics gridManager;
    void Start()
    {
        gridManager = GameObject.Find("GameManager").GetComponent<GameMechanics>();
    }

    private void OnMouseDown()
    {
        if (x.activeSelf == false)
        {
            if (gridManager.Grid_full((int)gameObject.transform.position.x, (int)gameObject.transform.position.y))
            {
                x.SetActive(true);
            }
        }
    }
    public void crossdisable()
    {
        x.SetActive(false);
    }
}
