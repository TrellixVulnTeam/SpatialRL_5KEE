// Generated by SpatialOS codegen. DO NOT EDIT!
// source: improbable.general.WorldVelocityData in improbable/general/WorldVelocity.schema.

namespace Improbable.General
{

public partial struct WorldVelocityData : global::System.IEquatable<WorldVelocityData>
{
  /// <summary>
  /// Field velocity = 1.
  /// </summary>
  public global::Improbable.Math.Vector3f velocity;

  public WorldVelocityData(global::Improbable.Math.Vector3f velocity)
  {
    this.velocity = velocity;
  }

  public WorldVelocityData DeepCopy()
  {
    var _result = new WorldVelocityData();
    _result.velocity = velocity.DeepCopy();
    return _result;

  }

  public override bool Equals(object _obj)
  {
    return _obj is WorldVelocityData && Equals((WorldVelocityData) _obj);
  }

  public static bool operator==(WorldVelocityData a, WorldVelocityData b)
  {
    return a.Equals(b);
  }

  public static bool operator!=(WorldVelocityData a, WorldVelocityData b)
  {
    return !a.Equals(b);
  }

  public bool Equals(WorldVelocityData _obj)
  {
    return
        velocity == _obj.velocity;
  }

  public override int GetHashCode()
  {
    int _result = 1327;
    _result = (_result * 977) + velocity.GetHashCode();
    return _result;
  }
}

public static class WorldVelocityData_Internal
{
  public static global::Schema.Improbable.General.WorldVelocityData Serialize(WorldVelocityData _data)
  {
    var _proto = new global::Schema.Improbable.General.WorldVelocityData();
    _proto.Field1Velocity = global::Improbable.Math.Vector3f_Internal.Serialize(_data.velocity);
    return _proto;
  }

  public static WorldVelocityData Deserialize(global::Schema.Improbable.General.WorldVelocityData _proto)
  {
    WorldVelocityData _data;
    _data.velocity = global::Improbable.Math.Vector3f_Internal.Deserialize(_proto.Field1Velocity);
    return _data;
  }
}

}
