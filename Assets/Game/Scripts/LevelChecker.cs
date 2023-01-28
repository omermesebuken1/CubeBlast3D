using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChecker : MonoBehaviour
{


    [SerializeField] private int hamleSayisi;
    public int boxCount;
    [SerializeField] private GameObject boxesParent;

    [HideInInspector] public bool countAgain;

    private List<GameObject> Boxes = new List<GameObject>();

    private void Start()
    {

        foreach (var item in boxesParent.GetComponentsInChildren<Transform>())
        {
            if (item != null)
            {
                Boxes.Add(item.gameObject);
            }
        }

        boxCount = Boxes.Count;

    }


    private void Update()
    {

        if (countAgain)
        {
            Boxes.Clear();

            foreach (var item in boxesParent.GetComponentsInChildren<Transform>())
            {
                if (item != null)
                {
                    Boxes.Add(item.gameObject);
                }
            }



            boxCount = Boxes.Count - 1;
            countAgain = false;

        }

    }




}
