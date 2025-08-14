````markdown
# network namespaces

```sh
# create network namespace
ip netns add mynamespace

# list network namespaces
ip netns list

# list network interfaces in a namespace
ip netns exec mynamespace ip link
ip -n mynamespace link # simpler way
```
````
