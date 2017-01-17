// Generated by SpatialOS codegen. DO NOT EDIT!
// source: improbable.WorkerClaim in improbable/standard_library.schema.

namespace Improbable
{

public partial struct WorkerClaim : global::System.IEquatable<WorkerClaim>
{
  /// <summary>
  /// Field atom = 1.
  /// </summary>
  public global::Improbable.Collections.List<global::Improbable.WorkerClaimAtom> atom;

  public WorkerClaim(global::Improbable.Collections.List<global::Improbable.WorkerClaimAtom> atom)
  {
    this.atom = atom;
  }

  public WorkerClaim DeepCopy()
  {
    var _result = new WorkerClaim();
    _result.atom = new global::Improbable.Collections.List<global::Improbable.WorkerClaimAtom>(atom.Count);
    for (int _i = 0; _i < atom.Count; ++_i)
    {
      _result.atom.Add(atom[_i].DeepCopy());
    }
    return _result;

  }

  public override bool Equals(object _obj)
  {
    return _obj is WorkerClaim && Equals((WorkerClaim) _obj);
  }

  public static bool operator==(WorkerClaim a, WorkerClaim b)
  {
    return a.Equals(b);
  }

  public static bool operator!=(WorkerClaim a, WorkerClaim b)
  {
    return !a.Equals(b);
  }

  public bool Equals(WorkerClaim _obj)
  {
    return
        atom == _obj.atom;
  }

  public override int GetHashCode()
  {
    int _result = 1327;
    _result = (_result * 977) + (atom == null ? 0 : atom.GetHashCode());
    return _result;
  }
}

public static class WorkerClaim_Internal
{
  public static global::Schema.Improbable.WorkerClaim Serialize(WorkerClaim _data)
  {
    var _proto = new global::Schema.Improbable.WorkerClaim();
    for (int _i = 0; _i < _data.atom.Count; ++_i)
    {
      _proto.Field1Atom.Add(global::Improbable.WorkerClaimAtom_Internal.Serialize(_data.atom[_i]));
    }
    return _proto;
  }

  public static WorkerClaim Deserialize(global::Schema.Improbable.WorkerClaim _proto)
  {
    WorkerClaim _data;
    _data.atom = new global::Improbable.Collections.List<global::Improbable.WorkerClaimAtom>(_proto.Field1Atom.Count);
    for (int _i = 0; _i < _proto.Field1Atom.Count; ++_i)
    {
      _data.atom.Add(global::Improbable.WorkerClaimAtom_Internal.Deserialize(_proto.Field1Atom[_i]));
    }
    return _data;
  }
}

}
