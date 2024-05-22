# NFS Server

## Services
```sh
dnf install nfs-utils
systemctl enable --now nfs-server
```
check the protocol versions
```sh
cat /proc/fs/nfsd/versions

```


## Firewall
[NFSv3 server behind firewall](https://access.redhat.com/solutions/3258)

NFS 4.1 default port: tcp/2049
```sh
firewall-cmd --add-service=nfs --permanent
firewall-cmd --reload
```

## Exports

```sh
cat /etc/exports
ls /etc/exports.d/

vim /etc/export.d/nfs.exports
```

example.exports
```
/srv/myshare client1.example.com
/srv/myshare *.example.com
/srv/myshare 192.168.0.0/24
/srv/myshare 192.168.0.0/24 client1.example.com *.example.net

/srv/myshare client1.example.com(rw,no_root_squash)
# no_root_squash: root user on client1.example.com will have root access on NFS share
```

## Inspectiong NFS Exports

```sh
# show current exports
exportfs

# show current exports with details
exportfs -v

# apply changes
exportfs -r
```

```sh
# show NFS shares on localhost
showmount -e localhost
```

## Client

```sh
mount serverd.lab.example.com:/nfsshare /mnt
```

/etc/fstab
```
serverd.lab.example.com:/nfsshare /share nfs defaults 0 0
```
```sh
mount /share
```



## Links

[NFS Performance tuning](https://cromwell-intl.com/open-source/performance-tuning/nfs.html)

[NFS and Smb exports of the same directory](https://access.redhat.com/solutions/39855)

