# Rootless Podman

## User Mapping
Podman maps users inside of the container to unprivileged users on the host system by using *subordinate ID* ranges
```sh
/etc/subuid
/etc/subgid
```

To generate the subordinate ID ranges, use the `usermod` command:
```sh
sudo usermod --add-subuids 100000-165535 \
  --add-subgids 100000-165535 student
# The /etc/subuid and /etc/subgid files must exist before you define the subordinate ID ranges

# for the new subordinate ID ranges to take effect:
podman system migrate
```

To verify the mapped user
```sh
podman run -it registry.access.redhat.com/ubi9/ubi id

podman top e6116477c5c9 huser user
```
> When you execute a container with elevated privileges on the host machine, the root mapping does not take place even when you define subordinate ID ranges

# Links

## [Shortcomings of Rootless Podman](https://github.com/containers/podman/blob/v4.2.0/rootless.md)

## [Rootless podman](https://github.com/containers/podman/blob/main/docs/tutorials/rootless_tutorial.md)

## [Understanding root inside and outside a container](https://www.redhat.com/en/blog/understanding-root-inside-and-outside-container)

## [Container Security Workshop](http://redhatgov.io/workshops/security_containers/)

## [Podman is gaining rootless overlay support](https://www.redhat.com/sysadmin/podman-rootless-overlay)