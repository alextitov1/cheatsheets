# Install and configure samba

```sh
yum install samba

systemctl enable --now smb
```

```sh
mkdir /srv/sambashare
```

```sh
chgrp developers /srv/sambashare

# The SGID bit ensures that new content automatically belongs to the developers group
chmod 2775 /srv/sambashare
```

## Settings SELinux Context Types
For Samba to work correctly with SELinux, set the directory context to `samba_share_t`. Samba can also serve files labeled with the SELinux `public_content_t`(read-only) and `public_content_rw_t` (read-write) types.

```sh
# add a rule to the SELinux policy so that the /srv/samabashare directory and its content have a context type of samba_share_t
semanage fcontext -a -t samba_share_t '/srv/sambashare(/.*)?'

# apply the SELinux rule to the /srv/sambashare directory
restorecon -Rv /srv/sambashare
```

## Configuring Samba

/etc/samba/smb.conf - divided into sections. Each section starts with the section name in square brackets.

[global] - provides general server configuration and default values. The next sections define file or printer shares.

```
[global]
        workgroup = MYCOMPANY
        smb encrypt = required
        server min protocol = SMB3

[data]
        path = /smbshare
        write list = @marketing

```

```sh
# verify the configuration file
testparm
```

## Prepare Samba Users

```sh
useradd -s /sbin/nologin operator1

# add the linux account to the Samba database with the `smbpasswd` command from the `samba-common-tools` package
smbpasswd -a operator1

# remove user from Samba database
smbpasswd -x operator1

# list all users in the Samba database
pdbedit -L
```
```
samba maintains its database in /var/lib/samba/private/ directory
```

## Firewall
```sh
firewall-cmd --add-service=samba --permanent
firewall-cmd --reload
```

# Client

```
dnf install cifs-utils
```

```sh
mount -o username=operator1 //host.example.com/devcode /mnt
mount -t cifs //malinka3.lan/transmission /mnt/malinka3-smb/
```

/ext/fstab
```
//host.example.com/devcode /data cifs credentials=/etc/samba/credentials 0 0
```

/etc/samba/credentials
```
username=operator1
password=redhat
```

# Multiuser

```sh
cifscreds add host.example.com
```
