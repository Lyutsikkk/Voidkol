using Robust.Shared.GameStates;
using Robust.Shared.Prototypes;
using Robust.Shared.Serialization;
using Robust.Shared.Serialization.TypeSerializers.Implementations.Custom.Prototype;

namespace Content.Shared.AlienXeno;

[RegisterComponent, NetworkedComponent, Access(typeof(SharedAlienXenoSystem))]
public sealed partial class AlienXenoComponent : Component
{
    [DataField("actionAlienCocoon", customTypeSerializer: typeof(PrototypeIdSerializer<EntityPrototype>))]
    public string ActionAlienCocoon = "AlienCocoonAction";

    [DataField("actionAlienCocoonEntity")]
    public EntityUid? ActionAlienCocoonEntity;

    [DataField("actionAlienWall", customTypeSerializer: typeof(PrototypeIdSerializer<EntityPrototype>))]
    public string ActionAlienWall = "AlienWallAction";

    [DataField("actionAlienWallEntity")]
    public EntityUid? ActionAlienWallEntity;

    [DataField("actionAlienDoor", customTypeSerializer: typeof(PrototypeIdSerializer<EntityPrototype>))]
    public string ActionAlienDoor = "AlienDoorAction";

    [DataField("actionAlienDoorEntity")]
    public EntityUid? ActionAlienDoorEntity;

    [ViewVariables(VVAccess.ReadWrite), DataField("hungerCocoonUse", required: false)]
    public float HungerCocoonUse = 30f;

    [ViewVariables(VVAccess.ReadWrite), DataField("hungerWallUse", required: false)]
    public float HungerWallUse = 10f;

    [ViewVariables(VVAccess.ReadWrite), DataField("hungerDoorUse", required: false)]
    public float HungerDoorUse = 10f;

    [ViewVariables(VVAccess.ReadWrite), DataField("cocoonSpawnId", customTypeSerializer: typeof(PrototypeIdSerializer<EntityPrototype>))]
    public string CocoonSpawnId = "AlienXenoCocoon";

    [ViewVariables(VVAccess.ReadWrite), DataField("wallPrototype", customTypeSerializer: typeof(PrototypeIdSerializer<EntityPrototype>))]
    public string WallPrototype = "AlienXenoWall";

    [ViewVariables(VVAccess.ReadWrite), DataField("doorPrototype", customTypeSerializer: typeof(PrototypeIdSerializer<EntityPrototype>))]
    public string DoorPrototype = "AlienXenoDoor";
}
