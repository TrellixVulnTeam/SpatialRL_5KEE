// Generated by SpatialOS codegen. DO NOT EDIT!
// source: improbable.WorkerClaimAtom in improbable/standard_library.schema.

namespace Improbable
{

public partial struct WorkerClaimAtom : global::System.IEquatable<WorkerClaimAtom>
{
  /// <summary>
  /// Field name = 1.
  /// </summary>
  public global::Improbable.Collections.Option<string> name;

  public WorkerClaimAtom(global::Improbable.Collections.Option<string> name)
  {
    this.name = name;
  }

  public WorkerClaimAtom DeepCopy()
  {
    var _result = new WorkerClaimAtom();
    _result.name = new global::Improbable.Collections.Option<string>();
    if (name.HasValue)
    {
      _result.name.Set(name.Value);
    }
    return _result;

  }

  public override bool Equals(object _obj)
  {
    return _obj is WorkerClaimAtom && Equals((WorkerClaimAtom) _obj);
  }

  public static bool operator==(WorkerClaimAtom a, WorkerClaimAtom b)
  {
    return a.Equals(b);
  }

  public static bool operator!=(WorkerClaimAtom a, WorkerClaimAtom b)
  {
    return !a.Equals(b);
  }

  public bool Equals(WorkerClaimAtom _obj)
  {
    return
        name == _obj.name;
  }

  public override int GetHashCode()
  {
    int _result = 1327;
    _result = (_result * 977) + name.GetHashCode();
    return _result;
  }
}

public static class WorkerClaimAtom_Internal
{
  public static global::Schema.Improbable.WorkerClaimAtom Serialize(WorkerClaimAtom _data)
  {
    var _proto = new global::Schema.Improbable.WorkerClaimAtom();
    if (_data.name.HasValue)
    {
      _proto.Field1Name = _data.name.Value;
    }
    return _proto;
  }

  public static WorkerClaimAtom Deserialize(global::Schema.Improbable.WorkerClaimAtom _proto)
  {
    WorkerClaimAtom _data;
    _data.name = new global::Improbable.Collections.Option<string>();
    if (_proto.Field1NameSpecified)
    {
      _data.name.Set(_proto.Field1Name);
    }
    return _data;
  }
}

}