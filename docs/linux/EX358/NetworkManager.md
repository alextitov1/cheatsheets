NetworkManager - system demon, which monitors and manages network settings and uses files in /etc/sysconfig/network-scripts/ to store them.

In NetworkManager:
* A `device` is a network interface.
* A 'connection' is a collection of settings that can be configured for a device.
* Only one connection is `active` for any one device at a time. Multiple connections may exist, for use by different devices or to allow a configuration to be altered for the same device.
* Each connection has a `name` or `ID` that identifies it.
* The `/etc/sysconfig/network-scripts/ifcfg-name` file stores the persistent configuration for a connection, where `name` is the name of the connection. When the connection name has spaces in its name, the spaces are replaced with underscores in the file name. This file can be edited by hand, if desired.
* The `nmcli` utility creates and edits connection files from the shell prompt.

```sh
nmcli dev status
nmcli dev show

nmcli con show
nmcli con show --active

ip addr show eno1

nmcli gen permissions
```

```sh
# adds a new connection named eno1 for the interface eno1. This connection:
# Gets IPv4 networking information dynamically from DHCP.
# Gets IPv6 networking information from router advertisements on the local link.
nmcli con add con-name eno1 type ethernet ifname eno1

# adds a new connection named static-eno1 for the interface eno1. This connection:
# Sets a static IPv4 address of 192.0.2.7/24 and an IPv4 gateway router of 192.0.2.1.
# Sets a static IPv6 address of 2001:db8:0:1::c000:207/64 and an IPv6 gateway router of 2001:db8:0:1::1.

nmcli con add con-name static-eno1 type ethernet ifname eno1 \
  ipv6.address 2001:db8:0:1::c000:207/64 ipv6.gateway 2001:db8:0:1::1 \
  ipv4.address 192.0.2.7/24 ipv4.gateway 192.0.2.1
```

```sh
nmcli con up static-eno1

nmcli dev dis eno1
```