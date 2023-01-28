using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCreator : MonoBehaviour
{


    [SerializeField] private float distance;
    [SerializeField] private GameObject CubePrefab;
    [SerializeField] private GameObject BoxPrefab;
    [SerializeField] private GameObject CubeParentPrefab;

    [SerializeField][Range(1, 50)] private int xCount;
    [SerializeField][Range(1, 50)] private int yCount;
    [SerializeField][Range(1, 50)] private int zCount;

    private List<GameObject> Cubes = new List<GameObject>();

    private List<GameObject> Boxes = new List<GameObject>();

    private GameObject tmpCube;
    private GameObject tmpBox;

    private Vector3 point1;
    private Vector3 point2;
    private Vector3 Midpoint;

    public void TheCubeCreator()
    {
        int i = 0;
        GameObject theParent = Instantiate(CubeParentPrefab);

        for (int y = 0; y < yCount; y++)
        {
            for (int z = 0; z < zCount; z++)
            {
                for (int x = 0; x < xCount; x++)
                {

                    
                    tmpCube = Instantiate(CubePrefab, transform.position + new Vector3(x * distance, y * distance, z * distance), transform.rotation);
                    Cubes.Add(tmpCube);
                    tmpCube.transform.parent = theParent.transform;
                    tmpCube.name = "Cube" + i.ToString();

                    tmpCube.GetComponent<Cube>().SetMetarial();
                    

                    if (x == 0 && z == 0 && y == 0)
                    {
                        point1 = tmpCube.transform.position;
                    }

                    if (x == xCount - 1 && z == zCount - 1 && y == 0)
                    {
                        point2 = tmpCube.transform.position;
                    }



                    i++;
                    tmpCube = null;



                }

            }

        }

        Midpoint = (point1 + point2) / 2;
        theParent.transform.position = transform.position + -1f * Midpoint;
    }

    public void TheBoxCreator()
    {
        int i = 0;
        GameObject theParent = Instantiate(CubeParentPrefab);

        for (int y = 0; y < yCount; y++)
        {
            for (int z = 0; z < zCount; z++)
            {
                for (int x = 0; x < xCount; x++)
                {

                    tmpBox = Instantiate(BoxPrefab, transform.position + new Vector3(x * distance, y * distance, z * distance), transform.rotation);
                    Boxes.Add(tmpBox);
                    tmpBox.transform.parent = theParent.transform;
                    tmpBox.name = "Box" + i.ToString();
                    
                    if (x == 0 && z == 0 && y == 0)
                    {
                        point1 = tmpBox.transform.position;
                    }

                    if (x == xCount - 1 && z == zCount - 1 && y == 0)
                    {
                        point2 = tmpBox.transform.position;
                    }

                    i++;
                }

            }

        }

        Midpoint = (point1 + point2) / 2;
        theParent.transform.position = transform.position + -1f * Midpoint;
    }


}
