using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    private List<PlayerScore> players;
    private TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        players = new List<PlayerScore>(FindObjectsByType<PlayerScore>(FindObjectsSortMode.InstanceID));
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        string txt = "";
        foreach (PlayerScore player in players)
        {
            txt += player.playerName + ": " + player.score.ToString() + "<br>";
        }
        text.text = txt;
    }
}
