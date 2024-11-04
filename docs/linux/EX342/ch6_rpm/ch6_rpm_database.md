# Recovering RPM Database

**Berkeley DB** - embedded database library manages the RPM package and transaction data that are stored in the `/var/lib/rpm` directory.

## Cleaning Stale Lock Files

Typically, stale locks are left behind by abnormal termination from a kernel crash, a *kill* command, or a loss of system power.

Two methods are available to clean stale lock files:

1. (Recommended) Reboot the system. Rebooting removes the locks during the *sysinit* portion of the boot.

1. If rebooting does not resolve the issue, then manually remove the lock files and RPM database index files.

```sh
# delete all files in the /var/spool/up2date directory
cd /var/spool/up2date
rm -f *
rm .*
```

```sh
# verify that no processes with open RPM database files are running
ps -aux | grep -e rpm -e yum -e up2date
```

```sh
# if no RPM database processes are running, delete the database index files
rm /var/lib/rpm/__db*
```

## Recovering the RPM Database

Recovering the RPM database might require rebuilding the package metadata files in the */var/lib/rpm* directory. Rebuilding the metadata files also requires reconstructing the database indexes.

```sh
# backup the existing RPM database
tar cjvf rpmdb-$(date +%Y%m%d-%H%M).tar.bz2 /var/lib/rpm
```

```sh
# verify RPM database integrity
cd /var/lib/rpm
/usr/lib/rpm/rpmdb_verify Packages
```

```sh
# if verification fails, rebuild the RPM database
mv Packages Packages.bad
/usr/lib/rpm/rpmdb_dump Packages.bad | /usr/lib/rpm/rpmdb_load Packages
/usr/lib/rpm/rpmdb_verify Packages
```

```sh
# rebuild the RPM database indexes
rpm -v --rebuilddb
```

```sh
# verify the RPM database integrity
/usr/lib/rpm/rpmdb_verify Packages
```
