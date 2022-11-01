using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//para el scene

public class PlayerLife : MonoBehaviour
{
    private bool dead = false;

    //audio
    [SerializeField] private AudioSource deathSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -1f && !dead)//el problema es que asi se ejecuta vaaarias veces, no solo 1 vez. le agrega un bool para verificar si ya sucedio 1 vez
        {
            Die();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemie"))//comparo tags, no name pues tendre varios enemie1, enemie2,enemie3, pero todos tendran el tag Enemie
        {
            GetComponent<MeshRenderer>().enabled = false;//le quita el mesh visible
            GetComponent<Rigidbody>().isKinematic = true;//lo detiene. en 2d es static, aca es kinematic
            GetComponent<PlayerMovement>().enabled = false;//le desactiva el script playermovement
            Die();
        }
    }
    private void Die()
    {
        Invoke("ReloadLevel", 2f);//delay de 2f y llama a la funcion ReloadScene
        dead = true;//para marcar si ya esta ono muerto, y que no se repita la funcion. (arribita en update el if)
        deathSound.Play();
    }
    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
