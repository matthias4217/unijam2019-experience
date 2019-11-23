using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using Random = UnityEngine.Random;


enum StructureChoice {
    Dolmen,
    Guillotine,
    StructureChoiceSize
}

class Structure
{
    public float originAngle;
    public (int, int)[] points;
    public List<int> availablePoints;


    public bool IsStructFull()
    {
        return availablePoints.Count < 1;
    }
    public (int, int) GetRandomAvailablePoint()
    {
        if (IsStructFull())
            throw new Exception("No available point found !");
        int pointIndex = availablePoints[Random.Range(0, availablePoints.Count)];
        availablePoints.Remove(pointIndex);
        return points[pointIndex];
    }

    public static Structure GetDolmen()
    {
        Structure dolmen = new Structure();
        dolmen.points = new[] {(4,0), (6,0), (3,1), (4,1), (5,1), (6,1), (7,1)};
        dolmen.availablePoints = new List<int>();
        for (int i = 0; i < 7; i++)
            dolmen.availablePoints.Add(i);

        return dolmen;
    }


    public static Structure GetGuillotine()
    {
        Structure guillotine = new Structure();
        guillotine.points = new[]
        {
            (1,0), (2,0), (3,0), (4,0), (5,0), (6,0), (7,0), (9,0),
            (2,1), (3,1), (4,1), (5,1), (6,1), (7,1),
            (3,2), (6,2),
            (3,3), (6,3),
            (3,4), (4,4), (6,4),
            (3,5), (4,5), (5,5), (6,5),
            (3,6), (4,6), (5,6), (6,6)
        };
        guillotine.availablePoints = new List<int>();
        for (int i = 0; i < guillotine.points.Length; i++)
            guillotine.availablePoints.Add(i);

        return guillotine;
    }
}