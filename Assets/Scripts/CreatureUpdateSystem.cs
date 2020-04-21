using Unity.Entities;
using Unity.Transforms;

public class CreatureUpdateSystem : ComponentSystem
{
    protected override void OnUpdate() {
        Entities.WithAll<CreatureTag>().ForEach((ref Translation pos, ref Rotation rot) => {
            pos = new Translation { Value = Settings.CreaturePosition };
            rot = new Rotation { Value = Settings.CreatureRotation };
        });
    }
}
