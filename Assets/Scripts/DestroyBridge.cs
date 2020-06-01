using UnityEngine;

public class DestroyBridge : MonoBehaviour
{

    PlayerMovement player;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if(player == null)
        {
            player = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
        }

        if (player != null && player.hasSword)
        {
            Destroy(gameObject);
        }
    }
}
