# Troubleshooting

## Container Startup

```sh
podman ps -a
podman logs CONTAINER_ID
# podman logs -f CONTAINER_ID
```

## Container Networking

```sh
podman port CONTAINER_ID
```

To verify the application ports in use `in` the container
```sh
podman exec -it CONTAINER ss -pant
```

>Containers usually lack many commands. Run the host system commands within the container network namespace by using the `nsenter` command

```sh
# get the PID of the container
podman inspect CONTAINER_ID --format '{{.State.Pid}}'

sudo nsenter -n -t CONTAINER_PID ss -pant
```

To verify that every container is using a specific network
```sh
podman inspect CONTAINER_ID --format '{{.NetworkSettings.Networks}}'
## When containers communicate by using Podman networks, there is no port mapping involved.
```

#### Troubleshoot Bind mounts

`podman-unshare` - Run a command inside of a modified user namespace

```sh
podman unshare ls -l /www/
```

SELinux
```
ls -Zd /www
system_u:object_r:default_t:s0:c228,c359 /www
```
The output shows the SELinux context label `system_u:object_r:default_t:s0:c228,c359`, which has the default_t type. A container must have the `container_file_t` SELinux type to have access to the bind mount.

To fix the SELinux configuration, add the :z or :Z option to the bind mount:

* z lets different containers share access to a bind mount.
* Z provides the container with exclusive access to the bind mount

```sh
podman run -p 8080:8080 --volume /www:/var/www/html:Z ubi8/httpd-24:latest
```

After adding the corresponding option, run the ls -Zd command and notice the right SELinux type.

```
[user@host ~]$ ls -Zd /www
system_u:object_r:container_file_t:s0:c240,c717 /www
```

# Utility

`getent` - retrieves information from various databases, including the user database, group database, and network services database, based on the configured sources, such as /etc/passwd, /etc/group, and /etc/services.
```sh
getent hosts <hostname>
getent passwd
```

`nsenter` is a command line utility that allows you to enter a namespace.

```sh
nsenter -t <pid> -n
```

# Links

[Application Container Security Guide](https://nvlpubs.nist.gov/nistpubs/specialpublications/nist.sp.800-190.pdf)

[Podman Setup](https://github.com/containers/podman/blob/v4.2.0/docs/tutorials/rootless_tutorial.md)

[Podman Troubleshooting](https://github.com/containers/podman/blob/v4.2.0/troubleshooting.md)

