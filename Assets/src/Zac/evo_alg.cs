/* Labeling of elements in position 0
 * AC  - 0
 * LG  - 1
 * RL  - 2
 * TaC - 3
 * TaG - 4
 * TG  - 5
 * TR  - 6
 * SpK - 7
 * max 8 enemies/room
 * [0][1][2][3][4][5][6][7]
 * [# of individuals, health, min fire delay, max fire delay, max distance, dmg]
 * individual = [[0: #, hp, min_f, max_f, max_dis, dmg],[1: #, hp, min_f, max_f, max_dis, dmg], ... [7: ...]]
 * population = [... X-individuals ...]
 * 
 * This is meant for 'Arena'  
 * In the arena there will be small rooms of 8 enemies.
 * The player is meant to get through the area.
 * Some rooms will require destruction, while others will just require to arrive at exit.
 * After third room, populations will evolve.
 * Fitness is calculated by dmg done and dmg taken and player dead condition
 * 
 * NEEDS WORK WAS MADE BEFORE TRIGGERS AND SPAWNERS WERE LIVE, evo was ready week 3 but triggers wasn't live till week 13.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class evo_alg : MonoBehaviour
{
    private static evo_alg _evo_algInstance;

    private void Awake()
    {
        if (_evo_algInstance != null && _evo_algInstance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _evo_algInstance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    //r-c
    // This is the initial individual
    public float[,] room_composition = new float[8, 6]
      { { 1, 50, 0.5f, 1, 10, 10 }, 
        { 1, 50, 0.5f, 1, 10, 10 }, 
        { 1, 50, 0.5f, 1, 10, 10 }, 
        { 1, 50, 0.5f, 1, 10, 10 }, 
        { 1, 50, 0.5f, 1, 10, 10 }, 
        { 1, 50, 0.5f, 1, 10, 10 },
        { 1, 50, 0.5f, 1, 10, 10 }, 
        { 1, 50, 0.5f, 1, 10, 10 } };

    // dmg done, dmg taken, player dead, fitness score
    public float[,] fitness_room_record = new float[8, 4]
      { { 0, 0, 0, 0},
        { 0, 0, 0, 0},
        { 0, 0, 0, 0},
        { 0, 0, 0, 0},
        { 0, 0, 0, 0},
        { 0, 0, 0, 0},
        { 0, 0, 0, 0},
        { 0, 0, 0, 0} };

    // This keeps track of score per room
    private float[] fitness_population_record = { 0, 0, 0 };
    // Start is called before the first frame update
    void Start()
    {

    }

    void evolve()
    {
        calc_fitness(fitness_room_record, fitness_population_record);
        parent_selection(fitness_population_record);
        cross_over(room_composition);
        mutation(room_composition);
        offspring(room_composition);
    }

    void calc_fitness( float[,] fitness_room_record, float[] fitness_population_record )
    {
        for (int i = 0; i < 8; i++)
        {
            float temp = 0.0f;
            for (int j = 0; j < 4; j++)
                temp += fitness_room_record[i, j];
            fitness_population_record[i] = temp;
        }
    }

    int parent_selection( float [] fitness_population_record ) { return fitness_population_record.ToList().IndexOf(fitness_population_record.Max());    }

    void cross_over( float [,] population )
    {
        for (int j = 0; j < 6; j++)
        {
            // Yet to be determined
        }
    }

    void mutation( float [,] room_composition )
    {
        int num = Random.Range(0, 2);
        if (num == 0)
            //Knuth Shuffle of elements
        {
            for (int t = 0; t < 8; t++)
            {
                float tmp = room_composition[t,0];
                int r = Random.Range(t, 6);
                room_composition[t,0] = room_composition[r,0];
                room_composition[r,0] = tmp + num;
            }
        }
    }

    void offspring( float [,] population )
    {
        // yet to be determined
    }


}
