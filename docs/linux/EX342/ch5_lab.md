# Review lab

## iSCSI Storage

```sh
iscsiadm -m session

iscsiadm -m node

iscsiadm -m discovery -t st -p serverb.lab.example.com

dig +short serverb.lab.example.com

vi /etc/hosts

iscsiadm -m discovery -t st -p serverb.lab.example.com

iscsiadm -m node -T iqn.2016-01.com.example.lab:iscsistorage --login

iscsiadm -m node -T iqn.2016-01.com.example.lab:iscsistorage  | grep authmethod

vi etc/iscsi/initiatorname.iscsi

systemctl restart iscsid

iscsiadm -m node -T iqn.2016-01.com.example.lab:iscsistorage --login

grep "Attached SCSI" /var/log/messages

```

## LUKS

```sh
# check if password is working
lsblk

cryptsetup luksOpen /dev/sda1 finance

```

## LVM

```sh
mkdir /mnt/save

mount /dev/save/old /mnt/save

ls /mnt/save

umount /mnt/save

lvs

vgcfgrestore -l save

vgcfgrestore -f /etc/lvm/archive/save_00003-184394976.vg save

lvchange -an /dev/save/old
lvchange -ay /dev/save/old

mount /dev/save/old /mnt/save

```

## XFS repair

```sh
ls -la /mnt/save/luks
blkid /dev/save/old

umount /dev/save/old
xfs_repair -n /dev/save/old
xfs_repair -n -o force_geometry /dev/save/old
xfs_repair -o force_geometry /dev/save/old

mount /dev/save/old /mnt/save
ls -la /mnt/save/lost+found/

file /mnt/save/lost+found/13801

mv /mnt/save/lost+found/13801 /mnt/save/luks/iscsistorage_luks_header
```

## LUKS restore header

```sh
cryptsetup luksHeaderRestore /dev/sda1 --header-backup-file /mnt/save/luks/iscsistorage_luks_header


cryptsetup luksOpen /dev/sda1 finance


###

mkdir /mnt/finance
mount /dev/mapper/finance /mnt/finance/
ls -la /mnt/finance

```

## Make persistent

```sh
vi /etc/crypttab
finance  /dev/sda1  /path/to/keyfile

vi /etc/fstab
/dev/mapper/finance  /mnt/finance  xfs  defaults  0 0
```
