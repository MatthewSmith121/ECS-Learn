using Unity.Entities;
using Unity.Transforms;

public class TransformUpdateSystem : ComponentSystem
{
    protected override void OnUpdate() {
        Entities.WithAll<PlayerTag>().ForEach((ref Translation pos, ref Rotation rot) => {
            pos = new Translation { Value = Settings.PlayerPosition };
            rot = new Rotation { Value = Settings.PlayerRotation };
        });
    }
}
