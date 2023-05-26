using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] private List<PuzzleSlot> _slotPrefabs;
    [SerializeField] private PuzzlePiece _piecePrefab;
    [SerializeField] private Transform _slotParent, _pieceParent;
    [SerializeField] private GameObject _pizzaPrefab;


    public int count; 

    void Start()
    {
        Spawn();
    }

    void Spawn()
    {
        for (int i = 0; i < _slotPrefabs.Count; i++)
        {
            var spawnedSlot = Instantiate(_slotPrefabs[i], _slotParent.GetChild(i).position, Quaternion.identity);
            spawnedSlot.pz = this;
            var spawnedPiece = Instantiate(_piecePrefab, _pieceParent.GetChild(i).position, Quaternion.identity);
            spawnedPiece.Init(spawnedSlot);
        }
    }

    private bool hasPizzaSpawned = false;

    public void setcount()
    {
        count += 1;
        if (count > 9 && !hasPizzaSpawned)
        {
            Debug.Log("Done");
            Instantiate(_pizzaPrefab, new Vector3(9, 0, -2), Quaternion.identity); // You can replace (0, 0, 0) with any position you want
            hasPizzaSpawned = true;
        }
    }











    //void Spawn()
    //{
    //   var randomSet = _slotPrefabs.OrderBy(s => Random.value).Take(10).ToList();
    //
    //   for (int i = 0; i < randomSet.Count; i++)
    //   {
    //        var spawnedSlot = Instantiate(randomSet[i], _slotParent.GetChild(i).position, Quaternion.identity);

    //        var spawnedPiece = Instantiate(_piecePrefab, _pieceParent.GetChild(i).position, Quaternion.identity);
    //        spawnedPiece.Init(spawnedSlot);
    //   }
    //  }




}
