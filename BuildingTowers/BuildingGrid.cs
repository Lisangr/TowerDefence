using UnityEngine;

public class BuildingGrid : MonoBehaviour
{
    public Vector3Int gridSize = new Vector3Int(300, 300, 300);

    private Builds[,,] grid;
    private Builds flyingBuilding;
    private Camera mainCamera;
    private void Awake()
    {
        grid = new Builds[gridSize.x, gridSize.y, gridSize.z];
        mainCamera = Camera.main;
    }
    public void StartPlacingBuilding(Builds buildingPrefab)
    {
        if (flyingBuilding != null)
        {
            Destroy(flyingBuilding.gameObject);
        }

        flyingBuilding = Instantiate(buildingPrefab);
    }
    private void Update()
    {
        if (flyingBuilding != null)
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, LayerMask.GetMask("Terrain"))) // Проверка столкновения с terrain
            {
                Vector3 worldPosition = hit.point;
                int x = Mathf.RoundToInt(worldPosition.x);
                int y = Mathf.RoundToInt(worldPosition.y);
                int z = Mathf.RoundToInt(worldPosition.z);

                bool available = true;
                /*
                if (!IsFlatSurface(x, y, z, flyingBuilding.Size.x, flyingBuilding.Size.z))
                {
                    available = false;
                }*/

                if (x < 0 || x > gridSize.x - flyingBuilding.Size.x) available = false;
                if (y < 0 || y > gridSize.y - flyingBuilding.Size.y) available = false;
                if (z < 0 || z > gridSize.z - flyingBuilding.Size.z) available = false;

                flyingBuilding.transform.position = new Vector3(x, y, z);

                if (available && IsPlaceTaken(x, y, z)) available = false;

                if (available && Input.GetMouseButtonDown(0))
                {
                    PlaceFlyingBuilding(x, y, z);
                }
            }
        }
    }
    private bool IsPlaceTaken(int placeX, int placeY, int placeZ)
    {
        for (int x = 0; x < flyingBuilding.Size.x; x++)
        {
            for (int y = 0; y < flyingBuilding.Size.y; y++)
            {
                for (int z = 0; z < flyingBuilding.Size.z; z++)
                {
                    if (grid[placeX + x, placeY + y, placeZ + z] != null) return true;
                }
            }
        }

        return false;
    }
    private void PlaceFlyingBuilding(int placeX, int placeY, int placeZ)
    {
        for (int x = 0; x < flyingBuilding.Size.x; x++)
        {
            for (int y = 0; y < flyingBuilding.Size.y; y++)
            {
                for (int z = 0; z < flyingBuilding.Size.z; z++)
                {
                    grid[placeX + x, placeY + y, placeZ + z] = flyingBuilding;
                }
            }
        }

        flyingBuilding.SetNormal();
        flyingBuilding = null;
    }
    /*private bool IsFlatSurface(int startX, int startY, int startZ, int width, int height)
    {
        for (int x = startX; x < startX + width; x++)
        {
            for (int y = startY; y < startY; y++)
            {
                for (int z = startZ; z < startZ + height; z++)
                {
                    if ((Mathf.Abs(grid[x, 0, z].transform.position.x - transform.position.x) > 0.5f)
                        || (Mathf.Abs(grid[x, 0, z].transform.position.z - transform.position.z) > 0.5f))
                    {
                        return false;
                    }
                }
            }
        }
        return true;
    }*/

}
