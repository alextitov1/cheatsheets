# Kernel messages

*dmesg* - preallocated a ring buffer

```
dmesg or journalctl -k

dmesg -f kern -l warn

# dmesg -h
# -l level (emerg, alert, crit, err, warning, notice, info, debug)
# -f facility (kern, user, mail, daemon ... etc)
# -T human readable time

dmesg -T -l emerg,alert,crit,err
```

# CPU

*lscpu* - display information about the CPU architecture

# Memory

*dmidecode* - display information about the system's hardware components

```
dmidecode -t memory
```

# Storage

*lsscsi* - list SCSI devices

```
lsscsi -v
```

*hdparm* - get/set hard disk parameters

```
hdparm -I /dev/sda
```

# USB

*lsusb* - list USB devices

*lspci* - list PCI devices

# Hardware errors

*rasdaemon* - R A S (Reliability, Availability, Serviceability) daemon; logs hardware errors that are generated by kernel tracing. These trace events are logged in */sys/kernel/debug/tracing* and are reported by *rsyslog* and *journald*.

```
dnf install rasdaemon
systemctl enable --now rasdaemon

ras-mc-ctl --help

ras-mc-ctl --summary

ras-mc-ctl --errors
```

# Memory testing

*memtest86* - memory testing tool

```
dnf install memtest86+
memtest-setup

grub2-mkconfig -o /boot/grub2/grub.cfg
```