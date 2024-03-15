## CGroups (Control Groups) - Linux kernel feature to limit, prioritize, and isolate resource usage (CPU, memory, disk I/O, network, etc.) of a collection of processes.

> Memory is incompressible resource
```sh
# start container with mem limit
docker run -d --name lowmem100 -m=100m monitoringartist/docker-killer:latest membomb

# check out of memory events
docker inspect lowmem100 | grep OOM
```

> CPU is compressible resource
```sh
# start container with cpu limit
docker run -d --cpu=0.01 --name slow nginx
# checking that container is running slowly
docker exec slow sha1sum /dev/hosts
```

## Namespaces - Linux kernel feature to isolate resources of a collection of processes. (abstraction of system resources)

* Cgroup
* IPC (Inter-Process Communication)
* Network
* Mount
* PID (Process ID)
* User
* UTS (Unix Time-Sharing)

```sh
# list all namespaces
lsns
```

```sh
# enter into network namespace
nsenter -t 91 -n ip a
```

## Capabilities - Linux kernel feature to grant a process a subset of the full set of root privileges.

* CAP_CHOWN - Make arbitrary changes to file UIDs and GIDs
* CAP_KILL - Bypass permission checks for sending signals
* CAP_NET_BIND_SERVICE - Bind a socket to internet domain privileged ports

```sh
cat /proc/<PID>/status | grep Cap
```

# Dockerd

Dockerd - Docker daemon, the persistent process that manages containers. (Build images, network, storage, logs, etc.)

Containerd - High-level container runtime that manages the complete container lifecycle. (Start/Stop, network on driver level, etc.)

Runc - Low-level container runtime that runs containers according to the OCI specification. (Build container, start/stop, etc.)

Docker-containerd-shim - A shim process that is responsible for forwarding signals and reaping processes.

Docker-proxy - A process that forwards traffic to and from the container.

# OCI

Runtime-spec - Open Container Initiative (OCI) runtime specification.

Image-spec - Open Container Initiative (OCI) image specification.

# Containerd
ctr - Command-line client for containerd.

```sh
ctr image pull docker.io/library/alpine:latest
ctr run -d docker.io/library/alpine:latest alpine

ctr tasks exec --exec-id 1006 alpine echo "Hello, World!"

# stop container
kill -9 1006
```

```sh
```

```sh
```

# RunC

oci bundle - A directory that contains the configuration and root filesystem for a container.

oci image - A directory that contains the configuration and root filesystem for a container.

```sh
runc spec

runc run test
mkdir rootfs
skopeo copy docker://busybox:latest oci:rootfs:latest

umoci unpack --image busybox:latest bundle

cp -r ./bundle/rootfs/* rootfs

runc run test
```

```sh
runc list
runc --root /run/docker/runtime-runc/moby list
```

```sh
```
