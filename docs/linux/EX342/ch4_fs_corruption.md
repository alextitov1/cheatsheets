# Recovering from File System Corruption

## Checking ext4 File System

```sh
# -n (dry-run) - places the file system in read-only mode and answers "no"
umount /dev/sdb1
e2fsck -n /dev/sdb1
```

Checking a file system requires a usable superblock. If the superblock location is corrupted, then locate a backup superblock.

```sh
# Determine the location of backup superblocks
dumpe2fs /dev/sdb1 | grep -i superblock
 >Backup superblock at 32768, Group descriptors at 32769-32769
 >Backup superblock at 98304, Group descriptors at 98305-98305
 >Backup superblock at 163840, Group descriptors at 163841-163841
 >Backup superblock at 229376, Group descriptors at 229377-229377

# After locating a backup superblock, run e2fsck with the -b option
e2fsck -b 32768 /dev/sdb1
echo $?
# 0 - No errors; 1 - Errors corrected; 2 - File system errors not corrected ...
```

## Checking XFS File System

```sh
# -n (dry-run) - places the file system in read-only mode and answers "no"
umount /dev/sdb1
xfs_repair -n /dev/sdb1
xfs_repair /dev/sdb1
```

The xfs_repair command does not execute on an XFS file system that does not have a clear journal log. Mount and unmount the file system to clear the journal log.

## Restoring XFS File System

```sh
umount /mnt/etc_restore
xfs_repair -n /dev/vdb1

 > Metadata corruption detected at 0x564c8914a8e8, xfs_dir3_block block 0xa7e0/0x1000
 > entry "subscription-manager" at block 0 offset 456 in directory inode 144973
 > references invalid inode 1234567890

xfs_repair /dev/vdb1

mount /dev/vdb1 /mnt/etc_restore
ls -la /mnt/etc_restore/lost+found
find /mnt/etc_restore -inum 144973
tar -C /tmp -xzf /root/etc.tgz
cd /tmp/etc/security/console.apps
diff -s subscription-manager /mnt/etc_restore/lost+found/145282
cd /mnt/etc_restore/etc/security/console.apps
mv /mnt/etc_restore/lost+found/145282 subscription-manager
