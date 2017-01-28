// Generated by SpatialOS codegen. DO NOT EDIT!
// source: Name in improbable/player/name.schema.

namespace Improbable.Player
{

public static class Name_Extensions
{
  public static Name.Data Get(this global::Improbable.Worker.IComponentData<Name> data)
  {
    return (Name.Data) data;
  }

  public static Name.Update Get(this global::Improbable.Worker.IComponentUpdate<Name> update)
  {
    return (Name.Update) update;
  }
}

public partial class Name : global::Improbable.Worker.IComponentMetaclass
{
  public static uint ComponentId = 1001;

  uint global::Improbable.Worker.IComponentMetaclass.ComponentId
  {
    get { return ComponentId; }
  }

  /// <summary>
  /// Concrete data type for the Name component.
  /// </summary>
  public class Data : global::Improbable.Worker.IComponentData<Name>
  {
    public global::Improbable.Player.NameData Value;

    public Data(global::Improbable.Player.NameData value)
    {
      Value = value;
    }

    public Data(string entityName)
    {
      Value = new global::Improbable.Player.NameData(entityName);
    }

    public Data DeepCopy()
    {
      return new Data(Value.DeepCopy());
    }

    public global::Improbable.Worker.IComponentUpdate<Name> ToUpdate()
    {
      var update = new Update();
      update.SetEntityName(Value.entityName);
      return update;
    }
  }

  /// <summary>
  /// Concrete update type for the Name component.
  /// </summary>
  public class Update : global::Improbable.Worker.IComponentUpdate<Name>
  {
    /// <summary>
    /// Field entity_name = 1.
    /// </summary>
    public global::Improbable.Collections.Option<string> entityName;
    public Update SetEntityName(string _value)
    {
      entityName.Set(_value);
      return this;
    }

    public Update DeepCopy()
    {
      var _result = new Update();
      if (entityName.HasValue)
      {
        string field;
        field = entityName.Value;
        _result.entityName.Set(field);
      }
      return _result;
    }

    public global::Improbable.Worker.IComponentData<Name> ToInitialData()
    {
      return new Data(new global::Improbable.Player.NameData(entityName.Value));
    }

    public void ApplyTo(global::Improbable.Worker.IComponentData<Name> _data)
    {
      var _concrete = _data.Get();
      if (entityName.HasValue)
      {
        _concrete.Value.entityName = entityName.Value;
      }
    }
  }

  public partial class Commands
  {
  }

  // Implementation details below here.
  //----------------------------------------------------------------

  public global::Improbable.Worker.Internal.ComponentProtocol.ClientComponentVtable Vtable {
    get {
      global::Improbable.Worker.Internal.ComponentProtocol.ClientComponentVtable vtable;
      vtable.ComponentId = ComponentId;
      vtable.BufferFree = global::System.Runtime.InteropServices.Marshal
          .GetFunctionPointerForDelegate(global::Improbable.Worker.Internal.ClientObjects.ClientBufferFree);
      vtable.Free = global::System.Runtime.InteropServices.Marshal
          .GetFunctionPointerForDelegate(global::Improbable.Worker.Internal.ClientObjects.ClientFree);
      vtable.Copy = global::System.Runtime.InteropServices.Marshal
          .GetFunctionPointerForDelegate(global::Improbable.Worker.Internal.ClientObjects.ClientCopy);
      vtable.Deserialize = global::System.Runtime.InteropServices.Marshal
          .GetFunctionPointerForDelegate(clientDeserialize);
      vtable.Serialize = global::System.Runtime.InteropServices.Marshal
          .GetFunctionPointerForDelegate(clientSerialize);
      return vtable;
    }
  }

  public void AddToEntityWithInitialData(global::Improbable.Worker.Internal.ComponentProtocol.ClientObject update,
                                         global::Improbable.Worker.Entity entity)
  {
    var dereferenced = (global::Improbable.Worker.IComponentUpdate<Name>)
        global::Improbable.Worker.Internal.ClientObjects.Instance
        .Dereference(update.Reference);
    entity.Add<Name>(dereferenced.ToInitialData());
  }

  public object ExtractAsUpdate(global::Improbable.Worker.Entity entity)
  {
    return entity.Get<Name>().Value.ToUpdate();
  }

  public void TrackComponent(global::Improbable.Worker.View view)
  {
    view.OnAddComponent<Name>(op =>
    {
      if (view.Entities.ContainsKey(op.EntityId))
      {
        view.Entities[op.EntityId].Add<Name>(op.Data);
      }
    });
    view.OnRemoveComponent<Name>(op =>
    {
      if (view.Entities.ContainsKey(op.EntityId))
      {
        view.Entities[op.EntityId].Remove<Name>();
      }
    });
    view.OnAuthorityChange<Name>(op =>
    {
      if (view.Entities.ContainsKey(op.EntityId))
      {
        view.Entities[op.EntityId].SetAuthority<Name>(op.HasAuthority);
      }
    });
    view.OnComponentUpdate<Name>(op =>
    {
      if (view.Entities.ContainsKey(op.EntityId))
      {
        view.Entities[op.EntityId].Update<Name>(op.Update);
      }
    });
  }

  private static unsafe readonly global::Improbable.Worker.Internal.ComponentProtocol.ClientDeserialize
      clientDeserialize = ClientDeserialize;
  private static unsafe readonly global::Improbable.Worker.Internal.ComponentProtocol.ClientSerialize
      clientSerialize = ClientSerialize;

  private static unsafe bool
  ClientDeserialize(global::System.UInt32 componentId,
                    global::System.Byte objType,
                    global::System.Byte* buffer,
                    global::System.UInt32 length,
                    global::Improbable.Worker.Internal.ComponentProtocol.ClientObject** obj)
  {
    *obj = null;
    try
    {
      *obj = global::Improbable.Worker.Internal.ClientObjects.ObjectAlloc();
      if (objType == (byte) global::Improbable.Worker.Internal.ComponentProtocol.ClientObjectType.Update) {
        var data = new Update();
        (*obj)->Reference = global::Improbable.Worker.Internal.ClientObjects.Instance
            .CreateReference(data);
        var stream = new global::System.IO.UnmanagedMemoryStream(buffer, (long) length);
        var protoWrapper = global::ProtoBuf.Serializer
            .Deserialize<global::Schema.Improbable.EntityComponentUpdate>(stream);
        if (protoWrapper.EntityState != null)
        {
          global::Schema.Improbable.Player.NameData _proto;
          if (global::ProtoBuf.Extensible.TryGetValue<global::Schema.Improbable.Player.NameData>(
                  protoWrapper.EntityState, (int) 1001, out _proto))
          {
            if (_proto.Field1EntityNameSpecified)
            {
              string field;
              field = _proto.Field1EntityName;
              data.entityName.Set(field);
            }
          }
        }
      }
      else if (objType == (byte) global::Improbable.Worker.Internal.ComponentProtocol.ClientObjectType.Snapshot)
      {
        var data = new Update();
        (*obj)->Reference = global::Improbable.Worker.Internal.ClientObjects.Instance
            .CreateReference(data);
        var stream = new global::System.IO.UnmanagedMemoryStream(buffer, (long) length);
        var protoWrapper = global::ProtoBuf.Serializer
            .Deserialize<global::Schema.Improbable.EntityState>(stream);
        var _proto = global::ProtoBuf.Extensible.GetValue<global::Schema.Improbable.Player.NameData>(
            protoWrapper, (int) 1001);
        {
          string field;
          field = _proto.Field1EntityName;
          data.entityName.Set(field);
        }
      }
      else if (objType == (byte) global::Improbable.Worker.Internal.ComponentProtocol.ClientObjectType.Request)
      {
        var data = new global::Improbable.Worker.Internal.GenericCommandObject();
        (*obj)->Reference = global::Improbable.Worker.Internal.ClientObjects.Instance
            .CreateReference(data);
      }
      else if (objType == (byte) global::Improbable.Worker.Internal.ComponentProtocol.ClientObjectType.Response)
      {
        var data = new global::Improbable.Worker.Internal.GenericCommandObject();
        (*obj)->Reference = global::Improbable.Worker.Internal.ClientObjects.Instance
            .CreateReference(data);
      }
    }
    catch (global::System.Exception e)
    {
      global::Improbable.Worker.ClientError.LogClientException(e);
      return false;
    }
    return true;
  }

  private static unsafe void
  ClientSerialize(global::System.UInt32 componentId,
                  global::System.Byte objType,
                  global::Improbable.Worker.Internal.ComponentProtocol.ClientObject* obj,
                  global::System.Byte** buffer,
                  global::System.UInt32* length)
  {
    *buffer = null;
    try
    {
      if (objType == (byte) global::Improbable.Worker.Internal.ComponentProtocol.ClientObjectType.Update) {
        var protoWrapper = new global::Schema.Improbable.EntityComponentUpdate();
        var data = (Update) global::Improbable.Worker.Internal.ClientObjects.Instance.Dereference(obj->Reference);
        {
          var _proto = new global::Schema.Improbable.Player.NameData();
          if (data.entityName.HasValue)
          {
            _proto.Field1EntityName = data.entityName.Value;
          }
          protoWrapper.EntityState = new global::Schema.Improbable.EntityState();
          global::ProtoBuf.Extensible.AppendValue(protoWrapper.EntityState, 1001, _proto);
        }
        {
          var _proto = new global::Schema.Improbable.Player.Name.Events();
          protoWrapper.EntityEvent = new global::Schema.Improbable.EntityEvent();
          global::ProtoBuf.Extensible.AppendValue(protoWrapper.EntityEvent, 1001, _proto);
        }
        using (var stream = new global::Improbable.Worker.Internal.ExpandableUnmanagedMemoryStream())
        {
          global::ProtoBuf.Serializer.Serialize(stream, protoWrapper);
          *buffer = stream.TakeOwnershipOfBuffer();
          *length = (uint) stream.Length;
        }
      }
      else if (objType == (byte) global::Improbable.Worker.Internal.ComponentProtocol.ClientObjectType.Snapshot) {
        var protoWrapper = new global::Schema.Improbable.EntityState();
        var _proto = new global::Schema.Improbable.Player.NameData();
        var data = (Update) global::Improbable.Worker.Internal.ClientObjects.Instance.Dereference(obj->Reference);
        _proto.Field1EntityName = data.entityName.Value;
        global::ProtoBuf.Extensible.AppendValue(protoWrapper, 1001, _proto);
        using (var stream = new global::Improbable.Worker.Internal.ExpandableUnmanagedMemoryStream())
        {
          global::ProtoBuf.Serializer.Serialize(stream, protoWrapper);
          *buffer = stream.TakeOwnershipOfBuffer();
          *length = (uint) stream.Length;
        }
      }
      else if (objType == (byte) global::Improbable.Worker.Internal.ComponentProtocol.ClientObjectType.Request)
      {
        var protoWrapper = new global::Schema.Improbable.EntityCommand();
        var _proto = new global::Schema.Improbable.Player.Name.Commands();
        global::ProtoBuf.Extensible.AppendValue(protoWrapper, 1001, _proto);
        using (var stream = new global::Improbable.Worker.Internal.ExpandableUnmanagedMemoryStream())
        {
          global::ProtoBuf.Serializer.Serialize(stream, protoWrapper);
          *buffer = stream.TakeOwnershipOfBuffer();
          *length = (uint) stream.Length;
        }
      }
      else if (objType == (byte) global::Improbable.Worker.Internal.ComponentProtocol.ClientObjectType.Response)
      {
        var protoWrapper = new global::Schema.Improbable.EntityCommand();
        var _proto = new global::Schema.Improbable.Player.Name.Commands();
        global::ProtoBuf.Extensible.AppendValue(protoWrapper, 1001, _proto);
        using (var stream = new global::Improbable.Worker.Internal.ExpandableUnmanagedMemoryStream())
        {
          global::ProtoBuf.Serializer.Serialize(stream, protoWrapper);
          *buffer = stream.TakeOwnershipOfBuffer();
          *length = (uint) stream.Length;
        }
      }
    }
    catch (global::System.Exception e)
    {
      global::Improbable.Worker.ClientError.LogClientException(e);
    }
  }
}

}
