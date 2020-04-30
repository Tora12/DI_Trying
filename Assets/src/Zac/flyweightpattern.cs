using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Flyweight design pattern main class
namespace FlyweightPattern
{
    public class Flyweight : MonoBehaviour
    {
        //The list that stores all aliens
        List<Spikes> allSpikes = new List<Spikes>();

        List<Vector3> centerPositions;
        List<Vector3> leftPositions;
        List<Vector3> rightPositions;


        void Start()
        {
            //List used when flyweight is enabled
            centerPositions = GetBodyPositions();
            leftPositions = GetBodyPositions();
            rightPositions = GetBodyPositions();

            //Create all aliens
            for (int i = 0; i < 10000; i++)
            {
                Spikes newSpikes = new Spikes();

                //Add center,left,right positions
                //Without flyweight
                //newSpikes.centerPositions = GetBodyPositions();
                //newSpikes.leftPositions = GetBodyPositions();
                //newSpikes.rightPositions = GetBodyPositions();

                //With flyweight
                //newSpikes.centerPositions = centerPositions;
                //newSpikes.leftPositions = leftPositions;
                //newSpikes.rightPositions = rightPositions;

                allSpikes.Add(newSpikes);
            }
        }


        //Generate a list with body part positions
        List<Vector3> GetBodyPositions()
        {
            //Create a new list
            List<Vector3> bodyPositions = new List<Vector3>();

            //Add body part positions to the list
            for (int i = 0; i < 1000; i++)
            {
                bodyPositions.Add(new Vector3());
            }

            return bodyPositions;
        }
    }
}