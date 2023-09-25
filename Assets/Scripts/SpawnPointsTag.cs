
using UnityEngine;

public class SpawnPointsTag : MonoBehaviour
{
    public void ShowTag()
    {
        Debug.Log("show tag");
        gameObject.SetActive(true);
    }

    public void HideTag()
    {
        Debug.Log("hide tag");
        gameObject.SetActive(false);
    }
}
