# Scheduler
Scheduler is a control plane component that watches for newly created pods with no assigned node, and selects a node for them to run on.

```sh
# Installation
curl -LO https://storage.googleapis.com/kubernetes-release/release/$(curl -s https://storage.googleapis.com/kubernetes-release/release/stable.txt)/bin/linux/amd64/kube-scheduler
```

```sh
# run as a service
cat <<EOF | sudo tee /etc/systemd/system/kube-scheduler.service
[Unit]
Description=Kubernetes Scheduler
Documentation=https://kubernetes.io/docs/concepts/scheduling-eviction/kube-scheduler/
After=network.target
[Service]
ExecStart=/usr/local/bin/kube-scheduler \\
    --config=/etc/kubernetes/kube-scheduler.yaml \\
    --v=2
```

```sh
# kube admin config
cat /etc/kubernetes/manifests/kube-scheduler.yaml
```

