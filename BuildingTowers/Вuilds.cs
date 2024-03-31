using UnityEngine;

public class Builds : MonoBehaviour
{
    public Renderer mainRenderer;
    public Vector3Int Size = Vector3Int.one; //размер здания на сетке

    public void SetTransparent(bool available)
    {
        if (available) 
        {
            mainRenderer.material.color = Color.green;
        }
        else
        {
            mainRenderer.material.color = Color.red;
        }
    }
    public void SetNormal()
    {
        mainRenderer.material.color = Color.white;
    }
    private void OnDrawGizmos()
    {
        for (int x = 0; x < Size.x; x++)
        {
            for (int y = 0; y < Size.y; y++)
            {
                for (int z = 0; z < Size.z; z++)
                {
                    if ((x + y) % 2 == 0) Gizmos.color = Color.yellow;
                    else Gizmos.color = Color.red;

                    Gizmos.DrawCube(transform.position + new Vector3(x, 0, y), new Vector3(1, .1f, 1));

                }
            }
        }
    }
}
