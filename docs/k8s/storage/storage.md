````markdown
* CRI (Container Runtime Interface)
cri - Interface between Kubernetes and container runtimes, allowing Kubernetes to use different container runtimes like Docker, containerd, or CRI-O.

* CSI (Container Storage Interface)
csi - Standard for exposing block and file storage systems to containerized workloads on Kubernetes, enabling

https://github.com/container-storage-interface/spec


# HostPath Volumes

HostPath volumes allow you to mount a file or directory from the host node's filesystem into a pod.

```yaml
# hostpath-volume.yaml
apiVersion: v1
kind: Pod
metadata:
    name: hostpath-pod
spec:
    containers:
    - name: hostpath-container
        image: nginx
        volumeMounts:
        - mountPath: /opt
          name: hostpath-volume
    volumes:
    - name: hostpath-volume
      hostPath:
        path: /data
```

# Persistent Volumes (PV)

```yaml
# pv-definition.yaml
apiVersion: v1
kind: PersistentVolume
metadata:
    name: my-pv
spec:
    accessModes:
    - ReadWriteOnce  # other options: ReadOnlyMany, ReadWriteMany
    capacity:
        storage: 1Gi
    hostPath:
        path: /data
```

````
