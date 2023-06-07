# Container
A container is a set of one or more processes that are isolated from the rest of the system.

# container engine:
  * runc
  * crio

# container management:
  * kubernetes
  * docker swarm
  * mesos
  * nomad
  * podman
  
# Linux kernel container features

## Namespaces
A **namespace** isolates specific system resources usually visible to all processes. Inside a namespace, only processes that are members of that namespace can see those resources. Namespaces can include resources like **network interfaces**, the **process ID list**, **mount points**, **IPC resources**, and the **system's host name** information.

## Control groups (cgroups)
Control groups **partition sets of processes** and their **children** into groups to manage and limit the **resources** they consume. Control groups place restrictions on the amount of system resources processes might use. Those restrictions keep one process from using too many resources on the host.

## Seccomp
Developed in 2005 and introduced to containers circa 2014, **Seccomp** limits how processes could use **system call**s. Seccomp defines a security profile for processes that lists the system calls, parameters and file descriptors they are allowed to use.

## SELinux
Security-Enhanced Linux (SELinux) is a **mandatory access control system** for processes. Linux kernel uses SELinux to protect processes from each other and to protect the host system from its running processes. Processes run as a confined SELinux type that has limited access to host system resources.
