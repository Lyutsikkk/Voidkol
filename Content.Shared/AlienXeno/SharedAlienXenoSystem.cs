using Content.Shared.Actions;
using Content.Shared.DoAfter;
using Content.Shared.Random;
using Content.Shared.Random.Helpers;
using Content.Shared.Verbs;
using Robust.Shared.Audio;
using Robust.Shared.Audio.Systems;
using Robust.Shared.Network;
using Robust.Shared.Prototypes;
using Robust.Shared.Random;
using Robust.Shared.Serialization;

namespace Content.Shared.AlienXeno;

public abstract class SharedAlienXenoSystem : EntitySystem
{
    [Dependency] private readonly INetManager _net = default!;
    [Dependency] protected readonly IPrototypeManager PrototypeManager = default!;
    [Dependency] protected readonly IRobustRandom Random = default!;
    [Dependency] private readonly SharedActionsSystem _action = default!;
    [Dependency] private readonly SharedAudioSystem _audio = default!;
    [Dependency] private readonly SharedDoAfterSystem _doAfter = default!;

    public override void Initialize()
    {
        SubscribeLocalEvent<AlienXenoComponent, ComponentStartup>(OnStartup);
        SubscribeLocalEvent<AlienXenoComponent, ComponentShutdown>(OnShutdown);
    }

    private void OnStartup(EntityUid uid, AlienXenoComponent component, ComponentStartup args)
    {
        if (!TryComp(uid, out ActionsComponent? comp))
            return;

        _action.AddAction(uid, ref component.ActionAlienCocoonEntity, component.ActionAlienCocoon, component: comp);
        _action.AddAction(uid, ref component.ActionAlienWallEntity, component.ActionAlienWall, component: comp);
        _action.AddAction(uid, ref component.ActionAlienDoorEntity, component.ActionAlienDoor, component: comp);
    }

    private void OnShutdown(EntityUid uid, AlienXenoComponent component, ComponentShutdown args)
    {
        if (!TryComp(uid, out ActionsComponent? comp))
            return;

        _action.RemoveAction(uid, component.ActionAlienCocoonEntity, comp);
        _action.RemoveAction(uid, component.ActionAlienWallEntity, comp);
        _action.RemoveAction(uid, component.ActionAlienDoorEntity, comp);
    }
}
