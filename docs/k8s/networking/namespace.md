List of network namespaces:
```sh
ip netns
```

exec ip command in a specific network namespace:
```sh
ip netns exec <namespace> ip link show
ip netns exec <namespace> ping yandex.ru

# or
ip -n <namespace> arp
```

Create a virtual ethernet pair and move one end to a specific namespace:
```sh
ip link add veth-ns1 type veth peer name veth-ns2

ip link set veth-ns1 netns namespace1
ip link set veth-ns2 netns namespace2

ip -n namespace1 addr add 192.168.1.1/24 dev veth-ns1
ip -n namespace2 addr add 192.168.1.2/24 dev veth-ns2
```

Create a linux bridge
```sh
ip link add name br0 type bridge
ip link set br0 up
ip link add veth-ns1 type veth peer name veth-br0
ip link set veth-ns1 netns namespace1
ip link set veth-br0 master br0
```


