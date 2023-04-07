using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassCreator : MonoBehaviour
{


    [SerializeField] private GameObject glassPrefab;
    [SerializeField] private float cubeSpace;

    [SerializeField] private int positionX;
    [SerializeField] private int positionY;
    [SerializeField] private int positionZ;

    [SerializeField] private int scaleX;
    [SerializeField] private int scaleY;
    [SerializeField] private int scaleZ;

    private GameObject newGlass;




    public void TheGlassCreator()
    {
        Vector3 pos = new Vector3(cubeSpace*positionX,cubeSpace*positionY,cubeSpace*positionZ); 
        Vector3 newScale = new Vector3(cubeSpace*scaleX,cubeSpace*scaleY,cubeSpace*scaleZ);

        newGlass = Instantiate(glassPrefab,pos,Quaternion.identity);
        newGlass.transform.localScale = newScale;
        newGlass = null;


    }

    


}
