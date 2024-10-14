# Stratis Storage Management

Stratis - a local storage management solution for Linux - provides a unified interface for managing storage volumes.

## Installation

```sh
dnf install stratis-cli stratisd
systemctl enable --now stratisd
```

Prepare devices for use in pools by erasing any existing file system, partition tables.

```sh
wipes --all /dev/sdb
```

## Creating a Pool

Stratis file systems are thinly provisioned without a fixed total size. If the size of the data approaches the virtual size of the file system, then Stratis grows the thin volume and its XFS file system automatically.

```sh
# Create a pool named pool1 with the devices /dev/sdb and /dev/sdc
stratis pool create pool1 /dev/sdb /dev/sdc

# List block devices
stratis blockdev

# List pools
stratis pool list

# Create a file system named fs1 in the pool1 pool
stratis fs create pool1 fs1

# List file systems
stratis fs list pool1

# List device UUID
lsblk --output=UUID /dev/stratis/pool1/fs1
blkid /dev/stratis/pool1/fs1


# Mount the file system
mkdir /mnt/test
mount /dev/stratis/pool1/fs1 /mnt/test
df -h /mnt/test

# Create/Delete a snapshot
stratis fs snapshot pool1 fs1 snapshot1
stratis fs
stratis filesystem destroy pool1 snapshot1
```
