using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BombUI : MonoBehaviour
{
    private List<PlayerInventoryLogic> players;
    private List<PlayerScore> playerNames;
    private TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        players = new List<PlayerInventoryLogic>(FindObjectsByType<PlayerInventoryLogic>(FindObjectsSortMode.InstanceID));
        playerNames = new List<PlayerScore>();
        foreach (PlayerInventoryLogic player in players)
        {
            playerNames.Add(player.GetComponent<PlayerScore>());
        }
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        string txt = "";
        int i = 0;
        foreach (PlayerInventoryLogic player in players)
        {
            txt += playerNames[i].playerName + ": " + player.bombCount.ToString() + "<br>";
            i++;
        }
        txt += "Press shift to plant";
        text.text = txt;
    }
}
