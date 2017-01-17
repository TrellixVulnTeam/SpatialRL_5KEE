// Generated by SpatialOS codegen. DO NOT EDIT!
// source: WorldTransform in improbable/general/WorldTransform.schema.

namespace Improbable.General
{

/// <summary>
/// Deprecated and will be removed in a future version. Consider migrating to the simplified
/// <c>WorldTransform.Writer</c> interface (but see its documentation for semantic differences).
/// </summary>
[global::Improbable.Entity.Component.WriterInterface]
[global::Improbable.Entity.Component.ComponentId(1000)]
public interface WorldTransformWriter : WorldTransformReader
{
  WorldTransform.Updater Update { get; }
}

/// <summary>
/// Deprecated and will be removed in a future version. Consider migrating to the simplified
/// <c>WorldTransform.Reader</c> interface (but see its documentation for semantic differences).
/// </summary>
[global::Improbable.Entity.Component.ReaderInterface]
[global::Improbable.Entity.Component.ComponentId(1000)]
public interface WorldTransformReader
{
  bool IsAuthoritativeHere { get; }
  event global::System.Action PropertyUpdated;
  event global::System.Action<bool> AuthorityChanged;
  // Field position = 1.
  global::Improbable.Math.Coordinates Position { get; }
  event global::System.Action<global::Improbable.Math.Coordinates> PositionUpdated;
  // Field rotation = 2.
  uint Rotation { get; }
  event global::System.Action<uint> RotationUpdated;
}

public partial class WorldTransform : global::Improbable.Entity.Component.IComponentFactory
{
  [global::Improbable.Entity.Component.WriterInterface]
  [global::Improbable.Entity.Component.ComponentId(1000)]
  public interface Writer : Reader, global::Improbable.Entity.Component.IComponentWriter
  {
    /// <summary>
    /// Sends a component update.
    /// </summary>
    /// <remarks>
    /// Unlike the deprecated <c>WorldTransformWriter</c> interface, changes made by the update are not
    /// applied to the local copy of the component (returned by the <c>Data</c> property) until the
    /// update is processed by the connection. Therefore, the <c>ComponentUpdated</c> event is not
    /// triggered immediately, but queued to be triggered at a later time. Additionally, the
    /// update will be sent even if it would have no effect on the current local copy of the
    /// component data; discarding of no-op updates should be done manually. The behaviour is
    /// undefined if the update is mutated after it is sent; use <c>Send(update.DeepCopy())</c> if
    /// you intend to hold on to the update and modify it later.
    /// </remarks>
    void Send(Update update);
    /// <summary>
    /// Returns the CommandReceiver for this component.
    /// </summary>
    ICommandReceiver CommandReceiver { get; }
  }

  [global::Improbable.Entity.Component.ReaderInterface]
  [global::Improbable.Entity.Component.ComponentId(1000)]
  public interface Reader
  {
    /// <summary>
    /// Whether the local worker currently has authority over this component.
    /// </summary>
    bool HasAuthority { get; }
    /// <summary>
    /// Retrieves the local copy of the component data.
    /// </summary>
    global::Improbable.General.WorldTransformData Data { get; }

    /// <summary>
    /// Triggered whenever an update is received for this component.
    /// </summary>
    /// <remarks>
    /// Unlike the deprecated <c>WorldTransformReader</c> interface, registered handlers are not
    /// invoked immediately upon registration. Additionally, callbacks are not automatically removed
    /// OnDisable - visualizers must clean up themselves.
    /// </remarks>
    event global::System.Action<Update> ComponentUpdated;
    /// <summary>
    /// Triggered whenever the local worker's authority over this component changes.
    /// </summary>
    /// <remarks>
    /// Unlike the deprecated <c>WorldTransformReader</c> interface, registered handlers are not
    /// invoked immediately upon registration. Additionally, callbacks are not automatically removed
    /// OnDisable - visualizers must clean up themselves.
    /// </remarks>
    event global::System.Action<bool> AuthorityChanged;
  }

  /// <summary>
  /// Deprecated and will be removed in the next major version. Please migrate to the simplified
  /// <c>WorldTransform.Writer</c> interface (but see its documentation for semantic differences).
  /// </summary>
  public interface Updater
  {
    void FinishAndSend();
    // Field position = 1.
    Updater Position(global::Improbable.Math.Coordinates newValue);
    // Field rotation = 2.
    Updater Rotation(uint newValue);
  }

  public interface ICommandReceiver
  {
  }

  // Implementation details below here.
  //-----------------------------------

  private readonly global::System.Collections.Generic.Dictionary<global::Improbable.EntityId, Impl> implMap =
      new global::System.Collections.Generic.Dictionary<global::Improbable.EntityId, Impl>();
  private bool loggedInvalidAddComponent = false;
  private bool loggedInvalidRemoveComponent = false;

  public void UnregisterWithConnection(global::Improbable.Worker.Connection connection, global::Improbable.Worker.Dispatcher dispatcher) {
    loggedInvalidAddComponent = false;
    loggedInvalidRemoveComponent = false;
    implMap.Clear();
  }

  public void RegisterWithConnection(global::Improbable.Worker.Connection connection, global::Improbable.Worker.Dispatcher dispatcher,
                                     global::Improbable.Entity.Component.ComponentFactoryCallbacks callbacks)
  {
    dispatcher.OnAddComponent<WorldTransform>((op) => {
      if (!implMap.ContainsKey(op.EntityId))
      {
        var impl = new Impl(connection, op.EntityId, op.Data.Get());
        implMap.Add(op.EntityId, impl);
        if (callbacks.OnComponentAdded != null)
        {
          callbacks.OnComponentAdded(op.EntityId, this, impl);
        }
      }
      else if (!loggedInvalidAddComponent)
      {
        global::Improbable.Worker.ClientError.LogClientException(new global::System.InvalidOperationException(
            "Component WorldTransform added to entity " + op.EntityId + ", but it already exists." +
            "This error will be reported once only for each component."));
        loggedInvalidAddComponent = true;
      }
    });

    dispatcher.OnRemoveComponent<WorldTransform>((op) => {
      Impl impl;
      if (implMap.TryGetValue(op.EntityId, out impl))
      {
        if (callbacks.OnComponentRemoved != null)
        {
          callbacks.OnComponentRemoved(op.EntityId, this, impl);
        }
        implMap.Remove(op.EntityId);
      }
      else if (!loggedInvalidRemoveComponent)
      {
        global::Improbable.Worker.ClientError.LogClientException(new global::System.InvalidOperationException(
            "Component WorldTransform removed from entity " + op.EntityId + ", but it does not exist." +
            "This error will be reported once only for each component."));
        loggedInvalidRemoveComponent = true;
      }
    });

    dispatcher.OnAuthorityChange<WorldTransform>((op) => {
      Impl impl;
      if (implMap.TryGetValue(op.EntityId, out impl))
      {
        impl.On_AuthorityChange(op.HasAuthority);
        if (callbacks.OnAuthorityChanged != null)
        {
          callbacks.OnAuthorityChanged(op.EntityId, this, op.HasAuthority, impl);
        }
      }
    });

    dispatcher.OnComponentUpdate<WorldTransform>((op) => {
      Impl impl;
      if (implMap.TryGetValue(op.EntityId, out impl))
      {
        impl.On_ComponentUpdate(op.Update.Get());
        if (callbacks.OnComponentUpdated != null)
        {
          callbacks.OnComponentUpdated(op.EntityId, this, impl);
        }
      }
    });
  }

  public object GetComponentForEntity(global::Improbable.EntityId entityId)
  {
    Impl impl;
    implMap.TryGetValue(entityId, out impl);
    return impl;
  }

  public void DisconnectEventHandlersWithTarget(global::Improbable.EntityId entityId, object actionTarget)
  {
    Impl impl;
    if (implMap.TryGetValue(entityId, out impl))
    {
      impl.DisconnectEventHandlers(actionTarget);
    }
  }

  #pragma warning disable 0618
  public class Impl : WorldTransformWriter, Writer, Updater
  #pragma warning restore 0618
  {
    private readonly global::Improbable.Worker.Connection connection;
    private readonly global::Improbable.EntityId entityId;
    private readonly CommandReceiverImpl commandReceiver;

    private Data data;
    private bool hasAuthority = false;
    private readonly global::System.Collections.Generic.List<global::System.Action<Update>> componentUpdateCallbacks =
        new global::System.Collections.Generic.List<global::System.Action<Update>>();
    private readonly global::System.Collections.Generic.List<global::System.Action<bool>> authorityChangeCallbacks =
        new global::System.Collections.Generic.List<global::System.Action<bool>>();

    public uint ComponentId { get { return 1000; } }

    public Impl(global::Improbable.Worker.Connection connection, global::Improbable.EntityId entityId, Data initialData)
    {
      this.connection = connection;
      this.entityId = entityId;
      this.commandReceiver = new CommandReceiverImpl();
      data = initialData.DeepCopy();
    }

    public ICommandReceiver CommandReceiver
    {
      get { return commandReceiver; }
    }

    internal CommandReceiverImpl CommandReceiverInternal
    {
      get { return commandReceiver; }
    }

    public event global::System.Action<Update> ComponentUpdated
    {
      add { componentUpdateCallbacks.Add(value); }
      remove { componentUpdateCallbacks.Remove(value); }
    }

    event global::System.Action<bool> Reader.AuthorityChanged
    {
      add { authorityChangeCallbacks.Add(value); }
      remove { authorityChangeCallbacks.Remove(value); }
    }

    public bool HasAuthority
    {
      get { return hasAuthority; }
    }

    public global::Improbable.General.WorldTransformData Data
    {
      get { return data.Value; }
    }

    public void Send(Update update)
    {
      connection.SendComponentUpdate(entityId, update);
    }

    internal void On_AuthorityChange(bool newAuthority)
    {
      hasAuthority = newAuthority;
      for (int i = 0; i < authorityChangeCallbacks.Count; ++i)
      {
        authorityChangeCallbacks[i](newAuthority);
      }
    }

    internal void On_ComponentUpdate(Update update)
    {
      update.ApplyTo(data);
      for (int i = 0; i < componentUpdateCallbacks.Count; ++i)
      {
        componentUpdateCallbacks[i](update);
      }
    }

    public global::Improbable.EntityId EntityId
    {
      get { return entityId; }
    }

    // Implementation of deprecated interface.
    //----------------------------------------

    private WorldTransform.Update currentUpdate = null;

    public Updater Update
    {
      get
      {
        if (currentUpdate == null)
        {
          currentUpdate = new WorldTransform.Update();
        }
        else
        {
          global::Improbable.Worker.ClientError.LogClientException(new global::System.InvalidOperationException(
              "Update for component WorldTransform called with an update already in-flight! " +
              "Each Update must be followed by a FinishAndSend() before another update is made."));
        }
        return this;
      }
    }

    public void FinishAndSend()
    {
      if (currentUpdate != null)
      {
        if (FinishAndSend_ResolveDiff(currentUpdate)) {
          On_ComponentUpdate(currentUpdate);
          connection.SendComponentUpdate(entityId, currentUpdate, /* legacy semantics */ true);
        }
        currentUpdate = null;
      }
      else
      {
        global::Improbable.Worker.ClientError.LogClientException(new global::System.InvalidOperationException(
            "FinishAndSend() for component WorldTransform called with no update in-flight!"));
      }
    }

    public bool IsAuthoritativeHere
    {
      get { return HasAuthority; }
    }

    private readonly global::Improbable.Entity.Component.DeprecatedEvent<global::System.Action<bool>, global::System.Action<bool>> authorityChangedWrapper =
        new global::Improbable.Entity.Component.DeprecatedEvent<global::System.Action<bool>, global::System.Action<bool>>((x) => x);

    event global::System.Action<bool> WorldTransformReader.AuthorityChanged
    {
      add { ((Reader) this).AuthorityChanged += authorityChangedWrapper.Add(value, value.Target); value(HasAuthority); }
      remove { ((Reader) this).AuthorityChanged -= authorityChangedWrapper.Remove(value, value.Target); }
    }

    private readonly global::Improbable.Entity.Component.DeprecatedEvent<global::System.Action<Update>, global::System.Action> propertyUpdatedWrapper =
        new global::Improbable.Entity.Component.DeprecatedEvent<global::System.Action<Update>, global::System.Action>(PropertyUpdated_Wrap);

    private static global::System.Action<Update> PropertyUpdated_Wrap(global::System.Action action)
    {
      return (update) => { action(); };
    }

    public event global::System.Action PropertyUpdated
    {
      add { ComponentUpdated += propertyUpdatedWrapper.Add(value, value.Target); value(); }
      remove { ComponentUpdated -= propertyUpdatedWrapper.Remove(value, value.Target); }
    }

    public global::Improbable.Math.Coordinates Position
    {
      get { return Data.position; }
    }

    private readonly global::Improbable.Entity.Component.DeprecatedEvent<global::System.Action<Update>, global::System.Action<global::Improbable.Math.Coordinates>> positionWrapper =
        new global::Improbable.Entity.Component.DeprecatedEvent<global::System.Action<Update>, global::System.Action<global::Improbable.Math.Coordinates>>(PositionUpdated_Wrap);

    private static global::System.Action<Update> PositionUpdated_Wrap(global::System.Action<global::Improbable.Math.Coordinates> action)
    {
      return (update) => { if (update.position.HasValue) { action(update.position.Value); } };
    }

    public event global::System.Action<global::Improbable.Math.Coordinates> PositionUpdated
    {
      add { ComponentUpdated += positionWrapper.Add(value, value.Target); value(Data.position); }
      remove { ComponentUpdated -= positionWrapper.Remove(value, value.Target); }
    }

    Updater Updater.Position(global::Improbable.Math.Coordinates newValue)
    {
      currentUpdate.SetPosition(newValue);
      return this;
    }

    public uint Rotation
    {
      get { return Data.rotation; }
    }

    private readonly global::Improbable.Entity.Component.DeprecatedEvent<global::System.Action<Update>, global::System.Action<uint>> rotationWrapper =
        new global::Improbable.Entity.Component.DeprecatedEvent<global::System.Action<Update>, global::System.Action<uint>>(RotationUpdated_Wrap);

    private static global::System.Action<Update> RotationUpdated_Wrap(global::System.Action<uint> action)
    {
      return (update) => { if (update.rotation.HasValue) { action(update.rotation.Value); } };
    }

    public event global::System.Action<uint> RotationUpdated
    {
      add { ComponentUpdated += rotationWrapper.Add(value, value.Target); value(Data.rotation); }
      remove { ComponentUpdated -= rotationWrapper.Remove(value, value.Target); }
    }

    Updater Updater.Rotation(uint newValue)
    {
      currentUpdate.SetRotation(newValue);
      return this;
    }

    private bool FinishAndSend_ResolveDiff(Update update)
    {
      bool isNoOp = true;
      if (update.position.HasValue)
      {
        if (update.position.Value == Data.position)
        {
          update.position.Clear();
        }
        else
        {
          isNoOp = false;
        }
      }
      if (update.rotation.HasValue)
      {
        if (update.rotation.Value == Data.rotation)
        {
          update.rotation.Clear();
        }
        else
        {
          isNoOp = false;
        }
      }
      return !isNoOp;
    }

    internal void DisconnectEventHandlers(object actionTarget)
    {
      positionWrapper.DisconnectTarget(actionTarget);
      rotationWrapper.DisconnectTarget(actionTarget);
    }

    internal class CommandReceiverImpl : ICommandReceiver
    {
    }
  }
}

}
