using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    [SerializeField] private GameObject towerPrefab;
    [SerializeField] private GameObject[] towerSlots;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
    
            if(hit.collider != null)
            {
                int towerSlotIndex = Array.IndexOf(towerSlots, hit.collider.gameObject);
                if (towerSlotIndex != -1) {
                    PlaceTower(towerSlotIndex);
                }
            }
        }
    }

    void PlaceTower(int towerSlotIndex) 
    {
        GameObject tower = Instantiate(towerPrefab);
        tower.transform.position = towerSlots[towerSlotIndex].transform.position;
    }
}
