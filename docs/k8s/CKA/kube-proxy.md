**Kube-proxy** is a network proxy that __runs on each node__ in a Kubernetes cluster. It is responsible for managing network rules and facilitating communication between pods and services. Kube-proxy can operate in different modes, such as `iptables`, `ipvs`, or `userspace`, to handle traffic routing.

```sh
# Installation
curl -LO https://storage.googleapis.com/kubernetes-release/release/$(curl -s https://storage.googleapis.com/kubernetes-release/release/stable.txt)/bin/linux/amd64/kube-proxy

# Run as a service
cat <<EOF | sudo tee /etc/systemd/system/kube-proxy.service
[Unit]
Description=Kubernetes Kube-proxy
Documentation=https://kubernetes.io/docs/concepts/services-networking/service/
After=network.target
...
EOF

# Troubleshooting
kubectl get pods -n kube-system # kubeadm

kubectl get daemonset -n kube-system