using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace FlyweightPattern
{
    //Class that includes lists with position of parts
    public class Spikes
    {
        List<Vector3> centerPositions;
        List<Vector3> leftPositions;
        List<Vector3> rightPositions;
    }
}