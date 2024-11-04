# Resolving Package Dependencies Issues

**RPM** - Red Hat Package Manager (doesn't resolve dependencies)

**YUM** - Yellowdog Updater, Modified

YUMv4 is based on DNF (Dandified YUM) - used in RHEL 8

**BaseOS** - content in the BaseOS repository provides the core set of the OS functionality.

**AppStream** - content in the AppStream repository provides applications that run on top of the OS.

**EPEL** - Extra Packages for Enterprise Linux

## Diagnosing Dependency Issues

```sh
# contains the history of installed and removed packages
cat /var/log/dnf.log
```

```sh
# -v verbose mode to see the details of the transaction
dnf install -v dnf
```

## Package Dependencies

```sh
dnf deplist yum
```

```sh
# alternatively use rpm
rpm -q --required yum

# additionally, to list capabilities that the package provides:
rpm -q --provides yum
```

```sh
# replace the specified package with an earlier version. Works for packages that allow only one version to be installed.
yum downgrade yum-3.4.3-161.el7.centos
```

> Note: some packages, such as for the Linux kernel, C libraries, or the system dbus, are restricted to update-only or install-only and cannot be downgraded.

```sh
# list all version of a package
dnf list --showduplicates python3-bind.noarch
```

```sh
# yum lock
yum versionlock list
yum versionlock add WILDCARD
yum versionlock delete WILDCARD
yum versionlock clear
```

## Transaction History

```sh
dnf history

# to view the details of a specific transaction
dnf history info 7
```

```sh
# undo a transaction
dnf history undo 7

# To repeat a specific transaction
dnf history redo 7
```

## Section lab

```sh
yum -v install rht-main

yum deplist rht-main

yum list --showduplicates rht-prereq

yum versionlock

yum versionlock delete rht-prereq-0:0.2-1.el8

yum versionlock

yum install rht-main

yum update rht-prereq

yum versionlock add rht-prereq

yum versionlock

yum update rht-prereq
```