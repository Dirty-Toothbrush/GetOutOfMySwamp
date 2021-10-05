using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Path
{
    CellInfo[] cells;
    float spawnWait = 1f;
    float nextSpawnTime = 0;
    public float Length { get { return cells.Length; } }

    public Path(CellInfo[] cellInfos)
    {
        cells = cellInfos;
    }
    public Vector3 GetStep(int idx) { return new Vector3(cells[idx].x, cells[idx].y, -1); }

    public bool CheckSpawn()
    {
        if (Time.time > nextSpawnTime)
        {
            nextSpawnTime = Time.time + spawnWait;
            return true;
        }
        return false;
    }
}