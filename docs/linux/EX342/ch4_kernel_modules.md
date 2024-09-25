# Managing Kernel Modules

Most device drivers are built as kernel modules, as are file system drivers, encryption algorithms, and many other kernel features.

Modules are found in the */lib/modules/\<KERNEL_VERSION\>/kernel/\<SUBSYSTEM\>/\<KERNEL_MOdULE_NAME\>.ko.xz* .


## Viewing Kernel Modules

**lsmod** - list loaded modules

lsmod - nicely formats the contents of */proc/modules*.


## Loading and Unloading Kernel Modules

**insmod** - upload a module into the kernel

**rmmod** - unload a module from the kernel

**modprobe** - load and unload modules, as well as resolve dependencies and the checks kernel version(recommended)

```
modprobe mce-inject -v
> insmod /lib/modules/4.18.0-305.el8.x86_64/kernel/arch/x86/kernel/cpu/mce/mce-inject.ko.xz

modprobe -r mce-inject -v
> rmmod mce-inject
```

## Viewing Module Parameters

Most modules set their parameters in */sys/module/\<MODULE_NAME\>/parameters/* directory, with each parameter being a file. If a parameter is modifiable at runtime, the corresponding file is *root* writable.

```
modinfo -p kvm

```

## Managing Module Parameters

**modprobe** - can set module parameters

```
modprobe -v st buffer_kbs=64
> insmod /lib/modules/4.18.0-305.el8.x86_64/kernel/drivers/scsi/st.ko buffer_kbs=64

modprobe -c
```

to set a parameter permanently, add a line to */etc/modprobe.d/\<MEANINGFUL\>.conf*.

```