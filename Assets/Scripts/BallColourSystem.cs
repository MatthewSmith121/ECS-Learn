using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

/*public class BallColourSystem : JobComponentSystem
{
    [BurstCompile]
    [RequireComponentTag(typeof(BallTag))]
    struct ColourJob : IJobForEach<Renderer>
    {
        public void Execute([ReadOnly] ref Renderer renderer) {
            Color colour;
            switch (Random.Range(0, 3)) {
                case 0:
                    colour = Color.red;
                    break;
                case 1:
                    colour = Color.blue;
                    break;
                case 2:
                    colour = Color.green;
                    break;
                default:
                    colour = Color.red;
                    break;
            };
            renderer.material.color = colour;
        }
    }

    protected override JobHandle OnUpdate(JobHandle inputDeps) {
        throw new System.NotImplementedException();
    }
}*/
