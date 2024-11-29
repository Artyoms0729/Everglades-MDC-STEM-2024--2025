using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalPool : MonoBehaviour
{


    public GameObject[] aligators;

    public GameObject[] toads;

    public GameObject[] rabbits;

    public GameObject[] bass;

    public GameObject[] cats;

    public GameObject[] pythons;

    //programmer Ian added thse animals
    public GameObject[] herons;

    public GameObject[] egrets;

    public GameObject[] opossums;


    private UIManager uiManager;

    void  Start()
    {
        uiManager = GameObject.FindGameObjectWithTag("Player").GetComponent<UIManager>();
    }

    public void SpawnAligator(int count = 0)
    {
        ActivateGameObject(aligators);
        if (count > 0)
        {
            if(count > aligators.Length)
            {
                count = aligators.Length;
            }
            ActivateGameobjectWithCount(aligators, count);
        }
    }

    public void SpawnToad(int count = 0)
    {

        if(count > toads.Length)
        {
            count = toads.Length;
        }
        ActivateGameObject(toads);
        if (count > 0)
        {
            ActivateGameobjectWithCount(toads, count);
        }
    }
//! currently use a coroutine to fix the async issue of the animals not exisitng
// you can try changing this so the function keeps calling itself until its no longer null
    public void SpawnRabbit(int count = 0)
    {
        if(count > rabbits.Length)
        {
            count = rabbits.Length;
        }
        ActivateGameObject(rabbits);
        if (count > 0)
        {
            ActivateGameobjectWithCount(rabbits, count);
        }
    }

    public void SpawnBass(int count = 0)
    {
        if(count > bass.Length)
        {
            count = bass.Length;
        }
        ActivateGameObject(bass);
        if (count > 0)
        {
            ActivateGameobjectWithCount(bass, count);
        }
    }

    public void SpawnCat(int count = 0)
    {
        if(count > cats.Length)
        {
            count = cats.Length;
        }
        ActivateGameObject(cats);
        if (count > 0)
        {
            ActivateGameobjectWithCount(cats, count);
        }
    } 

    public void SpawnPython(int count = 0)
    {
        if(count > pythons.Length)
        {
            count = pythons.Length;
        }
        ActivateGameObject(pythons);
        if (count > 0)
        {
            ActivateGameobjectWithCount(pythons, count);
        }
    }
    
    public void SpawnHeron(int count = 0)
    {
        if(count > herons.Length)
        {
            count = herons.Length;
        }
        ActivateGameObject(herons);
        if (count > 0)
        {
            ActivateGameobjectWithCount(herons, count);
        }
    }
    public void SpawnEgret(int count = 0)
    {
        if(count > egrets.Length)
        {
            count = egrets.Length;
        }
        ActivateGameObject(egrets);
        if (count > 0)
        {
            ActivateGameobjectWithCount(egrets, count);
        }
    }
    public void SpawnOpossum(int count = 0)
    {
        if(count > opossums.Length)
        {
            count = opossums.Length;
        }
        ActivateGameObject(opossums);
        if (count > 0)
        {
            ActivateGameobjectWithCount(opossums, count);
        }
    }


    public void DeactiveAligator()
    {
        DeactiveGameObject(aligators);
    }
    public void DeactiveToad()
    {
        DeactiveGameObject(toads);
    }
    public void DeactiveRabbit()
    {
        DeactiveGameObject(rabbits);
    }
    public void DeactiveBass()
    {
        DeactiveGameObject(bass);
    }
    public void DeactiveCat()
    {
        DeactiveGameObject(cats);
    }
    public void DeactivePython()
    {
        DeactiveGameObject(pythons);
    }
    public void DeactiveHeron()
    {
        DeactiveGameObject(herons);
    }
    public void DeactiveEgret()
    {
        DeactiveGameObject(egrets);
    }
    public void DeactiveOpossum()
    {
        DeactiveGameObject(opossums);
    }

    public int returactiveAligator()
    {
        int j = 0;
        for (int i = 0; i < aligators.Length; i++)
        {
            if (aligators[i].activeInHierarchy)
            {
                j++;
            }
        }
        return j;
    }
    public int returactiveToad()
    {
        int j = 0;
        for (int i = 0; i < toads.Length; i++)
        {
            if (toads[i].activeInHierarchy)
            {
                j++;
            }
        }
        return j;
    }
    public int returactiveRabbit()
    {
        int j = 0;
        for (int i = 0; i < rabbits.Length; i++)
        {
            if (rabbits[i].activeInHierarchy)
            {
                j++;
            }
        }
        return j;
    }
    public int returactiveBass()
    {
        int j = 0;
        for (int i = 0; i < bass.Length; i++)
        {
            if (bass[i].activeInHierarchy)
            {
                j++;
            }
        }
        return j;
    }
    public int returactiveCat()
    {
        int j = 0;
        for (int i = 0; i < cats.Length; i++)
        {
            if (cats[i].activeInHierarchy)
            {
                j++;
            }
        }
        return j;
    }
    public int returactivePython()
    {
        int j = 0;
        for (int i = 0; i < pythons.Length; i++)
        {
            if (pythons[i].activeInHierarchy)
            {
                j++;
            }
        }
        return j;
    }
    public int returactiveHeron()
    {
        int j = 0;
        for (int i = 0; i < herons.Length; i++)
        {
            if (herons[i].activeInHierarchy)
            {
                j++;
            }
        }
        return j;
    }
    public int returactiveEgret()
    {
        int j = 0;
        for (int i = 0; i < egrets.Length; i++)
        {
            if (egrets[i].activeInHierarchy)
            {
                j++;
            }
        }
        return j;
    }
    public int returactiveOpossum()
    {
        int j = 0;
        for (int i = 0; i < opossums.Length; i++)
        {
            if (opossums[i].activeInHierarchy)
            {
                j++;
            }
        }
        return j;
    }
    


    private void ActivateGameObject(GameObject[] gameObjects)
    {
        while (gameObjects == null)
        {
            Debug.Log("gameObjects is null");
            break;
        }
        for (int i = 0; i < gameObjects.Length; i++)
        {
            if (!gameObjects[i].activeInHierarchy)
            {
                gameObjects[i].SetActive(true);
                break;
            }
        }
    }
    
    public void DeactiveGameObject(GameObject[] gameObject)
    {
        for (int i = 0; i < gameObject.Length; i++)
        {
            if (!gameObject[i].activeInHierarchy)
            {
                gameObject[i].SetActive(false);
                break;
            }
        }
    }
    //! this should only ever be called after all the pools hav
    private void ActivateGameobjectWithCount(GameObject[] gameObjects, int count)
    {
        for (int i = 0; i <  gameObjects.Length; i++)
        {
            gameObjects[i].SetActive(false);
        }

        for (int i = 0; i < count; i++)
        {
            gameObjects[i].SetActive(true);
        }
    }
}
