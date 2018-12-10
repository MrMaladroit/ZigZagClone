using UnityEngine;

public class Collectibles : MonoBehaviour
{
    // If more collectibles are add, extract this into a Crystal class that inherits this class.
    #region Crystal Collectible Code
    private ParticleSystem particleSystemInChild;
    private MeshRenderer meshRendererComponent;

    [SerializeField]
    private int scoreValue = 15;


    private void Awake()
    {
        particleSystemInChild = GetComponentInChildren<ParticleSystem>();
        meshRendererComponent = GetComponent<MeshRenderer>();
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag != "Player")
        {
            return;
        }

        Debug.Log("OnTriggerEnter Triggered By Player");
        GameManager.instance.UpdateScore(scoreValue);

        particleSystemInChild.Play();
        meshRendererComponent.enabled = false;

        Destroy(gameObject, 2);
    }
    #endregion

}