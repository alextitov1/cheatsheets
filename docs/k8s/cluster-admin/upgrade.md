# Upgrade Kubernetes Cluster
Kubernetes cluster upgrades involve updating the control plane components and worker nodes to a newer version. Only a one-minor-version gap is generally considered safe and officially supported limit for version skew.

```sh
# check current cluster version
kubectl version

# check node kubelet version
kubectl get nodes -o wide
kubelet --version
```

## Upgrade cluster components

```sh
# update kubeadm
apt-get install kubeadm=1.33.0-1.1
kubeadm upgrade plan
```

## Update nodes

```sh
# take node out of service
kubectl drain node01 --ignore-daemonsets


kubeadm upgrade plan v1.33.0

kubeadm upgrade apply v1.33.0

apt-get install kubelet=1.33.0-1.1
systemctl daemon-reload
systemctl restart kubelet

# mark node as schedulable
kubectl uncordon node01


# kubeadm upgrade node
apt-get install kubeadm=1.33.0-1.1

kubeadm upgrade node