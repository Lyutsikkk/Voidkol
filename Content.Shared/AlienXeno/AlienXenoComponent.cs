using Robust.Shared.GameStates;
using Robust.Shared.Prototypes;
using Robust.Shared.Serialization;
using Robust.Shared.Serialization.TypeSerializers.Implementations.Custom.Prototype;

namespace Content.Shared.AlienXeno;

[RegisterComponent, NetworkedComponent, Access(typeof(SharedAlienXenoSystem))]
public sealed partial class AlienXenoComponent : Component
{
    [DataField("actionAlienXeno", customTypeSerializer: typeof(PrototypeIdSerializer<EntityPrototype>))]
    public string ActionAlienXeno = "AlienXenoAction";

    /// <summary>
    ///     The action for the Raise Army ability
    /// </summary>
    [DataField("actionAlienXenoEntity")]
    public EntityUid? ActionAlienXenoEntity;

    /// <summary>
    ///     The amount of hunger one use of Raise Army consumes
    /// </summary>
    [ViewVariables(VVAccess.ReadWrite), DataField("hungerPerArmyUse", required: false)]
    public float HungerPerArmyUse = 70f;

    /// <summary>
    ///     The entity prototype of the mob that Raise Army summons
    /// </summary>
    [ViewVariables(VVAccess.ReadWrite), DataField("armyMobSpawnId", customTypeSerializer: typeof(PrototypeIdSerializer<EntityPrototype>))]
    public string ArmyMobSpawnId = "AlienXenoCocoon";
}
