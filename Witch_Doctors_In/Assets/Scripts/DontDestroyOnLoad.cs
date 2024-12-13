using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject); // Prevent this GameObject from being destroyed when scenes change
    }
}