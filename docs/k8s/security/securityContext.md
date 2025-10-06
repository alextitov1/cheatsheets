# Security Context

You can set security context at both the Pod and Container level.

## Linux Capabilities

Some of most commonly used capabilities:

- `CAP_AUDIT_WRITE` - allows writing to the audit log
- `CAP_KILL` - allows sending signals to processes
- `CAP_NET_BIND_SERVICE` - allows binding to ports below 1024
- `CAP_SYS_CHROOT` - allows use of `chroot()`
- `CAP_SYS_ADMIN` - a very powerful capability that allows a wide range of system administration
- `CAP_DAC_OVERRIDE` - allows bypassing file read, write, and execute permission checks
- `CAP_SETUID` - allows changing user IDs
- `CAP_SETGID` - allows changing group IDs
- `CAP_NET_ADMIN` - allows various network-related operations
- `CAP_SYS_PTRACE` - allows tracing any process using `ptrace()`
- `CAP_MKNOD` - allows creating special files using `mknod()`
- `CAP_CHOWN` - allows changing file ownership