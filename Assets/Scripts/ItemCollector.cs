using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//para el text

public class ItemCollector : MonoBehaviour
{
    private int coinsCount = 0;
    [SerializeField] Text coinsText;

    //audio collect
    [SerializeField] private AudioSource collectSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            coinsCount++;
            Debug.Log("coinsCount:" + coinsCount);
            coinsText.text = "Coins: " + coinsCount;//para mostrar en el text de la pantalla
            collectSound.Play();//para auido collect
        }
    }
}
