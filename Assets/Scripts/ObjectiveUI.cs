using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectiveUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textP1;
    [SerializeField] private TextMeshProUGUI textP2;

    private PlayerInventoryLogic player1;
    private PlayerInventoryLogic player2;
    // Start is called before the first frame update
    void Start()
    {
        List<PlayerInventoryLogic> players = new List<PlayerInventoryLogic>(FindObjectsOfType<PlayerInventoryLogic>());
        player1 = players[1];
        player2 = players[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (player1.hasPackage)
        {
            textP1.text = "Deliver the package";
        }
        else
        {
            textP1.text = "Find the package";
        }

        if (player2.hasPackage)
        {
            textP2.text = "Deliver the package";
        }
        else
        {
            textP2.text = "Find the package";
        }
    }
}
