using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMechanics : MonoBehaviour
{
    private int width, height;

    [SerializeField] GameObject _tilePrefab;

    [SerializeField] Camera _cam;
    private List<GameObject> tiles = new List<GameObject>();

    private int[,] Grid = new int[InputManager.gridsize + 2, InputManager.gridsize + 2];

    private void Start()
    {
        width = InputManager.gridsize;
        height = InputManager.gridsize;

        GenerateGrid();
    }

    void GenerateGrid()
    {
        Camera.main.orthographicSize = width / 2 + 1;

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                GameObject spawnedTile = Instantiate(_tilePrefab, new Vector3(i, j), Quaternion.identity) as GameObject;
                spawnedTile.name = $"Tile {i}{j}";
                tiles.Add(spawnedTile);

            }
        }
        for (int i = 0; i < width + 2; i++)
        {
            for (int j = 0; j<height + 2; j++)
            {
                Grid[i, j] = 0;
                
            }
        }
        _cam.transform.position = new Vector3((float)width / 2 - 0.5f, (float)height / 2 - 0.5f, -10);
    }

    public bool Grid_full(int x, int y)
    {
        List<GameObject> neighbourTiles = new List<GameObject>();
        countNeighbours(x, y, neighbourTiles);

        if (neighbourTiles.Count == 0)
        {
            Grid[x + 1, y + 1] = 1;
            return true;
        }
        if (neighbourTiles.Count == 1)
        {
            List<GameObject> nneighbours = new List<GameObject>();
            countNeighbours((int)neighbourTiles[0].transform.position.x, (int)neighbourTiles[0].transform.position.y, nneighbours);
            if (nneighbours.Count == 0)
            {
                Grid[x + 1, y + 1] = 1;
                return true;
            }
            else
            {
                Cross_Grid_operations(neighbourTiles);
                Cross_Grid_operations(nneighbours);
                return false;
            }

        }
        else
        {
            List<GameObject> nnneighbours = new List<GameObject>();
            for (int i = 0; i < neighbourTiles.Count; i++)
            {
                countNeighbours((int)neighbourTiles[i].transform.position.x, (int)neighbourTiles[i].transform.position.y, nnneighbours);
            }
            Cross_Grid_operations(neighbourTiles);
            Cross_Grid_operations(nnneighbours);
            return false;
        }
    }
    private void countNeighbours(int x, int y, List<GameObject> neighbourtiles)
    {
        int a = 0;
        for (int i = -1; i < 2; i++)
        {
            for (int j = -1; j < 2; j++)
            {
                if (!((i == 0) & (j == 0)))
                {
                    a++;

                    if (Grid[x + 1 + i, y + 1 + j] == 1)
                    {
                        //Debug.Log(tiles[10 * (x + i) + (y + j)]);
                        neighbourtiles.Add(tiles[width * (x + i) + (y + j)]);
                    }
                }
            }
        }
    }

    private void Cross_Grid_operations(List<GameObject> nTiles)
    {

        for (int i = 0; i < nTiles.Count; i++)
        {
            nTiles[i].GetComponent<Tile>().crossdisable();
            Grid[(int)nTiles[i].transform.position.x + 1, (int)nTiles[i].transform.position.y + 1] = 0;
        }
    }
}
