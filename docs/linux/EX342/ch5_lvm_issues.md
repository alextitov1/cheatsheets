# Repairing LVM Issues

## Logical Volume Management (LVM)

Similar to *dm-multipath*, logical volume management (LVM) uses the kernel Device Mapper subsystem to create the LVM devices. Logical volumes are created from in the */dev/* directory as *dm-* device nodes, but with symlinks in both the */dev/mapper/* and */dev/vg_name/* directories with persistent names.

## Configuration files

LVM behavior is configured in the */etc/lvm/lvm.conf* file.

* **scan** - witch directories to scan for physical volume device nodes
* **obtain_device_list_from_udev** - if *udev* should be used to obtain the list of devices for scanning
* **preferred_names** - A list of regular expressions that are used to match device names to the preferred name
* **filter** - A list of regular expressions that are used to filter devices that are scanned for physical volumes
* **backup** - determines whether a to store a text-based backup of volume metadata after every change
* **archive** -  determines whether to archive old volume group configurations or layouts to use later to revert changes

## Reverting Changes

If you need to revert changes to the LVM configuration, you can use the *vgcfgrestore* command to restore the previous configuration.

```sh
vgcfgrestore -l vg_example
vgcfgrestore -f /etc/lvm/archive/vg_example_00002-1484695080.vg vg_example
```

In some scenarios, it might be necessary to deactivate the volume group and reactivate it to apply the changes.

```sh
lvchange -an /dev/vg_example/lv_example
lvchange -ay /dev/vg_example/lv_example
```
