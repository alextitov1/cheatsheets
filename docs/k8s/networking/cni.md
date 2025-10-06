# CNI (Container Network Interface)

Container Runtime:

- Container Runtime must create network namespace
- Identify network the container must attach to
- Container Runtime to invoke Network Plugin (bridge) when container is ADDed
- Container Runtime to invoke Network Plugin (bridge) when container is DELeted
- JSON format of the Network Configuration

Network Plugin:
- Must support command line arguments ADD, DEL, CHECK
- Must support parameters container ID, network ns etc.
- Must manage IP Address assignment to PODs
- Must return results in a specific format


CNI comes with supported plugins:
- bridge
- vlan
- ipvlan
- macvlan
- windows


Docker does not support CNI, but supports CNM (Container Network Model)

```
/etc/cni/net.d/
```
````
