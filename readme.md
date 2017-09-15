# SimpleBroadcastSystem

SimpleBroadcastSystem is a minimal implementation of a MessageBus or Pub/Sub pattern. It's up to the calling code to create a static instance of `SimpleBroadcastSystem`

To include SimpleBroadcastSystem into your project, you can use `npm` method of unity package management described [here](https://github.com/minhhh/UBootstrap).

## Usage

**Add Subscriber**

Each subscriber is a method that receives one parameter of type `object`, i.e. UnityAction <object>.

```
SimpleBroadcastSystem simpleBroadcastSystem = new SimpleBroadcastSystem ();
simpleBroadcastSystem.AddSubscriber ("Attack", OnAttack);
```

**Remove Subscriber**

```
simpleBroadcastSystem.RemoveSubscriber ("Attack", OnAttack);
```

**Broadcast Event**

```
simpleBroadcastSystem.Broadcast ("Attack", 1);
```


## Changelog

**0.0.1**

* Initial commit

<br/>

