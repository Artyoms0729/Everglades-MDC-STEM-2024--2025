using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalTrackerAdder : MonoBehaviour
{
    private void Awake()
    {
        addAnima();

    }
    void addAnima()
    {
        TrackAnimalCount.addtoPopulationCount(this.gameObject.tag);

    }
    public void KillAnimal()
    {
        TrackAnimalCount.RemoveFromCount(this.gameObject.tag);
        Destroy(this.gameObject);
    }
}
