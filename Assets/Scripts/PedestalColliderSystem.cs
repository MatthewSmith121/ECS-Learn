using Unity.Entities;

[UpdateInGroup(typeof(InitializationSystemGroup))]
public class PedestalColliderSystem : ComponentSystem
{
    protected override void OnUpdate() {
        if (Settings.DoneSpawning()) {
            Entities.WithAll<PedestalColliderTag>().ForEach((Entity entity) => {
                PostUpdateCommands.DestroyEntity(entity);
            });
        }
    }
}