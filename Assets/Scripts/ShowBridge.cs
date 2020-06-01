using UnityEngine;
using UnityEngine.Tilemaps;

public class ShowBridge : MonoBehaviour
{

    PlayerMovement player;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TilemapRenderer>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
        }

        if (player != null && player.hasSword)
        {
            GetComponent<TilemapRenderer>().enabled = true;
        }

    }
}
