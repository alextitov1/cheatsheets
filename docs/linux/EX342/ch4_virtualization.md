# Virtualization Support

*KVM* - Kernel-based Virtual Machine.

## Hardware Virtualization Support

```sh
egrep 'processor|vmx|svm' /proc/cpuinfo

# svm - AMD "Secure Virtual Machine"
# vmx - Intel "Virtual Machine Extension"
```

Load modules
```sh
modprobe -v kvm-intel
```

Use the *virsh capabilities* command to check for hardware virtualization support.
```sh
virsh capabilities
```

## Viewing Resource Use

KVM virtual machines are implemented as regular processes on the host. To view, resource usage, user normal performance metrics tools such as *top*.
More specialized tools:

```sh
virsh nodecpustats

virsh nodememstats

virsh dommemstats ??
```

## Libvirt XML Configuration

*libvirt* service stores virtual machine definitions and related configuration as XML files.

Path: `/etc/libvirt`

Schema path: `/usr/share/libvirt/schemas`

<br>

To ensure that the file is valid XML:
```sh
xmllint --noout FILENAME
```

After the file validates as well-structured XML, use:
```sh
virt-xml-validate FILENAME
```

## Libvirt Networking

Libvirt uses software bridges to provide virtual networks to virtual machines.

Networks are defined in files in the */etc/libvirt/qemu/networks/*, and can be configured to autostart by adding a symbolic link in the */etc/libvirt/qemu/networks/autostart/*

Virtual Networking issues:
* A virtual machine is unreachable from the outside
  * nat
  * firewall on the hypervisor, or on teh VM
  * routing
  * The virtual network is operating in isolated mode.
  * A firewall rule on the hypervisor might be blocking outgoing connections.
