using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    #region Singleton
    public static ObjectPooler Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public GameObject prefab;
    public int size;

    [SerializeField] private GameObject inactiveParentPrefab;
    private GameObject inactiveParent;
    


    [SerializeField] private List<GameObject> inactiveObjects = new List<GameObject>();
    [SerializeField] private List<GameObject> activeObjects = new List<GameObject>();


    void Start()
    {

        SetObjects();
        inactiveParent = Instantiate(inactiveParentPrefab);
        inactiveParent.transform.name = "InactiveCubes";
    }

    private void FixedUpdate()
    {
        SetInactiveObjectsParent();
    }

    public GameObject GetObject(Vector3 position, Quaternion rotation)
    {
        GameObject obj;

        obj = inactiveObjects[0];
        inactiveObjects.RemoveAt(0);
        activeObjects.Add(obj);

        obj.transform.position = position;
        obj.transform.rotation = rotation;
        obj.SetActive(true);

        IPooledObject pooledObj = obj.GetComponent<IPooledObject>();

        

        if (pooledObj != null)
        {
            pooledObj.OnObjectSpawn();
        }

        return obj;

    }

    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        activeObjects.Remove(obj);
        inactiveObjects.Add(obj);


    }

    public void SetObjects()
    {
       
        

            for (int i = size - activeObjects.Count; i < size; i++)
            {
                GameObject obj = Instantiate(prefab);
                obj.name = "Kutu" + i.ToString();
                obj.SetActive(false);
                inactiveObjects.Add(obj);

            }

        



    }

    private void SetInactiveObjectsParent()
    {
        if (inactiveParent != null)
        {
            foreach (GameObject obj in inactiveObjects)
            {
                obj.transform.parent = inactiveParent.transform;

            }
        }
    }


}
