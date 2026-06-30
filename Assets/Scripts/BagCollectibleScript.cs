using UnityEngine;
using TMPro;

public class BagCollectibleScript : MonoBehaviour
{
    public int currentItems;
    public int maxItems = 7;

    [SerializeField] private TMP_Text itemsText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        currentItems = 0;
        itemsText.text = "Gold:\n" + currentItems.ToString() + "/" + maxItems.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            Destroy(other.gameObject);
            currentItems++;
            itemsText.text = "Gold:\n" + currentItems.ToString() + "/" + maxItems.ToString();
            if (currentItems >= maxItems)
            {
                GameManagerScript.singleton.YouWin();
            }
        }
    }
}
