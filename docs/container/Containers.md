# Podman/Docker OCI

## Get Help

Inline help
```sh
podman --help
```

Man pages are available for each command. For example:
```sh
man podman-run
man podman-build
```
## Basic commands

Run = Create + Start
```sh
podman create ...
podman run ...
podman start ...
```

**podman stop** sends `SIGTERM` to the container and waits 10 sec, then send `SIGKILL`
```sh
podman stop $(podman ps -aq)
```

**podman kill** sends `SIGKILL` to stop the container immediately
```sh
podman kill containerID
```

**podman pause/unpuase** sends `SIGSTOP/SIGCONT` to the container to all processes in the container. it requires cgroups v2, it's not enabled on RHEL8 by default.
```sh
podman pause 4f2038c05b8c
```

```sh
# -i - interactive, -t - tty
podman exec -it <ContainerId> /bin/sh

podman ps -a

podman logs containerID

podman inspect --format='{{.State.Running}}' containerID

podman pull

podman image ls

podman rm $(podman ps -aq)
# remove all stopped containers
podman rm --all

# build
podman build -t localhost/my-container -f Containerfile.my-container
```

## Network

```sh
podman network --help
```

### Network specific commands

```sh
podman network create example-net
podman network ls
podman network inspect example-net
# port mapping
podman port example-net

# Containers can be connected to multiple networks by specifying network names in a comma-separated list
podman run -d --name double-connector --net postgres-net,redis-net container-image:latest

# If the a container is already running, the following command connects it to the example-net network
podman network connect example-net my-container

# Removes any networks that are not currently in use by any containers
podman network prune
```

### DNS

>DNS is disabled in the default podman network. To enable DNS resolution between containers, create a Podman network and connect your containers to that network.


### Port-Forwarding

`-p` or `--publish` option of the podman run command forwards a port *HOST_PORT:CONTAINER_PORT*

```sh
podman run -p 8075:80 my-app
podman run -p 127.0.0.1:8075:80 my-app

# List port mappings
podman port my-app
# --all option lists port mappings for all containers
podman port --all

podman inspect my-app -f '{{.NetworkSettings.Networks.apps.IPAddress}}'
```

## Storage

### Storage commands
```sh
podman inspect volumeID
podman volume prune
podman volume create volumeNAME

podman volume ls --format="{{.Name}}\t{{.Mountpoint}}"
```

`diff` - display the changes made to a container's filesystem since it was started

```sh
podman diff elastic_maxwell
```

`cp` - copy files/folders between a container and the local filesystem

```sh
podman cp index.html elastic_maxwell:/var/wwww/index.html
```

### Volumes and Bind mounts

Volumes - managed by Podman

```sh
podman volume create http-data
podman volume inspect http-data
```

for rootless containers, Podman stores volume in the `$HOME/.local/share/containers/storage/volumes` directory.

**Bind mounts** - can exist anywhere on the host filesystem

Both **volumes** and **bind mounts** can use `--volume` or `-v` parameter

```sh
# --volume /path/on/host:/path/in/container:OPTIONS

# Bind mounts with the read-only option
podman run --volume  /www:/var/www/html:ro ubi8/httpd-24:latest

# Volume mount into a container
podman run --volume http-data:/var/www/html ubi8/httpd-24:latest
## Because Podman manages the volume, you do not need to configure SELinux permissions.
```
Alternatively, you can use the `--mount` parameter
```sh
--mount type=TYPE,source=/path/on/host,destination=/path/in/container,options=OPTIONS
# type= bind | volume | tmpfs
# options=ro | rw | z | Z
```
Some application cannot use the default COW file system in a specific directory for performance reasons, but do not use persistence or data sharing. In this case, you can use the `tmpfs` mount type, which means that the data in mount is ephemeral but does not use the COW file system.

```sh
podman run -e POSTGRESQL_ADMIN_PASSWORD=redhat --network lab-net \
  --mount  type=tmpfs,tmpfs-size=512M,destination=/var/lib/pgsql/data \
  registry.redhat.io/rhel9/postgresql-13:1
```

### Import/export volumes
```sh 
podman volume export http_data --output web_data.tar.gz
podman volume import web_data.tar.gz
```

# Links

## Storage

### [Overlay.go](https://github.com/containers/podman/blob/v4.2.0/vendor/github.com/containers/storage/drivers/overlay/overlay.go)

### [SELinux and Container File Permissions](https://www.redhat.com/sysadmin/user-namespaces-selinux-rootless-containers)

## Networking

### [Podman 4 network](https://www.redhat.com/sysadmin/podman-new-network-stack)

### [`nsenter`](https://www.redhat.com/sysadmin/container-namespaces-nsenter)