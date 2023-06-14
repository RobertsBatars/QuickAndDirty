using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapons : MonoBehaviour
{
    [SerializeField] GameObject bombPrefab;
    private PlayerInventoryLogic inventory;
    private bool player1;

    private void Start()
    {
        inventory = GetComponent<PlayerInventoryLogic>();
        player1 = GetComponent<WheelController>().player1;
    }

    private void Update()
    {
        if (player1)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) && inventory.bombCount > 0)
            {
                PlaceBomb();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.RightShift) && inventory.bombCount > 0)
            {
                PlaceBomb();
            }
        }
    }

    private void PlaceBomb()
    {
        Instantiate(bombPrefab, transform.position, Quaternion.identity);
        inventory.bombCount--;
    }
}
