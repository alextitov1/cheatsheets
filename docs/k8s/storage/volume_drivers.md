# Volume Drivers

Volume plugins (or CSI drivers) allow Kubernetes to interface with various storage backends for persistent storage needs. Unlike container runtime **storage drivers** (which manage container image layers and writable container filesystems, e.g., overlay2, btrfs), Kubernetes volume plugins/CSI are specifically designed to provision, attach, and mount external storage as volumes for pods.

Common volume drivers include:
- Local
- Azure File Storage
- Kubernetes NFS
- Kubernetes iSCSI
- Kubernetes Ceph
- Kubernetes GlusterFS
- Kubernetes AWS EBS
- Kubernetes GCE PD